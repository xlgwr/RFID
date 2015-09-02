namespace AnXinWH.RFIDScan
{
    partial class frmScanDoc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScanDoc));
            this.plnMenu = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timScan = new System.Windows.Forms.Timer();
            this.lblNotice = new System.Windows.Forms.Label();
            this.imgeStatus = new System.Windows.Forms.ImageList();
            this.txtFilterCardNo = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.cbxReadPower = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.plnMenu.SuspendLayout();
            this.SuspendLayout();
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
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(2, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(234, 22);
            this.lblTitle.Text = "图册定位扫描";
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnExit.Location = new System.Drawing.Point(129, 213);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(102, 28);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "退出(S2)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(7, 62);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 20);
            this.label1.Text = "定位图册编号:";
            // 
            // timScan
            // 
            this.timScan.Interval = 50;
            this.timScan.Tick += new System.EventHandler(this.timScan_Tick);
            // 
            // lblNotice
            // 
            this.lblNotice.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lblNotice.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblNotice.Location = new System.Drawing.Point(7, 256);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(213, 14);
            this.lblNotice.Text = "搜索到指定图册后，扫描自动停止";
            this.imgeStatus.Images.Clear();
            this.imgeStatus.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imgeStatus.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.imgeStatus.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            this.imgeStatus.Images.Add(((System.Drawing.Image)(resources.GetObject("resource3"))));
            this.imgeStatus.Images.Add(((System.Drawing.Image)(resources.GetObject("resource4"))));
            this.imgeStatus.Images.Add(((System.Drawing.Image)(resources.GetObject("resource5"))));
            this.imgeStatus.Images.Add(((System.Drawing.Image)(resources.GetObject("resource6"))));
            // 
            // txtFilterCardNo
            // 
            this.txtFilterCardNo.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.txtFilterCardNo.Location = new System.Drawing.Point(7, 84);
            this.txtFilterCardNo.Name = "txtFilterCardNo";
            this.txtFilterCardNo.Size = new System.Drawing.Size(154, 26);
            this.txtFilterCardNo.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button1.Location = new System.Drawing.Point(7, 213);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 28);
            this.button1.TabIndex = 3;
            this.button1.Text = "扫描(S1)";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(7, 176);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(213, 34);
            this.label3.Text = "已扫描到需要定位的RFID卡，扫描停止！";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button2.Location = new System.Drawing.Point(167, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 28);
            this.button2.TabIndex = 2;
            this.button2.Text = "查询";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbxReadPower
            // 
            this.cbxReadPower.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular);
            this.cbxReadPower.Items.Add("5");
            this.cbxReadPower.Items.Add("10");
            this.cbxReadPower.Items.Add("15");
            this.cbxReadPower.Items.Add("20");
            this.cbxReadPower.Items.Add("23");
            this.cbxReadPower.Location = new System.Drawing.Point(115, 30);
            this.cbxReadPower.Name = "cbxReadPower";
            this.cbxReadPower.Size = new System.Drawing.Size(94, 26);
            this.cbxReadPower.TabIndex = 0;
            this.cbxReadPower.SelectedIndexChanged += new System.EventHandler(this.cbxReadPower_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(7, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(102, 16);
            this.label2.Text = "功率选择";
            // 
            // frmScanDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 295);
            this.ControlBox = false;
            this.Controls.Add(this.cbxReadPower);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblNotice);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.plnMenu);
            this.Controls.Add(this.txtFilterCardNo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "frmScanDoc";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmScanning_Load);
            this.Closing += new System.ComponentModel.CancelEventHandler(this.frmScanning_Closing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmScanning_KeyDown);
            this.plnMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel plnMenu;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timScan;
        internal System.Windows.Forms.Label lblNotice;
        private System.Windows.Forms.ImageList imgeStatus;
        private System.Windows.Forms.TextBox txtFilterCardNo;
        internal System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox cbxReadPower;
        private System.Windows.Forms.Label label2;
    }
}

