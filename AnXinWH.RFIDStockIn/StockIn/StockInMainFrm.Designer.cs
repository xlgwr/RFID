namespace AnXinWH.RFIDStockIn.StockIn
{
    partial class StockInMainFrm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.col0RFID = new System.Windows.Forms.ColumnHeader();
            this.col0Product = new System.Windows.Forms.ColumnHeader();
            this.col0XianHaoNum = new System.Windows.Forms.ColumnHeader();
            this.col2Num = new System.Windows.Forms.ColumnHeader();
            this.col3Weight = new System.Windows.Forms.ColumnHeader();
            this.col4Pqty = new System.Windows.Forms.ColumnHeader();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txt3RFID = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txt6nwet = new System.Windows.Forms.TextBox();
            this.txt5qty = new System.Windows.Forms.TextBox();
            this.txt12prdct_no = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.lblTitle = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.txt11stockin_id = new System.Windows.Forms.TextBox();
            this.lbl0Msg = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txt4XiangHao = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.txt5PQty = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(12, 116);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 31);
            this.label7.Text = "RFID号";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(12, 247);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 31);
            this.label5.Text = "重    量";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(12, 212);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 31);
            this.label4.Text = "数    量";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.label2.Location = new System.Drawing.Point(12, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(148, 31);
            this.label2.Text = "货物编码";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(12, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 31);
            this.label1.Text = "入库单";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // listView1
            // 
            this.listView1.Columns.Add(this.col0RFID);
            this.listView1.Columns.Add(this.col0Product);
            this.listView1.Columns.Add(this.col0XianHaoNum);
            this.listView1.Columns.Add(this.col2Num);
            this.listView1.Columns.Add(this.col3Weight);
            this.listView1.Columns.Add(this.col4Pqty);
            this.listView1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(12, 376);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(448, 204);
            this.listView1.TabIndex = 39;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // col0RFID
            // 
            this.col0RFID.Text = "RFID号";
            this.col0RFID.Width = 80;
            // 
            // col0Product
            // 
            this.col0Product.Text = "货物编号";
            this.col0Product.Width = 100;
            // 
            // col0XianHaoNum
            // 
            this.col0XianHaoNum.Text = "托盘号/箱号";
            this.col0XianHaoNum.Width = 95;
            // 
            // col2Num
            // 
            this.col2Num.Text = "数量";
            this.col2Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col2Num.Width = 80;
            // 
            // col3Weight
            // 
            this.col3Weight.Text = "重量";
            this.col3Weight.Width = 60;
            // 
            // col4Pqty
            // 
            this.col4Pqty.Text = "箱数";
            this.col4Pqty.Width = 60;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(387, 124);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 20);
            this.label9.Text = "*";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(387, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(18, 20);
            this.label8.Text = "*";
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(387, 61);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(18, 20);
            this.label10.Text = "*";
            // 
            // txt3RFID
            // 
            this.txt3RFID.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.txt3RFID.Location = new System.Drawing.Point(166, 114);
            this.txt3RFID.Name = "txt3RFID";
            this.txt3RFID.Size = new System.Drawing.Size(215, 32);
            this.txt3RFID.TabIndex = 56;
            this.txt3RFID.TextChanged += new System.EventHandler(this.txt3RFID_TextChanged);
            this.txt3RFID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt3RFID_KeyDown);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(334, 249);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 20);
            this.label6.Text = "KG";
            // 
            // txt6nwet
            // 
            this.txt6nwet.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.txt6nwet.Location = new System.Drawing.Point(166, 242);
            this.txt6nwet.Name = "txt6nwet";
            this.txt6nwet.Size = new System.Drawing.Size(162, 32);
            this.txt6nwet.TabIndex = 55;
            this.txt6nwet.TextChanged += new System.EventHandler(this.txt6nwet_TextChanged);
            this.txt6nwet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt6nwet_KeyDown);
            // 
            // txt5qty
            // 
            this.txt5qty.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.txt5qty.Location = new System.Drawing.Point(166, 210);
            this.txt5qty.Name = "txt5qty";
            this.txt5qty.Size = new System.Drawing.Size(215, 32);
            this.txt5qty.TabIndex = 54;
            this.txt5qty.TextChanged += new System.EventHandler(this.txt5qty_TextChanged);
            this.txt5qty.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt5qty_KeyDown);
            // 
            // txt12prdct_no
            // 
            this.txt12prdct_no.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.txt12prdct_no.Location = new System.Drawing.Point(166, 82);
            this.txt12prdct_no.Name = "txt12prdct_no";
            this.txt12prdct_no.Size = new System.Drawing.Size(215, 32);
            this.txt12prdct_no.TabIndex = 51;
            this.txt12prdct_no.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt12prdct_no_KeyDown);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button3.Location = new System.Drawing.Point(310, 281);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 48);
            this.button3.TabIndex = 43;
            this.button3.Text = "取消(S2)";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(2, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(473, 35);
            this.lblTitle.Text = "货物卸货";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button2.Location = new System.Drawing.Point(64, 281);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 48);
            this.button2.TabIndex = 41;
            this.button2.Text = "提交(S1)";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txt11stockin_id
            // 
            this.txt11stockin_id.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txt11stockin_id.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.txt11stockin_id.Location = new System.Drawing.Point(166, 50);
            this.txt11stockin_id.Name = "txt11stockin_id";
            this.txt11stockin_id.Size = new System.Drawing.Size(215, 32);
            this.txt11stockin_id.TabIndex = 48;
            this.txt11stockin_id.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt11stockin_id_KeyDown);
            // 
            // lbl0Msg
            // 
            this.lbl0Msg.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lbl0Msg.ForeColor = System.Drawing.Color.Red;
            this.lbl0Msg.Location = new System.Drawing.Point(12, 332);
            this.lbl0Msg.Name = "lbl0Msg";
            this.lbl0Msg.Size = new System.Drawing.Size(448, 41);
            this.lbl0Msg.Text = "正在提交数据：";
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.Silver;
            this.label11.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(12, 146);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(148, 31);
            this.label11.Text = "托盘号/箱号";
            this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // txt4XiangHao
            // 
            this.txt4XiangHao.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.txt4XiangHao.Location = new System.Drawing.Point(166, 146);
            this.txt4XiangHao.Name = "txt4XiangHao";
            this.txt4XiangHao.Size = new System.Drawing.Size(215, 32);
            this.txt4XiangHao.TabIndex = 61;
            this.txt4XiangHao.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt4XiangHao_KeyDown);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label12.ForeColor = System.Drawing.Color.Red;
            this.label12.Location = new System.Drawing.Point(388, 155);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(18, 20);
            this.label12.Text = "*";
            // 
            // txt5PQty
            // 
            this.txt5PQty.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.txt5PQty.Location = new System.Drawing.Point(166, 178);
            this.txt5PQty.Name = "txt5PQty";
            this.txt5PQty.Size = new System.Drawing.Size(215, 32);
            this.txt5PQty.TabIndex = 54;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(12, 180);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 31);
            this.label3.Text = "箱    数";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StockInMainFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(478, 615);
            this.ControlBox = false;
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txt4XiangHao);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.txt3RFID);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt6nwet);
            this.Controls.Add(this.txt5PQty);
            this.Controls.Add(this.txt5qty);
            this.Controls.Add(this.txt12prdct_no);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txt11stockin_id);
            this.Controls.Add(this.lbl0Msg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockInMainFrm";
            this.Text = "StockInMainFrm";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.StockInMainFrm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StockInMainFrm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader col0XianHaoNum;
        private System.Windows.Forms.ColumnHeader col2Num;
        private System.Windows.Forms.ColumnHeader col3Weight;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txt3RFID;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt6nwet;
        private System.Windows.Forms.TextBox txt5qty;
        private System.Windows.Forms.TextBox txt12prdct_no;
        private System.Windows.Forms.Button button3;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txt11stockin_id;
        private System.Windows.Forms.Label lbl0Msg;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txt4XiangHao;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ColumnHeader col0RFID;
        private System.Windows.Forms.ColumnHeader col0Product;
        private System.Windows.Forms.ColumnHeader col4Pqty;
        private System.Windows.Forms.TextBox txt5PQty;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timer1;
    }
}