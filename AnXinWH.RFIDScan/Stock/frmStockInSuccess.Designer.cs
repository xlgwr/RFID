namespace AnXinWH.RFIDScan.Stock
{
    partial class frmStockInSuccess
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
            this.lnlTotal = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.plnMenu = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.col1RFIDNo = new System.Windows.Forms.ColumnHeader();
            this.listView1 = new System.Windows.Forms.ListView();
            this.col2shelf_no = new System.Windows.Forms.ColumnHeader();
            this.txt1RfidNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt2ShelfNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl0Count = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.plnMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lnlTotal
            // 
            this.lnlTotal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lnlTotal.ForeColor = System.Drawing.Color.Red;
            this.lnlTotal.Location = new System.Drawing.Point(2, 233);
            this.lnlTotal.Name = "lnlTotal";
            this.lnlTotal.Size = new System.Drawing.Size(234, 22);
            this.lnlTotal.Text = "正在提交数据：";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button3.Location = new System.Drawing.Point(147, 258);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 28);
            this.button3.TabIndex = 2;
            this.button3.Text = "取消(S2)";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button2.Location = new System.Drawing.Point(37, 258);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 28);
            this.button2.TabIndex = 1;
            this.button2.Text = "提交(S1)";
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.lblTitle.Text = "货物上架";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // col1RFIDNo
            // 
            this.col1RFIDNo.Text = "RFID卡号";
            this.col1RFIDNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col1RFIDNo.Width = 139;
            // 
            // listView1
            // 
            this.listView1.Columns.Add(this.col1RFIDNo);
            this.listView1.Columns.Add(this.col2shelf_no);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 90);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(238, 141);
            this.listView1.TabIndex = 0;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // col2shelf_no
            // 
            this.col2shelf_no.Text = "货架番号";
            this.col2shelf_no.Width = 91;
            // 
            // txt1RfidNo
            // 
            this.txt1RfidNo.Location = new System.Drawing.Point(87, 37);
            this.txt1RfidNo.Name = "txt1RfidNo";
            this.txt1RfidNo.Size = new System.Drawing.Size(139, 23);
            this.txt1RfidNo.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.Text = "RFID卡号";
            // 
            // txt2ShelfNo
            // 
            this.txt2ShelfNo.Location = new System.Drawing.Point(87, 61);
            this.txt2ShelfNo.Name = "txt2ShelfNo";
            this.txt2ShelfNo.Size = new System.Drawing.Size(139, 23);
            this.txt2ShelfNo.TabIndex = 11;
            this.txt2ShelfNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt21ctnno_no_KeyDown);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(19, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.Text = "货架番号";
            // 
            // lbl0Count
            // 
            this.lbl0Count.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl0Count.ForeColor = System.Drawing.Color.Red;
            this.lbl0Count.Location = new System.Drawing.Point(114, 92);
            this.lbl0Count.Name = "lbl0Count";
            this.lbl0Count.Size = new System.Drawing.Size(24, 15);
            this.lbl0Count.Text = "0";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // frmStockInSuccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lbl0Count);
            this.Controls.Add(this.txt2ShelfNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt1RfidNo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.plnMenu);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.lnlTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "frmStockInSuccess";
            this.Text = "盘点项目";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmInvtryScan_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInvtryScan_KeyDown);
            this.plnMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lnlTotal;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        internal System.Windows.Forms.Panel plnMenu;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ColumnHeader col1RFIDNo;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox txt1RfidNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt2ShelfNo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ColumnHeader col2shelf_no;
        private System.Windows.Forms.Label lbl0Count;
        private System.Windows.Forms.Timer timer1;
    }
}