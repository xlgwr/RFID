namespace AnXinWH.RFIDScan
{
    partial class frmInvtryDetail
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.listView1 = new System.Windows.Forms.ListView();
            this.MakeNumbers = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.InventStatus = new System.Windows.Forms.ColumnHeader();
            this.DocNo = new System.Windows.Forms.ColumnHeader();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.listView2 = new System.Windows.Forms.ListView();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.listView3 = new System.Windows.Forms.ListView();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.lblINvtryNo = new System.Windows.Forms.Label();
            this.lbltotal = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEndIntrv = new System.Windows.Forms.Button();
            this.btnBack = new System.Windows.Forms.Button();
            this.btnStartInvr = new System.Windows.Forms.Button();
            this.lblpage = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPages = new System.Windows.Forms.TextBox();
            this.lblfirst = new System.Windows.Forms.LinkLabel();
            this.lblpre = new System.Windows.Forms.LinkLabel();
            this.lblnext = new System.Windows.Forms.LinkLabel();
            this.lblmax = new System.Windows.Forms.LinkLabel();
            this.lblgo = new System.Windows.Forms.LinkLabel();
            this.plnMenu = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.plnMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.tabControl1.Location = new System.Drawing.Point(4, 24);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(232, 185);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.listView1);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(224, 158);
            this.tabPage1.Text = "详单";
            // 
            // listView1
            // 
            this.listView1.Columns.Add(this.MakeNumbers);
            this.listView1.Columns.Add(this.columnHeader8);
            this.listView1.Columns.Add(this.columnHeader7);
            this.listView1.Columns.Add(this.InventStatus);
            this.listView1.Columns.Add(this.DocNo);
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(224, 158);
            this.listView1.TabIndex = 2;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // MakeNumbers
            // 
            this.MakeNumbers.Text = "制作番号";
            this.MakeNumbers.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MakeNumbers.Width = 100;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "主标题";
            this.columnHeader8.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader8.Width = 120;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "图册名称";
            this.columnHeader7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader7.Width = 120;
            // 
            // InventStatus
            // 
            this.InventStatus.Text = "状态";
            this.InventStatus.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.InventStatus.Width = 80;
            // 
            // DocNo
            // 
            this.DocNo.Text = "图册编号";
            this.DocNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DocNo.Width = 80;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.listView2);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(224, 158);
            this.tabPage2.Text = "正常";
            // 
            // listView2
            // 
            this.listView2.Columns.Add(this.columnHeader2);
            this.listView2.Columns.Add(this.columnHeader9);
            this.listView2.Columns.Add(this.columnHeader10);
            this.listView2.Columns.Add(this.columnHeader3);
            this.listView2.Columns.Add(this.columnHeader1);
            this.listView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.listView2.Location = new System.Drawing.Point(0, 0);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(224, 158);
            this.listView2.TabIndex = 3;
            this.listView2.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "制作番号";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 100;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "图册名称";
            this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader9.Width = 120;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "主标题";
            this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader10.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "状态";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader3.Width = 80;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "图册编号";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader1.Width = 80;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.listView3);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(224, 158);
            this.tabPage3.Text = "异常";
            // 
            // listView3
            // 
            this.listView3.Columns.Add(this.columnHeader5);
            this.listView3.Columns.Add(this.columnHeader11);
            this.listView3.Columns.Add(this.columnHeader12);
            this.listView3.Columns.Add(this.columnHeader6);
            this.listView3.Columns.Add(this.columnHeader4);
            this.listView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.listView3.Location = new System.Drawing.Point(0, 0);
            this.listView3.Name = "listView3";
            this.listView3.Size = new System.Drawing.Size(224, 158);
            this.listView3.TabIndex = 3;
            this.listView3.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "制作番号";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader5.Width = 100;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "图册名称";
            this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader11.Width = 120;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "主标题";
            this.columnHeader12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader12.Width = 120;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "状态";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader6.Width = 80;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "图册编号";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 80;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(4, 239);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 16);
            this.label1.Text = "盘点号：";
            // 
            // lblINvtryNo
            // 
            this.lblINvtryNo.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lblINvtryNo.Location = new System.Drawing.Point(63, 239);
            this.lblINvtryNo.Name = "lblINvtryNo";
            this.lblINvtryNo.Size = new System.Drawing.Size(77, 16);
            // 
            // lbltotal
            // 
            this.lbltotal.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lbltotal.Location = new System.Drawing.Point(192, 238);
            this.lbltotal.Name = "lbltotal";
            this.lbltotal.Size = new System.Drawing.Size(36, 16);
            this.lbltotal.Text = "0";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(147, 238);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 16);
            this.label4.Text = "合计：";
            // 
            // btnEndIntrv
            // 
            this.btnEndIntrv.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnEndIntrv.Location = new System.Drawing.Point(86, 258);
            this.btnEndIntrv.Name = "btnEndIntrv";
            this.btnEndIntrv.Size = new System.Drawing.Size(69, 28);
            this.btnEndIntrv.TabIndex = 3;
            this.btnEndIntrv.Text = "完成盘点";
            this.btnEndIntrv.Click += new System.EventHandler(this.btnEndIntrv_Click);
            // 
            // btnBack
            // 
            this.btnBack.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnBack.Location = new System.Drawing.Point(168, 258);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(69, 28);
            this.btnBack.TabIndex = 4;
            this.btnBack.Text = "返回(S2)";
            this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
            // 
            // btnStartInvr
            // 
            this.btnStartInvr.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.btnStartInvr.Location = new System.Drawing.Point(7, 258);
            this.btnStartInvr.Name = "btnStartInvr";
            this.btnStartInvr.Size = new System.Drawing.Size(69, 28);
            this.btnStartInvr.TabIndex = 2;
            this.btnStartInvr.Text = "开始(S1)";
            this.btnStartInvr.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblpage
            // 
            this.lblpage.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.lblpage.ForeColor = System.Drawing.Color.Blue;
            this.lblpage.Location = new System.Drawing.Point(191, 216);
            this.lblpage.Name = "lblpage";
            this.lblpage.Size = new System.Drawing.Size(37, 16);
            this.lblpage.Text = "0/0";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.label6.Location = new System.Drawing.Point(148, 217);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 16);
            this.label6.Text = "当前：";
            // 
            // txtPages
            // 
            this.txtPages.AcceptsTab = true;
            this.txtPages.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPages.ForeColor = System.Drawing.Color.Blue;
            this.txtPages.Location = new System.Drawing.Point(43, 214);
            this.txtPages.MaxLength = 3;
            this.txtPages.Name = "txtPages";
            this.txtPages.Size = new System.Drawing.Size(25, 23);
            this.txtPages.TabIndex = 1;
            this.txtPages.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPages_KeyUp);
            // 
            // lblfirst
            // 
            this.lblfirst.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.lblfirst.Location = new System.Drawing.Point(0, 216);
            this.lblfirst.Name = "lblfirst";
            this.lblfirst.Size = new System.Drawing.Size(23, 16);
            this.lblfirst.TabIndex = 20;
            this.lblfirst.Text = "|<";
            this.lblfirst.Click += new System.EventHandler(this.lblfirst_Click);
            // 
            // lblpre
            // 
            this.lblpre.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.lblpre.Location = new System.Drawing.Point(22, 216);
            this.lblpre.Name = "lblpre";
            this.lblpre.Size = new System.Drawing.Size(17, 16);
            this.lblpre.TabIndex = 21;
            this.lblpre.Text = "<";
            this.lblpre.Click += new System.EventHandler(this.lblpre_Click);
            // 
            // lblnext
            // 
            this.lblnext.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.lblnext.Location = new System.Drawing.Point(94, 216);
            this.lblnext.Name = "lblnext";
            this.lblnext.Size = new System.Drawing.Size(17, 16);
            this.lblnext.TabIndex = 23;
            this.lblnext.Text = ">";
            this.lblnext.Click += new System.EventHandler(this.lblnext_Click);
            // 
            // lblmax
            // 
            this.lblmax.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.lblmax.Location = new System.Drawing.Point(113, 216);
            this.lblmax.Name = "lblmax";
            this.lblmax.Size = new System.Drawing.Size(23, 16);
            this.lblmax.TabIndex = 22;
            this.lblmax.Text = ">|";
            this.lblmax.Click += new System.EventHandler(this.lblmax_Click);
            // 
            // lblgo
            // 
            this.lblgo.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Regular);
            this.lblgo.Location = new System.Drawing.Point(68, 216);
            this.lblgo.Name = "lblgo";
            this.lblgo.Size = new System.Drawing.Size(28, 22);
            this.lblgo.TabIndex = 24;
            this.lblgo.Text = "GO";
            this.lblgo.Click += new System.EventHandler(this.lblgo_Click);
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
            this.lblTitle.Text = "盘点详细";
            // 
            // frmInvtryDetail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 295);
            this.ControlBox = false;
            this.Controls.Add(this.lblINvtryNo);
            this.Controls.Add(this.plnMenu);
            this.Controls.Add(this.btnStartInvr);
            this.Controls.Add(this.btnEndIntrv);
            this.Controls.Add(this.lblgo);
            this.Controls.Add(this.btnBack);
            this.Controls.Add(this.lblnext);
            this.Controls.Add(this.lblmax);
            this.Controls.Add(this.lblpre);
            this.Controls.Add(this.lblfirst);
            this.Controls.Add(this.lblpage);
            this.Controls.Add(this.txtPages);
            this.Controls.Add(this.lbltotal);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "frmInvtryDetail";
            this.Text = "盘点详细";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmInvtryDetail_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmInvtryDetail_KeyDown);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.plnMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblINvtryNo;
        private System.Windows.Forms.Label lbltotal;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnEndIntrv;
        private System.Windows.Forms.Button btnBack;
        private System.Windows.Forms.Button btnStartInvr;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader DocNo;
        private System.Windows.Forms.ColumnHeader MakeNumbers;
        private System.Windows.Forms.ColumnHeader InventStatus;
        private System.Windows.Forms.Label lblpage;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPages;
        private System.Windows.Forms.LinkLabel lblfirst;
        private System.Windows.Forms.LinkLabel lblpre;
        private System.Windows.Forms.LinkLabel lblnext;
        private System.Windows.Forms.LinkLabel lblmax;
        private System.Windows.Forms.LinkLabel lblgo;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ListView listView3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        internal System.Windows.Forms.Panel plnMenu;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
    }
}