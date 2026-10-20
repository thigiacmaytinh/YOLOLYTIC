using TGMTcontrols;

namespace Yololytic
{
    partial class FormCamera
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
            this.pnCamera0 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_resolution = new System.Windows.Forms.Label();
            this.lbl_count = new System.Windows.Forms.Label();
            this.circle0 = new TGMTcontrols.ProcessingControl();
            this.btn_start = new TGMTcontrols.DefaultButton();
            this.txt_camera = new TGMTcontrols.BrowseFile();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnCamera0
            // 
            this.pnCamera0.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.pnCamera0.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnCamera0.Location = new System.Drawing.Point(0, 80);
            this.pnCamera0.Name = "pnCamera0";
            this.pnCamera0.Size = new System.Drawing.Size(738, 393);
            this.pnCamera0.TabIndex = 21;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.lbl_resolution);
            this.panel1.Controls.Add(this.lbl_count);
            this.panel1.Controls.Add(this.circle0);
            this.panel1.Controls.Add(this.btn_start);
            this.panel1.Controls.Add(this.txt_camera);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1083, 80);
            this.panel1.TabIndex = 38;
            // 
            // lbl_resolution
            // 
            this.lbl_resolution.AutoSize = true;
            this.lbl_resolution.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.lbl_resolution.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lbl_resolution.Location = new System.Drawing.Point(13, 51);
            this.lbl_resolution.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_resolution.Name = "lbl_resolution";
            this.lbl_resolution.Size = new System.Drawing.Size(79, 20);
            this.lbl_resolution.TabIndex = 42;
            this.lbl_resolution.Text = "Resolution";
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_count.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lbl_count.Location = new System.Drawing.Point(826, 24);
            this.lbl_count.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(56, 21);
            this.lbl_count.TabIndex = 18;
            this.lbl_count.Text = "Count";
            // 
            // circle0
            // 
            this.circle0.BackColor = System.Drawing.Color.Transparent;
            this.circle0.IndexColor = System.Drawing.Color.DeepSkyBlue;
            this.circle0.Interval = 50;
            this.circle0.Location = new System.Drawing.Point(780, 17);
            this.circle0.Name = "circle0";
            this.circle0.NCircle = 8;
            this.circle0.Others = System.Drawing.Color.LightGray;
            this.circle0.Radius = 3;
            this.circle0.Size = new System.Drawing.Size(39, 31);
            this.circle0.TabIndex = 11;
            this.circle0.Text = "processingControl1";
            this.circle0.Visible = false;
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
            this.btn_start.ImageSize = new System.Drawing.Size(22, 22);
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
            // txt_camera
            // 
            this.txt_camera.BackColor = System.Drawing.Color.Transparent;
            this.txt_camera.BackgroundColor = System.Drawing.Color.White;
            this.txt_camera.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.txt_camera.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txt_camera.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_camera.Location = new System.Drawing.Point(168, 17);
            this.txt_camera.Name = "txt_camera";
            this.txt_camera.Padding = new System.Windows.Forms.Padding(5);
            this.txt_camera.Pattern = "";
            this.txt_camera.Size = new System.Drawing.Size(501, 30);
            this.txt_camera.TabIndex = 9;
            this.txt_camera.TextChanged += new System.EventHandler(this.txt_imagePath_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label3.Location = new System.Drawing.Point(9, 22);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 20);
            this.label3.TabIndex = 8;
            this.label3.Text = "Video/camera stream";
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader2,
            this.columnHeader3});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Right;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(738, 80);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(345, 393);
            this.listView1.TabIndex = 39;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Idx";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "ClassID";
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Class name";
            this.columnHeader2.Width = 140;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Confident";
            this.columnHeader3.Width = 100;
            // 
            // FormCamera
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 473);
            this.Controls.Add(this.pnCamera0);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormCamera";
            this.Text = "Form Camera";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormCamera_FormClosing);
            this.Load += new System.EventHandler(this.FormExtract_Load);
            this.SizeChanged += new System.EventHandler(this.FormCamera_SizeChanged);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnCamera0;
        private System.Windows.Forms.Panel panel1;
        private ProcessingControl circle0;
        private DefaultButton btn_start;
        private BrowseFile txt_camera;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label lbl_resolution;
    }
}