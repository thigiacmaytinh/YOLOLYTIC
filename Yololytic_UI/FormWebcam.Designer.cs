using TGMTcontrols;

namespace Yololytic
{
    partial class FormWebcam
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
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timerClear = new System.Windows.Forms.Timer(this.components);
            this.panelLogo = new System.Windows.Forms.Panel();
            this.btn_start = new TGMTcontrols.DefaultButton();
            this.cb_resolution = new System.Windows.Forms.ComboBox();
            this.chk_drawText = new System.Windows.Forms.CheckBox();
            this.chk_drawRect = new System.Windows.Forms.CheckBox();
            this.btn_save = new TGMTcontrols.DefaultButton();
            this.circle1 = new TGMTcontrols.ProcessingControl();
            this.cb_webcam = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picWebcam = new System.Windows.Forms.PictureBox();
            this.workerDetect = new System.ComponentModel.BackgroundWorker();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.circle_frame = new TGMTcontrols.ProcessingControl();
            this.panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).BeginInit();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.imageList1.ImageSize = new System.Drawing.Size(100, 100);
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // timerClear
            // 
            this.timerClear.Interval = 2000;
            // 
            // panelLogo
            // 
            this.panelLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.panelLogo.Controls.Add(this.btn_start);
            this.panelLogo.Controls.Add(this.cb_resolution);
            this.panelLogo.Controls.Add(this.chk_drawText);
            this.panelLogo.Controls.Add(this.chk_drawRect);
            this.panelLogo.Controls.Add(this.btn_save);
            this.panelLogo.Controls.Add(this.circle1);
            this.panelLogo.Controls.Add(this.cb_webcam);
            this.panelLogo.Controls.Add(this.label1);
            this.panelLogo.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelLogo.Location = new System.Drawing.Point(0, 0);
            this.panelLogo.Name = "panelLogo";
            this.panelLogo.Size = new System.Drawing.Size(982, 75);
            this.panelLogo.TabIndex = 21;
            // 
            // btn_start
            // 
            this.btn_start.Active1 = System.Drawing.Color.DodgerBlue;
            this.btn_start.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.btn_start.BackColor = System.Drawing.Color.Transparent;
            this.btn_start.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_start.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_start.ForeColor = System.Drawing.Color.White;
            this.btn_start.Icon = null;
            this.btn_start.ImageLocation = new System.Drawing.Point(0, 0);
            this.btn_start.ImageSize = new System.Drawing.Size(0, 0);
            this.btn_start.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.btn_start.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.btn_start.Location = new System.Drawing.Point(558, 12);
            this.btn_start.Name = "btn_start";
            this.btn_start.Radius = 6;
            this.btn_start.Size = new System.Drawing.Size(82, 33);
            this.btn_start.Stroke = 0;
            this.btn_start.StrokeColor = System.Drawing.Color.Gray;
            this.btn_start.TabIndex = 45;
            this.btn_start.Text = "Start";
            this.btn_start.Transparency = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // cb_resolution
            // 
            this.cb_resolution.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_resolution.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_resolution.FormattingEnabled = true;
            this.cb_resolution.Location = new System.Drawing.Point(373, 16);
            this.cb_resolution.Name = "cb_resolution";
            this.cb_resolution.Size = new System.Drawing.Size(176, 25);
            this.cb_resolution.TabIndex = 44;
            this.cb_resolution.SelectedIndexChanged += new System.EventHandler(this.cb_resolution_SelectedIndexChanged);
            // 
            // chk_drawText
            // 
            this.chk_drawText.AutoSize = true;
            this.chk_drawText.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chk_drawText.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.chk_drawText.Location = new System.Drawing.Point(252, 47);
            this.chk_drawText.Name = "chk_drawText";
            this.chk_drawText.Size = new System.Drawing.Size(87, 23);
            this.chk_drawText.TabIndex = 43;
            this.chk_drawText.Text = "Draw text";
            this.chk_drawText.UseVisualStyleBackColor = true;
            this.chk_drawText.CheckedChanged += new System.EventHandler(this.chk_drawText_CheckedChanged);
            // 
            // chk_drawRect
            // 
            this.chk_drawRect.AutoSize = true;
            this.chk_drawRect.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.chk_drawRect.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.chk_drawRect.Location = new System.Drawing.Point(104, 47);
            this.chk_drawRect.Name = "chk_drawRect";
            this.chk_drawRect.Size = new System.Drawing.Size(120, 23);
            this.chk_drawRect.TabIndex = 42;
            this.chk_drawRect.Text = "Draw rectangle";
            this.chk_drawRect.UseVisualStyleBackColor = true;
            this.chk_drawRect.CheckedChanged += new System.EventHandler(this.chk_drawRect_CheckedChanged);
            // 
            // btn_save
            // 
            this.btn_save.Active1 = System.Drawing.Color.DodgerBlue;
            this.btn_save.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.btn_save.BackColor = System.Drawing.Color.Transparent;
            this.btn_save.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_save.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Icon = null;
            this.btn_save.ImageLocation = new System.Drawing.Point(0, 0);
            this.btn_save.ImageSize = new System.Drawing.Size(0, 0);
            this.btn_save.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.btn_save.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.btn_save.Location = new System.Drawing.Point(646, 12);
            this.btn_save.Name = "btn_save";
            this.btn_save.Radius = 6;
            this.btn_save.Size = new System.Drawing.Size(111, 33);
            this.btn_save.Stroke = 0;
            this.btn_save.StrokeColor = System.Drawing.Color.Gray;
            this.btn_save.TabIndex = 8;
            this.btn_save.Text = "Save frame";
            this.btn_save.Transparency = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // circle1
            // 
            this.circle1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.circle1.BackColor = System.Drawing.Color.Transparent;
            this.circle1.Enabled = false;
            this.circle1.IndexColor = System.Drawing.Color.DeepSkyBlue;
            this.circle1.Interval = 50;
            this.circle1.Location = new System.Drawing.Point(932, 28);
            this.circle1.Name = "circle1";
            this.circle1.NCircle = 8;
            this.circle1.Others = System.Drawing.Color.LightGray;
            this.circle1.Radius = 4;
            this.circle1.Size = new System.Drawing.Size(38, 41);
            this.circle1.TabIndex = 7;
            this.circle1.Text = "processingControl1";
            // 
            // cb_webcam
            // 
            this.cb_webcam.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_webcam.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_webcam.FormattingEnabled = true;
            this.cb_webcam.Location = new System.Drawing.Point(102, 16);
            this.cb_webcam.Name = "cb_webcam";
            this.cb_webcam.Size = new System.Drawing.Size(264, 25);
            this.cb_webcam.TabIndex = 3;
            this.cb_webcam.SelectedIndexChanged += new System.EventHandler(this.cb_webcam_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label1.Location = new System.Drawing.Point(16, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Webcam";
            // 
            // picWebcam
            // 
            this.picWebcam.BackColor = System.Drawing.Color.White;
            this.picWebcam.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picWebcam.Location = new System.Drawing.Point(0, 75);
            this.picWebcam.Name = "picWebcam";
            this.picWebcam.Size = new System.Drawing.Size(637, 403);
            this.picWebcam.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picWebcam.TabIndex = 25;
            this.picWebcam.TabStop = false;
            // 
            // workerDetect
            // 
            this.workerDetect.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerDetect_DoWork);
            this.workerDetect.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerDetect_RunWorkerCompleted);
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
            this.listView1.Location = new System.Drawing.Point(637, 75);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(345, 403);
            this.listView1.TabIndex = 36;
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
            this.columnHeader2.Text = "Class name";
            this.columnHeader2.Width = 200;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Score";
            this.columnHeader3.Width = 100;
            // 
            // circle_frame
            // 
            this.circle_frame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.circle_frame.BackColor = System.Drawing.Color.Transparent;
            this.circle_frame.Enabled = false;
            this.circle_frame.IndexColor = System.Drawing.Color.DeepSkyBlue;
            this.circle_frame.Interval = 50;
            this.circle_frame.Location = new System.Drawing.Point(597, 75);
            this.circle_frame.Name = "circle_frame";
            this.circle_frame.NCircle = 8;
            this.circle_frame.Others = System.Drawing.Color.LightGray;
            this.circle_frame.Radius = 4;
            this.circle_frame.Size = new System.Drawing.Size(38, 41);
            this.circle_frame.TabIndex = 37;
            this.circle_frame.Text = "processingControl1";
            // 
            // FormWebcam
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 478);
            this.Controls.Add(this.circle_frame);
            this.Controls.Add(this.picWebcam);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panelLogo);
            this.Name = "FormWebcam";
            this.Text = "Phần mềm đọc biển số xe máy xe hơi";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormWebcam_FormClosing);
            this.Load += new System.EventHandler(this.FormWebcam_Load);
            this.SizeChanged += new System.EventHandler(this.FormWebcam_SizeChanged);
            this.panelLogo.ResumeLayout(false);
            this.panelLogo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picWebcam)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timerClear;
        private System.Windows.Forms.Panel panelLogo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_webcam;
        private System.Windows.Forms.PictureBox picWebcam;
        private System.ComponentModel.BackgroundWorker workerDetect;
        private ProcessingControl circle1;
        private DefaultButton btn_save;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.CheckBox chk_drawText;
        private System.Windows.Forms.CheckBox chk_drawRect;
        private System.Windows.Forms.ComboBox cb_resolution;
        private DefaultButton btn_start;
        private ProcessingControl circle_frame;
    }
}

