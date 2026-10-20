using NAudio;
using NAudio.Utils;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMT;
using TGMTcs;

namespace YoloSegment
{
    public partial class FormFolder : Form
    {

        static FormFolder _instance;
        bool _inited = false;

        List<string> _filePaths = new List<string>();
        List<Segmented> _results = new List<Segmented>();

        Segmented m_segmented;
        Stopwatch _watch = new Stopwatch();
        string _imagePath = "";


        string _inputDir = "";
        string _outputDir = "";
        bool _enableOutput = false;

        Pen pen_blue_thick = new Pen(Color.Blue, 2);
        Pen pen_blue_dash = new Pen(Color.Blue, 2);
        Brush pen_blue_brush_soft = new SolidBrush(Color.FromArgb(100, Color.Blue));
        SolidBrush redBrush = new SolidBrush(Color.Red);
        Brush blue_brush = new SolidBrush(Color.Blue);

        Font myFont;

        Bitmap m_bmp;
        double m_scaleX = 0;
        double m_scaleY = 0;
        double m_aspect = 0;

        int ANCHOR_WIDTH = 2;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormFolder()
        {
            InitializeComponent();
            this.AutoScaleMode = AutoScaleMode.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public static FormFolder GetInstance()
        {
            if (_instance == null)
                _instance = new FormFolder();
            return _instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormFolder_Load(object sender, EventArgs e)
        {
            int fontsize = TGMTregistry.GetInstance().ReadInt("numFontSize", 14);
            myFont = new Font("Arial", fontsize);

            txt_inputFolder.Text = TGMTregistry.GetInstance().ReadString("inputFolder");
            txt_outputFolder.Text = TGMTregistry.GetInstance().ReadString("outputFolder");
            chk_outputFolder.Checked = TGMTregistry.GetInstance().ReadBool("enableOutput");

            if (TGMTregistry.GetInstance().ReadString("folder_mode", "extract") == "extract")
                rd_extract.Checked = true;
            else
                rd_draw.Checked = true;

            int splitterDistance1 = TGMTregistry.GetInstance().ReadInt("splitContainer1", -1);
            if (splitterDistance1 != -1)
                splitContainer1.SplitterDistance = splitterDistance1;

            _inited = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormFolder_SizeChanged(object sender, EventArgs e)
        {
            AdjustSize();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public void OnFormSelected(bool selected)
        {
            if (selected)
            {

            }
            else
            {

            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_inputFolder_TextChanged(object sender, EventArgs e)
        {
            btn_detect.Enabled = false;
            if (txt_inputFolder.Text == "")
            {                
                return;
            }
            _inputDir = TGMTutil.CorrectPath(txt_inputFolder.Text);
            listView1.Items.Clear();
            workerLoadFile.RunWorkerAsync();

            TGMTregistry.GetInstance().SaveValue("inputFolder", txt_inputFolder.Text);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_outputFolder_TextChanged(object sender, EventArgs e)
        {

            _outputDir = TGMTutil.CorrectPath(txt_outputFolder.Text);

            TGMTregistry.GetInstance().SaveValue("outputFolder", txt_outputFolder.Text);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_outputFolder_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_outputFolder.Checked)
            {
                txt_outputFolder.Enabled = true;
                _enableOutput = true;
                rd_draw.Enabled = true;
                rd_extract.Enabled = true;
            }
            else
            {
                txt_outputFolder.Enabled = false;
                _enableOutput = false;
                rd_draw.Enabled = false;
                rd_extract.Enabled = false;
            }

            TGMTregistry.GetInstance().SaveValue("enableOutput", chk_outputFolder.Checked);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rd_draw_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_draw.Checked)
                TGMTregistry.GetInstance().SaveValue("folder_mode", "draw");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void rd_extract_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_extract.Checked)
                TGMTregistry.GetInstance().SaveValue("folder_mode", "extract");
        }           

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_detect_Click(object sender, EventArgs e)
        {
            if(btn_detect.Text == "Start")
            {
                _watch.Start();
                _results.Clear();

                if (chk_outputFolder.Checked && txt_outputFolder.Text != "")
                {
                    Directory.CreateDirectory(txt_outputFolder.Text);
                }

                workerDetect.RunWorkerAsync();
                circle1.Visible = true;
                listView1.Enabled = false;

                btn_detect.Text = "Stop";
            }
            else
            {
                workerDetect.CancelAsync();
                btn_detect.Text = "Start";
                circle1.Visible = false;
                listView1.Enabled = true;
            }            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (!_inited)
                return;
            int distance = splitContainer1.SplitterDistance;
            TGMTregistry.GetInstance().SaveValue("splitContainer1", distance);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
                return;

            int selectedIndex = listView1.SelectedIndices[0];

            _imagePath = _inputDir + _filePaths[selectedIndex];
            m_bmp = new Bitmap(_imagePath);
            AdjustSize();

            pictureBox1.ImageLocation = _imagePath;
            if (selectedIndex > _results.Count - 1)
                return;

            m_segmented = _results[selectedIndex];

            //m_polygons.Clear();
            listView2.Items.Clear();

            for (int i = 0; i < m_segmented.polygons.Count; i++)
            {
                Polygon polygon = m_segmented.polygons[i];
                //m_polygons.Add(new YoloSegment.Polygon());

                ListViewItem item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(polygon.classID.ToString());
                if (polygon.className != null && polygon.className != "")
                    item.SubItems.Add(polygon.className);
                else
                    item.SubItems.Add("Unknown");

                item.SubItems.Add(polygon.score.ToString("0.00"));
                listView2.Items.Add(item);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
                return;

            int selectedIndex = listView1.SelectedIndices[0];
            _imagePath = _inputDir + _filePaths[selectedIndex];
            Process.Start("explorer.exe", "/select,\"" + _imagePath + "\"");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            //return;//because not accurate
            if (m_segmented == null || m_segmented.polygons == null)            
                return;

            
            int offset = ANCHOR_WIDTH / 2;
            for (int i = 0; i < m_segmented.polygons.Count; i++)
            {
                //string elements = m_polygons[i].ToString();
                //int spaceIdx = elements.IndexOf(" ");
                //if (spaceIdx == -1)
                //    continue;

                Polygon po = m_segmented.polygons[i];

                int classID = po.classID;
                string className = "Unknown";
                //if (classID < cb_classes.Items.Count)
                if (po.className != null && po.className != "")
                    className = po.className;



                //if (po.pointFs == null)
                //    continue;

                //if (po.classID < cb_classes.Items.Count)
                //    className = cb_classes.Items[po.classID].ToString();

                List<Point> drawPoints = ConvertToDrawPoint(po.contour);
                if (drawPoints.Count == 0)
                    continue;

                if (drawPoints.Count > 2)
                {
                    e.Graphics.DrawPolygon(pen_blue_thick, drawPoints.ToArray());
                    e.Graphics.FillPolygon(pen_blue_brush_soft, drawPoints.ToArray());
                }

                if (drawPoints.Count > 0)
                {
                    e.Graphics.DrawString(className, myFont, redBrush, drawPoints[0].X, drawPoints[0].Y);
                }

                for (int j = 0; j < drawPoints.Count; j++)
                {
                    Point point = drawPoints[j];

                    e.Graphics.FillEllipse(blue_brush,
                        point.X - ANCHOR_WIDTH / 2, point.Y - ANCHOR_WIDTH / 2, ANCHOR_WIDTH, ANCHOR_WIDTH);

                }                
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_copyImgPath_Click(object sender, EventArgs e)
        {
            if (_imagePath != "")
            {
                Clipboard.SetText(_imagePath);
                FormMain.GetInstance().PrintSuccess("Image path copied to clipboard");
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_copyImage_Click(object sender, EventArgs e)
        {            
            if (_imagePath == "")
                return;

            StringCollection paths = new StringCollection();
            paths.Add(_imagePath);

            Clipboard.SetFileDropList(paths);
            FormMain.GetInstance().PrintSuccess("Copied! Now open any folder and press Ctrl+V to paste.");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void workerLoadFile_DoWork(object sender, DoWorkEventArgs e)
        {
            List<string> files = new List<string>();
            listView1.Items.Clear();

            if (!Directory.Exists(txt_inputFolder.Text))
                return;

            string[] fileList = Directory.GetFiles(txt_inputFolder.Text, "*.jpg");
            foreach (string filePath in fileList)
            {
                files.Add(Path.GetFileName(filePath));
            }

            fileList = Directory.GetFiles(txt_inputFolder.Text, "*.png");
            foreach (string filePath in fileList)
            {
                files.Add(Path.GetFileName(filePath));
            }

            fileList = Directory.GetFiles(txt_inputFolder.Text, "*.bmp");
            foreach (string filePath in fileList)
            {
                files.Add(Path.GetFileName(filePath));
            }

            e.Result = files;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void workerLoadFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Result == null)
                return;

            _filePaths = (List<string>)e.Result;

            List<ListViewItem> items = new List<ListViewItem>();

            for (int i = 0; i < _filePaths.Count; i++)
            {
                ListViewItem item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(_filePaths[i]);
                item.SubItems.Add("");
                item.SubItems.Add("");
                items.Add(item);
            }

            listView1.Items.AddRange(items.ToArray());

            FormMain.GetInstance().PrintMessage("Loaded " + _filePaths.Count + " images");

            btn_detect.Enabled = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void workerDetect_DoWork(object sender, DoWorkEventArgs e)
        {
            bool draw = rd_draw.Checked;
            int imageCount = _filePaths.Count;

            Segmented[] orderedResults = new Segmented[imageCount];
            int[] totalByIndex = new int[imageCount];
            long[] elapsedByIndex = new long[imageCount];
            bool[] completed = new bool[imageCount];

            int nextDisplayIndex = 0;
            int canceled = 0;
            int nextWorkIndex = -1;

            object displayLock = new object();

            int workerCount = Math.Max(1, EngineMgr.GetInstance().MaxReader);
            Task[] workers = new Task[workerCount];

            for (int w = 0; w < workerCount; w++)
            {
                workers[w] = Task.Run(() =>
                {
                    while (true)
                    {
                        if (workerDetect.CancellationPending)
                        {
                            Interlocked.Exchange(ref canceled, 1);
                            return;
                        }

                        int i = Interlocked.Increment(ref nextWorkIndex);
                        if (i >= imageCount)
                            return;

                        string inputPathAbs = Path.Combine(_inputDir, _filePaths[i]);
                        string outputPathAbs = Path.Combine(_outputDir, _filePaths[i].ToLower());

                        Segmented result = EngineMgr.GetInstance().Segment(inputPathAbs);

                        if (result == null)
                        {
                            result = new Segmented();
                            result.polygons = new List<Polygon>();
                            result.elapsedMilisecond = 0;
                        }

                        Segmented filteredResult = new Segmented();
                        filteredResult.elapsedMilisecond = result.elapsedMilisecond;
                        filteredResult.bitmap = result.bitmap;

                        if (result.polygons != null)
                        {
                            List<Polygon> filteredPolygons = result.polygons.ToList();
                            if (Program.minScoreEnabled)
                            {
                                filteredPolygons = filteredPolygons.Where(p => p.score >= Program.minScore).ToList();
                            }
                            filteredResult.polygons = filteredPolygons;
                        }
                        else
                        {
                            filteredResult.polygons = new List<Polygon>();
                        }

                        orderedResults[i] = filteredResult;

                        if (_enableOutput)
                        {
                            if (draw)
                            {
                                if (filteredResult.bitmap != null)
                                {
                                    filteredResult.bitmap.Save(outputPathAbs, ImageFormat.Jpeg);
                                }
                            }
                            else
                            {
                                using (Bitmap bmp = new Bitmap(inputPathAbs))
                                {
                                    List<string> content = new List<string>();
                                    for (int j = 0; j < filteredResult.polygons.Count; j++)
                                    {
                                        content.Add(GenRow(bmp.Width, bmp.Height, filteredResult.polygons[j]));
                                    }
                                    bmp.Save(outputPathAbs, ImageFormat.Jpeg);
                                    string filePath = outputPathAbs.Replace(".jpg", ".txt");
                                    File.WriteAllLines(filePath, content.ToArray());
                                }
                            }
                        }

                        totalByIndex[i] = (filteredResult.polygons != null) ? filteredResult.polygons.Count : 0;
                        elapsedByIndex[i] = filteredResult.elapsedMilisecond;

                        List<int> readyToDisplay = null;

                        lock (displayLock)
                        {
                            completed[i] = true;

                            if (i == nextDisplayIndex)
                            {
                                readyToDisplay = new List<int>();
                                while (nextDisplayIndex < imageCount && completed[nextDisplayIndex])
                                {
                                    readyToDisplay.Add(nextDisplayIndex);
                                    nextDisplayIndex++;
                                }
                            }
                        }

                        if (readyToDisplay != null && readyToDisplay.Count > 0)
                        {
                            BeginInvoke(new Action(() =>
                            {
                                for (int k = 0; k < readyToDisplay.Count; k++)
                                {
                                    int index = readyToDisplay[k];
                                    listView1.Items[index].SubItems[2].Text = totalByIndex[index].ToString();
                                    listView1.Items[index].SubItems[3].Text = elapsedByIndex[index].ToString();
                                    listView1.EnsureVisible(index);
                                }
                            }));
                        }
                    }
                });
            }

            Task.WaitAll(workers);

            _results = orderedResults.ToList();

            if (canceled == 1)
                e.Cancel = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void workerDetect_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            circle1.Visible = false;
            listView1.Enabled = true;
            btn_detect.Text = "Start";

            _watch.Stop();
            FormMain.GetInstance().PrintSuccess(string.Format( "Elapsed: {0} ms", _watch.ElapsedMilliseconds));
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        string GenRow(double width, double height, Polygon polygon)
        {
            string row = polygon.classID.ToString();

            if (polygon.contour != null)
            {
                for (int i = 0; i < polygon.contour.Length; i++)
                {
                    double x = polygon.contour[i].X / width;
                    double y = polygon.contour[i].Y / height;
                    row += " " + x.ToString() + " " + y.ToString();
                }
            }

            return row;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        List<Point> ConvertToDrawPoint(List<PointF> pointFs)
        {
            List<Point> points = new List<Point>();
            for (int i = 0; i < pointFs.Count; i++)
            {
                PointF pointF = pointFs[i];
                Point point = new Point();
                point.X = (int)(pointF.X * m_bmp.Width / m_scaleX);
                point.Y = (int)(pointF.Y * m_bmp.Height / m_scaleY);

                points.Add(point);
            }

            return points;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        List<Point> ConvertToDrawPoint(Point[] points)
        {
            List<Point> results = new List<Point>();
            for (int i = 0; i < points.Length; i++)
            {
                Point point = points[i];
                Point result = new Point();
                result.X = (int)(point.X / m_scaleX);
                result.Y = (int)(point.Y / m_scaleY);

                results.Add(result);
            }

            return results;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        Point ConvertToDrawPoint(PointF pointF)
        {
            Point p = new Point();
            p.X = (int)(pointF.X * m_bmp.Width / m_scaleX);
            p.Y = (int)(pointF.Y * m_bmp.Height / m_scaleY);

            return p;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////

        void AdjustSize()
        {
            if (m_bmp == null)
                return;

            m_aspect = (double)m_bmp.Width / (double)m_bmp.Height;
            double panelAspect = (double)panelPicture.Width / (double)panelPicture.Height;
            if (m_aspect > panelAspect)
            {
                pictureBox1.Width = panelPicture.Width;
                pictureBox1.Height = (int)(pictureBox1.Width / m_aspect);
            }
            else if (m_aspect < panelAspect)
            {
                pictureBox1.Height = panelPicture.Height;
                pictureBox1.Width = (int)(pictureBox1.Height * m_aspect);
            }
            m_scaleX = (double)m_bmp.Width / pictureBox1.Width;
            m_scaleY = (double)m_bmp.Height / pictureBox1.Height;
        }
    }
}
