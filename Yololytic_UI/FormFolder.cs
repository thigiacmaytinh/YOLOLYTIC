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


namespace Yololytic
{
    public partial class FormFolder : Form
    {
        static FormFolder _instance;
        bool _inited = false;

        List<string> _filePaths = new List<string>();
        List<Predicted> _results = new List<Predicted>();

        Stopwatch _watch = new Stopwatch();


        string _inputDir = "";
        string _outputDir = "";
        bool _enableOutput = false;
        string _imagePath = "";

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

        private void FormFolder_EnabledChanged(object sender, EventArgs e)
        {
            OnFormSelected(this.Enabled);
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
            }
            else
            {
                txt_outputFolder.Enabled = false;
                _enableOutput = false;
            }

            TGMTregistry.GetInstance().SaveValue("enableOutput", chk_outputFolder.Checked);
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
            if(e.Result == null)
            {
                FormMain.GetInstance().PrintError("Input folder not found");
                return;
            }
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

        private void btn_detect_Click(object sender, EventArgs e)
        {
            if(btn_detect.Text == "Start")
            {
                if(workerDetect.IsBusy)
                    return;

                btn_detect.Text = "Stop";

                _watch.Start();
                _results.Clear();



                if (chk_outputFolder.Checked && txt_outputFolder.Text != "")
                {
                    Directory.CreateDirectory(txt_outputFolder.Text);
                }

                workerDetect.RunWorkerAsync();
                circle1.Visible = true;
                listView1.Enabled = false;
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

        private void workerDetect_DoWork(object sender, DoWorkEventArgs e)
        {
            bool draw = rd_draw.Checked;
            int imageCount = _filePaths.Count;

            Predicted[] orderedResults = new Predicted[imageCount];
            int[] totalByIndex = new int[imageCount];
            long[] elapsedByIndex = new long[imageCount];
            bool[] completed = new bool[imageCount];

            int nextDisplayIndex = 0;
            int canceled = 0;
            int nextWorkIndex = -1;

            object displayLock = new object();

            int workerCount = Math.Max(1, EngineMgr.GetInstance().MaxReader);
            Task[] workers = new Task[workerCount];

            for(int w = 0; w < workerCount; w++)
            {
                workers[w] = Task.Run(() =>
                {
                    while(true)
                    {
                        if(workerDetect.CancellationPending)
                        {
                            Interlocked.Exchange(ref canceled, 1);
                            return;
                        }

                        int i = Interlocked.Increment(ref nextWorkIndex);
                        if(i >= imageCount)
                            return;

                        string inputPathAbs = Path.Combine(_inputDir, _filePaths[i]);
                        string outputPathAbs = Path.Combine(_outputDir, Path.GetFileNameWithoutExtension(_filePaths[i]) + ".jpg");

                        Predicted result = EngineMgr.GetInstance().Detect(inputPathAbs);
                        if(result == null)
                            result = new Predicted();

                        Predicted filteredResult = new Predicted();
                        filteredResult.elapsedMilisecond = result.elapsedMilisecond;
                        filteredResult.bitmap = result.bitmap;

                        if(result.boxes != null)
                        {
                            for(int j = 0; j < result.boxes.Count; j++)
                            {
                                Box box = result.boxes[j];
                                if(Program.minScoreEnabled && box.score < Program.minScore)
                                    continue;
                                if(Program.selectClass && !Program.classSelecteds.Contains(box.classID))
                                    continue;

                                filteredResult.boxes.Add(box);
                            }
                        }

                        orderedResults[i] = filteredResult;

                        if(_enableOutput)
                        {
                            if(draw)
                            {
                                if(filteredResult.bitmap != null)
                                    filteredResult.bitmap.Save(outputPathAbs, ImageFormat.Jpeg);
                            }
                            else
                            {
                                using(Bitmap bmp = new Bitmap(inputPathAbs))
                                {
                                    List<string> content = new List<string>();
                                    for(int j = 0; j < filteredResult.boxes.Count; j++)
                                    {
                                        content.Add(GenRow(bmp.Width, bmp.Height, filteredResult.boxes[j]));
                                    }

                                    bmp.Save(outputPathAbs, ImageFormat.Jpeg);

                                    string labelPath = Path.Combine(_outputDir, Path.GetFileNameWithoutExtension(_filePaths[i]) + ".txt");
                                    File.WriteAllLines(labelPath, content.ToArray());
                                }
                            }
                        }

                        totalByIndex[i] = (filteredResult.boxes == null) ? 0 : filteredResult.boxes.Count;
                        elapsedByIndex[i] = filteredResult.elapsedMilisecond;

                        List<int> readyToDisplay = null;

                        lock(displayLock)
                        {
                            completed[i] = true;

                            if(i == nextDisplayIndex)
                            {
                                readyToDisplay = new List<int>();
                                while(nextDisplayIndex < imageCount && completed[nextDisplayIndex])
                                {
                                    readyToDisplay.Add(nextDisplayIndex);
                                    nextDisplayIndex++;
                                }
                            }
                        }

                        if(readyToDisplay != null && readyToDisplay.Count > 0)
                        {
                            BeginInvoke(new Action(() =>
                            {
                                for(int k = 0; k < readyToDisplay.Count; k++)
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

            if(canceled == 1)
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
            {
                listView2.Items.Clear();
                return;
            }

            listView2.Items.Clear();

            int selectedIndex = listView1.SelectedIndices[0];

            _imagePath = _inputDir + _filePaths[selectedIndex];

            Bitmap bmp = TGMTimage.LoadBitmapWithoutLock(_imagePath);
            if (_results.Count <= selectedIndex)
            {
                pictureBox1.Image = bmp;
                return;
            }               

            
            Predicted predicted = _results[selectedIndex];
            Util.DrawObject(bmp, predicted.boxes, selectedIndex);
            pictureBox1.Image = bmp;

            List <ListViewItem> items = new List<ListViewItem>();

            for (int i = 0; i < predicted.boxes.Count; i++)
            {
                Box box = predicted.boxes[i];
                ListViewItem item = new ListViewItem((i + 1).ToString());
                item.SubItems.Add(box.classID.ToString());
                item.SubItems.Add(box.className);
                item.SubItems.Add(box.score.ToString());
                items.Add(item);
            }
            this.Invoke(new Action(() =>
            {
                listView2.Items.AddRange(items.ToArray());
            }));
            
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listView1.SelectedIndices.Count == 0)
                return;

            int selectedIndex = listView1.SelectedIndices[0];
            _imagePath = _inputDir + _filePaths[selectedIndex];
            Process.Start(_imagePath);
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedIndices.Count == 0)
                return;

            int selectedIndex = listView2.SelectedIndices[0];

            if (listView1.SelectedIndices.Count == 0)
                return;

            int imageIndex = listView1.SelectedIndices[0];

            if (_results.Count <= imageIndex)
                return;

            Predicted predicted = _results[imageIndex];
            Box box = predicted.boxes[selectedIndex];
            string inputPathAbs = _inputDir + _filePaths[imageIndex];
            Bitmap bmp = TGMTimage.LoadBitmapWithoutLock(inputPathAbs);
            Util.DrawObject(bmp, predicted.boxes, selectedIndex);
            pictureBox1.Image = bmp;
        }

        ///////////////////////////////////////////////////////////////////////////////////////////////

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

        private void btn_openFolder_Click(object sender, EventArgs e)
        {
            if(_imagePath == "")
                return;

            System.Diagnostics.Process.Start("explorer.exe", "/select,\"" + _imagePath + "\"");
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

        private void btn_copyImgPath_Click(object sender, EventArgs e)
        {
            if (_imagePath != "")
            {
                Clipboard.SetText(_imagePath);
                FormMain.GetInstance().PrintSuccess("Image path copied to clipboard");
            }
        }


    }
}
