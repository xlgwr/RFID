namespace AnXinWH.RFIDStockIn.StockIn
{
    partial class StockCheckWet
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
            this.col3Weight = new System.Windows.Forms.ColumnHeader();
            this.col4Pqty = new System.Windows.Forms.ColumnHeader();
            this.col2Num = new System.Windows.Forms.ColumnHeader();
            this.lblTitle = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.col0RFID = new System.Windows.Forms.ColumnHeader();
            this.col5Gwet = new System.Windows.Forms.ColumnHeader();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt3RFID = new System.Windows.Forms.TextBox();
            this.txt6gwet = new System.Windows.Forms.TextBox();
            this.txt5PQty = new System.Windows.Forms.TextBox();
            this.txt5qty = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbl0Msg = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt5nWet = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer();
            this.SuspendLayout();
            // 
            // col3Weight
            // 
            this.col3Weight.Text = "重量";
            this.col3Weight.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col3Weight.Width = 100;
            // 
            // col4Pqty
            // 
            this.col4Pqty.Text = "箱数";
            this.col4Pqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col4Pqty.Width = 60;
            // 
            // col2Num
            // 
            this.col2Num.Text = "数量";
            this.col2Num.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col2Num.Width = 80;
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 0);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(473, 35);
            this.lblTitle.Text = "货物抽检";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(13, 46);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 31);
            this.label7.Text = "RFID号";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.label5.Location = new System.Drawing.Point(13, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(148, 31);
            this.label5.Text = "实际重量";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(13, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 31);
            this.label3.Text = "箱    数";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.label4.Location = new System.Drawing.Point(13, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(148, 31);
            this.label4.Text = "数    量";
            this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // listView1
            // 
            this.listView1.Columns.Add(this.col0RFID);
            this.listView1.Columns.Add(this.col4Pqty);
            this.listView1.Columns.Add(this.col2Num);
            this.listView1.Columns.Add(this.col3Weight);
            this.listView1.Columns.Add(this.col5Gwet);
            this.listView1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(13, 322);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(448, 285);
            this.listView1.TabIndex = 7;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // col0RFID
            // 
            this.col0RFID.Text = "RFID号";
            this.col0RFID.Width = 100;
            // 
            // col5Gwet
            // 
            this.col5Gwet.Text = "实际重量";
            this.col5Gwet.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col5Gwet.Width = 100;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(388, 54);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 20);
            this.label9.Text = "*";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(335, 179);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 20);
            this.label6.Text = "KG";
            // 
            // txt3RFID
            // 
            this.txt3RFID.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.txt3RFID.Location = new System.Drawing.Point(167, 44);
            this.txt3RFID.Name = "txt3RFID";
            this.txt3RFID.Size = new System.Drawing.Size(215, 32);
            this.txt3RFID.TabIndex = 0;
            this.txt3RFID.TextChanged += new System.EventHandler(this.txt3RFID_TextChanged);
            this.txt3RFID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt3RFID_KeyDown);
            // 
            // txt6gwet
            // 
            this.txt6gwet.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.txt6gwet.Location = new System.Drawing.Point(167, 172);
            this.txt6gwet.Name = "txt6gwet";
            this.txt6gwet.Size = new System.Drawing.Size(162, 32);
            this.txt6gwet.TabIndex = 4;
            this.txt6gwet.TextChanged += new System.EventHandler(this.txt6gwet_TextChanged);
            this.txt6gwet.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt6gwet_KeyDown);
            // 
            // txt5PQty
            // 
            this.txt5PQty.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.txt5PQty.Location = new System.Drawing.Point(167, 76);
            this.txt5PQty.Name = "txt5PQty";
            this.txt5PQty.Size = new System.Drawing.Size(215, 32);
            this.txt5PQty.TabIndex = 1;
            // 
            // txt5qty
            // 
            this.txt5qty.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.txt5qty.Location = new System.Drawing.Point(167, 108);
            this.txt5qty.Name = "txt5qty";
            this.txt5qty.Size = new System.Drawing.Size(215, 32);
            this.txt5qty.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button3.Location = new System.Drawing.Point(311, 227);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 48);
            this.button3.TabIndex = 6;
            this.button3.Text = "取消(S2)";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button2.Location = new System.Drawing.Point(65, 227);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 48);
            this.button2.TabIndex = 5;
            this.button2.Text = "提交(S1)";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbl0Msg
            // 
            this.lbl0Msg.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lbl0Msg.ForeColor = System.Drawing.Color.Red;
            this.lbl0Msg.Location = new System.Drawing.Point(13, 278);
            this.lbl0Msg.Name = "lbl0Msg";
            this.lbl0Msg.Size = new System.Drawing.Size(448, 41);
            this.lbl0Msg.Text = "正在提交数据：";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.label1.Location = new System.Drawing.Point(13, 141);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(148, 31);
            this.label1.Text = "重    量";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(335, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 20);
            this.label2.Text = "KG";
            // 
            // txt5nWet
            // 
            this.txt5nWet.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.txt5nWet.Location = new System.Drawing.Point(167, 140);
            this.txt5nWet.Name = "txt5nWet";
            this.txt5nWet.Size = new System.Drawing.Size(162, 32);
            this.txt5nWet.TabIndex = 3;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // StockCheckWet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(480, 640);
            this.ControlBox = false;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt5nWet);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt3RFID);
            this.Controls.Add(this.txt6gwet);
            this.Controls.Add(this.txt5PQty);
            this.Controls.Add(this.txt5qty);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbl0Msg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StockCheckWet";
            this.Text = "StockCheckWet";
            this.Load += new System.EventHandler(this.StockCheckWet_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.StockCheckWet_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ColumnHeader col3Weight;
        private System.Windows.Forms.ColumnHeader col4Pqty;
        private System.Windows.Forms.ColumnHeader col2Num;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader col0RFID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt3RFID;
        private System.Windows.Forms.TextBox txt6gwet;
        private System.Windows.Forms.TextBox txt5PQty;
        private System.Windows.Forms.TextBox txt5qty;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl0Msg;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt5nWet;
        private System.Windows.Forms.ColumnHeader col5Gwet;
        private System.Windows.Forms.Timer timer1;
    }
}