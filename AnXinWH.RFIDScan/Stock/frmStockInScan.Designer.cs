namespace AnXinWH.RFIDScan.Stock
{
    partial class frmStockInScan
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
            this.col0XianHaoNum = new System.Windows.Forms.ColumnHeader();
            this.col2Num = new System.Windows.Forms.ColumnHeader();
            this.col3Weight = new System.Windows.Forms.ColumnHeader();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.txt11stockin_id = new System.Windows.Forms.TextBox();
            this.txt12prdct_no = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt13pqty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt22qty = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txt23nwet = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt21ctnno_no = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.plnMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lnlTotal
            // 
            this.lnlTotal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lnlTotal.ForeColor = System.Drawing.Color.Red;
            this.lnlTotal.Location = new System.Drawing.Point(3, 253);
            this.lnlTotal.Name = "lnlTotal";
            this.lnlTotal.Size = new System.Drawing.Size(207, 15);
            this.lnlTotal.Text = "正在提交数据：";
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button3.Location = new System.Drawing.Point(141, 273);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(69, 28);
            this.button3.TabIndex = 2;
            this.button3.Text = "取消(S2)";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button2.Location = new System.Drawing.Point(25, 273);
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
            this.lblTitle.Text = "货物入库";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // col0XianHaoNum
            // 
            this.col0XianHaoNum.Text = "箱号";
            this.col0XianHaoNum.Width = 70;
            // 
            // col2Num
            // 
            this.col2Num.Text = "数量";
            this.col2Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col2Num.Width = 50;
            // 
            // col3Weight
            // 
            this.col3Weight.Text = "重量";
            this.col3Weight.Width = 50;
            // 
            // listView1
            // 
            this.listView1.Columns.Add(this.col0XianHaoNum);
            this.listView1.Columns.Add(this.col2Num);
            this.listView1.Columns.Add(this.col3Weight);
            this.listView1.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(2, 176);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(236, 69);
            this.listView1.TabIndex = 0;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(-7, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.Text = "入库单";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt11stockin_id
            // 
            this.txt11stockin_id.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt11stockin_id.Location = new System.Drawing.Point(69, 29);
            this.txt11stockin_id.Name = "txt11stockin_id";
            this.txt11stockin_id.Size = new System.Drawing.Size(148, 23);
            this.txt11stockin_id.TabIndex = 6;
            this.txt11stockin_id.TextChanged += new System.EventHandler(this.txt11stockin_id_TextChanged);
            this.txt11stockin_id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt11stockin_id_KeyDown);
            // 
            // txt12prdct_no
            // 
            this.txt12prdct_no.Location = new System.Drawing.Point(69, 53);
            this.txt12prdct_no.Name = "txt12prdct_no";
            this.txt12prdct_no.Size = new System.Drawing.Size(148, 23);
            this.txt12prdct_no.TabIndex = 8;
            this.txt12prdct_no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt12prdct_no_KeyDown);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(-7, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.Text = "货物编码";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt13pqty
            // 
            this.txt13pqty.Location = new System.Drawing.Point(69, 77);
            this.txt13pqty.Name = "txt13pqty";
            this.txt13pqty.Size = new System.Drawing.Size(148, 23);
            this.txt13pqty.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-7, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.Text = "箱    数";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt22qty
            // 
            this.txt22qty.Location = new System.Drawing.Point(69, 125);
            this.txt22qty.Name = "txt22qty";
            this.txt22qty.Size = new System.Drawing.Size(148, 23);
            this.txt22qty.TabIndex = 14;
            this.txt22qty.TextChanged += new System.EventHandler(this.txt22qty_TextChanged);
            this.txt22qty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt22qty_KeyDown);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(-7, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.Text = "数    量";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt23nwet
            // 
            this.txt23nwet.Location = new System.Drawing.Point(69, 149);
            this.txt23nwet.Name = "txt23nwet";
            this.txt23nwet.Size = new System.Drawing.Size(95, 23);
            this.txt23nwet.TabIndex = 17;
            this.txt23nwet.TextChanged += new System.EventHandler(this.txt23nwet_TextChanged);
            this.txt23nwet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt23nwet_KeyDown);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(-7, 151);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.Text = "重    量";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(166, 151);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 20);
            this.label6.Text = "KG";
            // 
            // txt21ctnno_no
            // 
            this.txt21ctnno_no.Location = new System.Drawing.Point(69, 101);
            this.txt21ctnno_no.Name = "txt21ctnno_no";
            this.txt21ctnno_no.Size = new System.Drawing.Size(148, 23);
            this.txt21ctnno_no.TabIndex = 35;
            this.txt21ctnno_no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt21ctnno_no_KeyDown);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(-7, 103);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 20);
            this.label7.Text = "箱    号";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(219, 32);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 20);
            this.label10.Text = "*";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(219, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 20);
            this.label8.Text = "*";
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(219, 80);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 20);
            this.label9.Text = "*";
            // 
            // frmStockInScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 320);
            this.ControlBox = false;
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt21ctnno_no);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt23nwet);
            this.Controls.Add(this.txt22qty);
            this.Controls.Add(this.txt13pqty);
            this.Controls.Add(this.txt12prdct_no);
            this.Controls.Add(this.txt11stockin_id);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.plnMenu);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lnlTotal);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "frmStockInScan";
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
        private System.Windows.Forms.ColumnHeader col0XianHaoNum;
        private System.Windows.Forms.ColumnHeader col2Num;
        private System.Windows.Forms.ColumnHeader col3Weight;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt11stockin_id;
        private System.Windows.Forms.TextBox txt12prdct_no;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt13pqty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt22qty;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt23nwet;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt21ctnno_no;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;


    }
}