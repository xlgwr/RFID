namespace AnXinWH.RFIDScan
{
    partial class frmLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmLogin));
            this.plnMenu = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picAirPort = new System.Windows.Forms.PictureBox();
            this.picBattery = new System.Windows.Forms.PictureBox();
            this.txtPaswd = new System.Windows.Forms.TextBox();
            this.lblPswd = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtUserId = new System.Windows.Forms.TextBox();
            this.lblDeviceInfo = new System.Windows.Forms.Label();
            this.lblVersion = new System.Windows.Forms.Label();
            this.lblUserId = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.imgeStatus = new System.Windows.Forms.ImageList();
            this.timStatus = new System.Windows.Forms.Timer();
            this.button1 = new System.Windows.Forms.Button();
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
            this.lblTitle.Text = "用户登录";
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
            // txtPaswd
            // 
            this.txtPaswd.Location = new System.Drawing.Point(18, 132);
            this.txtPaswd.MaxLength = 20;
            this.txtPaswd.Name = "txtPaswd";
            this.txtPaswd.PasswordChar = '*';
            this.txtPaswd.Size = new System.Drawing.Size(204, 23);
            this.txtPaswd.TabIndex = 10;
            // 
            // lblPswd
            // 
            this.lblPswd.Location = new System.Drawing.Point(18, 112);
            this.lblPswd.Name = "lblPswd";
            this.lblPswd.Size = new System.Drawing.Size(204, 20);
            this.lblPswd.Text = "密码输入:";
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(18, 187);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(99, 35);
            this.btnLogin.TabIndex = 11;
            this.btnLogin.Text = "用户登录(S2)";
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtUserId
            // 
            this.txtUserId.Location = new System.Drawing.Point(18, 86);
            this.txtUserId.MaxLength = 20;
            this.txtUserId.Name = "txtUserId";
            this.txtUserId.Size = new System.Drawing.Size(204, 23);
            this.txtUserId.TabIndex = 9;
            // 
            // lblDeviceInfo
            // 
            this.lblDeviceInfo.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblDeviceInfo.Location = new System.Drawing.Point(18, 159);
            this.lblDeviceInfo.Name = "lblDeviceInfo";
            this.lblDeviceInfo.Size = new System.Drawing.Size(196, 25);
            // 
            // lblVersion
            // 
            this.lblVersion.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lblVersion.Location = new System.Drawing.Point(172, 271);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(63, 20);
            this.lblVersion.Text = "Ver 1.0.0";
            // 
            // lblUserId
            // 
            this.lblUserId.Location = new System.Drawing.Point(18, 63);
            this.lblUserId.Name = "lblUserId";
            this.lblUserId.Size = new System.Drawing.Size(204, 20);
            this.lblUserId.Text = "用户编号输入:";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.Label1.Location = new System.Drawing.Point(96, 271);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(73, 20);
            this.Label1.Text = "版本号： ";
            this.Label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 187);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 35);
            this.button1.TabIndex = 11;
            this.button1.Text = "退出系统";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(240, 295);
            this.ControlBox = false;
            this.Controls.Add(this.picAirPort);
            this.Controls.Add(this.picBattery);
            this.Controls.Add(this.txtPaswd);
            this.Controls.Add(this.lblPswd);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.txtUserId);
            this.Controls.Add(this.lblDeviceInfo);
            this.Controls.Add(this.lblVersion);
            this.Controls.Add(this.lblUserId);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.plnMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MinimizeBox = false;
            this.Name = "frmLogin";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmLogin_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmLogin_KeyDown);
            this.plnMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Panel plnMenu;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.PictureBox picAirPort;
        internal System.Windows.Forms.PictureBox picBattery;
        internal System.Windows.Forms.TextBox txtPaswd;
        internal System.Windows.Forms.Label lblPswd;
        internal System.Windows.Forms.Button btnLogin;
        internal System.Windows.Forms.TextBox txtUserId;
        internal System.Windows.Forms.Label lblDeviceInfo;
        internal System.Windows.Forms.Label lblVersion;
        internal System.Windows.Forms.Label lblUserId;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.ImageList imgeStatus;
        private System.Windows.Forms.Timer timStatus;
        internal System.Windows.Forms.Button button1;
    }
}

