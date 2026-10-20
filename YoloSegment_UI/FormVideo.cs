using NAudio;
using NAudio.Utils;
using OpenCV;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMT;
using TGMTcs;


namespace YoloSegment
{
    public partial class FormVideo : Form
    {
        static FormVideo m_instance;


        bool m_formClosed = false;
        public bool m_isBusy = false;
        bool m_isConnecting = false;

        private readonly object _bitmapLock = new object();


        //int m_index = 0;

        string m_outputDir = "";
        int m_totalFrame = 0;
        string m_fileName = "";


        //List<YOLODetector> m_detectors = new List<YOLODetector>();


        

        int m_minArea = 0;

        int m_frameCount = 0;

        int frameSkip = 0;
        Bitmap m_bmp;
        int m_frameSkip;
        bool m_overwrite = false;

        int SKIP_FRAME = 10;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormVideo()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static FormVideo GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormVideo();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormVideo_Load(object sender, EventArgs e)
        {
            txt_inputVideo.Text = TGMTregistry.GetInstance().ReadString("inputVideo2");
            
            txt_minArea.Value = TGMTregistry.GetInstance().ReadInt("minArea", 0);
            
            txt_startFrame.Value = TGMTregistry.GetInstance().ReadInt("txt_startFrame", 0);

            SKIP_FRAME = TGMTregistry.GetInstance().ReadInt("txt_skipFrame", SKIP_FRAME);
            txt_skipFrame.Value = SKIP_FRAME;

            
            TGMTform.SetDoubleBuffer(listView1);            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormExtract_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Width = pnCamera1.Width;
            pictureBox1.Height = pnCamera1.Height;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void OnFormSelected(bool selected)
        {
            if (selected)
            {
                FFMPEG.OnVideoFrame += OnVideoFrame;
            }
            else
            {
                FFMPEG.OnVideoFrame -= OnVideoFrame;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (btn_start.Text == "Start")
            {
                m_frameCount = (int)txt_startFrame.Value;
                FFMPEG.PlayVideoAsync(txt_inputVideo.Text, m_frameCount);

                m_formClosed = false;
                btn_start.Text = "Stop";                
            }
            else
            {
                FFMPEG.StopVideo();

                circle1.Visible = false;
                btn_start.Text = "Start";
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void txt_inputVideo_TextChanged(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().SaveValue("inputVideo2", txt_inputVideo.Text);

            if (!File.Exists(txt_inputVideo.Text))
                return;

            m_totalFrame = FFMPEG.CountTotalFrame(txt_inputVideo.Text);

            lbl_count.Text = "/" + m_totalFrame;
            trackBar1.Maximum = m_totalFrame;

            m_fileName = Path.GetFileName(txt_inputVideo.Text);

            pictureBox1.Image = FFMPEG.ReadFrame(txt_inputVideo.Text, 0);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_startFrame_ValueChanged(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().SaveValue("txt_startFrame", txt_startFrame.Value);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_skipFrame_ValueChanged(object sender, EventArgs e)
        {
            SKIP_FRAME = (int)txt_skipFrame.Value;
            TGMTregistry.GetInstance().SaveValue("txt_skipFrame", SKIP_FRAME);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_minArea_ValueChanged(object sender, EventArgs e)
        {
            m_minArea = (int)txt_minArea.Value;
            TGMTregistry.GetInstance().SaveValue("minArea", m_minArea);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void trackBar1_ValueChanged(object sender, EventArgs e)
        {
            txt_frameIdx.Value = trackBar1.Value;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void trackBar1_MouseUp(object sender, MouseEventArgs e)
        {
            int value = (int)trackBar1.Value;
            circle1.Visible = true;
            circle1.Enabled = true;


            Thread t = new Thread(() =>
            {
                m_bmp = FFMPEG.ReadFrame(txt_inputVideo.Text, value);
                this.Invoke(new Action(() =>
                {
                    pictureBox1.Image = m_bmp;
                    pictureBox1.Refresh();
                    
                }));
                
                Segment(m_bmp);
            });
        
            t.Start();            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void OnVideoFrame(Bitmap bmp, bool isEndFrame, long frameIndex)
        {
            if (bmp == null)
            {
                if (isEndFrame)
                {
                    MessageBox.Show("Đã đọc hoàn tất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Invoke(new Action(() =>
                    {
                        btn_start.Text = "Start";
                    }));

                    m_frameCount = 0;
                }
                return;
            }


            NextCircleFrame();

            m_bmp = TGMTimage.FastClone(bmp);
            

            m_frameCount++;
            m_frameSkip++;            

            TGMTthread.BeginInvokeSafe(this, () =>
            {
                lbl_count.Text = m_frameCount.ToString() + "/" + m_totalFrame.ToString();
                lbl_count.Refresh();
            });


            if (SKIP_FRAME > 0)
            {
                if (m_frameSkip < SKIP_FRAME)
                {
                    return;
                }
                m_frameSkip = 0;
            }



            Segment(m_bmp);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormExtract_FormClosing(object sender, FormClosingEventArgs e)
        {
            FFMPEG.StopVideo();
            m_formClosed = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //string GenRow(double width, double height, YOLOobject obj)
        //{
        //    double x = obj.rect.X / width;
        //    double y = obj.rect.Y / height;
        //    double w = obj.rect.Width / width;
        //    double h = obj.rect.Height / height;
        //    double cx = x + w / 2;
        //    double cy = y + h / 2;

        //    return obj.classID + " " + cx + " " + cy + " " + w + " " + h;
        //}

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string GenFilePath(string saveDir)
        {
            string dirName = Path.GetFileNameWithoutExtension(m_fileName);
            string filePath = saveDir + dirName + "\\" + m_fileName + "_";
            filePath += String.Format("{0:00000}", m_frameCount)  + ".jpg";
            return filePath;
        }        

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                
        void NextCircleFrame()
        {
            TGMTthread.BeginInvokeSafe(this, () =>
            {
                circleFrame.Next();
            });
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void Segment(Bitmap bmp)
        {
            Segmented predicted = EngineMgr.GetInstance().Segment(TGMTimage.FastClone(bmp));

            int numObject = 0;

            if (predicted != null && predicted.polygons != null)
            {
                numObject = predicted.polygons.Count;
            }

            List<ListViewItem> items = new List<ListViewItem>();
            List<Polygon> validPolygons = new List<Polygon>();

            for (int i = 0; i < numObject; i++)
            {
                TGMT.Polygon polygon = predicted.polygons[i];
                if(polygon.classID != 0)
                    continue;

                if (m_minArea > 0)
                {
                    int area = polygon.rect.Width * polygon.rect.Height;
                    if (area < m_minArea)
                        continue;
                }

                validPolygons.Add(polygon);

                ListViewItem item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(polygon.className);
                item.SubItems.Add(polygon.score.ToString("0.00"));

                items.Add(item);
            }

            try
            {
                this.Invoke(new Action(() =>
                {
                    listView1.Items.Clear();

                    if (items.Count > 0)
                    {
                        listView1.Items.AddRange(items.ToArray());
                        listView1.EnsureVisible(listView1.Items.Count - 1);
                    }

                    //if (circle1.Enabled)
                    //    circle1.Visible = false;
                }));
            }
            catch (Exception ex)
            {
            }


            Util.DrawObject(bmp, validPolygons, pictureBox1.Size, 
                Program.drawText, Program.drawContour, Program.drawRect, Program.drawRotatedRectangle);
            pictureBox1.Image = bmp;

            

            Thread.Sleep(10); //avoid 100% CPU
        }        
    }
}
