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
    public partial class FormExtractVideo : Form
    {
        static FormExtractVideo m_instance;


        bool m_formClosed = false;

        public bool m_isBusy = false;
        bool m_isConnecting = false;

        private readonly object _bitmapLock = new object();


        //int m_index = 0;

        string m_outputDir = "";
        int m_totalFrame = 0;
        string m_fileName = "";


        object m_lock = new object();

        Dictionary<int, Color> m_colors = new Dictionary<int, Color>();

        int _maxImageWidth = 0;

        long m_frameCount = 0;

        int frameSkip = 0;
        
        int m_frameSkip;
        bool m_overwrite = false;
        bool _inited = false;

        int _skipFrame = 10;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormExtractVideo()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public static FormExtractVideo GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormExtractVideo();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormExtract_Load(object sender, EventArgs e)
        {
            txt_inputVideo.Text = TGMTregistry.GetInstance().ReadString("inputVideo2");
            m_outputDir = TGMTutil.CorrectPath(TGMTregistry.GetInstance().ReadString("outputDir"));
            txt_output.Text = m_outputDir;

            _maxImageWidth = TGMTregistry.GetInstance().ReadInt("minArea", _maxImageWidth);
            txt_maxImageWidth.Text = _maxImageWidth.ToString();

            m_overwrite = chk_overWrite.Checked = TGMTregistry.GetInstance().ReadBool("chk_overWrite", m_overwrite);
            txt_startFrame.Text = TGMTregistry.GetInstance().ReadString("txt_startFrame", "1");

            _skipFrame = TGMTregistry.GetInstance().ReadInt("txt_skipFrame", _skipFrame);
            txt_skipFrame.Text = _skipFrame.ToString();

            
            TGMTform.SetDoubleBuffer(listView1);

            _inited = true;
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
                if (txt_output.Text == "")
                {
                    MessageBox.Show("Output folder is empty");
                    return;
                }

                string outputDir = TGMTutil.CorrectPath(txt_output.Text) + Path.GetFileNameWithoutExtension(txt_inputVideo.Text);
                Directory.CreateDirectory(outputDir);
                

                listView1.Items.Clear();
                m_frameCount = long.Parse(txt_startFrame.Text);
                FFMPEG.PlayVideoAsync(txt_inputVideo.Text, m_frameCount, _skipFrame);

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

            lbl_count.Text = "Total frame: " + m_totalFrame;

            m_fileName = Path.GetFileName(txt_inputVideo.Text);
            pictureBox1.Image = FFMPEG.ReadFrame(txt_inputVideo.Text, 0);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_overWrite_CheckedChanged(object sender, EventArgs e)
        {
            m_overwrite = chk_overWrite.Checked;
            TGMTregistry.GetInstance().SaveValue("chk_overWrite", chk_overWrite.Checked);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_startFrame_TextChanged(object sender, EventArgs e)
        {
            if(!_inited)
                return;
            TGMTregistry.GetInstance().SaveValue("txt_startFrame", txt_startFrame.Text);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_output_TextChanged(object sender, EventArgs e)
        {
            if(!_inited) return;

            txt_output.Text = txt_output.Text.Replace("\"", "");
            m_outputDir = TGMTutil.CorrectPath(txt_output.Text);

            TGMTregistry.GetInstance().SaveValue("outputDir", txt_output.Text);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_skipFrame_TextChanged(object sender, EventArgs e)
        {
            if(!_inited) return;

            _skipFrame = int.Parse(txt_skipFrame.Text);
            TGMTregistry.GetInstance().SaveValue("txt_skipFrame", _skipFrame);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_maxImageWidth_TextChanged(object sender, EventArgs e)
        {
            if(!_inited) return;

            _maxImageWidth = int.Parse(txt_maxImageWidth.Text);
            TGMTregistry.GetInstance().SaveValue("maxImageWidth", _maxImageWidth);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void OnVideoFrame(Bitmap frame, bool isEndFrame, long frameIndex)
        {
            if (frame == null)
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

            m_frameCount = frameIndex;

            Bitmap bmp = TGMTimage.FastClone(frame);
            Bitmap bmpDisplay = TGMTimage.FastClone(frame);

    

            Task.Run(() =>
            {
                TGMTthread.BeginInvokeSafe(this, () =>
                {
                    if(pictureBox1.Image != null)
                        pictureBox1.Image.Dispose();
                    pictureBox1.Image = bmpDisplay;

                    lbl_count.Text = frameIndex.ToString() + "/" + m_totalFrame.ToString();
                    circle1.Next();
                });
            });
            
            string outFilePath = GenFilePath(m_outputDir);
            Task.Run(() => { Detect(bmp, outFilePath, frameIndex); });
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Predicted Detect(Bitmap bmp, string outFilePath, long frameCount)
        {
            if (bmp == null)
            {
                return null;
            }
            if (m_formClosed)
                return null;

            Predicted result = EngineMgr.GetInstance().Detect(bmp);


            int numObject = 0;

            if (result != null && result.boxes != null)
            {
                numObject = result.boxes.Count;
            }


            List<string> content = new List<string>();
            for (int i = 0; i < numObject; i++)
            {
                Box box = result.boxes[i];
                if( Program.selectClass && !Program.classSelecteds.Contains(box.classID))
                    continue;

                if(_maxImageWidth > 0)
                {
                    int area = box.rect.Width * box.rect.Height;
                    if (area < _maxImageWidth)
                        continue;
                }
                content.Add(GenRow(bmp.Width, bmp.Height, box));
            }

            if(outFilePath != "")
            {
                bool fileExist = false;
                if(File.Exists(outFilePath))
                {
                    fileExist = true;
                    if (m_overwrite)
                    {
                        File.Delete(outFilePath);
                        fileExist = false;
                    }
                }

                if(!fileExist)
                {
                    if(_maxImageWidth > 0)
                    {
                        if (bmp.Width > _maxImageWidth)
                        {
                            bmp = TGMTimage.ResizeBitmapByWidth(bmp, _maxImageWidth);
                        }
                    }
                    bmp.Save(outFilePath, ImageFormat.Jpeg);
                }                    


                fileExist = false;
                string outTextPath = outFilePath.Replace(".jpg", ".txt");
                if (File.Exists(outTextPath))
                {
                    fileExist = true;
                    if (m_overwrite)
                    {
                        File.Delete(outTextPath);
                        fileExist = false;
                    }                        
                }
                if (!fileExist)
                    File.WriteAllLines(outTextPath, content.ToArray());
            }


            try
            {
                TGMTthread.BeginInvokeSafe(this, () =>
                {
                    ListViewItem item = new ListViewItem(frameCount.ToString());
                    item.SubItems.Add(outFilePath);
                    item.SubItems.Add(numObject.ToString());

                    listView1.Items.Add(item);
                    listView1.EnsureVisible(listView1.Items.Count - 1);
                });
            }
            catch (Exception ex)
            {
            }
            

            return result;            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormExtract_FormClosing(object sender, FormClosingEventArgs e)
        {
            FFMPEG.StopVideo();
            m_formClosed = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        string GenRow(double width, double height, Box box)
        {
            double x = box.rect.X / width;
            double y = box.rect.Y / height;
            double w = box.rect.Width / width;
            double h = box.rect.Height / height;
            double cx = x + w / 2;
            double cy = y + h / 2;

            return box.classID + " " + cx + " " + cy + " " + w + " " + h;
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

        Color GetColor(int classID)
        {
            if (m_colors.ContainsKey(classID))
                return m_colors[classID];

            m_colors[classID] = TGMTdraw.GenerateRandomColor();
            return m_colors[classID];
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
                
        void NextCircleFrame()
        {
            TGMTthread.BeginInvokeSafe(this, () =>
            {
                circleFrame.Next();
            });
        }


    }
}
