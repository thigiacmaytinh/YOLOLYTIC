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


namespace Yololytic
{
    public partial class FormVideo : Form
    {
        static FormVideo m_instance;
        bool _inited = false;

        bool m_formClosed = false;
        public bool m_isBusy = false;
        int m_totalFrame = 0;
        string m_fileName = "";

       
        int _startFrame = 0;
        int _minArea = 0;
        int m_frameCount = 0;

        int frameSkip = 0;
       
        bool m_overwrite = false;

        int _skipFrame = 10;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormVideo()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;

            TGMTform.SetDoubleBuffer(listView1);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static FormVideo GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormVideo();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormExtract_Load(object sender, EventArgs e)
        {
            txt_inputVideo.Text = TGMTregistry.GetInstance().ReadString("inputVideo2");
                      
            
            _startFrame = TGMTregistry.GetInstance().ReadInt("startFrame", _startFrame);
            txt_startFrame.Text = _startFrame.ToString();

            _skipFrame = TGMTregistry.GetInstance().ReadInt("skipFrame", _skipFrame);
            txt_skipFrame.Text = _skipFrame.ToString();

            _minArea = TGMTregistry.GetInstance().ReadInt("minArea", _minArea);
            txt_minArea.Text = _minArea.ToString();


            _inited = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormExtract_SizeChanged(object sender, EventArgs e)
        {
            pictureBox1.Width = pnCamera1.Width;
            pictureBox1.Height = pnCamera1.Height;
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormExtract_FormClosing(object sender, FormClosingEventArgs e)
        {
            FFMPEG.StopVideo();
            m_formClosed = true;
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
                m_frameCount = _startFrame;
                FFMPEG.PlayVideoAsync(txt_inputVideo.Text, m_frameCount, _skipFrame);

                m_formClosed = false;
                circle1.Visible = true;
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

            lbl_count.Text = "Total frame: " + m_totalFrame;

            m_fileName = Path.GetFileName(txt_inputVideo.Text);
            pictureBox1.Image = FFMPEG.ReadFrame(txt_inputVideo.Text, 0);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_startFrame_TextChanged(object sender, EventArgs e)
        {
            if(!_inited || txt_startFrame.Text == "")
                return;

            _startFrame = int.Parse(txt_startFrame.Text);

            TGMTregistry.GetInstance().SaveValue("startFrame", _startFrame);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_skipFrame_TextChanged(object sender, EventArgs e)
        {
            if(!_inited || txt_skipFrame.Text == "")
                return;

            _skipFrame = int.Parse(txt_skipFrame.Text);
            TGMTregistry.GetInstance().SaveValue("skipFrame", _skipFrame);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_minArea_TextChanged(object sender, EventArgs e)
        {
            if(!_inited || txt_minArea.Text == "")
                return;

            _minArea = int.Parse(txt_minArea.Text);
            TGMTregistry.GetInstance().SaveValue("minArea", _minArea);
        }      

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
      
        private void OnVideoFrame(Bitmap frame, bool isEndFrame, long frameIndex)
        {
            if (frame == null)
            {
                if (isEndFrame)
                {
                    MessageBox.Show("Đã đọc hoàn tất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TGMTthread.BeginInvokeSafe(this, () =>
                    {
                        btn_start.Text = "Start";
                        circle1.Visible = false;
                    });

                    m_frameCount = 0;
                }
                return;
            }


            Bitmap bitmap = TGMTimage.FastClone(frame);

            List<Box> boxes = Detect(bitmap);
            //if(predicted.boxes.Count() > 0)
            //{
            //    bitmap.Save("input\\" + DateTime.Now.ToString("hh-mm-ss.fff") + ".jpg");
            //}

            int numObject = 0;

            if(boxes != null && boxes != null)
            {
                numObject = boxes.Count;
            }

            List<ListViewItem> items = new List<ListViewItem>();

            int index = 1;
            for(int i = 0; i < numObject; i++)
            {
                Box box = boxes[i];

                ListViewItem item = new ListViewItem((index).ToString());
                item.SubItems.Add(box.className);
                item.SubItems.Add(box.score.ToString("0.00"));

                items.Add(item);
                index++;
            }

            Util.DrawObject(frame, boxes);

            try
            {
                this.Invoke(new Action(() => {
                    circle1.Next();
                    lbl_count.Text = frameIndex.ToString() + "/" + m_totalFrame.ToString();

                    pictureBox1.Image = frame;


                    listView1.Items.Clear();
                    listView1.Items.AddRange(items.ToArray());
                }));
            }
            catch(Exception ex)
            {
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        List<Box> Detect(Bitmap bmp)
        {
            if (bmp == null)
            {
                return null;
            }
            if (m_formClosed)
                return null;

            Predicted predicted = EngineMgr.GetInstance().Detect(bmp);           
            List<Box> result = new List<Box>();

            for(int i = 0; i < predicted.boxes.Count; i++)
            {
                Box box = predicted.boxes[i];

                if(_minArea > 0)
                {
                    int area = box.rect.Width * box.rect.Height;
                    if(area < _minArea)
                        continue;
                }

                if(Program.selectClass && !Program.classSelecteds.Contains(box.classID))
                    continue;                

                result.Add(box);
            }
            

            return result;            
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        string GenRow(double width, double height, Box obj)
        {
            double x = obj.rect.X / width;
            double y = obj.rect.Y / height;
            double w = obj.rect.Width / width;
            double h = obj.rect.Height / height;
            double cx = x + w / 2;
            double cy = y + h / 2;

            return obj.classID + " " + cx + " " + cy + " " + w + " " + h;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public string GenFilePath(string saveDir)
        {
            string dirName = Path.GetFileNameWithoutExtension(m_fileName);
            string filePath = saveDir + dirName + "\\" + m_fileName + "_";
            filePath += String.Format("{0:00000}", m_frameCount)  + ".jpg";
            return filePath;
        }

        

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                
        void NextCircle()
        {
            TGMTthread.BeginInvokeSafe(this, () =>
            {
                circle1.Next();
            });
        }
    }
}
