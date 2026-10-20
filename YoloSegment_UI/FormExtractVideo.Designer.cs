using TGMTcontrols;

namespace YoloSegment
{
    partial class FormExtractVideo
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
            this.pnCamera1 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_startFrame = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.txt_skipFrame = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.chk_overWrite = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_minArea = new System.Windows.Forms.NumericUpDown();
            this.rd_saveObject = new System.Windows.Forms.RadioButton();
            this.rd_saveAll = new System.Windows.Forms.RadioButton();
            this.lbl_count = new System.Windows.Forms.Label();
            this.txt_numThread = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_output = new TGMTcontrols.BrowseDir();
            this.circle1 = new TGMTcontrols.ProcessingControl();
            this.btn_start = new TGMTcontrols.DefaultButton();
            this.txt_inputVideo = new TGMTcontrols.BrowseFile();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.pnCamera1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_startFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_skipFrame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_minArea)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_numThread)).BeginInit();
            this.SuspendLayout();
            // 
            // pnCamera1
            // 
            this.pnCamera1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnCamera1.Controls.Add(this.pictureBox1);
            this.pnCamera1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCamera1.Location = new System.Drawing.Point(0, 124);
            this.pnCamera1.Name = "pnCamera1";
            this.pnCamera1.Size = new System.Drawing.Size(738, 349);
            this.pnCamera1.TabIndex = 21;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.Highlight;
            this.pictureBox1.Location = new System.Drawing.Point(1, 1);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(737, 313);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.txt_startFrame);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txt_skipFrame);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chk_overWrite);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txt_minArea);
            this.panel1.Controls.Add(this.rd_saveObject);
            this.panel1.Controls.Add(this.rd_saveAll);
            this.panel1.Controls.Add(this.lbl_count);
            this.panel1.Controls.Add(this.txt_numThread);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txt_output);
            this.panel1.Controls.Add(this.circle1);
            this.panel1.Controls.Add(this.btn_start);
            this.panel1.Controls.Add(this.txt_inputVideo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1083, 124);
            this.panel1.TabIndex = 38;
            // 
            // txt_startFrame
            // 
            this.txt_startFrame.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_startFrame.Location = new System.Drawing.Point(184, 89);
            this.txt_startFrame.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txt_startFrame.Name = "txt_startFrame";
            this.txt_startFrame.Size = new System.Drawing.Size(59, 25);
            this.txt_startFrame.TabIndex = 28;
            this.txt_startFrame.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_startFrame.ValueChanged += new System.EventHandler(this.txt_startFrame_ValueChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label5.Location = new System.Drawing.Point(107, 92);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 19);
            this.label5.TabIndex = 27;
            this.label5.Text = "Start frame";
            // 
            // txt_skipFrame
            // 
            this.txt_skipFrame.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_skipFrame.Location = new System.Drawing.Point(359, 89);
            this.txt_skipFrame.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txt_skipFrame.Name = "txt_skipFrame";
            this.txt_skipFrame.Size = new System.Drawing.Size(59, 25);
            this.txt_skipFrame.TabIndex = 26;
            this.txt_skipFrame.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_skipFrame.ValueChanged += new System.EventHandler(this.txt_skipFrame_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label1.Location = new System.Drawing.Point(282, 92);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 25;
            this.label1.Text = "Skip frame";
            // 
            // chk_overWrite
            // 
            this.chk_overWrite.AutoSize = true;
            this.chk_overWrite.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chk_overWrite.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.chk_overWrite.Location = new System.Drawing.Point(12, 90);
            this.chk_overWrite.Name = "chk_overWrite";
            this.chk_overWrite.Size = new System.Drawing.Size(88, 23);
            this.chk_overWrite.TabIndex = 24;
            this.chk_overWrite.Text = "Overwrite";
            this.chk_overWrite.UseVisualStyleBackColor = true;
            this.chk_overWrite.CheckedChanged += new System.EventHandler(this.chk_overWrite_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label2.Location = new System.Drawing.Point(863, 86);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 19);
            this.label2.TabIndex = 22;
            this.label2.Text = "Min area";
            // 
            // txt_minArea
            // 
            this.txt_minArea.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_minArea.Location = new System.Drawing.Point(933, 84);
            this.txt_minArea.Maximum = new decimal(new int[] {
            9999999,
            0,
            0,
            0});
            this.txt_minArea.Name = "txt_minArea";
            this.txt_minArea.Size = new System.Drawing.Size(97, 25);
            this.txt_minArea.TabIndex = 21;
            this.txt_minArea.ValueChanged += new System.EventHandler(this.txt_minArea_ValueChanged);
            // 
            // rd_saveObject
            // 
            this.rd_saveObject.AutoSize = true;
            this.rd_saveObject.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rd_saveObject.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.rd_saveObject.Location = new System.Drawing.Point(863, 51);
            this.rd_saveObject.Name = "rd_saveObject";
            this.rd_saveObject.Size = new System.Drawing.Size(167, 21);
            this.rd_saveObject.TabIndex = 20;
            this.rd_saveObject.Text = "Save frame has object";
            this.rd_saveObject.UseVisualStyleBackColor = true;
            // 
            // rd_saveAll
            // 
            this.rd_saveAll.AutoSize = true;
            this.rd_saveAll.Checked = true;
            this.rd_saveAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.rd_saveAll.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.rd_saveAll.Location = new System.Drawing.Point(863, 24);
            this.rd_saveAll.Name = "rd_saveAll";
            this.rd_saveAll.Size = new System.Drawing.Size(116, 21);
            this.rd_saveAll.TabIndex = 19;
            this.rd_saveAll.TabStop = true;
            this.rd_saveAll.Text = "Save all frame";
            this.rd_saveAll.UseVisualStyleBackColor = true;
            this.rd_saveAll.CheckedChanged += new System.EventHandler(this.rd_saveAll_CheckedChanged);
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_count.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lbl_count.Location = new System.Drawing.Point(676, 92);
            this.lbl_count.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(47, 19);
            this.lbl_count.TabIndex = 18;
            this.lbl_count.Text = "Count";
            // 
            // txt_numThread
            // 
            this.txt_numThread.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_numThread.Location = new System.Drawing.Point(595, 90);
            this.txt_numThread.Maximum = new decimal(new int[] {
            999,
            0,
            0,
            0});
            this.txt_numThread.Name = "txt_numThread";
            this.txt_numThread.Size = new System.Drawing.Size(59, 25);
            this.txt_numThread.TabIndex = 16;
            this.txt_numThread.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.txt_numThread.ValueChanged += new System.EventHandler(this.txt_numThread_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label4.Location = new System.Drawing.Point(501, 93);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 19);
            this.label4.TabIndex = 15;
            this.label4.Text = "Num thread";
            // 
            // txt_output
            // 
            this.txt_output.BackColor = System.Drawing.Color.Transparent;
            this.txt_output.BackgroundColor = System.Drawing.Color.White;
            this.txt_output.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.txt_output.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_output.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_output.Location = new System.Drawing.Point(106, 54);
            this.txt_output.Name = "txt_output";
            this.txt_output.Padding = new System.Windows.Forms.Padding(5);
            this.txt_output.Size = new System.Drawing.Size(563, 30);
            this.txt_output.TabIndex = 12;
            this.txt_output.TextChanged += new System.EventHandler(this.txt_output_TextChanged);
            // 
            // circle1
            // 
            this.circle1.BackColor = System.Drawing.Color.Transparent;
            this.circle1.IndexColor = System.Drawing.Color.DeepSkyBlue;
            this.circle1.Interval = 50;
            this.circle1.Location = new System.Drawing.Point(780, 17);
            this.circle1.Name = "circle1";
            this.circle1.NCircle = 8;
            this.circle1.Others = System.Drawing.Color.LightGray;
            this.circle1.Radius = 3;
            this.circle1.Size = new System.Drawing.Size(39, 31);
            this.circle1.TabIndex = 11;
            this.circle1.Text = "processingControl1";
            this.circle1.Visible = false;
            // 
            // btn_start
            // 
            this.btn_start.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btn_start.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btn_start.BackColor = System.Drawing.Color.Transparent;
            this.btn_start.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_start.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_start.ForeColor = System.Drawing.Color.White;
            this.btn_start.Icon = null;
            this.btn_start.ImageLocation = new System.Drawing.Point(0, 0);
            this.btn_start.ImageSize = new System.Drawing.Size(0, 0);
            this.btn_start.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.btn_start.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btn_start.Location = new System.Drawing.Point(675, 16);
            this.btn_start.Name = "btn_start";
            this.btn_start.Radius = 6;
            this.btn_start.Size = new System.Drawing.Size(98, 33);
            this.btn_start.Stroke = 0;
            this.btn_start.StrokeColor = System.Drawing.Color.Gray;
            this.btn_start.TabIndex = 10;
            this.btn_start.Text = "Start";
            this.btn_start.Transparency = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // txt_inputVideo
            // 
            this.txt_inputVideo.BackColor = System.Drawing.Color.Transparent;
            this.txt_inputVideo.BackgroundColor = System.Drawing.Color.White;
            this.txt_inputVideo.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.txt_inputVideo.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_inputVideo.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_inputVideo.Location = new System.Drawing.Point(106, 17);
            this.txt_inputVideo.Name = "txt_inputVideo";
            this.txt_inputVideo.Padding = new System.Windows.Forms.Padding(5);
            this.txt_inputVideo.Pattern = "";
            this.txt_inputVideo.Size = new System.Drawing.Size(563, 30);
            this.txt_inputVideo.TabIndex = 9;
            this.txt_inputVideo.TextChanged += new System.EventHandler(this.txt_inputVideo_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label3.Location = new System.Drawing.Point(9, 24);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Input video";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(738, 124);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(345, 349);
            this.listView1.TabIndex = 39;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Idx";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Image path";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Num object";
            this.columnHeader3.Width = 100;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label6.Location = new System.Drawing.Point(12, 59);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 19);
            this.label6.TabIndex = 29;
            this.label6.Text = "Extract to";
            // 
            // FormExtractVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 473);
            this.Controls.Add(this.pnCamera1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormExtractVideo";
            this.Text = "FormExtract";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExtract_FormClosing);
            this.Load += new System.EventHandler(this.FormExtractVideo_Load);
            this.SizeChanged += new System.EventHandler(this.FormExtract_SizeChanged);
            this.pnCamera1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txt_startFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_skipFrame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_minArea)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txt_numThread)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnCamera1;
        private System.Windows.Forms.Panel panel1;
        private ProcessingControl circle1;
        private DefaultButton btn_start;
        private BrowseFile txt_inputVideo;
        private System.Windows.Forms.Label label3;
        private BrowseDir txt_output;
        private System.Windows.Forms.NumericUpDown txt_numThread;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.RadioButton rd_saveAll;
        private System.Windows.Forms.RadioButton rd_saveObject;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown txt_minArea;
        private System.Windows.Forms.CheckBox chk_overWrite;
        private System.Windows.Forms.NumericUpDown txt_skipFrame;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown txt_startFrame;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}