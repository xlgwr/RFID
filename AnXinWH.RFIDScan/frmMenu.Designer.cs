﻿namespace AnXinWH.RFIDScan
{
    partial class frmMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMenu));
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.plnMenu = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.picAirPort = new System.Windows.Forms.PictureBox();
            this.picBattery = new System.Windows.Forms.PictureBox();
            this.timStatus = new System.Windows.Forms.Timer();
            this.plnMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(69, 72);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(108, 41);
            this.button1.TabIndex = 0;
            this.button1.Text = "图纸盘点";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(69, 136);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(108, 41);
            this.button2.TabIndex = 1;
            this.button2.Text = "图纸归还";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(69, 200);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(108, 41);
            this.button3.TabIndex = 2;
            this.button3.Text = "注销登录";
            this.button3.Click += new System.EventHandler(this.button3_Click);
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
            this.lblTitle.Text = "菜单";
            // 
            // picAirPort
            // 
            this.picAirPort.BackColor = System.Drawing.Color.Transparent;
            this.picAirPort.Image = ((System.Drawing.Image)(resources.GetObject("picAirPort.Image")));
            this.picAirPort.Location = new System.Drawing.Point(3, 29);
            this.picAirPort.Name = "picAirPort";
            this.picAirPort.Size = new System.Drawing.Size(21, 20);
            // 
            // picBattery
            // 
            this.picBattery.BackColor = System.Drawing.Color.Transparent;
            this.picBattery.Image = ((System.Drawing.Image)(resources.GetObject("picBattery.Image")));
            this.picBattery.Location = new System.Drawing.Point(215, 29);
            this.picBattery.Name = "picBattery";
            this.picBattery.Size = new System.Drawing.Size(21, 20);
            // 
            // timStatus
            // 
            this.timStatus.Interval = 10000;
            this.timStatus.Tick += new System.EventHandler(this.timStatus_Tick);
            // 
            // frmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 295);
            this.ControlBox = false;
            this.Controls.Add(this.picAirPort);
            this.Controls.Add(this.picBattery);
            this.Controls.Add(this.plnMenu);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmMenu";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmMenu_Load);
            this.plnMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        internal System.Windows.Forms.Panel plnMenu;
        internal System.Windows.Forms.Label lblTitle;
        internal System.Windows.Forms.PictureBox picAirPort;
        internal System.Windows.Forms.PictureBox picBattery;
        private System.Windows.Forms.Timer timStatus;
    }
}