namespace HandSetRegist
{
    partial class frmWinceReg
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.MainMenu mainMenu1;

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
            this.mainMenu1 = new System.Windows.Forms.MainMenu();
            this.btnWinceReg = new System.Windows.Forms.Button();
            this.txtTerminalNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.lblMsgInfo = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtTerminalName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnWinceReg
            // 
            this.btnWinceReg.Location = new System.Drawing.Point(25, 119);
            this.btnWinceReg.Name = "btnWinceReg";
            this.btnWinceReg.Size = new System.Drawing.Size(66, 29);
            this.btnWinceReg.TabIndex = 2;
            this.btnWinceReg.Text = "注册";
            this.btnWinceReg.Click += new System.EventHandler(this.btnWinceReg_Click);
            // 
            // txtTerminalNo
            // 
            this.txtTerminalNo.Location = new System.Drawing.Point(25, 44);
            this.txtTerminalNo.Name = "txtTerminalNo";
            this.txtTerminalNo.Size = new System.Drawing.Size(147, 23);
            this.txtTerminalNo.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(25, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.Text = "采集器编号：";
            // 
            // lblStatus
            // 
            this.lblStatus.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblStatus.Location = new System.Drawing.Point(25, 160);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(147, 18);
            this.lblStatus.Text = "未绑定采集器";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(106, 119);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 29);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "关闭";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // lblMsgInfo
            // 
            this.lblMsgInfo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lblMsgInfo.ForeColor = System.Drawing.Color.Red;
            this.lblMsgInfo.Location = new System.Drawing.Point(25, 84);
            this.lblMsgInfo.Name = "lblMsgInfo";
            this.lblMsgInfo.Size = new System.Drawing.Size(147, 15);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(147, 20);
            this.label1.Text = "采集器名称：";
            // 
            // txtTerminalName
            // 
            this.txtTerminalName.Location = new System.Drawing.Point(25, 90);
            this.txtTerminalName.Name = "txtTerminalName";
            this.txtTerminalName.Size = new System.Drawing.Size(147, 23);
            this.txtTerminalName.TabIndex = 1;
            // 
            // frmWinceReg
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(203, 187);
            this.Controls.Add(this.txtTerminalName);
            this.Controls.Add(this.txtTerminalNo);
            this.Controls.Add(this.lblMsgInfo);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnWinceReg);
            this.MaximizeBox = false;
            this.Name = "frmWinceReg";
            this.Text = "采集器注册";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmWinceReg_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnWinceReg;
        private System.Windows.Forms.TextBox txtTerminalNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label lblMsgInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtTerminalName;
    }
}

