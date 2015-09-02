namespace RFIDScanSystem
{
    partial class frmScanning
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmScanning));
            this.plnMenu = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.lblWaitLoadCnt = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.ListView1_EPC = new System.Windows.Forms.ListView();
            this.CradNo = new System.Windows.Forms.ColumnHeader();
            this.ScanTime = new System.Windows.Forms.ColumnHeader();
            this.PrdctCD = new System.Windows.Forms.ColumnHeader();
            this.ReqstNum = new System.Windows.Forms.ColumnHeader();
            this.picAirPort = new System.Windows.Forms.PictureBox();
            this.picBattery = new System.Windows.Forms.PictureBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.stbSysInfo = new System.Windows.Forms.StatusBar();
            this.label1 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.lblScanCnt = new System.Windows.Forms.Label();
            this.timScan = new System.Windows.Forms.Timer();
            this.lblNotice = new System.Windows.Forms.Label();
            this.imgeStatus = new System.Windows.Forms.ImageList();
            this.timStatus = new System.Windows.Forms.Timer();
            this.timUploadTimer = new System.Windows.Forms.Timer();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.plnMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // plnMenu
            // 
            this.plnMenu.BackColor = System.Drawing.SystemColors.Highlight;
            this.plnMenu.Controls.Add(this.label3);
            this.plnMenu.Controls.Add(this.lblWaitLoadCnt);
            this.plnMenu.Controls.Add(this.lblTitle);
            this.plnMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.plnMenu.Location = new System.Drawing.Point(0, 0);
            this.plnMenu.Name = "plnMenu";
            this.plnMenu.Size = new System.Drawing.Size(242, 24);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Highlight;
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(124, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 18);
            this.label3.Text = "待上传:";
            // 
            // lblWaitLoadCnt
            // 
            this.lblWaitLoadCnt.BackColor = System.Drawing.Color.Aquamarine;
            this.lblWaitLoadCnt.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.lblWaitLoadCnt.ForeColor = System.Drawing.Color.Red;
            this.lblWaitLoadCnt.Location = new System.Drawing.Point(177, 3);
            this.lblWaitLoadCnt.Name = "lblWaitLoadCnt";
            this.lblWaitLoadCnt.Size = new System.Drawing.Size(60, 18);
            this.lblWaitLoadCnt.Text = "0";
            this.lblWaitLoadCnt.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(2, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(234, 22);
            this.lblTitle.Text = "部品扫描";
            // 
            // ListView1_EPC
            // 
            this.ListView1_EPC.Columns.Add(this.CradNo);
            this.ListView1_EPC.Columns.Add(this.ScanTime);
            this.ListView1_EPC.Columns.Add(this.PrdctCD);
            this.ListView1_EPC.Columns.Add(this.ReqstNum);
            this.ListView1_EPC.FullRowSelect = true;
            this.ListView1_EPC.Location = new System.Drawing.Point(0, 52);
            this.ListView1_EPC.Name = "ListView1_EPC";
            this.ListView1_EPC.Size = new System.Drawing.Size(233, 199);
            this.ListView1_EPC.TabIndex = 0;
            this.ListView1_EPC.View = System.Windows.Forms.View.Details;
            // 
            // CradNo
            // 
            this.CradNo.Text = "卡号";
            this.CradNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CradNo.Width = 65;
            // 
            // ScanTime
            // 
            this.ScanTime.Text = "扫描时间";
            this.ScanTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ScanTime.Width = 70;
            // 
            // PrdctCD
            // 
            this.PrdctCD.Text = "部品番号";
            this.PrdctCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PrdctCD.Width = 70;
            // 
            // ReqstNum
            // 
            this.ReqstNum.Text = "需求数量";
            this.ReqstNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ReqstNum.Width = 70;
            // 
            // picAirPort
            // 
            this.picAirPort.BackColor = System.Drawing.Color.Transparent;
            this.picAirPort.Image = ((System.Drawing.Image)(resources.GetObject("picAirPort.Image")));
            this.picAirPort.Location = new System.Drawing.Point(3, 27);
            this.picAirPort.Name = "picAirPort";
            this.picAirPort.Size = new System.Drawing.Size(21, 20);
            // 
            // picBattery
            // 
            this.picBattery.BackColor = System.Drawing.Color.Transparent;
            this.picBattery.Image = ((System.Drawing.Image)(resources.GetObject("picBattery.Image")));
            this.picBattery.Location = new System.Drawing.Point(215, 27);
            this.picBattery.Name = "picBattery";
            this.picBattery.Size = new System.Drawing.Size(21, 20);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(3, 252);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(69, 28);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "送信(S1)";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(167, 252);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(69, 28);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "退出(S2)";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // stbSysInfo
            // 
            this.stbSysInfo.Location = new System.Drawing.Point(0, 261);
            this.stbSysInfo.Name = "stbSysInfo";
            this.stbSysInfo.Size = new System.Drawing.Size(242, 24);
            this.stbSysInfo.Text = "操作者：admin|设备状态：采集";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(26, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.Text = "已扫描:";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(86, 252);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(69, 28);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "清空扫描";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // lblScanCnt
            // 
            this.lblScanCnt.BackColor = System.Drawing.Color.LightGray;
            this.lblScanCnt.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lblScanCnt.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblScanCnt.Location = new System.Drawing.Point(82, 28);
            this.lblScanCnt.Name = "lblScanCnt";
            this.lblScanCnt.Size = new System.Drawing.Size(59, 19);
            this.lblScanCnt.Tag = "";
            this.lblScanCnt.Text = "0";
            this.lblScanCnt.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            this.lblNotice.Location = new System.Drawing.Point(10, 282);
            this.lblNotice.Name = "lblNotice";
            this.lblNotice.Size = new System.Drawing.Size(213, 14);
            this.lblNotice.Text = "点击\"送信\"按钮完成当前扫描部品上传";
            this.imgeStatus.Images.Clear();
            this.imgeStatus.Images.Add(((System.Drawing.Image)(resources.GetObject("resource"))));
            this.imgeStatus.Images.Add(((System.Drawing.Image)(resources.GetObject("resource1"))));
            this.imgeStatus.Images.Add(((System.Drawing.Image)(resources.GetObject("resource2"))));
            this.imgeStatus.Images.Add(((System.Drawing.Image)(resources.GetObject("resource3"))));
            this.imgeStatus.Images.Add(((System.Drawing.Image)(resources.GetObject("resource4"))));
            this.imgeStatus.Images.Add(((System.Drawing.Image)(resources.GetObject("resource5"))));
            this.imgeStatus.Images.Add(((System.Drawing.Image)(resources.GetObject("resource6"))));
            // 
            // timStatus
            // 
            this.timStatus.Interval = 10000;
            this.timStatus.Tick += new System.EventHandler(this.timStatus_Tick);
            // 
            // timUploadTimer
            // 
            this.timUploadTimer.Interval = 30000;
            this.timUploadTimer.Tick += new System.EventHandler(this.tmrUploadTimer_Tick);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnRefresh.Location = new System.Drawing.Point(146, 26);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(67, 21);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "部品刷新";
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // frmScanning
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(242, 285);
            this.ControlBox = false;
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblNotice);
            this.Controls.Add(this.ListView1_EPC);
            this.Controls.Add(this.lblScanCnt);
            this.Controls.Add(this.stbSysInfo);
            this.Controls.Add(this.picAirPort);
            this.Controls.Add(this.picBattery);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.plnMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "frmScanning";
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
        internal System.Windows.Forms.PictureBox picAirPort;
        internal System.Windows.Forms.PictureBox picBattery;
        internal System.Windows.Forms.Button btnSend;
        internal System.Windows.Forms.Button btnExit;
        internal System.Windows.Forms.StatusBar stbSysInfo;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Button btnClear;
        internal System.Windows.Forms.Label lblWaitLoadCnt;
        internal System.Windows.Forms.Label label3;
        internal System.Windows.Forms.Label lblScanCnt;
        private System.Windows.Forms.ListView ListView1_EPC;
        private System.Windows.Forms.ColumnHeader CradNo;
        private System.Windows.Forms.ColumnHeader ScanTime;
        private System.Windows.Forms.Timer timScan;
        internal System.Windows.Forms.Label lblNotice;
        private System.Windows.Forms.ColumnHeader PrdctCD;
        private System.Windows.Forms.ColumnHeader ReqstNum;
        private System.Windows.Forms.ImageList imgeStatus;
        private System.Windows.Forms.Timer timStatus;
        private System.Windows.Forms.Timer timUploadTimer;
        internal System.Windows.Forms.Button btnRefresh;
    }
}

