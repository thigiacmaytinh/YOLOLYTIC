using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TGMT;
using TGMTcontrols;
using TGMTcs;

namespace Yololytic
{
    public partial class FormMain : BaseForm
    {
        static FormMain m_instance;
        bool _inited = false;
        string _classPath = "";

        PerformanceCounter _cpuCounter;

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public FormMain()
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        
        public static FormMain GetInstance()
        {
            if (m_instance == null)
                m_instance = new FormMain();
            return m_instance;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormMain_Load(object sender, EventArgs e)
        {
            Application.DoEvents(); // Force UI refresh

            tabControl1.SelectedIndex = -1;
            tabControl1.Enabled = false;

#if HAVE_CUDA
            this.Text += " [CUDA]";
#endif
            this.Text += " " + TGMTutil.GetVersion();
#if DEBUG
            this.Text += " *";
#endif            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////
        
        private void FormMain_Shown(object sender, EventArgs e)
        {
            txt_weightPath.Pattern = "ONXX file|*.onnx";
            txt_classesPath.Pattern = "Classes file|*.names";


            txt_weightPath.Text = TGMTregistry.GetInstance().ReadString("txt_weightPath");
            txt_classesPath.Text = TGMTregistry.GetInstance().ReadString("txt_classesPath");

            Program.selectClass = TGMTregistry.GetInstance().ReadBool("selectClass", Program.selectClass);
            chk_selectClass.Checked = Program.selectClass;
            cb_class.Enabled = Program.selectClass;

            Program.inputWidth = TGMTregistry.GetInstance().ReadInt("txt_inputWidth", 640);
            txt_inputWidth.Text = Program.inputWidth.ToString();

            Program.inputHeight = TGMTregistry.GetInstance().ReadInt("txt_inputHeight", 640);
            txt_inputHeight.Text = Program.inputHeight.ToString();

            Program.minScoreEnabled = TGMTregistry.GetInstance().ReadBool("chk_minScore", Program.minScoreEnabled);
            chk_minScore.Checked = txt_minScore.Enabled = Program.minScoreEnabled;
            Program.minScore = TGMTregistry.GetInstance().ReadFloat("txt_minScore", Program.minScore);
            txt_minScore.Text = Program.minScore.ToString();

            chk_drawRect.Checked = TGMTregistry.GetInstance().ReadBool("chk_drawRect");
            chk_drawText.Checked = TGMTregistry.GetInstance().ReadBool("chk_drawText");
            txt_numEngine.Value = TGMTregistry.GetInstance().ReadInt("txt_numEngine", 1);

            btn_loadModel.Enabled = txt_weightPath.Text != "" && txt_classesPath.Text != "";

            
            tabControl1.SelectedIndex = TGMTregistry.GetInstance().ReadInt("selected_tab_index", 0);

            Task.Run(() =>
            {
                ShowHardwareUsage();
            });
            

            _inited = true;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormImage.GetInstance().Close();
            FormFolder.GetInstance().Close();
            FormWebcam.GetInstance().Close();
            FormCamera.GetInstance().Close();
            FormVideo.GetInstance().Close();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_loadModel_Click(object sender, EventArgs e)
        {
            if(!File.Exists(txt_weightPath.Text))
            {
                PrintError("Weight file does not exist");
                return;
            }

            if (!File.Exists(txt_classesPath.Text))
            {
                PrintError("Classes file does not exist");
                return;
            }

            Program.weightPath = txt_weightPath.Text;
            Program.classesPath = txt_classesPath.Text;
            Program.inputWidth = int.Parse(txt_inputWidth.Text);
            Program.inputHeight = int.Parse(txt_inputHeight.Text);

            btn_loadModel.Enabled = false;
            circle1.Visible = true;
            workerLoading.RunWorkerAsync();
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_weightPath_TextChanged(object sender, EventArgs e)
        {
            if(!_inited || txt_weightPath.Text == "")
                return;

            txt_weightPath.Text = txt_weightPath.Text.Replace("\"", "");
            TGMTregistry.GetInstance().SaveValue("txt_weightPath", txt_weightPath.Text);
            PopupRecent.SaveStream(txt_weightPath.Name, txt_weightPath.Text);
            btn_loadModel.Enabled = txt_weightPath.Text != "" && txt_classesPath.Text != "";            
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_classesPath_TextChanged(object sender, EventArgs e)
        {
            if(!_inited || txt_classesPath.Text == "")
                return;

            txt_classesPath.Text = txt_classesPath.Text.Replace("\"", "");
            if(_classPath != "" && _classPath == txt_classesPath.Text)
            {
                Program.classSelecteds = new List<int>();
                TGMTregistry.GetInstance().SaveValue("classSelecteds", "");
            }

            TGMTregistry.GetInstance().SaveValue("txt_classesPath", txt_classesPath.Text);
            PopupRecent.SaveStream(txt_classesPath.Name, txt_classesPath.Text);
            btn_loadModel.Enabled = txt_weightPath.Text != "" && txt_classesPath.Text != "";
            cb_class.Items.Clear();

            if(File.Exists(txt_classesPath.Text))
            {
                string[] lines = File.ReadAllLines(txt_classesPath.Text);
                Program.classNames = lines.ToList();

                for(int i= 0; i < Program.classNames.Count; i++)
                {
                    Program.classNames[i] = Program.classNames[i].Trim();
                    cb_class.Items.Add(Program.classNames[i]);                    
                }

                if(Program.classNames.Count > 0)
                {
                    string classSelecteds = TGMTregistry.GetInstance().ReadString("classSelecteds");
                    if(classSelecteds != "")
                    {
                        List<string> selectedIndices = new List<string>(classSelecteds.Split(','));
                        Program.classSelecteds = new List<int>();

                        for(int i = 0; i < selectedIndices.Count; i++)
                        {
                            Program.classSelecteds.Add(int.Parse(selectedIndices[i]));
                        }
                        cb_class.SelectedIndices = Program.classSelecteds;
                    }
                    else
                    {
                        cb_class.SelectAll();
                    }
                }
            }

            _classPath = txt_classesPath.Text;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_recentWeight_Click(object sender, EventArgs e)
        {
            PopupRecent popup = new PopupRecent();
            string selected = popup.Choose(txt_weightPath.Name);
            if(selected != "")
            {
                txt_weightPath.Text = selected;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void btn_recentClass_Click(object sender, EventArgs e)
        {
            PopupRecent popup = new PopupRecent();
            string selected = popup.Choose(txt_classesPath.Name);
            if(selected != "")
            {
                txt_classesPath.Text = selected;
            }
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void cb_class_SelectedIndexChanged(object sender, EventArgs e)
        {
            Program.classSelecteds = cb_class.SelectedIndices;
            TGMTregistry.GetInstance().SaveValue("classSelecteds", string.Join(",", Program.classSelecteds));
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_minScore_TextChanged(object sender, EventArgs e)
        {
            if(!_inited)
                return;
            TGMTregistry.GetInstance().SaveValue("txt_minScore", txt_minScore.Text);
            Program.minScore = float.Parse(txt_minScore.Text);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_minScore_CheckedChanged(object sender, EventArgs e)
        {
            if(!_inited) return;
            Program.minScoreEnabled = chk_minScore.Checked;
            txt_minScore.Enabled = Program.minScoreEnabled;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_selectClass_CheckedChanged(object sender, EventArgs e)
        {
            if(!_inited)
                return;

            Program.selectClass = chk_selectClass.Checked;
            cb_class.Enabled = Program.selectClass;
            TGMTregistry.GetInstance().SaveValue("selectClass", Program.selectClass);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_drawRect_CheckedChanged(object sender, EventArgs e)
        {
            //if (Program.detector != null)
            //    Program.detector.DrawRectangle = chk_drawRect.Checked;
            TGMTregistry.GetInstance().SaveValue("chk_drawRect", chk_drawRect.Checked);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void chk_drawText_CheckedChanged(object sender, EventArgs e)
        {
            TGMTregistry.GetInstance().SaveValue("chk_drawText", chk_drawText.Checked);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_numEngine_ValueChanged(object sender, EventArgs e)
        {
            if(!_inited)
                return;
            TGMTregistry.GetInstance().SaveValue("txt_numEngine", txt_numEngine.Value);
            EngineMgr.GetInstance().MaxReader = ((int)txt_numEngine.Value);
        }


        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void workerLoading_DoWork(object sender, DoWorkEventArgs e)
        {
            EngineMgr.GetInstance().Reset();
            EngineMgr.GetInstance().MaxReader = (int)txt_numEngine.Value;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void workerLoading_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            circle1.Visible = false;
            Program.inited = true;
            tabControl1.Enabled = true;
            btn_loadModel.Enabled = true;
            //lbl_cuda.Text = "CUDA: " + (Program.detector.CudaEnabled ? "YES" : "NO");

            if(tabControl1.SelectedIndex == -1)
                tabControl1.SelectedIndex = 0;

            PrintSuccess("Load model success");
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_inputWidth_TextChanged(object sender, EventArgs e)
        {
            if(!_inited)
                return;
            TGMTregistry.GetInstance().SaveValue("txt_inputWidth", txt_inputWidth.Text);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void txt_inputHeight_TextChanged(object sender, EventArgs e)
        {
            if(!_inited)
                return;
            TGMTregistry.GetInstance().SaveValue("txt_inputHeight", txt_inputHeight.Text);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PrintError(string message)
        {
            lblMessage.ForeColor = Color.Red;
            if (message == "")
                lblMessage.Text = "";
            else
                lblMessage.Text = DateTime.Now.ToString("(hh:mm:ss)") + message;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PrintSuccess(string message)
        {
            lblMessage.ForeColor = Color.Green;
            if (message == "")
                lblMessage.Text = "";
            else
                lblMessage.Text = DateTime.Now.ToString("(hh:mm:ss)") + message;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        public void PrintMessage(string message)
        {
            lblMessage.ForeColor = Color.Black;
            if (message == "")
                lblMessage.Text = "";
            else
                lblMessage.Text = DateTime.Now.ToString("(hh:mm:ss)") + message;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void AddFormToTab()
        {

            tabControl1.SelectedIndex = 0;
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(tabControl1.SelectedIndex == -1)
                return;
            if(tabControl1.SelectedIndex == 0)
            {
                if(tabPage1.Controls.Count == 0)
                    tabPage1.Controls.Add(FormImage.GetInstance());
                FormImage.GetInstance().Show();
            }
            else if(tabControl1.SelectedIndex == 1)
            {
                if(tabPage2.Controls.Count == 0)
                    tabPage2.Controls.Add(FormFolder.GetInstance());
                FormFolder.GetInstance().Show();
            }
            else if(tabControl1.SelectedIndex == 2)
            {
                if(tabPage3.Controls.Count == 0)
                    tabPage3.Controls.Add(FormWebcam.GetInstance());
                FormWebcam.GetInstance().Show();
            }
            else if(tabControl1.SelectedIndex == 3)
            {
                if(tabPage4.Controls.Count == 0)
                    tabPage4.Controls.Add(FormCamera.GetInstance());
                FormCamera.GetInstance().Show();
            }
            else if(tabControl1.SelectedIndex == 4)
            {
                if(tabPage5.Controls.Count == 0)
                    tabPage5.Controls.Add(FormVideo.GetInstance());
                FormVideo.GetInstance().Show();
            }
            else if(tabControl1.SelectedIndex == 5)
            {
                if(tabPage6.Controls.Count == 0)
                    tabPage6.Controls.Add(FormExtractVideo.GetInstance());
                FormExtractVideo.GetInstance().Show();
            }


            if(tabPage1.Controls.Count == 1)
                FormImage.GetInstance().OnFormSelected(tabControl1.SelectedIndex == 0);
            if(tabPage2.Controls.Count == 1)
                FormFolder.GetInstance().OnFormSelected(tabControl1.SelectedIndex == 1);
            if(tabPage3.Controls.Count == 1)
                FormWebcam.GetInstance().OnFormSelected(tabControl1.SelectedIndex == 2);
            if(tabPage4.Controls.Count == 1)
                FormCamera.GetInstance().OnFormSelected(tabControl1.SelectedIndex == 3);
            if(tabPage5.Controls.Count == 1)
                FormVideo.GetInstance().OnFormSelected(tabControl1.SelectedIndex == 4);
            if(tabPage6.Controls.Count == 1)
                FormExtractVideo.GetInstance().OnFormSelected(tabControl1.SelectedIndex == 5);


            TGMTregistry.GetInstance().SaveValue("selected_tab_index", tabControl1.SelectedIndex);
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        void ShowHardwareUsage()
        {
            _cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");
            TGMTthread.BeginInvokeSafe(this, () => {
                timerResource.Start();                
            });


#if HAVE_CUDA
            if(TGMTcuda.GetInstance().InitNvml())
            {
                TGMTthread.BeginInvokeSafe(this, () => {
                    lbl_CUDA.Visible = true;
                    lbl_VRAM.Visible = true;
                });
            }
#endif
        }

        ////////////////////////////////////////////////////////////////////////////////////////////////////

        private void timerResource_Tick(object sender, EventArgs e)
        {
            lbl_CPU.Text = "CPU: " + _cpuCounter.NextValue().ToString("F1") + "%  |";

            double usedMB, totalMB, percent;
            TGMThardware.GetMemory(out usedMB, out totalMB, out percent);

            lbl_RAM.Text = $"RAM: {usedMB:N0} / {totalMB:N0} MB ({percent:N0}%)  |";


#if HAVE_CUDA
            string nvmlPath = @"C:\Windows\System32\nvml.dll";
            if(File.Exists(nvmlPath))
            {

                Tuple<int, int, int> usage = TGMTcuda.GetInstance().GetUsage();

                int CUDApercent = usage.Item1;
                int VRAMused = usage.Item2;
                int VRAMtotal = usage.Item3;
                lbl_CUDA.Text = "CUDA: " + CUDApercent + "%  |";


                int percentVRAM = (int)((double)VRAMused / VRAMtotal * 100);
                lbl_VRAM.Text = $"VRAM: {VRAMused:N0}/{VRAMtotal:N0} MB ({percentVRAM}%) ";
            }
#endif
        }
    }
}
