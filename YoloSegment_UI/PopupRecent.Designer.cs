using System.Windows.Forms;

namespace YoloSegment
{
    partial class PopupRecent
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PopupRecent));
            this.timerProgressbar = new System.Windows.Forms.Timer(this.components);
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.timerClear = new System.Windows.Forms.Timer(this.components);
            this.worker1 = new System.ComponentModel.BackgroundWorker();
            this.panelSearch = new System.Windows.Forms.Panel();
            this.btn_delete = new TGMTcontrols.DangerButton();
            this.btn_ok = new TGMTcontrols.DefaultButton();
            this.listView1 = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerProgressbar
            // 
            this.timerProgressbar.Interval = 10;
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
            // panelSearch
            // 
            this.panelSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSearch.Controls.Add(this.btn_delete);
            this.panelSearch.Controls.Add(this.btn_ok);
            this.panelSearch.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelSearch.Location = new System.Drawing.Point(0, 323);
            this.panelSearch.Name = "panelSearch";
            this.panelSearch.Size = new System.Drawing.Size(982, 60);
            this.panelSearch.TabIndex = 78;
            // 
            // btn_delete
            // 
            this.btn_delete.Active1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btn_delete.Active2 = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btn_delete.BackColor = System.Drawing.Color.Transparent;
            this.btn_delete.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_delete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_delete.ForeColor = System.Drawing.Color.White;
            this.btn_delete.Icon = null;
            this.btn_delete.ImageLocation = new System.Drawing.Point(0, 0);
            this.btn_delete.ImageSize = new System.Drawing.Size(0, 0);
            this.btn_delete.Inactive1 = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_delete.Inactive2 = System.Drawing.Color.Red;
            this.btn_delete.Location = new System.Drawing.Point(493, 5);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Radius = 6;
            this.btn_delete.Size = new System.Drawing.Size(110, 40);
            this.btn_delete.Stroke = 0;
            this.btn_delete.StrokeColor = System.Drawing.Color.Gray;
            this.btn_delete.TabIndex = 28;
            this.btn_delete.Text = "Delete";
            this.btn_delete.Transparency = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.Active1 = System.Drawing.Color.DodgerBlue;
            this.btn_ok.Active2 = System.Drawing.Color.DeepSkyBlue;
            this.btn_ok.BackColor = System.Drawing.Color.Transparent;
            this.btn_ok.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_ok.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btn_ok.ForeColor = System.Drawing.Color.White;
            this.btn_ok.Icon = null;
            this.btn_ok.ImageLocation = new System.Drawing.Point(0, 0);
            this.btn_ok.ImageSize = new System.Drawing.Size(24, 24);
            this.btn_ok.Inactive1 = System.Drawing.Color.DeepSkyBlue;
            this.btn_ok.Inactive2 = System.Drawing.Color.DodgerBlue;
            this.btn_ok.Location = new System.Drawing.Point(374, 5);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Radius = 6;
            this.btn_ok.Size = new System.Drawing.Size(110, 40);
            this.btn_ok.Stroke = 0;
            this.btn_ok.StrokeColor = System.Drawing.Color.Gray;
            this.btn_ok.TabIndex = 27;
            this.btn_ok.Text = "OK";
            this.btn_ok.Transparency = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(982, 323);
            this.listView1.TabIndex = 79;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "ID";
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Value";
            this.columnHeader2.Width = 700;
            // 
            // PopupRecent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(982, 383);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.panelSearch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PopupRecent";
            this.Text = "Stream link";
            this.Load += new System.EventHandler(this.PopupRecent_Load);
            this.panelSearch.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer timerProgressbar;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.Timer timerClear;
        private System.ComponentModel.BackgroundWorker worker1;
        private Panel panelSearch;
        private TGMTcontrols.DefaultButton btn_ok;
        private ListView listView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private TGMTcontrols.DangerButton btn_delete;
    }
}

