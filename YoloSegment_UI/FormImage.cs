using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMT;
using TGMTcs;
using YoloSegment;

namespace YoloSegment
{
    public partial class FormImage : Form
    {
        static FormImage m_instance;
        int _selectedIndex = -1;

        Segmented _segmented = null;
        bool _inited = false;
        Bitmap _bmp = null;
        bool _drawText = false;
        bool _drawRect = false;
        int PADDING = 0;

        bool _drawCorner = false;

        static List<Color> m_colors = new List<Color> {
            Color.Lime,
            Color.FromArgb(255, 1, 228),
            Color.FromArgb(214, 40, 40),
            Color.FromArgb(247, 127, 0),
            Color.FromArgb(255, 169, 221),
            Color.FromArgb(28, 221, 218)};

        static List<Pen> m_pens = new List<Pen>();
        static SolidBrush redBrush = new SolidBrush(Color.FromArgb(255, 1, 228));
        static SolidBrush whiteBrush = new SolidBrush(Color.White);
        static List<Brush> m_brushes = new List<Brush>();

        double m_scaleX = 0;
        double m_scaleY = 0;
        double m_aspect = 0;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormImage()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormImage GetInstance()
        {
            if(m_instance == null)
                m_instance = new FormImage();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormImage_Load(object sender, EventArgs e)
        {
            txt_imagePath.Text = TGMTregistry.GetInstance().ReadString("txt_imagePath");
            chk_saveAnnotation.Checked = TGMTregistry.GetInstance().ReadBool("chk_saveAnnotation", false);
            chk_autoWarp.Checked = TGMTregistry.GetInstance().ReadBool("chk_autoWarp", false);

            _inited = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormImage_SizeChanged(object sender, EventArgs e)
        {
            if(!_inited)
                return;
            AdjustSize();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void OnFormSelected(bool selected)
        {
            if(selected)
            {

            }
            else
            {

            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_imagePath_TextChanged(object sender, EventArgs e)
        {
            _segmented = null;

            TGMTregistry.GetInstance().SaveValue("txt_imagePath", txt_imagePath.Text);
            _bmp = TGMTimage.LoadBitmapWithoutLock(txt_imagePath.Text);
            pictureBox1.Image = _bmp;

            AdjustSize();
            Predict();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_autoWarp_CheckedChanged(object sender, EventArgs e)
        {
            if(!_inited)
                return;

            TGMTregistry.GetInstance().SaveValue("chk_autoWarp", chk_autoWarp.Checked);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_predict_Click(object sender, EventArgs e)
        {
            Predict();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_saveAnnotation_Click(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().SaveValue("chk_saveAnnotation", chk_saveAnnotation.Checked);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            _selectedIndex = listView1.SelectedIndices.Count > 0 ? listView1.SelectedIndices[0] : -1;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if(_segmented == null || _segmented.polygons == null || _segmented.polygons.Count == 0)
                return;


            int thickness = Math.Max(1, pictureBox1.Width / 300);
            int fontSize = Math.Min(25, pictureBox1.Width / 60);
            Font drawFont = new Font("Arial", fontSize);
            Rectangle rectFrame = new Rectangle(0, 0, _bmp.Width, _bmp.Height);
            Pen yellowPen = new Pen(Color.Yellow, thickness);


            for(int i = 0; i < _segmented.polygons.Count; i++)
            {
                Polygon obj = _segmented.polygons[i];
                if(obj.classID != 0)
                    continue;


                Rectangle rect = obj.rect;
                bool overlapEdge = TGMTshape.IsOverlap(rect, rectFrame, PADDING);
                int classID = obj.classID;
                //if(classID != 0)
                //    continue;

                if(classID >= m_pens.Count)
                {
                    for(int j = m_pens.Count; j <= classID; j++)
                    {
                        int colorIndex = j % m_colors.Count;
                        Color c = m_colors[colorIndex];
                        //m_colors.Add(c);
                        m_pens.Add(new Pen(c, thickness));
                        m_brushes.Add(new SolidBrush(c));
                    }
                }
                Pen p = m_pens[classID];
                if(overlapEdge)
                    p = yellowPen;


                if(Program.drawContour && obj.contour != null && obj.contour.Length > 2)
                {
                    List<Point> points = ConvertToDrawPoint(obj.contour);

                    if(i == _selectedIndex)
                    {
                        e.Graphics.DrawPolygon(p, points.ToArray());
                    }
                    else
                    {
                        e.Graphics.FillPolygon(new SolidBrush(Color.FromArgb(100, p.Color)), points.ToArray());
                        e.Graphics.DrawPolygon(p, points.ToArray());
                    }
                }

                if(_drawRect)
                {
                    e.Graphics.DrawRectangle(p, rect);
                }

                if(_drawCorner && obj.corners != null)
                {
                    // Draw corner
                    PointF topLeft = obj.corners[0];
                    PointF topRight = obj.corners[1];
                    PointF bottomRight = obj.corners[2];
                    PointF bottomLeft = obj.corners[3];
                    e.Graphics.DrawLine(p, topLeft, topRight);
                    e.Graphics.DrawLine(p, topRight, bottomRight);
                    e.Graphics.DrawLine(p, bottomRight, bottomLeft);
                    e.Graphics.DrawLine(p, bottomLeft, topLeft);

                    for(int j = 0; j < obj.corners.Length; j++)
                    {
                        PointF corner = obj.corners[j];
                        e.Graphics.FillEllipse(new SolidBrush(p.Color), corner.X - 5, corner.Y - 5, 10, 10);
                    }
                }

                if(_drawText)
                {
                    string text = obj.className + " " + obj.score.ToString("N2");
                    SizeF textSize = e.Graphics.MeasureString(text, drawFont);
                    RectangleF rectf = new RectangleF(rect.X, rect.Y - (textSize.Height / 2), textSize.Width, textSize.Height);

                    e.Graphics.FillRectangle(redBrush, rect.X - 1, rect.Y - (textSize.Height / 2), textSize.Width + 2, textSize.Height);
                    e.Graphics.DrawString(text, drawFont, whiteBrush, rectf);
                }
            }

        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Predict()
        {
            if(EngineMgr.GetInstance() == null)
                return;
            if(!File.Exists(txt_imagePath.Text))
                return;

            btn_predict.Enabled = false;
            _selectedIndex = -1;

            listView1.Items.Clear();
            circle1.Visible = true;
            workerPredict.RunWorkerAsync();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void workerPredict_DoWork(object sender, DoWorkEventArgs e)
        {
            Segmented result = EngineMgr.GetInstance().Segment(txt_imagePath.Text);
            e.Result = result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void workerPredict_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            _segmented = (Segmented)e.Result;

            if(_segmented.polygons == null && _segmented.error != "")
            {
                if(_segmented.error.Contains("-201"))
                {
                    FormMain.GetInstance().PrintError("Wrong size of model");
                }
                else
                {
                    MessageBox.Show(_segmented.error);
                }

                circle1.Visible = false;
                return;
            }

            for(int i = 0; i < _segmented.polygons.Count; i++)
            {
                TGMT.Polygon obj = _segmented.polygons[i];


                ListViewItem item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(obj.classID.ToString());
                item.SubItems.Add(obj.className);
                item.SubItems.Add(obj.score.ToString());

                listView1.Items.Add(item);
            }
            FormMain.GetInstance().PrintMessage("Num polygons: " + _segmented.polygons.Count.ToString() + " (" + _segmented.elapsedMilisecond.ToString() + "ms)");

            pictureBox1.Invalidate();

            circle1.Visible = false;

            btn_predict.Enabled = true;

            if(chk_saveAnnotation.Checked)
            {
                List<string> content = new List<string>();
                Bitmap bmp = TGMTimage.LoadBitmapWithoutLock(txt_imagePath.Text);

                for(int i = 0; i < _segmented.polygons.Count; i++)
                {
                    TGMT.Polygon polygon = _segmented.polygons[i];
                    string row = polygon.classID.ToString();

                    if(polygon.contour != null)
                    {
                        for(int j = 0; j < polygon.contour.Length; j++)
                        {
                            double x = (double)polygon.contour[j].X / bmp.Width;
                            double y = (double)polygon.contour[j].Y / bmp.Height;
                            row += " " + x.ToString() + " " + y.ToString();
                        }
                    }

                    content.Add(row);
                }

                string filePath = txt_imagePath.Text.Replace(Path.GetExtension(txt_imagePath.Text), ".txt");
                File.WriteAllLines(filePath, content.ToArray());

            }

            if(chk_autoWarp.Checked && _segmented.polygons.Count == 1)
            {
                TGMT.Polygon polygon = _segmented.polygons[0];

                Bitmap bmpWarped = YOLOSegmentor.WarpRotatedRectangle(_segmented.bitmap, polygon.corners);

                pictureBox1.Image = bmpWarped;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void AdjustSize()
        {
            if(_bmp == null)
                return;

            m_aspect = (double)_bmp.Width / (double)_bmp.Height;
            double panelAspect = (double)panelPicture.Width / (double)panelPicture.Height;
            if(m_aspect > panelAspect)
            {
                pictureBox1.Width = panelPicture.Width;
                pictureBox1.Height = (int)(pictureBox1.Width / m_aspect);
            }
            else if(m_aspect < panelAspect)
            {
                pictureBox1.Height = panelPicture.Height;
                pictureBox1.Width = (int)(pictureBox1.Height * m_aspect);
            }
            m_scaleX = (double)_bmp.Width / pictureBox1.Width;
            m_scaleY = (double)_bmp.Height / pictureBox1.Height;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public List<Point> ConvertToDrawPoint(Point[] points)
        {
            List<Point> result = new List<Point>();
            for(int i = 0; i < points.Length; i++)
            {
                result.Add(ConvertToDrawPoint(points[i]));
            }

            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public Point ConvertToDrawPoint(Point p)
        {
            Point result = new Point();
            result.X = (int)(p.X / m_scaleX);
            result.Y = (int)(p.Y / m_scaleY);
            return result;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void UpdateUI()
        {
            pictureBox1.Invalidate();
        }
    }
}
