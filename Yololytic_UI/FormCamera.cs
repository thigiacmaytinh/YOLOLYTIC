using NAudio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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



namespace Yololytic
{
    public partial class FormCamera : Form
    {
        static FormCamera m_instance;

        bool m_formClosed = false;
        public bool m_isBusy = false;
        bool m_isConnecting = false;

        Dictionary<int, Color> m_colors = new Dictionary<int, Color>();

        CameraWall.CameraWall _displayWall;
        int _camID = 0;
        private int _sourceWidth = 0;
        private int _sourceHeight = 0;
        AtomicBool _isDetecting = new AtomicBool(true);
        private CancellationTokenSource _aiLoopCts;
        private ulong _lastAiFrameId = 0;

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormCamera()
        {
            InitializeComponent();

            this.AutoScaleMode = AutoScaleMode.None;
            this.TopLevel = false;
            this.Dock = DockStyle.Fill;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        public static FormCamera GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormCamera();
            return m_instance;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormExtract_Load(object sender, EventArgs e)
        {
            txt_camera.Text = TGMTregistry.GetInstance().ReadString("inputVideo1");
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormCamera_SizeChanged(object sender, EventArgs e)
        {
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        public void OnFormSelected(bool selected)
        {
            //if(selected)
            //{
            //    FFMPEG.OnVideoFrame += OnVideoFrame;
            //}
            //else
            //{
            //    FFMPEG.OnVideoFrame -= OnVideoFrame;
            //}
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void FormCamera_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_formClosed = true;
            e.Cancel = false;
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_start_Click(object sender, EventArgs e)
        {
            if(btn_start.Text == "Start")
            {
                InitNativeDisplay(txt_camera.Text, pnCamera0);

                StartDetect();

                m_formClosed = false;
                circle0.Visible = true;
                btn_start.Text = "Stop";
            }
            else
            {
                //FFMPEG.StopVideo();

                circle0.Visible = false;
                btn_start.Text = "Start";
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void txt_imagePath_TextChanged(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().SaveValue("inputVideo1", txt_camera.Text);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        //private void M_cameraPanel_NewFrame1(object sender, TGMTplayer.Sources.NewFrameEventArgs e)
        //{
        //    if (!Program.inited || m_formClosed)
        //        return;


        //    Bitmap bmp = e.Frame.Clone(new Rectangle(0, 0, e.Frame.Width, e.Frame.Height), e.Frame.PixelFormat);

        //    Bitmap bmpDraw = e.Frame.Clone(new Rectangle(0, 0, e.Frame.Width, e.Frame.Height), e.Frame.PixelFormat);

        //    Predicted result = Detect(bmp, 1);


        //    int numObject = 0;

        //    if (result != null)
        //    {
        //        numObject = result.boxes.Count;
        //    }



        //    if (m_formClosed)
        //        return;

        //    this.Invoke(new Action(() =>
        //    {
        //        listView1.Items.Clear();

        //        for (int i = 0; i < numObject; i++)
        //        {
        //            Box box = result.boxes[i];

        //            ListViewItem item = new ListViewItem((i + 1).ToString());
        //            item.SubItems.Add(box.classID.ToString());
        //            item.SubItems.Add(box.className);
        //            item.SubItems.Add(box.score.ToString());
        //            listView1.Items.Add(item);


        //            TGMTdraw.DrawRectangle(bmpDraw, box.rect, GetColor(box.classID), false, 6);
        //        }

        //        pictureBox1.Image = bmpDraw;
        //        lbl_count.Text = numObject.ToString();
        //    }));
            
        //}

        

        //////////////////////////////////////////////////////////////////////////////////////////////////////////////
        
        Color GetColor(int classID)
        {
            if(m_colors.ContainsKey(classID))
                return m_colors[classID];

            m_colors[classID] = TGMTdraw.GenerateRandomColor();
            return m_colors[classID];
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void InitNativeDisplay(string url, Panel panelDisplay)
        {
            if(string.IsNullOrWhiteSpace(url))
                return;


            //circle0.Enabled = true;

            if(!panelDisplay.IsHandleCreated)
                panelDisplay.CreateControl();

            if(_displayWall == null)
            {
                _displayWall = new CameraWall.CameraWall();

                bool ok = _displayWall.Initialize(panelDisplay.Handle);
                if(!ok)
                    throw new Exception("Cannot initialize native camera renderer.");

                _displayWall.Resize(panelDisplay.ClientSize.Width, panelDisplay.ClientSize.Height);
                _displayWall.SetGridLayout(1, 1);

                panelDisplay.Resize -= pnCamera0_Resize;
                panelDisplay.Resize += pnCamera0_Resize;

                //panelDisplay.MouseUp -= pnCamera0_MouseUp;
                //panelDisplay.MouseUp += pnCamera0_MouseUp;
            }

            _displayWall.RemoveCamera(_camID);

            _displayWall.AddCamera(_camID, url);
            
            _displayWall.AssignCameraToCell(0, _camID);
            _displayWall.Start();

            // this run async task to update the source resolution after the display wall has started and first frame has been received
            _ = UpdateSourceResolutionAsync();

            _isDetecting.Set(false);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void pnCamera0_Resize(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;

            if(_displayWall == null || panel == null)
                return;

            int width = panel.ClientSize.Width;
            int height = panel.ClientSize.Height;

            if(width <= 0 || height <= 0)
                return;

            _displayWall.Resize(width, height);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private async Task UpdateSourceResolutionAsync()
        {
            const int retryCount = 50;
            const int retryDelayMs = 100;

            for(int i = 0; i < retryCount; i++)
            {
                if(m_formClosed || _displayWall == null)
                    return;

                int width = 0;
                int height = 0;

                if(_displayWall.TryGetCameraSourceResolution(
                        _camID,
                        ref width,
                        ref height))
                {
                    _sourceWidth = width;
                    _sourceHeight = height;

                    if(!IsDisposed && IsHandleCreated)
                    {
                        BeginInvoke(new Action(() =>
                        {
                            lbl_resolution.Text = $"CAMERA {_camID + 1} ({width}x{height})";
                            circle0.Enabled = false;
                            //btn_takePicture.Enabled = true; // Enable the take picture button after first frame is received
                        }));
                    }

                    return;
                }

                await Task.Delay(retryDelayMs);
            }

            Console.WriteLine($"Camera {_camID}: source resolution is not available.");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void StartDetect()
        {
            StopDetect();

            _aiLoopCts = new CancellationTokenSource();
            CancellationToken token = _aiLoopCts.Token;

            Task.Run(() => DetectLoopAsync(token), token);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void StopDetect()
        {
            if(_aiLoopCts != null)
            {
                _aiLoopCts.Cancel();
                _aiLoopCts.Dispose();
                _aiLoopCts = null;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private Task DetectLoopAsync(CancellationToken token)
        {
            while(!token.IsCancellationRequested && !m_formClosed)
            {
                try
                {
                    if(_displayWall == null || _isDetecting.Get())
                    {
                        Thread.Sleep(100);
                        continue;
                    }

                    ulong newFrameId = 0;
                    Bitmap frame = null;

                    if(_displayWall.TryGetLatestAiFrameBitmap(_camID, _lastAiFrameId, ref newFrameId, ref frame))
                    {
                        _lastAiFrameId = newFrameId;
                        _isDetecting.Set(true);

                        TGMTthread.BeginInvokeSafe(this, () => { circle0.Next(); });


                        _ = Task.Run(() =>
                        {
                            try
                            {
                                Detect(frame);
                            }
                            catch
                            {
                            }
                            finally
                            {
                                frame.Dispose();
                                _isDetecting.Set(false);
                            }
                        }, token);
                    }
                }
                catch
                {
                }
            }

            return Task.CompletedTask;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void Detect(Bitmap frame)
        {
            if(frame == null)                
                return;
            


            Bitmap bitmap = TGMTimage.FastClone(frame);

            Predicted predicted = EngineMgr.GetInstance().Detect(bitmap);
            //if(predicted.boxes.Count() > 0)
            //{
            //    bitmap.Save("input\\" + DateTime.Now.ToString("hh-mm-ss.fff") + ".jpg");
            //}

            int numObject = 0;

            if(predicted.boxes != null && predicted.boxes != null)
            {
                numObject = predicted.boxes.Count;
            }

            List<ListViewItem> items = new List<ListViewItem>();

            int index = 1;
            for(int i = 0; i < numObject; i++)
            {
                Box box = predicted.boxes[i];

                ListViewItem item = new ListViewItem(index.ToString());
                item.SubItems.Add(box.classID.ToString());
                item.SubItems.Add(box.className);
                item.SubItems.Add(box.score.ToString("0.00"));

                items.Add(item);
                index++;
            }

            Util.DrawObject(frame, predicted.boxes);

            try
            {
                this.Invoke(new Action(() => {
                    circle0.Next();
                    //lbl_count.Text = frameIndex.ToString() + "/" + m_totalFrame.ToString();

                    //pictureBox1.Image = frame;


                    listView1.Items.Clear();
                    listView1.Items.AddRange(items.ToArray());
                }));
            }
            catch(Exception ex)
            {
            }
        }
    }
}
