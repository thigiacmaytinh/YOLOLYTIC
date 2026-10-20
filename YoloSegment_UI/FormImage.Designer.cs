using TGMTcontrols;

namespace YoloSegment
{
    partial class FormImage
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_count = new System.Windows.Forms.Label();
            this.chk_autoWarp = new TGMTcontrols.SwitchButton();
            this.chk_saveAnnotation = new TGMTcontrols.SwitchButton();
            this.circle1 = new TGMTcontrols.ProcessingControl();
            this.btn_predict = new TGMTcontrols.DefaultButton();
            this.txt_imagePath = new TGMTcontrols.BrowseFile();
            this.label3 = new System.Windows.Forms.Label();
            this.workerPredict = new System.ComponentModel.BackgroundWorker();
            this.panelPicture = new System.Windows.Forms.Panel();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panelPicture.SuspendLayout();
            this.SuspendLayout();
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
            this.listView1.Location = new System.Drawing.Point(642, 83);
            this.listView1.MultiSelect = false;
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(345, 448);
            this.listView1.TabIndex = 35;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Idx";
            this.columnHeader1.Width = 40;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Class name";
            this.columnHeader2.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Score";
            this.columnHeader3.Width = 100;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(302, 158);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(240)))), ((int)(((byte)(250)))));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lbl_count);
            this.panel1.Controls.Add(this.chk_autoWarp);
            this.panel1.Controls.Add(this.chk_saveAnnotation);
            this.panel1.Controls.Add(this.circle1);
            this.panel1.Controls.Add(this.btn_predict);
            this.panel1.Controls.Add(this.txt_imagePath);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(987, 83);
            this.panel1.TabIndex = 37;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label1.Location = new System.Drawing.Point(100, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 19);
            this.label1.TabIndex = 19;
            this.label1.Text = "Auto warp (only 1 object)";
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lbl_count.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.lbl_count.Location = new System.Drawing.Point(354, 55);
            this.lbl_count.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(108, 19);
            this.lbl_count.TabIndex = 19;
            this.lbl_count.Text = "Save annotation";
            // 
            // chk_autoWarp
            // 
            this.chk_autoWarp.BorderColor = System.Drawing.Color.LightGray;
            this.chk_autoWarp.Checked = true;
            this.chk_autoWarp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chk_autoWarp.Location = new System.Drawing.Point(50, 51);
            this.chk_autoWarp.Name = "chk_autoWarp";
            this.chk_autoWarp.Size = new System.Drawing.Size(48, 26);
            this.chk_autoWarp.TabIndex = 12;
            this.chk_autoWarp.Text = "switchButton1";
            this.chk_autoWarp.TextEnabled = true;
            this.chk_autoWarp.CheckedChanged += new System.EventHandler(this.chk_autoWarp_CheckedChanged);
            this.chk_autoWarp.Click += new System.EventHandler(this.chk_saveAnnotation_Click);
            // 
            // chk_saveAnnotation
            // 
            this.chk_saveAnnotation.BorderColor = System.Drawing.Color.LightGray;
            this.chk_saveAnnotation.Checked = true;
            this.chk_saveAnnotation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.chk_saveAnnotation.Location = new System.Drawing.Point(304, 51);
            this.chk_saveAnnotation.Name = "chk_saveAnnotation";
            this.chk_saveAnnotation.Size = new System.Drawing.Size(48, 26);
            this.chk_saveAnnotation.TabIndex = 12;
            this.chk_saveAnnotation.Text = "switchButton1";
            this.chk_saveAnnotation.TextEnabled = true;
            this.chk_saveAnnotation.Click += new System.EventHandler(this.chk_saveAnnotation_Click);
            // 
            // circle1
            // 
            this.circle1.BackColor = System.Drawing.Color.Transparent;
            this.circle1.IndexColor = System.Drawing.Color.DeepSkyBlue;
            this.circle1.Interval = 50;
            this.circle1.Location = new System.Drawing.Point(780, 9);
            this.circle1.Name = "circle1";
            this.circle1.NCircle = 8;
            this.circle1.Others = System.Drawing.Color.LightGray;
            this.circle1.Radius = 3;
            this.circle1.Size = new System.Drawing.Size(39, 31);
            this.circle1.TabIndex = 11;
            this.circle1.Text = "processingControl1";
            this.circle1.Visible = false;
            // 
            // btn_predict
            // 
            this.btn_predict.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(168)))), ((int)(((byte)(183)))));
            this.btn_predict.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(164)))), ((int)(((byte)(183)))));
            this.btn_predict.BackColor = System.Drawing.Color.Transparent;
            this.btn_predict.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_predict.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_predict.ForeColor = System.Drawing.Color.White;
            this.btn_predict.Icon = null;
            this.btn_predict.ImageLocation = new System.Drawing.Point(0, 0);
            this.btn_predict.ImageSize = new System.Drawing.Size(0, 0);
            this.btn_predict.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(188)))), ((int)(((byte)(210)))));
            this.btn_predict.Inactive2 = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(167)))), ((int)(((byte)(188)))));
            this.btn_predict.Location = new System.Drawing.Point(675, 8);
            this.btn_predict.Name = "btn_predict";
            this.btn_predict.Radius = 6;
            this.btn_predict.Size = new System.Drawing.Size(98, 33);
            this.btn_predict.Stroke = 0;
            this.btn_predict.StrokeColor = System.Drawing.Color.Gray;
            this.btn_predict.TabIndex = 10;
            this.btn_predict.Text = "Predict";
            this.btn_predict.Transparency = false;
            this.btn_predict.Click += new System.EventHandler(this.btn_predict_Click);
            // 
            // txt_imagePath
            // 
            this.txt_imagePath.BackColor = System.Drawing.Color.Transparent;
            this.txt_imagePath.BackgroundColor = System.Drawing.Color.White;
            this.txt_imagePath.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(92)))), ((int)(((byte)(133)))), ((int)(((byte)(200)))));
            this.txt_imagePath.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txt_imagePath.ForeColor = System.Drawing.SystemColors.WindowText;
            this.txt_imagePath.Location = new System.Drawing.Point(106, 9);
            this.txt_imagePath.Name = "txt_imagePath";
            this.txt_imagePath.Padding = new System.Windows.Forms.Padding(5);
            this.txt_imagePath.Pattern = "";
            this.txt_imagePath.Size = new System.Drawing.Size(563, 31);
            this.txt_imagePath.TabIndex = 9;
            this.txt_imagePath.TextChanged += new System.EventHandler(this.txt_imagePath_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(66)))), ((int)(((byte)(139)))));
            this.label3.Location = new System.Drawing.Point(19, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 19);
            this.label3.TabIndex = 8;
            this.label3.Text = "Image path";
            // 
            // workerPredict
            // 
            this.workerPredict.DoWork += new System.ComponentModel.DoWorkEventHandler(this.workerPredict_DoWork);
            this.workerPredict.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.workerPredict_RunWorkerCompleted);
            // 
            // panelPicture
            // 
            this.panelPicture.Controls.Add(this.pictureBox1);
            this.panelPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPicture.Location = new System.Drawing.Point(0, 83);
            this.panelPicture.Name = "panelPicture";
            this.panelPicture.Size = new System.Drawing.Size(642, 448);
            this.panelPicture.TabIndex = 38;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Class";
            // 
            // FormImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 531);
            this.Controls.Add(this.panelPicture);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panel1);
            this.Name = "FormImage";
            this.Text = "FormImage";
            this.Load += new System.EventHandler(this.FormImage_Load);
            this.SizeChanged += new System.EventHandler(this.FormImage_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panelPicture.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion


        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private DefaultButton btn_predict;
        private BrowseFile txt_imagePath;
        private System.Windows.Forms.Label label3;
        private ProcessingControl circle1;
        private System.ComponentModel.BackgroundWorker workerPredict;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private SwitchButton chk_saveAnnotation;
        private System.Windows.Forms.Label lbl_count;
        private System.Windows.Forms.Label label1;
        private SwitchButton chk_autoWarp;
        private System.Windows.Forms.Panel panelPicture;
        private System.Windows.Forms.ColumnHeader columnHeader4;
    }
}