﻿namespace AnXinWH.RFIDScan.Stock
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
            this.col4SumPty = new System.Windows.Forms.ColumnHeader();
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
            this.txt21CartonNo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt15ReceidNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.plnMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lnlTotal
            // 
            this.lnlTotal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lnlTotal.ForeColor = System.Drawing.Color.Red;
            this.lnlTotal.Location = new System.Drawing.Point(6, 269);
            this.lnlTotal.Name = "lnlTotal";
            this.lnlTotal.Size = new System.Drawing.Size(229, 21);
            this.lnlTotal.Text = "正在提交数据：";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(145, 289);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 25);
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
            this.col1RFIDNo.Width = 123;
            // 
            // col3qty
            // 
            this.col3qty.Text = "数量";
            this.col3qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col3qty.Width = 44;
            // 
            // col3Weight
            // 
            this.col3Weight.Text = "重量";
            this.col3Weight.Width = 36;
            // 
            // listView1
            // 
            this.listView1.Columns.Add(this.col1RFIDNo);
            this.listView1.Columns.Add(this.col2pqty);
            this.listView1.Columns.Add(this.col3qty);
            this.listView1.Columns.Add(this.col3Weight);
            this.listView1.Columns.Add(this.col4SumPty);
            this.listView1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(2, 187);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(238, 80);
            this.listView1.TabIndex = 0;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // col2pqty
            // 
            this.col2pqty.Text = "箱号";
            this.col2pqty.Width = 50;
            // 
            // col4SumPty
            // 
            this.col4SumPty.Text = "箱数";
            this.col4SumPty.Width = 60;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(-7, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 17);
            this.label1.Text = "出 库 单";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt11stockout_id
            // 
            this.txt11stockout_id.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt11stockout_id.Location = new System.Drawing.Point(81, 27);
            this.txt11stockout_id.Name = "txt11stockout_id";
            this.txt11stockout_id.Size = new System.Drawing.Size(138, 19);
            this.txt11stockout_id.TabIndex = 6;
            this.txt11stockout_id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt11stockout_id_KeyDown);
            // 
            // txt12Rfid_no
            // 
            this.txt12Rfid_no.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt12Rfid_no.Location = new System.Drawing.Point(81, 46);
            this.txt12Rfid_no.Name = "txt12Rfid_no";
            this.txt12Rfid_no.Size = new System.Drawing.Size(138, 19);
            this.txt12Rfid_no.TabIndex = 8;
            this.txt12Rfid_no.TextChanged += new System.EventHandler(this.txt12Rfid_no_TextChanged);
            this.txt12Rfid_no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt12Rfid_no_KeyDown);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(-7, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 17);
            this.label2.Text = "RFID卡号";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt13Shelf_no
            // 
            this.txt13Shelf_no.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt13Shelf_no.Location = new System.Drawing.Point(81, 103);
            this.txt13Shelf_no.Name = "txt13Shelf_no";
            this.txt13Shelf_no.Size = new System.Drawing.Size(138, 19);
            this.txt13Shelf_no.TabIndex = 11;
            this.txt13Shelf_no.TextChanged += new System.EventHandler(this.txt13Shelf_no_TextChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(-7, 107);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.Text = "货架编号";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt4Qty
            // 
            this.txt4Qty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt4Qty.Location = new System.Drawing.Point(81, 141);
            this.txt4Qty.Name = "txt4Qty";
            this.txt4Qty.Size = new System.Drawing.Size(138, 19);
            this.txt4Qty.TabIndex = 14;
            this.txt4Qty.TextChanged += new System.EventHandler(this.txt4Qty_TextChanged);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label4.Location = new System.Drawing.Point(-7, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 17);
            this.label4.Text = "数  量";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt5nwet
            // 
            this.txt5nwet.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt5nwet.Location = new System.Drawing.Point(81, 160);
            this.txt5nwet.Name = "txt5nwet";
            this.txt5nwet.Size = new System.Drawing.Size(95, 19);
            this.txt5nwet.TabIndex = 17;
            this.txt5nwet.TextChanged += new System.EventHandler(this.txt5nwet_TextChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(-7, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 17);
            this.label5.Text = "重  量";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(185, 163);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 20);
            this.label6.Text = "KG";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(29, 289);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(69, 25);
            this.button2.TabIndex = 25;
            this.button2.Text = "提交(S1)";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(222, 49);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 20);
            this.label8.Text = "*";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(222, 30);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 20);
            this.label10.Text = "*";
            // 
            // txt21pqty
            // 
            this.txt21pqty.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt21pqty.Location = new System.Drawing.Point(81, 122);
            this.txt21pqty.Name = "txt21pqty";
            this.txt21pqty.Size = new System.Drawing.Size(138, 19);
            this.txt21pqty.TabIndex = 33;
            this.txt21pqty.TextChanged += new System.EventHandler(this.txt21pqty_TextChanged);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(-7, 125);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 17);
            this.label7.Text = "箱  数";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // lbl0Count
            // 
            this.lbl0Count.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.lbl0Count.ForeColor = System.Drawing.Color.Red;
            this.lbl0Count.Location = new System.Drawing.Point(213, 171);
            this.lbl0Count.Name = "lbl0Count";
            this.lbl0Count.Size = new System.Drawing.Size(24, 15);
            this.lbl0Count.Text = "0";
            // 
            // txt21CartonNo
            // 
            this.txt21CartonNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt21CartonNo.Location = new System.Drawing.Point(81, 84);
            this.txt21CartonNo.Name = "txt21CartonNo";
            this.txt21CartonNo.Size = new System.Drawing.Size(138, 19);
            this.txt21CartonNo.TabIndex = 48;
            this.txt21CartonNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt21ctnno_no_KeyDown);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(-7, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 17);
            this.label9.Text = "仓 单 号";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt15ReceidNo
            // 
            this.txt15ReceidNo.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.txt15ReceidNo.Location = new System.Drawing.Point(81, 65);
            this.txt15ReceidNo.Name = "txt15ReceidNo";
            this.txt15ReceidNo.Size = new System.Drawing.Size(138, 19);
            this.txt15ReceidNo.TabIndex = 47;
            this.txt15ReceidNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt15ReceidNo_KeyDown);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Bold);
            this.label11.ForeColor = System.Drawing.Color.Red;
            this.label11.Location = new System.Drawing.Point(-7, 87);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 17);
            this.label11.Text = "托盘号/箱号";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(222, 69);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 20);
            this.label12.Text = "*";
            // 
            // label13
            // 
            this.label13.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(222, 87);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(18, 20);
            this.label13.Text = "*";
            // 
            // frmStockOutScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.txt21CartonNo);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt15ReceidNo);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.lbl0Count);
            this.Controls.Add(this.listView1);
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
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lnlTotal);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label13);
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
        private System.Windows.Forms.TextBox txt21CartonNo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt15ReceidNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ColumnHeader col4SumPty;
    }
}