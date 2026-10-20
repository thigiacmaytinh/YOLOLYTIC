using TGMTcontrols;

namespace Yololytic
{
    partial class FormVideo
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.txt_minArea = new TGMTcontrols.RoundedTextBox();
            this.txt_skipFrame = new TGMTcontrols.RoundedTextBox();
            this.txt_startFrame = new TGMTcontrols.RoundedTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_count = new System.Windows.Forms.Label();
            this.circle1 = new TGMTcontrols.ProcessingControl();
            this.btn_start = new TGMTcontrols.DefaultButton();
            this.txt_inputVideo = new TGMTcontrols.BrowseFile();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnCamera1.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pnCamera1
            // 
            this.pnCamera1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnCamera1.Controls.Add(this.pictureBox1);
            this.pnCamera1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCamera1.Location = new System.Drawing.Point(0, 93);
            this.pnCamera1.Name = "pnCamera1";
            this.pnCamera1.Size = new System.Drawing.Size(738, 380);
            this.pnCamera1.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.txt_minArea);
            this.panel1.Controls.Add(this.txt_skipFrame);
            this.panel1.Controls.Add(this.txt_startFrame);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.lbl_count);
            this.panel1.Controls.Add(this.circle1);
            this.panel1.Controls.Add(this.btn_start);
            this.panel1.Controls.Add(this.txt_inputVideo);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1083, 93);
            this.panel1.TabIndex = 38;
            // 
            // txt_minArea
            // 
            this.txt_minArea.BackColor = System.Drawing.Color.Transparent;
            this.txt_minArea.BackgroundColor = System.Drawing.Color.White;
            this.txt_minArea.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            // 
            // 
            // 
            this.txt_minArea.Button.Active1 = System.Drawing.Color.DodgerBlue;
            this.txt_minArea.Button.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.txt_minArea.Button.BackColor = System.Drawing.Color.Transparent;
            this.txt_minArea.Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.txt_minArea.Button.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txt_minArea.Button.ForeColor = System.Drawing.Color.White;
            this.txt_minArea.Button.Icon = null;
            this.txt_minArea.Button.ImageLocation = new System.Drawing.Point(0, 0);
            this.txt_minArea.Button.ImageSize = new System.Drawing.Size(22, 22);
            this.txt_minArea.Button.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.txt_minArea.Button.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.txt_minArea.Button.Location = new System.Drawing.Point(0, 0);
            this.txt_minArea.Button.Name = "";
            this.txt_minArea.Button.Radius = 0;
            this.txt_minArea.Button.Size = new System.Drawing.Size(110, 30);
            this.txt_minArea.Button.Stroke = 0;
            this.txt_minArea.Button.StrokeColor = System.Drawing.Color.Gray;
            this.txt_minArea.Button.TabIndex = 1;
            this.txt_minArea.Button.TabStop = false;
            this.txt_minArea.Button.Transparency = false;
            this.txt_minArea.Button.Visible = false;
            this.txt_minArea.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_minArea.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_minArea.Location = new System.Drawing.Point(510, 53);
            this.txt_minArea.Multiline = false;
            this.txt_minArea.Name = "txt_minArea";
            this.txt_minArea.NumberOnly = true;
            this.txt_minArea.Padding = new System.Windows.Forms.Padding(5);
            this.txt_minArea.Radius = 4;
            this.txt_minArea.Size = new System.Drawing.Size(96, 30);
            this.txt_minArea.TabIndex = 31;
            this.txt_minArea.TabStop = false;
            this.txt_minArea.Text = "0";
            this.txt_minArea.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_minArea.TextChanged += new System.EventHandler(this.txt_minArea_TextChanged);
            // 
            // txt_skipFrame
            // 
            this.txt_skipFrame.BackColor = System.Drawing.Color.Transparent;
            this.txt_skipFrame.BackgroundColor = System.Drawing.Color.White;
            this.txt_skipFrame.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            // 
            // 
            // 
            this.txt_skipFrame.Button.Active1 = System.Drawing.Color.DodgerBlue;
            this.txt_skipFrame.Button.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.txt_skipFrame.Button.BackColor = System.Drawing.Color.Transparent;
            this.txt_skipFrame.Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.txt_skipFrame.Button.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txt_skipFrame.Button.ForeColor = System.Drawing.Color.White;
            this.txt_skipFrame.Button.Icon = null;
            this.txt_skipFrame.Button.ImageLocation = new System.Drawing.Point(0, 0);
            this.txt_skipFrame.Button.ImageSize = new System.Drawing.Size(22, 22);
            this.txt_skipFrame.Button.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.txt_skipFrame.Button.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.txt_skipFrame.Button.Location = new System.Drawing.Point(0, 0);
            this.txt_skipFrame.Button.Name = "";
            this.txt_skipFrame.Button.Radius = 0;
            this.txt_skipFrame.Button.Size = new System.Drawing.Size(110, 30);
            this.txt_skipFrame.Button.Stroke = 0;
            this.txt_skipFrame.Button.StrokeColor = System.Drawing.Color.Gray;
            this.txt_skipFrame.Button.TabIndex = 1;
            this.txt_skipFrame.Button.TabStop = false;
            this.txt_skipFrame.Button.Transparency = false;
            this.txt_skipFrame.Button.Visible = false;
            this.txt_skipFrame.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_skipFrame.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_skipFrame.Location = new System.Drawing.Point(306, 53);
            this.txt_skipFrame.Multiline = false;
            this.txt_skipFrame.Name = "txt_skipFrame";
            this.txt_skipFrame.NumberOnly = true;
            this.txt_skipFrame.Padding = new System.Windows.Forms.Padding(5);
            this.txt_skipFrame.Radius = 4;
            this.txt_skipFrame.Size = new System.Drawing.Size(96, 30);
            this.txt_skipFrame.TabIndex = 30;
            this.txt_skipFrame.TabStop = false;
            this.txt_skipFrame.Text = "0";
            this.txt_skipFrame.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_skipFrame.TextChanged += new System.EventHandler(this.txt_skipFrame_TextChanged);
            // 
            // txt_startFrame
            // 
            this.txt_startFrame.BackColor = System.Drawing.Color.Transparent;
            this.txt_startFrame.BackgroundColor = System.Drawing.Color.White;
            this.txt_startFrame.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            // 
            // 
            // 
            this.txt_startFrame.Button.Active1 = System.Drawing.Color.DodgerBlue;
            this.txt_startFrame.Button.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.txt_startFrame.Button.BackColor = System.Drawing.Color.Transparent;
            this.txt_startFrame.Button.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.txt_startFrame.Button.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.txt_startFrame.Button.ForeColor = System.Drawing.Color.White;
            this.txt_startFrame.Button.Icon = null;
            this.txt_startFrame.Button.ImageLocation = new System.Drawing.Point(0, 0);
            this.txt_startFrame.Button.ImageSize = new System.Drawing.Size(22, 22);
            this.txt_startFrame.Button.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.txt_startFrame.Button.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.txt_startFrame.Button.Location = new System.Drawing.Point(0, 0);
            this.txt_startFrame.Button.Name = "";
            this.txt_startFrame.Button.Radius = 0;
            this.txt_startFrame.Button.Size = new System.Drawing.Size(110, 30);
            this.txt_startFrame.Button.Stroke = 0;
            this.txt_startFrame.Button.StrokeColor = System.Drawing.Color.Gray;
            this.txt_startFrame.Button.TabIndex = 1;
            this.txt_startFrame.Button.TabStop = false;
            this.txt_startFrame.Button.Transparency = false;
            this.txt_startFrame.Button.Visible = false;
            this.txt_startFrame.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_startFrame.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_startFrame.Location = new System.Drawing.Point(106, 53);
            this.txt_startFrame.Multiline = false;
            this.txt_startFrame.Name = "txt_startFrame";
            this.txt_startFrame.NumberOnly = true;
            this.txt_startFrame.Padding = new System.Windows.Forms.Padding(5);
            this.txt_startFrame.Radius = 4;
            this.txt_startFrame.Size = new System.Drawing.Size(96, 30);
            this.txt_startFrame.TabIndex = 29;
            this.txt_startFrame.TabStop = false;
            this.txt_startFrame.Text = "0";
            this.txt_startFrame.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txt_startFrame.TextChanged += new System.EventHandler(this.txt_startFrame_TextChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label5.Location = new System.Drawing.Point(13, 59);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 19);
            this.label5.TabIndex = 27;
            this.label5.Text = "Start frame";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label1.Location = new System.Drawing.Point(226, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 19);
            this.label1.TabIndex = 25;
            this.label1.Text = "Skip frame";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label2.Location = new System.Drawing.Point(440, 59);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 19);
            this.label2.TabIndex = 22;
            this.label2.Text = "Min area";
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_count.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lbl_count.Location = new System.Drawing.Point(671, 60);
            this.lbl_count.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(47, 19);
            this.lbl_count.TabIndex = 18;
            this.lbl_count.Text = "Count";
            // 
            // circle1
            // 
            this.circle1.BackColor = System.Drawing.Color.Transparent;
            this.circle1.Enabled = false;
            this.circle1.IndexColor = System.Drawing.Color.DeepSkyBlue;
            this.circle1.Interval = 50;
            this.circle1.Location = new System.Drawing.Point(780, 17);
            this.circle1.Name = "circle1";
            this.circle1.NCircle = 8;
            this.circle1.Others = System.Drawing.Color.LightGray;
            this.circle1.Radius = 4;
            this.circle1.Size = new System.Drawing.Size(39, 39);
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
            this.listView1.Location = new System.Drawing.Point(738, 93);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(345, 380);
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
            this.columnHeader2.Text = "Object";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Score";
            this.columnHeader3.Width = 100;
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
            // FormVideo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 473);
            this.Controls.Add(this.pnCamera1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormVideo";
            this.Text = "FormExtract";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormExtract_FormClosing);
            this.Load += new System.EventHandler(this.FormExtract_Load);
            this.SizeChanged += new System.EventHandler(this.FormExtract_SizeChanged);
            this.pnCamera1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnCamera1;
        private System.Windows.Forms.Panel panel1;
        private ProcessingControl circle1;
        private DefaultButton btn_start;
        private BrowseFile txt_inputVideo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private RoundedTextBox txt_startFrame;
        private RoundedTextBox txt_skipFrame;
        private RoundedTextBox txt_minArea;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}