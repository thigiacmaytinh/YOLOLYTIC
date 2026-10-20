using System;
using System.Collections.Generic;
using System.Threading;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Drawing.Imaging;
using System.Windows.Forms;
using TGMT;
using AForge.Video;
using AForge.Video.DirectShow;
using System.Diagnostics;
using TGMTcs;
using System.Timers;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Threading.Tasks;

namespace Yololytic
{
    public partial class FormWebcam : Form
    {
        static FormWebcam m_instance;
        VideoCaptureDevice m_videoSource;
        Bitmap m_bmp;


        private readonly object _bitmapLock = new object();
        private readonly object _objLock = new object();

        bool m_formClosed = false;

        float m_aspect = -1.0f;

        Predicted m_result;
        bool m_drawRect = true;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormWebcam()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public static FormWebcam GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormWebcam();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormWebcam_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory("input");
            LoadWebcam();

            chk_drawRect.Checked = TGMTregistry.GetInstance().ReadBool("chk_drawRect");
            chk_drawText.Checked = TGMTregistry.GetInstance().ReadBool("chk_drawText");

            TGMTform.SetDoubleBuffer(listView1);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormWebcam_SizeChanged(object sender, EventArgs e)
        {
            picWebcam.Width = (this.Width - 20) / 2;
            picWebcam.Width = (this.Width - 20) / 2;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cb_webcam_SelectedIndexChanged(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().SaveValue("cb_webcam", cb_webcam.SelectedIndex);
            LoadResolution();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cb_resolution_SelectedIndexChanged(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().SaveValue("cb_resolution", cb_resolution.SelectedIndex);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_start_Click(object sender, EventArgs e)
        {
            if (btn_start.Text == "Start")
            {
                StartWebcam();
                btn_start.Text = "Stop";
            }
            else
            {
                btn_start.Text = "Start";
                StopWebcam();
                return;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_drawRect_CheckedChanged(object sender, EventArgs e)
        {
            m_drawRect = chk_drawRect.Checked;
            TGMTregistry.GetInstance().SaveValue("chk_drawRect", chk_drawRect.Checked);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_drawText_CheckedChanged(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().SaveValue("chk_drawText", chk_drawText.Checked);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (m_bmp == null)
                return;

            string filePath = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";
            m_bmp.Save(filePath, ImageFormat.Jpeg);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void LoadWebcam()
        {
            cb_webcam.Items.Clear();

            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videosources.Count == 0)
            {
                FormMain.GetInstance().PrintError("Can not find camera");
                return;
            }


            for (int i = 0; i < videosources.Count; i++)
            {
                cb_webcam.Items.Add(videosources[i].Name);
            }
            cb_webcam.Enabled = true;

            int selectedIndex = TGMTregistry.GetInstance().ReadInt("cb_webcam", -1);
            if (selectedIndex >= 0 && selectedIndex < cb_webcam.Items.Count)
                cb_webcam.SelectedIndex = selectedIndex;
        }


        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void StartWebcam()
        {
            if (cb_webcam.Items.Count == 0 || cb_webcam.SelectedIndex == -1)
                return;
            if (m_videoSource != null)
            {
                m_videoSource.Stop();
            }

            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            m_videoSource = new VideoCaptureDevice(videosources[cb_webcam.SelectedIndex].MonikerString);            

            m_videoSource.VideoResolution = SelectResolution(m_videoSource, cb_resolution.SelectedIndex);

            m_videoSource.NewFrame += new NewFrameEventHandler(OnWebcamFrame);
            m_videoSource.Start();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnWebcamFrame(object sender, NewFrameEventArgs e)
        {
            if(m_formClosed)
                return;

            _ = NextCirleFrameAsync();

            if (m_bmp != null)
                m_bmp.Dispose();

            lock (_bitmapLock)
            {
                m_bmp = e.Frame.Clone(new Rectangle(0, 0, e.Frame.Width, e.Frame.Height), e.Frame.PixelFormat);
                Bitmap bmp2 = e.Frame.Clone(new Rectangle(0, 0, e.Frame.Width, e.Frame.Height), e.Frame.PixelFormat);
                if (!workerDetect.IsBusy)
                {
                    workerDetect.RunWorkerAsync(bmp2);
                    _ = NextCirleWorkingAsync();
                }
            }


            if (m_aspect == -1)
            {
                m_aspect = (float)m_bmp.Width / m_bmp.Height;

                float pictureBoxAspect = (float)picWebcam.Width / picWebcam.Height;

                if (pictureBoxAspect > m_aspect)
                {
                    int newWidth = (int)(m_bmp.Height * m_aspect);
                    this.Invoke(new Action(() =>
                    {
                        picWebcam.Width = newWidth;
                    }));
                }
                else
                {
                    int newHeight = (int)(m_bmp.Width / m_aspect);
                    this.Invoke(new Action(() =>
                    {
                        picWebcam.Height = newHeight;
                    }));
                }

            }

            Predicted result;
            lock (_objLock)
            {
                result = m_result;
            }


            //Bitmap bmp = (Bitmap)m_bmp.Clone();

            if (result != null)
            {
                lock (_bitmapLock)
                {                    
                    //Bitmap bmp3 = e.Frame.Clone(new Rectangle(0, 0, e.Frame.Width, e.Frame.Height), e.Frame.PixelFormat);

                    UpdateUI(m_bmp, result);
                }                
            }

            // Dispose of the cloned bitmap to prevent memory leaks
            //bmp.Dispose();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        async void UpdateUI(Bitmap _bmp, Predicted result)
        {
            if(m_formClosed) 
                return;

            Bitmap bmp = new Bitmap(_bmp);
            _bmp.Dispose();

            if (result == null || result.boxes == null)
                return;

            ListViewItem[] items = new ListViewItem[result.boxes.Count];


            // Iterate through detected objects and update the UI
            for (int i = 0; i < result.boxes.Count; i++)
            {
                Box box = result.boxes[i];
                Rectangle rect = box.rect;

                // Draw a rectangle around the detected object
                if (m_drawRect)
                {
                    TGMTdraw.DrawRectangle(bmp, rect, Color.Lime, false, 4);
                }
                    

                // Create a new ListViewItem for each object
                ListViewItem item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(box.className);
                item.SubItems.Add(box.score.ToString("0.00"));
                items[i] = item;
                // Add the item to the ListView

            }

            try
            {
                await Task.Run(() =>
                {

                    if (listView1.InvokeRequired)
                    {
                        listView1.Invoke(new Action(() =>
                        {
                            listView1.Items.Clear();
                            listView1.Items.AddRange(items);
                        }));
                    }
                    else
                    {
                        if (!listView1.IsDisposed && listView1.IsHandleCreated)
                        {
                            listView1.Items.Clear();
                            listView1.Items.AddRange(items);
                        }
                    }
                });
            }
            catch(Exception ex) { }
            



            //// Update the PictureBox with the processed frame
            picWebcam.Image?.Dispose(); // Dispose the old image to avoid memory leaks
            picWebcam.Image = (Bitmap)bmp.Clone(); // Clone the bitmap to avoid conflicts
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void OnFormSelected(bool selected)
        {
            if (selected)
            {
                m_formClosed = false;
            }
            else
            {
                m_formClosed = true;
                StopWebcam();
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StopWebcam()
        {
            if (m_videoSource != null)
            {
                m_videoSource.Stop();
                m_videoSource.NewFrame -= new NewFrameEventHandler(OnWebcamFrame);
            }               
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormWebcam_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_formClosed = true;
            //if (workerDetect.IsBusy)
            //{
            //    // Cancel the background worker and wait for it to finish
            //    workerDetect.CancelAsync();
            //    e.Cancel = true;  // Cancel the form closing to wait for worker
            //    workerDetect.RunWorkerCompleted += (s, args) => { Close(); }; // Close form after worker completes
            //}

            StopWebcam();
        }        

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void workerDetect_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Bitmap bmp = (Bitmap)e.Argument;


            Predicted result = EngineMgr.GetInstance().Detect(bmp);
            e.Result = result;


            if (workerDetect.CancellationPending)
            {
                e.Cancel = true;
                return;
            }

            e.Result = result;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void workerDetect_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (this == null || this.IsDisposed)
                return;

            if (e.Cancelled)
                return;

            if (e.Result == null)
                return;

            Predicted result = (Predicted)e.Result;

            lock (_objLock)
            {
                m_result = result;
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void LoadResolution()
        {
            if (cb_webcam.Items.Count == 0 || cb_webcam.SelectedIndex == -1)
                return;

            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            VideoCaptureDevice videoSource = new VideoCaptureDevice(videosources[cb_webcam.SelectedIndex].MonikerString);

            cb_resolution.Items.Clear();
            foreach (var cap in videoSource.VideoCapabilities)
            {
                cb_resolution.Items.Add(cap.FrameSize.Width + "x" + cap.FrameSize.Height + " (" + cap.MaximumFrameRate + " FPS)");
            }

            int selectedIndex = TGMTregistry.GetInstance().ReadInt("cb_resolution", -1);
            if (selectedIndex >= 0 && selectedIndex < cb_resolution.Items.Count)
                cb_resolution.SelectedIndex = selectedIndex;
            else
            {
                if (cb_resolution.Items.Count > 0)
                {
                    cb_resolution.SelectedIndex = 0;
                }
            }            
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        VideoCapabilities SelectResolution(VideoCaptureDevice device, int resolutionIndex)
        {
            VideoCapabilities videoCap = device.VideoCapabilities[resolutionIndex];
            if (videoCap == null)
                return null;

            m_aspect = (float)videoCap.FrameSize.Width / videoCap.FrameSize.Height;
            return videoCap;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        async Task NextCirleFrameAsync()
        {
            await Task.Run(() =>
            {
                TGMTthread.InvokeSafe(circle_frame, () =>
                {
                    circle_frame.Next();
                });
            });
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        async Task NextCirleWorkingAsync()
        {
            await Task.Run(() =>
            {
                TGMTthread.InvokeSafe(circle1, () =>
                {
                    circle1.Next();
                });
            });
        }
    }
}
