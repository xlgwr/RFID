namespace AnXinWH.RFIDScan
{
    partial class frmLoadReader
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
      
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLoadReader));
            this.Canclebutton = new System.Windows.Forms.Button();
            this.AboutpictureBox = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.Loadlabel = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.plnMenu = new System.Windows.Forms.Panel();
            this.plnMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Canclebutton
            // 
            this.Canclebutton.Location = new System.Drawing.Point(167, 213);
            this.Canclebutton.Name = "Canclebutton";
            this.Canclebutton.Size = new System.Drawing.Size(69, 28);
            this.Canclebutton.TabIndex = 0;
            this.Canclebutton.Text = "取消";
            this.Canclebutton.Click += new System.EventHandler(this.Canclebutton_Click);
            // 
            // AboutpictureBox
            // 
            this.AboutpictureBox.Image = ((System.Drawing.Image)(resources.GetObject("AboutpictureBox.Image")));
            this.AboutpictureBox.Location = new System.Drawing.Point(0, 24);
            this.AboutpictureBox.Name = "AboutpictureBox";
            this.AboutpictureBox.Size = new System.Drawing.Size(238, 87);
            this.AboutpictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(0, 115);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(238, 20);
            // 
            // Loadlabel
            // 
            this.Loadlabel.Location = new System.Drawing.Point(0, 159);
            this.Loadlabel.Name = "Loadlabel";
            this.Loadlabel.Size = new System.Drawing.Size(238, 48);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(2, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(234, 22);
            this.lblTitle.Text = "系统初始化";
            // 
            // plnMenu
            // 
            this.plnMenu.BackColor = System.Drawing.SystemColors.Highlight;
            this.plnMenu.Controls.Add(this.lblTitle);
            this.plnMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.plnMenu.Location = new System.Drawing.Point(0, 0);
            this.plnMenu.Name = "plnMenu";
            this.plnMenu.Size = new System.Drawing.Size(240, 24);
            // 
            // frmLoadReader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 295);
            this.ControlBox = false;
            this.Controls.Add(this.plnMenu);
            this.Controls.Add(this.Canclebutton);
            this.Controls.Add(this.Loadlabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.AboutpictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmLoadReader";
            this.Text = "LoadReader";
            this.Load += new System.EventHandler(this.LoadForm_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.LoadForm_Closing);
            this.plnMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Canclebutton;
        private System.Windows.Forms.PictureBox AboutpictureBox;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label Loadlabel;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Panel plnMenu;
    }
}