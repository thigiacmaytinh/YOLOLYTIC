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
using System.Threading.Tasks;

namespace YoloSegment
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

        Segmented m_result;


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

        private void Form1_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory("input");
            InitCamera();
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

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (m_bmp == null)
                return;

            string filePath = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg";
            m_bmp.Save(filePath, ImageFormat.Jpeg);
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void InitCamera()
        {
            cbCamera.Items.Clear();

            FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);

            if (videosources.Count == 0)
            {
                FormMain.GetInstance().PrintError("Can not find camera");
                return;
            }


            for (int i = 0; i < videosources.Count; i++)
            {
                cbCamera.Items.Add(videosources[i].Name);
            }
            cbCamera.Enabled = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cbCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            StartWebcam();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void StartWebcam()
        {
            if (cbCamera.Items.Count == 0 || cbCamera.SelectedIndex == -1)
                return;
            if (m_videoSource != null)
            {
                m_videoSource.Stop();
            }
            else
            {
                FilterInfoCollection videosources = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                m_videoSource = new VideoCaptureDevice(videosources[cbCamera.SelectedIndex].MonikerString);
            }

            m_videoSource.NewFrame += new NewFrameEventHandler(OnCameraFrame);
            m_videoSource.Start();

            circle1.Visible = true;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        void OnCameraFrame(object sender, NewFrameEventArgs e)
        {
            if(m_formClosed)
                return;

            if (m_bmp != null)
                m_bmp.Dispose();

            lock (_bitmapLock)
            {
                m_bmp = e.Frame.Clone(new Rectangle(0, 0, e.Frame.Width, e.Frame.Height), e.Frame.PixelFormat);
                Bitmap bmp2 = e.Frame.Clone(new Rectangle(0, 0, e.Frame.Width, e.Frame.Height), e.Frame.PixelFormat);
                if (!workerDetect.IsBusy)
                {
                    workerDetect.RunWorkerAsync(bmp2);
                }
            }
            

            if (m_aspect == -1)
            {
                m_aspect = (float)m_bmp.Width / m_bmp.Height;

                float pictureBoxAspect = (float)picWebcam.Width / picWebcam.Height;

                if(pictureBoxAspect > m_aspect)
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

            Segmented result;
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

        async void UpdateUI(Bitmap _bmp, Segmented result)
        {
            if(m_formClosed) return;

            Bitmap bmp = new Bitmap(_bmp);
            _bmp.Dispose();

            ListViewItem[] items = new ListViewItem[result.polygons.Count];


            // Iterate through detected objects and update the UI
            for (int i = 0; i < result.polygons.Count; i++)
            {
                Polygon obj = result.polygons[i];
                Rectangle rect = obj.rect;

                // Draw a rectangle around the detected object
                //bmp = TGMTdraw.DrawRectangle(bmp, rect, Color.Lime, false, 4);
                Util.DrawObject(bmp, result.polygons, picWebcam.Size, true, false, false, true, -1);

                // Create a new ListViewItem for each object
                ListViewItem item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(obj.className);
                item.SubItems.Add(obj.score.ToString());
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

        private void FormWebcam_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                //if(cbCamera.Items.Count == 1)
                //{
                //    cbCamera.SelectedIndex = 0;
                //}
            }
            else
            {
                
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void StopAllCamera()
        {
            if (m_videoSource != null)
            {
                m_videoSource.NewFrame -= new NewFrameEventHandler(OnCameraFrame);
                m_videoSource.Stop();
            }
                

            picWebcam.Image = null;
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

            StopAllCamera();
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormWebcam_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormWebcam_SizeChanged(object sender, EventArgs e)
        {
            picWebcam.Width = (this.Width - 20) / 2;
            picWebcam.Width = (this.Width - 20) / 2;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void workerDetect_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            Bitmap bmp = (Bitmap)e.Argument;


            Segmented result = EngineMgr.GetInstance().Segment(bmp);
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

            Segmented result = (Segmented)e.Result;

            lock (_objLock)
            {
                m_result = result;
            }
        }

        
    }
}
