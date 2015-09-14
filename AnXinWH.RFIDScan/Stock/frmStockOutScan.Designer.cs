namespace AnXinWH.RFIDScan.Stock
{
    partial class frmStockOutScan
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
            this.timer1 = new System.Windows.Forms.Timer();
            this.plnMenu = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.col1RFIDNo = new System.Windows.Forms.ColumnHeader();
            this.col3qty = new System.Windows.Forms.ColumnHeader();
            this.col3Weight = new System.Windows.Forms.ColumnHeader();
            this.listView1 = new System.Windows.Forms.ListView();
            this.col2pqty = new System.Windows.Forms.ColumnHeader();
            this.label1 = new System.Windows.Forms.Label();
            this.txt11stockout_id = new System.Windows.Forms.TextBox();
            this.txt12Rfid_no = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt13Shelf_no = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt4Qty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt5nwet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt21pqty = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.lbl0Count = new System.Windows.Forms.Label();
            this.plnMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lnlTotal
            // 
            this.lnlTotal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lnlTotal.ForeColor = System.Drawing.Color.Red;
            this.lnlTotal.Location = new System.Drawing.Point(6, 258);
            this.lnlTotal.Name = "lnlTotal";
            this.lnlTotal.Size = new System.Drawing.Size(229, 21);
            this.lnlTotal.Text = "正在提交数据：";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button3.Location = new System.Drawing.Point(145, 276);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 28);
            this.button3.TabIndex = 2;
            this.button3.Text = "取消(S2)";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
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
            this.lblTitle.Text = "货物出库";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // col1RFIDNo
            // 
            this.col1RFIDNo.Text = "RFID卡号";
            this.col1RFIDNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col1RFIDNo.Width = 106;
            // 
            // col3qty
            // 
            this.col3qty.Text = "数量";
            this.col3qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col3qty.Width = 50;
            // 
            // col3Weight
            // 
            this.col3Weight.Text = "重量";
            this.col3Weight.Width = 50;
            // 
            // listView1
            // 
            this.listView1.Columns.Add(this.col1RFIDNo);
            this.listView1.Columns.Add(this.col2pqty);
            this.listView1.Columns.Add(this.col3qty);
            this.listView1.Columns.Add(this.col3Weight);
            this.listView1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(2, 174);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(238, 79);
            this.listView1.TabIndex = 0;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // col2pqty
            // 
            this.col2pqty.Text = "箱数";
            this.col2pqty.Width = 40;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-11, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.Text = "出库单";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt11stockout_id
            // 
            this.txt11stockout_id.Location = new System.Drawing.Point(68, 27);
            this.txt11stockout_id.Name = "txt11stockout_id";
            this.txt11stockout_id.Size = new System.Drawing.Size(157, 23);
            this.txt11stockout_id.TabIndex = 6;
            // 
            // txt12Rfid_no
            // 
            this.txt12Rfid_no.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.txt12Rfid_no.Location = new System.Drawing.Point(68, 52);
            this.txt12Rfid_no.Name = "txt12Rfid_no";
            this.txt12Rfid_no.Size = new System.Drawing.Size(157, 21);
            this.txt12Rfid_no.TabIndex = 8;
            this.txt12Rfid_no.TextChanged += new System.EventHandler(this.txt12Rfid_no_TextChanged);
            this.txt12Rfid_no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt21ctnno_no_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(-11, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 20);
            this.label2.Text = "RFID卡号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt13Shelf_no
            // 
            this.txt13Shelf_no.Location = new System.Drawing.Point(68, 75);
            this.txt13Shelf_no.Name = "txt13Shelf_no";
            this.txt13Shelf_no.Size = new System.Drawing.Size(157, 23);
            this.txt13Shelf_no.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-11, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.Text = "货架编号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt4Qty
            // 
            this.txt4Qty.Location = new System.Drawing.Point(68, 123);
            this.txt4Qty.Name = "txt4Qty";
            this.txt4Qty.Size = new System.Drawing.Size(157, 23);
            this.txt4Qty.TabIndex = 14;
            this.txt4Qty.TextChanged += new System.EventHandler(this.txt4Qty_TextChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-11, 123);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(78, 20);
            this.label4.Text = "数  量";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt5nwet
            // 
            this.txt5nwet.Location = new System.Drawing.Point(68, 147);
            this.txt5nwet.Name = "txt5nwet";
            this.txt5nwet.Size = new System.Drawing.Size(114, 23);
            this.txt5nwet.TabIndex = 17;
            this.txt5nwet.TextChanged += new System.EventHandler(this.txt5nwet_TextChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-11, 147);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(78, 20);
            this.label5.Text = "重  量";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(188, 149);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 20);
            this.label6.Text = "KG";
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button2.Location = new System.Drawing.Point(29, 276);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 28);
            this.button2.TabIndex = 25;
            this.button2.Text = "提交(S1)";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(222, 58);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 20);
            this.label8.Text = "*";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(222, 34);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 20);
            this.label10.Text = "*";
            // 
            // txt21pqty
            // 
            this.txt21pqty.Location = new System.Drawing.Point(68, 99);
            this.txt21pqty.Name = "txt21pqty";
            this.txt21pqty.Size = new System.Drawing.Size(157, 23);
            this.txt21pqty.TabIndex = 33;
            this.txt21pqty.TextChanged += new System.EventHandler(this.txt21pqty_TextChanged);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(-11, 99);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(78, 20);
            this.label7.Text = "箱  数";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl0Count
            // 
            this.lbl0Count.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl0Count.ForeColor = System.Drawing.Color.Red;
            this.lbl0Count.Location = new System.Drawing.Point(213, 156);
            this.lbl0Count.Name = "lbl0Count";
            this.lbl0Count.Size = new System.Drawing.Size(24, 15);
            this.lbl0Count.Text = "0";
            // 
            // frmStockOutScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.lbl0Count);
            this.Controls.Add(this.txt21pqty);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt5nwet);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt4Qty);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt13Shelf_no);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt12Rfid_no);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt11stockout_id);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.plnMenu);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lnlTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "frmStockOutScan";
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
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Panel plnMenu;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ColumnHeader col1RFIDNo;
        private System.Windows.Forms.ColumnHeader col3qty;
        private System.Windows.Forms.ColumnHeader col3Weight;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt11stockout_id;
        private System.Windows.Forms.TextBox txt12Rfid_no;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt13Shelf_no;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt4Qty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt5nwet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ColumnHeader col2pqty;
        private System.Windows.Forms.TextBox txt21pqty;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lbl0Count;
    }
}