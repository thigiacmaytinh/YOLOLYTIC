using TGMTcontrols;

namespace YoloSegment
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk_drawContour = new System.Windows.Forms.CheckBox();
            this.txt_minScore = new TGMTcontrols.RoundedTextBox();
            this.txt_weightPath = new TGMTcontrols.BrowseFile();
            this.chk_minScore = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_numEngine = new TGMTcontrols.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_inputHeight = new TGMTcontrols.RoundedTextBox();
            this.txt_classesPath = new TGMTcontrols.BrowseFile();
            this.txt_inputWidth = new TGMTcontrols.RoundedTextBox();
            this.btn_loadModel = new TGMTcontrols.DefaultButton();
            this.btn_recentClass = new TGMTcontrols.DefaultButton();
            this.circle1 = new TGMTcontrols.ProcessingControl();
            this.btn_recentWeight = new TGMTcontrols.DefaultButton();
            this.chk_drawRect = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.chk_drawText = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cb_class = new TGMTcontrols.Controls.SelectBox();
            this.label6 = new System.Windows.Forms.Label();
            this.chk_selectClass = new System.Windows.Forms.CheckBox();
            this.wokerLoading = new System.ComponentModel.BackgroundWorker();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.tabPage6 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.progressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.lblMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_CPU = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_RAM = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_CUDA = new System.Windows.Forms.ToolStripStatusLabel();
            this.lbl_VRAM = new System.Windows.Forms.ToolStripStatusLabel();
            this.timerResource = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(9)))), ((int)(((byte)(103)))), ((int)(((byte)(161)))));
            this.panel1.Controls.Add(this.chk_drawContour);
            this.panel1.Controls.Add(this.txt_minScore);
            this.panel1.Controls.Add(this.txt_weightPath);
            this.panel1.Controls.Add(this.chk_minScore);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txt_numEngine);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_inputHeight);
            this.panel1.Controls.Add(this.txt_classesPath);
            this.panel1.Controls.Add(this.txt_inputWidth);
            this.panel1.Controls.Add(this.btn_loadModel);
            this.panel1.Controls.Add(this.btn_recentClass);
            this.panel1.Controls.Add(this.circle1);
            this.panel1.Controls.Add(this.btn_recentWeight);
            this.panel1.Controls.Add(this.chk_drawRect);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.chk_drawText);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.cb_class);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.chk_selectClass);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1041, 169);
            this.panel1.TabIndex = 1;
            // 
            // chk_drawContour
            // 
            this.chk_drawContour.AutoSize = true;
            this.chk_drawContour.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chk_drawContour.ForeColor = System.Drawing.Color.White;
            this.chk_drawContour.Location = new System.Drawing.Point(299, 131);
            this.chk_drawContour.Name = "chk_drawContour";
            this.chk_drawContour.Size = new System.Drawing.Size(118, 24);
            this.chk_drawContour.TabIndex = 83;
            this.chk_drawContour.Text = "Draw contour";
            this.chk_drawContour.UseVisualStyleBackColor = true;
            this.chk_drawContour.CheckedChanged += new System.EventHandler(this.chk_drawContour_CheckedChanged);
            // 
            // txt_minScore
            // 
            this.txt_minScore.BackColor = System.Drawing.Color.Transparent;
            this.txt_minScore.BackgroundColor = System.Drawing.Color.White;
            this.txt_minScore.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            // 
            // 
            // 
            this.txt_minScore.Button.Active1 = System.Drawing.Color.DodgerBlue;
            this.txt_minScore.Button.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.txt_minScore.Button.BackColor = System.Drawing.Color.Transparent;
            this.txt_minScore.Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.txt_minScore.Button.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txt_minScore.Button.ForeColor = System.Drawing.Color.White;
            this.txt_minScore.Button.Icon = null;
            this.txt_minScore.Button.ImageLocation = new System.Drawing.Point(0, 0);
            this.txt_minScore.Button.ImageSize = new System.Drawing.Size(22, 22);
            this.txt_minScore.Button.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.txt_minScore.Button.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.txt_minScore.Button.Location = new System.Drawing.Point(0, 0);
            this.txt_minScore.Button.Name = "";
            this.txt_minScore.Button.Radius = 0;
            this.txt_minScore.Button.Size = new System.Drawing.Size(110, 30);
            this.txt_minScore.Button.Stroke = 0;
            this.txt_minScore.Button.StrokeColor = System.Drawing.Color.Gray;
            this.txt_minScore.Button.TabIndex = 1;
            this.txt_minScore.Button.TabStop = false;
            this.txt_minScore.Button.Transparency = false;
            this.txt_minScore.Button.Visible = false;
            this.txt_minScore.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_minScore.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_minScore.Location = new System.Drawing.Point(560, 125);
            this.txt_minScore.Multiline = false;
            this.txt_minScore.Name = "txt_minScore";
            this.txt_minScore.NumberOnly = true;
            this.txt_minScore.Padding = new System.Windows.Forms.Padding(5);
            this.txt_minScore.Radius = 4;
            this.txt_minScore.Size = new System.Drawing.Size(50, 30);
            this.txt_minScore.TabIndex = 82;
            this.txt_minScore.TabStop = false;
            this.txt_minScore.Text = "0.5";
            this.txt_minScore.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_minScore.TextChanged += new System.EventHandler(this.txt_minScore_TextChanged);
            // 
            // txt_weightPath
            // 
            this.txt_weightPath.BackColor = System.Drawing.Color.Transparent;
            this.txt_weightPath.BackgroundColor = System.Drawing.Color.White;
            this.txt_weightPath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.txt_weightPath.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_weightPath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_weightPath.Location = new System.Drawing.Point(149, 17);
            this.txt_weightPath.Name = "txt_weightPath";
            this.txt_weightPath.Padding = new System.Windows.Forms.Padding(5);
            this.txt_weightPath.Pattern = "";
            this.txt_weightPath.Size = new System.Drawing.Size(563, 30);
            this.txt_weightPath.TabIndex = 65;
            this.txt_weightPath.TextChanged += new System.EventHandler(this.txt_weightPath_TextChanged);
            // 
            // chk_minScore
            // 
            this.chk_minScore.AutoSize = true;
            this.chk_minScore.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chk_minScore.ForeColor = System.Drawing.Color.White;
            this.chk_minScore.Location = new System.Drawing.Point(465, 130);
            this.chk_minScore.Name = "chk_minScore";
            this.chk_minScore.Size = new System.Drawing.Size(92, 24);
            this.chk_minScore.TabIndex = 81;
            this.chk_minScore.Text = "Min score";
            this.chk_minScore.UseVisualStyleBackColor = true;
            this.chk_minScore.CheckedChanged += new System.EventHandler(this.chk_minScore_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(58, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 20);
            this.label1.TabIndex = 63;
            this.label1.Text = "Weight path";
            // 
            // txt_numEngine
            // 
            this.txt_numEngine.BackColor = System.Drawing.Color.Transparent;
            this.txt_numEngine.BackgroundColor = System.Drawing.Color.White;
            this.txt_numEngine.BorderColor = System.Drawing.Color.White;
            this.txt_numEngine.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_numEngine.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_numEngine.Location = new System.Drawing.Point(475, 88);
            this.txt_numEngine.Name = "txt_numEngine";
            this.txt_numEngine.Padding = new System.Windows.Forms.Padding(5);
            this.txt_numEngine.Radius = 4;
            this.txt_numEngine.Size = new System.Drawing.Size(135, 30);
            this.txt_numEngine.TabIndex = 80;
            this.txt_numEngine.TabStop = false;
            this.txt_numEngine.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_numEngine.Value = 1D;
            this.txt_numEngine.ValueChanged += new System.EventHandler(this.txt_numEngine_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(58, 60);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 64;
            this.label2.Text = "Classes path";
            // 
            // txt_inputHeight
            // 
            this.txt_inputHeight.BackColor = System.Drawing.Color.Transparent;
            this.txt_inputHeight.BackgroundColor = System.Drawing.Color.White;
            this.txt_inputHeight.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            // 
            // 
            // 
            this.txt_inputHeight.Button.Active1 = System.Drawing.Color.DodgerBlue;
            this.txt_inputHeight.Button.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.txt_inputHeight.Button.BackColor = System.Drawing.Color.Transparent;
            this.txt_inputHeight.Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.txt_inputHeight.Button.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txt_inputHeight.Button.ForeColor = System.Drawing.Color.White;
            this.txt_inputHeight.Button.Icon = null;
            this.txt_inputHeight.Button.ImageLocation = new System.Drawing.Point(0, 0);
            this.txt_inputHeight.Button.ImageSize = new System.Drawing.Size(22, 22);
            this.txt_inputHeight.Button.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.txt_inputHeight.Button.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.txt_inputHeight.Button.Location = new System.Drawing.Point(0, 0);
            this.txt_inputHeight.Button.Name = "";
            this.txt_inputHeight.Button.Radius = 0;
            this.txt_inputHeight.Button.Size = new System.Drawing.Size(110, 30);
            this.txt_inputHeight.Button.Stroke = 0;
            this.txt_inputHeight.Button.StrokeColor = System.Drawing.Color.Gray;
            this.txt_inputHeight.Button.TabIndex = 1;
            this.txt_inputHeight.Button.TabStop = false;
            this.txt_inputHeight.Button.Transparency = false;
            this.txt_inputHeight.Button.Visible = false;
            this.txt_inputHeight.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_inputHeight.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_inputHeight.Location = new System.Drawing.Point(299, 88);
            this.txt_inputHeight.Multiline = false;
            this.txt_inputHeight.Name = "txt_inputHeight";
            this.txt_inputHeight.NumberOnly = true;
            this.txt_inputHeight.Padding = new System.Windows.Forms.Padding(5);
            this.txt_inputHeight.Radius = 4;
            this.txt_inputHeight.Size = new System.Drawing.Size(70, 30);
            this.txt_inputHeight.TabIndex = 79;
            this.txt_inputHeight.TabStop = false;
            this.txt_inputHeight.Text = "640";
            this.txt_inputHeight.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txt_classesPath
            // 
            this.txt_classesPath.BackColor = System.Drawing.Color.Transparent;
            this.txt_classesPath.BackgroundColor = System.Drawing.Color.White;
            this.txt_classesPath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.txt_classesPath.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_classesPath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_classesPath.Location = new System.Drawing.Point(149, 52);
            this.txt_classesPath.Name = "txt_classesPath";
            this.txt_classesPath.Padding = new System.Windows.Forms.Padding(5);
            this.txt_classesPath.Pattern = "";
            this.txt_classesPath.Size = new System.Drawing.Size(563, 30);
            this.txt_classesPath.TabIndex = 66;
            this.txt_classesPath.TextChanged += new System.EventHandler(this.txt_classesPath_TextChanged);
            // 
            // txt_inputWidth
            // 
            this.txt_inputWidth.BackColor = System.Drawing.Color.Transparent;
            this.txt_inputWidth.BackgroundColor = System.Drawing.Color.White;
            this.txt_inputWidth.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            // 
            // 
            // 
            this.txt_inputWidth.Button.Active1 = System.Drawing.Color.DodgerBlue;
            this.txt_inputWidth.Button.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.txt_inputWidth.Button.BackColor = System.Drawing.Color.Transparent;
            this.txt_inputWidth.Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.txt_inputWidth.Button.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txt_inputWidth.Button.ForeColor = System.Drawing.Color.White;
            this.txt_inputWidth.Button.Icon = null;
            this.txt_inputWidth.Button.ImageLocation = new System.Drawing.Point(0, 0);
            this.txt_inputWidth.Button.ImageSize = new System.Drawing.Size(22, 22);
            this.txt_inputWidth.Button.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.txt_inputWidth.Button.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.txt_inputWidth.Button.Location = new System.Drawing.Point(0, 0);
            this.txt_inputWidth.Button.Name = "";
            this.txt_inputWidth.Button.Radius = 0;
            this.txt_inputWidth.Button.Size = new System.Drawing.Size(110, 30);
            this.txt_inputWidth.Button.Stroke = 0;
            this.txt_inputWidth.Button.StrokeColor = System.Drawing.Color.Gray;
            this.txt_inputWidth.Button.TabIndex = 1;
            this.txt_inputWidth.Button.TabStop = false;
            this.txt_inputWidth.Button.Transparency = false;
            this.txt_inputWidth.Button.Visible = false;
            this.txt_inputWidth.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_inputWidth.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_inputWidth.Location = new System.Drawing.Point(149, 88);
            this.txt_inputWidth.Multiline = false;
            this.txt_inputWidth.Name = "txt_inputWidth";
            this.txt_inputWidth.NumberOnly = true;
            this.txt_inputWidth.Padding = new System.Windows.Forms.Padding(5);
            this.txt_inputWidth.Radius = 4;
            this.txt_inputWidth.Size = new System.Drawing.Size(70, 30);
            this.txt_inputWidth.TabIndex = 78;
            this.txt_inputWidth.TabStop = false;
            this.txt_inputWidth.Text = "640";
            this.txt_inputWidth.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btn_loadModel
            // 
            this.btn_loadModel.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btn_loadModel.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btn_loadModel.BackColor = System.Drawing.Color.Transparent;
            this.btn_loadModel.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_loadModel.Enabled = false;
            this.btn_loadModel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_loadModel.ForeColor = System.Drawing.Color.White;
            this.btn_loadModel.Icon = null;
            this.btn_loadModel.ImageLocation = new System.Drawing.Point(0, 0);
            this.btn_loadModel.ImageSize = new System.Drawing.Size(0, 0);
            this.btn_loadModel.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.btn_loadModel.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btn_loadModel.Location = new System.Drawing.Point(768, 11);
            this.btn_loadModel.Name = "btn_loadModel";
            this.btn_loadModel.Radius = 6;
            this.btn_loadModel.Size = new System.Drawing.Size(137, 38);
            this.btn_loadModel.Stroke = 0;
            this.btn_loadModel.StrokeColor = System.Drawing.Color.Gray;
            this.btn_loadModel.TabIndex = 67;
            this.btn_loadModel.Text = "Load model";
            this.btn_loadModel.Transparency = false;
            this.btn_loadModel.Click += new System.EventHandler(this.btn_loadModel_Click);
            // 
            // btn_recentClass
            // 
            this.btn_recentClass.Active1 = System.Drawing.Color.DodgerBlue;
            this.btn_recentClass.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.btn_recentClass.BackColor = System.Drawing.Color.Transparent;
            this.btn_recentClass.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_recentClass.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btn_recentClass.ForeColor = System.Drawing.Color.White;
            this.btn_recentClass.Icon = global::YoloSegment.Properties.Resources.history_32;
            this.btn_recentClass.ImageLocation = new System.Drawing.Point(0, 0);
            this.btn_recentClass.ImageSize = new System.Drawing.Size(22, 22);
            this.btn_recentClass.Inactive1 = System.Drawing.Color.Empty;
            this.btn_recentClass.Inactive2 = System.Drawing.Color.Empty;
            this.btn_recentClass.Location = new System.Drawing.Point(718, 52);
            this.btn_recentClass.Name = "btn_recentClass";
            this.btn_recentClass.Radius = 6;
            this.btn_recentClass.Size = new System.Drawing.Size(30, 30);
            this.btn_recentClass.Stroke = 0;
            this.btn_recentClass.StrokeColor = System.Drawing.Color.Gray;
            this.btn_recentClass.TabIndex = 77;
            this.btn_recentClass.Transparency = false;
            this.btn_recentClass.Click += new System.EventHandler(this.btn_recentClass_Click);
            // 
            // circle1
            // 
            this.circle1.BackColor = System.Drawing.Color.Transparent;
            this.circle1.IndexColor = System.Drawing.Color.Turquoise;
            this.circle1.Interval = 50;
            this.circle1.Location = new System.Drawing.Point(907, 12);
            this.circle1.Name = "circle1";
            this.circle1.NCircle = 8;
            this.circle1.Others = System.Drawing.Color.LightGray;
            this.circle1.Radius = 4;
            this.circle1.Size = new System.Drawing.Size(39, 34);
            this.circle1.TabIndex = 68;
            this.circle1.Text = "processingControl1";
            this.circle1.Visible = false;
            // 
            // btn_recentWeight
            // 
            this.btn_recentWeight.Active1 = System.Drawing.Color.DodgerBlue;
            this.btn_recentWeight.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.btn_recentWeight.BackColor = System.Drawing.Color.Transparent;
            this.btn_recentWeight.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_recentWeight.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btn_recentWeight.ForeColor = System.Drawing.Color.White;
            this.btn_recentWeight.Icon = global::YoloSegment.Properties.Resources.history_32;
            this.btn_recentWeight.ImageLocation = new System.Drawing.Point(0, 0);
            this.btn_recentWeight.ImageSize = new System.Drawing.Size(22, 22);
            this.btn_recentWeight.Inactive1 = System.Drawing.Color.Empty;
            this.btn_recentWeight.Inactive2 = System.Drawing.Color.Empty;
            this.btn_recentWeight.Location = new System.Drawing.Point(718, 17);
            this.btn_recentWeight.Name = "btn_recentWeight";
            this.btn_recentWeight.Radius = 6;
            this.btn_recentWeight.Size = new System.Drawing.Size(30, 30);
            this.btn_recentWeight.Stroke = 0;
            this.btn_recentWeight.StrokeColor = System.Drawing.Color.Gray;
            this.btn_recentWeight.TabIndex = 76;
            this.btn_recentWeight.Transparency = false;
            this.btn_recentWeight.Click += new System.EventHandler(this.btn_recentWeight_Click);
            // 
            // chk_drawRect
            // 
            this.chk_drawRect.AutoSize = true;
            this.chk_drawRect.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chk_drawRect.ForeColor = System.Drawing.Color.White;
            this.chk_drawRect.Location = new System.Drawing.Point(52, 131);
            this.chk_drawRect.Name = "chk_drawRect";
            this.chk_drawRect.Size = new System.Drawing.Size(129, 24);
            this.chk_drawRect.TabIndex = 69;
            this.chk_drawRect.Text = "Draw rectangle";
            this.chk_drawRect.UseVisualStyleBackColor = true;
            this.chk_drawRect.CheckedChanged += new System.EventHandler(this.chk_drawRect_CheckedChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(238, 94);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(54, 20);
            this.label10.TabIndex = 75;
            this.label10.Text = "Height";
            // 
            // chk_drawText
            // 
            this.chk_drawText.AutoSize = true;
            this.chk_drawText.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.chk_drawText.ForeColor = System.Drawing.Color.White;
            this.chk_drawText.Location = new System.Drawing.Point(200, 131);
            this.chk_drawText.Name = "chk_drawText";
            this.chk_drawText.Size = new System.Drawing.Size(92, 24);
            this.chk_drawText.TabIndex = 70;
            this.chk_drawText.Text = "Draw text";
            this.chk_drawText.UseVisualStyleBackColor = true;
            this.chk_drawText.CheckedChanged += new System.EventHandler(this.chk_drawText_CheckedChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(49, 94);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(93, 20);
            this.label7.TabIndex = 74;
            this.label7.Text = "Model width";
            // 
            // cb_class
            // 
            this.cb_class.BackColor = System.Drawing.Color.Transparent;
            this.cb_class.BackgroundColor = System.Drawing.Color.White;
            this.cb_class.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.cb_class.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.cb_class.ForeColor = System.Drawing.SystemColors.WindowText;
            this.cb_class.Location = new System.Drawing.Point(692, 126);
            this.cb_class.MultiSelect = true;
            this.cb_class.Name = "cb_class";
            this.cb_class.Padding = new System.Windows.Forms.Padding(5);
            this.cb_class.SelectedIndices = ((System.Collections.Generic.List<int>)(resources.GetObject("cb_class.SelectedIndices")));
            this.cb_class.Size = new System.Drawing.Size(135, 29);
            this.cb_class.TabIndex = 71;
            this.cb_class.Text = "Class";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(378, 92);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 20);
            this.label6.TabIndex = 73;
            this.label6.Text = "Num engine";
            // 
            // chk_selectClass
            // 
            this.chk_selectClass.AutoSize = true;
            this.chk_selectClass.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chk_selectClass.ForeColor = System.Drawing.Color.White;
            this.chk_selectClass.Location = new System.Drawing.Point(633, 131);
            this.chk_selectClass.Name = "chk_selectClass";
            this.chk_selectClass.Size = new System.Drawing.Size(57, 23);
            this.chk_selectClass.TabIndex = 72;
            this.chk_selectClass.Text = "Only";
            this.chk_selectClass.UseVisualStyleBackColor = true;
            // 
            // wokerLoading
            // 
            this.wokerLoading.DoWork += new System.ComponentModel.DoWorkEventHandler(this.worker_loadModel_DoWork);
            this.wokerLoading.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.worker_loadModel_RunWorkerCompleted);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage6);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.tabControl1.Location = new System.Drawing.Point(0, 169);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1041, 477);
            this.tabControl1.TabIndex = 18;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.tabPage1.Location = new System.Drawing.Point(4, 26);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1033, 447);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Image";
            // 
            // tabPage2
            // 
            this.tabPage2.Location = new System.Drawing.Point(4, 26);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(1033, 447);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Folder";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 26);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(1033, 447);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Webcam";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tabPage4
            // 
            this.tabPage4.Location = new System.Drawing.Point(4, 26);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(1033, 447);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Camera";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.tabPage5.Location = new System.Drawing.Point(4, 26);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(1033, 447);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Video";
            // 
            // tabPage6
            // 
            this.tabPage6.Location = new System.Drawing.Point(4, 26);
            this.tabPage6.Name = "tabPage6";
            this.tabPage6.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage6.Size = new System.Drawing.Size(1033, 447);
            this.tabPage6.TabIndex = 5;
            this.tabPage6.Text = "Extract video";
            this.tabPage6.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.statusStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.progressBar1,
            this.lblMessage,
            this.lbl_CPU,
            this.lbl_RAM,
            this.lbl_CUDA,
            this.lbl_VRAM});
            this.statusStrip1.Location = new System.Drawing.Point(0, 646);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1041, 30);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 36;
            this.statusStrip1.Text = "statusStrip2";
            // 
            // progressBar1
            // 
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(100, 24);
            // 
            // lblMessage
            // 
            this.lblMessage.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.lblMessage.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMessage.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(616, 25);
            this.lblMessage.Spring = true;
            this.lblMessage.Text = "Status";
            this.lblMessage.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_CPU
            // 
            this.lbl_CPU.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CPU.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lbl_CPU.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.lbl_CPU.Name = "lbl_CPU";
            this.lbl_CPU.Size = new System.Drawing.Size(75, 25);
            this.lbl_CPU.Text = "CPU: 0%  |";
            // 
            // lbl_RAM
            // 
            this.lbl_RAM.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_RAM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lbl_RAM.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.lbl_RAM.Name = "lbl_RAM";
            this.lbl_RAM.Size = new System.Drawing.Size(68, 25);
            this.lbl_RAM.Text = "RAM: 0  |";
            // 
            // lbl_CUDA
            // 
            this.lbl_CUDA.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_CUDA.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lbl_CUDA.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.lbl_CUDA.Name = "lbl_CUDA";
            this.lbl_CUDA.Size = new System.Drawing.Size(88, 25);
            this.lbl_CUDA.Text = "CUDA: 0%  |";
            // 
            // lbl_VRAM
            // 
            this.lbl_VRAM.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_VRAM.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lbl_VRAM.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(255)))));
            this.lbl_VRAM.Name = "lbl_VRAM";
            this.lbl_VRAM.Size = new System.Drawing.Size(77, 25);
            this.lbl_VRAM.Text = "VRAM: 0%";
            // 
            // timerResource
            // 
            this.timerResource.Interval = 1000;
            this.timerResource.Tick += new System.EventHandler(this.timerResource_Tick);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1041, 676);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FormMain";
            this.Text = "Yolosegment -";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.LocationChanged += new System.EventHandler(this.FormMain_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.FormMain_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker wokerLoading;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.TabPage tabPage6;
        private RoundedTextBox txt_minScore;
        public BrowseFile txt_weightPath;
        private System.Windows.Forms.CheckBox chk_minScore;
        private System.Windows.Forms.Label label1;
        private NumericUpDown txt_numEngine;
        private System.Windows.Forms.Label label2;
        private RoundedTextBox txt_inputHeight;
        public BrowseFile txt_classesPath;
        private RoundedTextBox txt_inputWidth;
        private DefaultButton btn_loadModel;
        private DefaultButton btn_recentClass;
        private ProcessingControl circle1;
        private DefaultButton btn_recentWeight;
        private System.Windows.Forms.CheckBox chk_drawRect;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.CheckBox chk_drawText;
        private System.Windows.Forms.Label label7;
        private TGMTcontrols.Controls.SelectBox cb_class;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox chk_selectClass;
        private System.Windows.Forms.CheckBox chk_drawContour;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar progressBar1;
        private System.Windows.Forms.ToolStripStatusLabel lblMessage;
        private System.Windows.Forms.ToolStripStatusLabel lbl_CPU;
        private System.Windows.Forms.ToolStripStatusLabel lbl_RAM;
        private System.Windows.Forms.ToolStripStatusLabel lbl_CUDA;
        private System.Windows.Forms.ToolStripStatusLabel lbl_VRAM;
        private System.Windows.Forms.Timer timerResource;
    }
}

