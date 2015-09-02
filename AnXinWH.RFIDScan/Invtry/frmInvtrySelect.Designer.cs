namespace AnXinWH.RFIDScan
{
    partial class frmInvtrySelect
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.listView1 = new System.Windows.Forms.ListView();
            this.InventoryNo = new System.Windows.Forms.ColumnHeader();
            this.totalcount = new System.Windows.Forms.ColumnHeader();
            this.InventStatus = new System.Windows.Forms.ColumnHeader();
            this.InventBeginDate = new System.Windows.Forms.ColumnHeader();
            this.InventEndDate = new System.Windows.Forms.ColumnHeader();
            this.plnMenu = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblINvtryNo = new System.Windows.Forms.Label();
            this.lblgo = new System.Windows.Forms.LinkLabel();
            this.lblnext = new System.Windows.Forms.LinkLabel();
            this.lblmax = new System.Windows.Forms.LinkLabel();
            this.lblpre = new System.Windows.Forms.LinkLabel();
            this.lblfirst = new System.Windows.Forms.LinkLabel();
            this.lblpage = new System.Windows.Forms.Label();
            this.txtPages = new System.Windows.Forms.TextBox();
            this.lbltotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.plnMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button1.Location = new System.Drawing.Point(7, 259);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(106, 28);
            this.button1.TabIndex = 2;
            this.button1.Text = "计划选择(S1)";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button2.Location = new System.Drawing.Point(126, 259);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 28);
            this.button2.TabIndex = 3;
            this.button2.Text = "返回(S2)";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // listView1
            // 
            this.listView1.Columns.Add(this.InventoryNo);
            this.listView1.Columns.Add(this.totalcount);
            this.listView1.Columns.Add(this.InventStatus);
            this.listView1.Columns.Add(this.InventBeginDate);
            this.listView1.Columns.Add(this.InventEndDate);
            this.listView1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(3, 27);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(232, 186);
            this.listView1.TabIndex = 0;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // InventoryNo
            // 
            this.InventoryNo.Text = "盘点号";
            this.InventoryNo.Width = 91;
            // 
            // totalcount
            // 
            this.totalcount.Text = "总数";
            this.totalcount.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.totalcount.Width = 60;
            // 
            // InventStatus
            // 
            this.InventStatus.Text = "盘点状态";
            this.InventStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.InventStatus.Width = 80;
            // 
            // InventBeginDate
            // 
            this.InventBeginDate.Text = "开始日期";
            this.InventBeginDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.InventBeginDate.Width = 120;
            // 
            // InventEndDate
            // 
            this.InventEndDate.Text = "结束日期";
            this.InventEndDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.InventEndDate.Width = 120;
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
            this.lblTitle.Text = "盘点计划选择";
            // 
            // lblINvtryNo
            // 
            this.lblINvtryNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lblINvtryNo.Location = new System.Drawing.Point(59, 243);
            this.lblINvtryNo.Name = "lblINvtryNo";
            this.lblINvtryNo.Size = new System.Drawing.Size(77, 16);
            // 
            // lblgo
            // 
            this.lblgo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.lblgo.Location = new System.Drawing.Point(70, 221);
            this.lblgo.Name = "lblgo";
            this.lblgo.Size = new System.Drawing.Size(28, 22);
            this.lblgo.TabIndex = 36;
            this.lblgo.Text = "GO";
            this.lblgo.Click += new System.EventHandler(this.lblgo_Click);
            // 
            // lblnext
            // 
            this.lblnext.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.lblnext.Location = new System.Drawing.Point(96, 221);
            this.lblnext.Name = "lblnext";
            this.lblnext.Size = new System.Drawing.Size(17, 16);
            this.lblnext.TabIndex = 35;
            this.lblnext.Text = ">";
            this.lblnext.Click += new System.EventHandler(this.lblnext_Click);
            // 
            // lblmax
            // 
            this.lblmax.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.lblmax.Location = new System.Drawing.Point(115, 221);
            this.lblmax.Name = "lblmax";
            this.lblmax.Size = new System.Drawing.Size(23, 16);
            this.lblmax.TabIndex = 34;
            this.lblmax.Text = ">|";
            this.lblmax.Click += new System.EventHandler(this.lblmax_Click);
            // 
            // lblpre
            // 
            this.lblpre.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.lblpre.Location = new System.Drawing.Point(24, 221);
            this.lblpre.Name = "lblpre";
            this.lblpre.Size = new System.Drawing.Size(17, 16);
            this.lblpre.TabIndex = 33;
            this.lblpre.Text = "<";
            this.lblpre.Click += new System.EventHandler(this.lblpre_Click);
            // 
            // lblfirst
            // 
            this.lblfirst.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.lblfirst.Location = new System.Drawing.Point(2, 221);
            this.lblfirst.Name = "lblfirst";
            this.lblfirst.Size = new System.Drawing.Size(23, 16);
            this.lblfirst.TabIndex = 32;
            this.lblfirst.Text = "|<";
            this.lblfirst.Click += new System.EventHandler(this.lblfirst_Click);
            // 
            // lblpage
            // 
            this.lblpage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lblpage.ForeColor = System.Drawing.Color.Blue;
            this.lblpage.Location = new System.Drawing.Point(195, 222);
            this.lblpage.Name = "lblpage";
            this.lblpage.Size = new System.Drawing.Size(37, 16);
            this.lblpage.Text = "0/0";
            // 
            // txtPages
            // 
            this.txtPages.AcceptsTab = true;
            this.txtPages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPages.ForeColor = System.Drawing.Color.Blue;
            this.txtPages.Location = new System.Drawing.Point(45, 219);
            this.txtPages.MaxLength = 3;
            this.txtPages.Name = "txtPages";
            this.txtPages.Size = new System.Drawing.Size(25, 23);
            this.txtPages.TabIndex = 1;
            // 
            // lbltotal
            // 
            this.lbltotal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbltotal.Location = new System.Drawing.Point(194, 243);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(36, 16);
            this.lbltotal.Text = "0";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(149, 243);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.Text = "合计：";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(150, 222);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.Text = "当前：";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(2, 243);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 16);
            this.label1.Text = "盘点号：";
            // 
            // frmInvtrySelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lblINvtryNo);
            this.Controls.Add(this.lblgo);
            this.Controls.Add(this.lblnext);
            this.Controls.Add(this.lblmax);
            this.Controls.Add(this.lblpre);
            this.Controls.Add(this.lblfirst);
            this.Controls.Add(this.lblpage);
            this.Controls.Add(this.txtPages);
            this.Controls.Add(this.lbltotal);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.plnMenu);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "frmInvtrySelect";
            this.Text = "盘点计划列表";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmInvtrySelect_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInvtrySelect_KeyDown);
            this.plnMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader InventoryNo;
        private System.Windows.Forms.ColumnHeader InventBeginDate;
        private System.Windows.Forms.ColumnHeader InventEndDate;
        private System.Windows.Forms.ColumnHeader InventStatus;
        private System.Windows.Forms.ColumnHeader totalcount;
        internal System.Windows.Forms.Panel plnMenu;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblINvtryNo;
        private System.Windows.Forms.LinkLabel lblgo;
        private System.Windows.Forms.LinkLabel lblnext;
        private System.Windows.Forms.LinkLabel lblmax;
        private System.Windows.Forms.LinkLabel lblpre;
        private System.Windows.Forms.LinkLabel lblfirst;
        private System.Windows.Forms.Label lblpage;
        private System.Windows.Forms.TextBox txtPages;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label1;
    }
}