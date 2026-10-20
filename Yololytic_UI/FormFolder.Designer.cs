using TGMTcontrols;

namespace Yololytic
{
    partial class FormFolder
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
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rd_extract = new System.Windows.Forms.RadioButton();
            this.rd_draw = new System.Windows.Forms.RadioButton();
            this.lbl_count = new System.Windows.Forms.Label();
            this.txt_inputWidth = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menu1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btn_openFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_copyImage = new System.Windows.Forms.ToolStripMenuItem();
            this.btn_copyImgPath = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk_outputFolder = new System.Windows.Forms.CheckBox();
            this.txt_outputFolder = new TGMTcontrols.BrowseDir();
            this.txt_inputFolder = new TGMTcontrols.BrowseDir();
            this.circle1 = new TGMTcontrols.ProcessingControl();
            this.btn_detect = new TGMTcontrols.DefaultButton();
            this.workerDetect = new System.ComponentModel.BackgroundWorker();
            this.workerLoadFile = new System.ComponentModel.BackgroundWorker();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputWidth)).BeginInit();
            this.menu1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Count";
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Idx";
            this.columnHeader1.Width = 40;
            // 
            // rd_extract
            // 
            this.rd_extract.AutoSize = true;
            this.rd_extract.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rd_extract.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.rd_extract.Location = new System.Drawing.Point(793, 52);
            this.rd_extract.Name = "rd_extract";
            this.rd_extract.Size = new System.Drawing.Size(140, 21);
            this.rd_extract.TabIndex = 20;
            this.rd_extract.Text = "Extract annotation";
            this.rd_extract.UseVisualStyleBackColor = true;
            this.rd_extract.CheckedChanged += new System.EventHandler(this.rd_extract_CheckedChanged);
            // 
            // rd_draw
            // 
            this.rd_draw.AutoSize = true;
            this.rd_draw.Checked = true;
            this.rd_draw.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rd_draw.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.rd_draw.Location = new System.Drawing.Point(680, 52);
            this.rd_draw.Name = "rd_draw";
            this.rd_draw.Size = new System.Drawing.Size(98, 21);
            this.rd_draw.TabIndex = 19;
            this.rd_draw.TabStop = true;
            this.rd_draw.Text = "Draw frame";
            this.rd_draw.UseVisualStyleBackColor = true;
            this.rd_draw.CheckedChanged += new System.EventHandler(this.rd_draw_CheckedChanged);
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_count.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lbl_count.Location = new System.Drawing.Point(981, 23);
            this.lbl_count.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(47, 19);
            this.lbl_count.TabIndex = 18;
            this.lbl_count.Text = "Count";
            this.lbl_count.Visible = false;
            // 
            // txt_inputWidth
            // 
            this.txt_inputWidth.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_inputWidth.Location = new System.Drawing.Point(915, 21);
            this.txt_inputWidth.Maximum = new decimal(new int[] {
            8,
            0,
            0,
            0});
            this.txt_inputWidth.Name = "txt_inputWidth";
            this.txt_inputWidth.Size = new System.Drawing.Size(52, 25);
            this.txt_inputWidth.TabIndex = 16;
            this.txt_inputWidth.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_inputWidth.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label4.Location = new System.Drawing.Point(827, 24);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Num thread";
            this.label4.Visible = false;
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader8});
            this.listView1.ContextMenuStrip = this.menu1;
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(401, 323);
            this.listView1.TabIndex = 42;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Image path";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Elapsed";
            // 
            // menu1
            // 
            this.menu1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.menu1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menu1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btn_openFolder,
            this.btn_copyImage,
            this.btn_copyImgPath});
            this.menu1.Name = "_ctxtMnu";
            this.menu1.Size = new System.Drawing.Size(170, 82);
            // 
            // btn_openFolder
            // 
            this.btn_openFolder.Image = global::Yololytic.Properties.Resources.folder_open_icon_32;
            this.btn_openFolder.Name = "btn_openFolder";
            this.btn_openFolder.Size = new System.Drawing.Size(169, 26);
            this.btn_openFolder.Text = "Open folder";
            this.btn_openFolder.Click += new System.EventHandler(this.btn_openFolder_Click);
            // 
            // btn_copyImage
            // 
            this.btn_copyImage.Image = global::Yololytic.Properties.Resources.double_select_16;
            this.btn_copyImage.Name = "btn_copyImage";
            this.btn_copyImage.Size = new System.Drawing.Size(169, 26);
            this.btn_copyImage.Text = "Copy image";
            this.btn_copyImage.Click += new System.EventHandler(this.btn_copyImage_Click);
            // 
            // btn_copyImgPath
            // 
            this.btn_copyImgPath.Image = global::Yololytic.Properties.Resources.copy16;
            this.btn_copyImgPath.Name = "btn_copyImgPath";
            this.btn_copyImgPath.Size = new System.Drawing.Size(169, 26);
            this.btn_copyImgPath.Text = "Copy image path";
            this.btn_copyImgPath.Click += new System.EventHandler(this.btn_copyImgPath_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label3.Location = new System.Drawing.Point(24, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Input folder";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.chk_outputFolder);
            this.panel1.Controls.Add(this.txt_outputFolder);
            this.panel1.Controls.Add(this.txt_inputFolder);
            this.panel1.Controls.Add(this.rd_extract);
            this.panel1.Controls.Add(this.rd_draw);
            this.panel1.Controls.Add(this.lbl_count);
            this.panel1.Controls.Add(this.txt_inputWidth);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.circle1);
            this.panel1.Controls.Add(this.btn_detect);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1034, 87);
            this.panel1.TabIndex = 41;
            // 
            // chk_outputFolder
            // 
            this.chk_outputFolder.AutoSize = true;
            this.chk_outputFolder.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_outputFolder.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.chk_outputFolder.Location = new System.Drawing.Point(8, 52);
            this.chk_outputFolder.Name = "chk_outputFolder";
            this.chk_outputFolder.Size = new System.Drawing.Size(106, 21);
            this.chk_outputFolder.TabIndex = 24;
            this.chk_outputFolder.Text = "Output folder";
            this.chk_outputFolder.UseVisualStyleBackColor = true;
            this.chk_outputFolder.CheckedChanged += new System.EventHandler(this.chk_outputFolder_CheckedChanged);
            // 
            // txt_outputFolder
            // 
            this.txt_outputFolder.BackColor = System.Drawing.Color.Transparent;
            this.txt_outputFolder.BackgroundColor = System.Drawing.Color.White;
            this.txt_outputFolder.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.txt_outputFolder.Enabled = false;
            this.txt_outputFolder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_outputFolder.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_outputFolder.Location = new System.Drawing.Point(115, 46);
            this.txt_outputFolder.Name = "txt_outputFolder";
            this.txt_outputFolder.Padding = new System.Windows.Forms.Padding(5);
            this.txt_outputFolder.Size = new System.Drawing.Size(554, 30);
            this.txt_outputFolder.TabIndex = 23;
            this.txt_outputFolder.TextChanged += new System.EventHandler(this.txt_outputFolder_TextChanged);
            // 
            // txt_inputFolder
            // 
            this.txt_inputFolder.BackColor = System.Drawing.Color.Transparent;
            this.txt_inputFolder.BackgroundColor = System.Drawing.Color.White;
            this.txt_inputFolder.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.txt_inputFolder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_inputFolder.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_inputFolder.Location = new System.Drawing.Point(115, 10);
            this.txt_inputFolder.Name = "txt_inputFolder";
            this.txt_inputFolder.Padding = new System.Windows.Forms.Padding(5);
            this.txt_inputFolder.Size = new System.Drawing.Size(554, 30);
            this.txt_inputFolder.TabIndex = 21;
            this.txt_inputFolder.TextChanged += new System.EventHandler(this.txt_inputFolder_TextChanged);
            // 
            // circle1
            // 
            this.circle1.BackColor = System.Drawing.Color.Transparent;
            this.circle1.IndexColor = System.Drawing.Color.DeepSkyBlue;
            this.circle1.Interval = 50;
            this.circle1.Location = new System.Drawing.Point(780, 8);
            this.circle1.Name = "circle1";
            this.circle1.NCircle = 8;
            this.circle1.Others = System.Drawing.Color.LightGray;
            this.circle1.Radius = 3;
            this.circle1.Size = new System.Drawing.Size(39, 31);
            this.circle1.TabIndex = 11;
            this.circle1.Text = "processingControl1";
            this.circle1.Visible = false;
            // 
            // btn_detect
            // 
            this.btn_detect.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btn_detect.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btn_detect.BackColor = System.Drawing.Color.Transparent;
            this.btn_detect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_detect.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_detect.ForeColor = System.Drawing.Color.White;
            this.btn_detect.Icon = null;
            this.btn_detect.ImageLocation = new System.Drawing.Point(0, 0);
            this.btn_detect.ImageSize = new System.Drawing.Size(0, 0);
            this.btn_detect.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.btn_detect.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btn_detect.Location = new System.Drawing.Point(675, 7);
            this.btn_detect.Name = "btn_detect";
            this.btn_detect.Radius = 6;
            this.btn_detect.Size = new System.Drawing.Size(98, 33);
            this.btn_detect.Stroke = 0;
            this.btn_detect.StrokeColor = System.Drawing.Color.Gray;
            this.btn_detect.TabIndex = 10;
            this.btn_detect.Text = "Start";
            this.btn_detect.Transparency = false;
            this.btn_detect.Click += new System.EventHandler(this.btn_detect_Click);
            // 
            // workerDetect
            // 
            this.workerDetect.WorkerSupportsCancellation = true;
            this.workerDetect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerDetect_DoWork);
            this.workerDetect.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerDetect_RunWorkerCompleted);
            // 
            // workerLoadFile
            // 
            this.workerLoadFile.WorkerSupportsCancellation = true;
            this.workerLoadFile.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerLoadFile_DoWork);
            this.workerLoadFile.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerLoadFile_RunWorkerCompleted);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Left;
            this.splitContainer1.Location = new System.Drawing.Point(0, 87);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.listView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView2);
            this.splitContainer1.Size = new System.Drawing.Size(401, 463);
            this.splitContainer1.SplitterDistance = 323;
            this.splitContainer1.TabIndex = 44;
            this.splitContainer1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // listView2
            // 
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7});
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listView2.FullRowSelect = true;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(401, 136);
            this.listView2.TabIndex = 0;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
            this.listView2.SelectedIndexChanged += new System.EventHandler(this.listView2_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Idx";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Class";
            this.columnHeader5.Width = 50;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Name";
            this.columnHeader6.Width = 140;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Score";
            this.columnHeader7.Width = 80;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(401, 87);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(633, 463);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 43;
            this.pictureBox1.TabStop = false;
            // 
            // FormFolder
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1034, 550);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Name = "FormFolder";
            this.Text = "FormFolder";
            this.Load += new System.EventHandler(this.FormFolder_Load);
            this.EnabledChanged += new System.EventHandler(this.FormFolder_EnabledChanged);
            ((System.ComponentModel.ISupportInitialize)(this.txt_inputWidth)).EndInit();
            this.menu1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.RadioButton rd_extract;
        private System.Windows.Forms.RadioButton rd_draw;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.NumericUpDown txt_inputWidth;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private ProcessingControl circle1;
        private DefaultButton btn_detect;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.ComponentModel.BackgroundWorker workerDetect;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.ComponentModel.BackgroundWorker workerLoadFile;
        private BrowseDir txt_inputFolder;
        private System.Windows.Forms.CheckBox chk_outputFolder;
        private BrowseDir txt_outputFolder;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ContextMenuStrip menu1;
        private System.Windows.Forms.ToolStripMenuItem btn_copyImage;
        private System.Windows.Forms.ToolStripMenuItem btn_copyImgPath;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ToolStripMenuItem btn_openFolder;
    }
}