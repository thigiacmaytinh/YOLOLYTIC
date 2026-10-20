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
    public partial class FormExtractVideo : Form
    {
        static FormExtractVideo m_instance;


        bool m_formClosed = false;
        public bool m_isBusy = false;
        bool m_isConnecting = false;



        //int m_index = 0;

        string m_outputDir = "";
        int m_totalFrame = 0;
        string m_fileName = "";

        int m_numThread = 1;


        Dictionary<int, Color> m_colors = new Dictionary<int, Color>();

        int m_minArea = 0;

        int m_frameCount = 0;

        int frameSkip = 0;
        Bitmap m_bmp;
        int m_frameSkip;
        bool m_overwrite = false;

        int SKIP_FRAME = 10;
        bool _saveAll = true;

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

        private void FormExtractVideo_Load(object sender, EventArgs e)
        {
            txt_inputVideo.Text = TGMTregistry.GetInstance().ReadString("inputVideo2");
            txt_output.Text = TGMTregistry.GetInstance().ReadString("outputDir");
            txt_minArea.Value = TGMTregistry.GetInstance().ReadInt("minArea", 0);
            m_numThread = TGMTregistry.GetInstance().ReadInt("txt_numThread", m_numThread);
            txt_numThread.Value = m_numThread;
            m_overwrite = chk_overWrite.Checked = TGMTregistry.GetInstance().ReadBool("chk_overWrite", m_overwrite);
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
                if (txt_output.Text == "")
                {
                    MessageBox.Show("Output folder is empty", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string outputDir = TGMTutil.CorrectPath(txt_output.Text) + Path.GetFileNameWithoutExtension(txt_inputVideo.Text);
                Directory.CreateDirectory(outputDir);
                

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

            lbl_count.Text = "Total frame: " + m_totalFrame;

            m_fileName = Path.GetFileName(txt_inputVideo.Text);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_overWrite_CheckedChanged(object sender, EventArgs e)
        {
            m_overwrite = chk_overWrite.Checked;
            TGMTregistry.GetInstance().SaveValue("chk_overWrite", chk_overWrite.Checked);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_startFrame_ValueChanged(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().SaveValue("txt_startFrame", txt_startFrame.Value);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_output_TextChanged(object sender, EventArgs e)
        {
            txt_output.Text = txt_output.Text.Replace("\"", "");
            m_outputDir = TGMTutil.CorrectPath(txt_output.Text);

            TGMTregistry.GetInstance().SaveValue("outputDir", txt_output.Text);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_skipFrame_ValueChanged(object sender, EventArgs e)
        {
            SKIP_FRAME = (int)txt_skipFrame.Value;
            TGMTregistry.GetInstance().SaveValue("txt_skipFrame", SKIP_FRAME);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_numThread_ValueChanged(object sender, EventArgs e)
        {
            m_numThread = (int)txt_numThread.Value;
            TGMTregistry.GetInstance().SaveValue("txt_numThread", m_numThread);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_minArea_ValueChanged(object sender, EventArgs e)
        {
            m_minArea = (int)txt_minArea.Value;
            TGMTregistry.GetInstance().SaveValue("minArea", m_minArea);
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


            m_bmp = TGMTimage.FastClone(frame);
            Bitmap bmpDisplay = TGMTimage.FastClone(frame);

            m_frameCount++;
            m_frameSkip++;            

            TGMTthread.BeginInvokeSafe(this, () =>
            {
                if(pictureBox1.Image != null)
                    pictureBox1.Image.Dispose();
                pictureBox1.Image = bmpDisplay;

                lbl_count.Text = m_frameCount.ToString() + "/" + m_totalFrame.ToString();
                lbl_count.Refresh();
            });


            //if (SKIP_FRAME > 0)
            //{
            //    if (m_frameSkip < SKIP_FRAME)
            //    {
            //        return;
            //    }
            //    m_frameSkip = 0;
            //}


            string outFilePath = GenFilePath(m_outputDir);

            Bitmap bmp = TGMTimage.FastClone(m_bmp);
            Task.Run(() => { Segment(bmp, outFilePath, m_frameCount); });

            //Thread.Sleep(10); //avoid 100% CPU
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        Segmented Segment(Bitmap bmp, string outFilePath, int frameCount)
        {
            if (bmp == null)
            {
                return null;
            }
            if (m_formClosed)
                return null;

            Segmented result = EngineMgr.GetInstance().Segment(bmp);

            int numObject = 0;

            if (result != null && result.polygons != null)
            {
                numObject = result.polygons.Count;
            }


            List<string> content = new List<string>();
            for (int i = 0; i < numObject; i++)
            {
                TGMT.Polygon obj = result.polygons[i];
                if(m_minArea > 0)
                {
                    int area = obj.rect.Width * obj.rect.Height;
                    if (area < m_minArea)
                        continue;
                }
                content.Add(Util.GenRow(bmp.Width, bmp.Height, obj));
            }

            if(outFilePath != "" && (content.Count > 0 || _saveAll))
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
                    bmp.Save(outFilePath, ImageFormat.Jpeg);


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
                this.Invoke(new Action(() =>
                {
                    ListViewItem item = new ListViewItem(frameCount.ToString());
                    item.SubItems.Add(outFilePath);
                    item.SubItems.Add(numObject.ToString());

                    listView1.Items.Add(item);
                    listView1.EnsureVisible(listView1.Items.Count - 1);
                }));
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

        private void rd_saveAll_CheckedChanged(object sender, EventArgs e)
        {
            _saveAll = rd_saveAll.Checked;
        }
    }
}
