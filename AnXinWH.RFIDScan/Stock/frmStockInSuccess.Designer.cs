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
            this.timer1 = new System.Windows.Forms.Timer();
            this.plnMenu = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.col0XianHaoNum = new System.Windows.Forms.ColumnHeader();
            this.col1RFIDNo = new System.Windows.Forms.ColumnHeader();
            this.col2Num = new System.Windows.Forms.ColumnHeader();
            this.col3Weight = new System.Windows.Forms.ColumnHeader();
            this.col4Del = new System.Windows.Forms.ColumnHeader();
            this.listView1 = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.plnMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // lnlTotal
            // 
            this.lnlTotal.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lnlTotal.ForeColor = System.Drawing.Color.Red;
            this.lnlTotal.Location = new System.Drawing.Point(7, 238);
            this.lnlTotal.Name = "lnlTotal";
            this.lnlTotal.Size = new System.Drawing.Size(207, 15);
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
            this.button2.Text = "提交";
            this.button2.Click += new System.EventHandler(this.button2_Click);
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
            this.lblTitle.Text = "货物上架";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // col0XianHaoNum
            // 
            this.col0XianHaoNum.Text = "箱号";
            this.col0XianHaoNum.Width = 70;
            // 
            // col1RFIDNo
            // 
            this.col1RFIDNo.Text = "RFID卡号";
            this.col1RFIDNo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.col1RFIDNo.Width = 90;
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
            // col4Del
            // 
            this.col4Del.Text = "操作";
            this.col4Del.Width = 60;
            // 
            // listView1
            // 
            this.listView1.Columns.Add(this.col0XianHaoNum);
            this.listView1.Columns.Add(this.col1RFIDNo);
            this.listView1.Columns.Add(this.col2Num);
            this.listView1.Columns.Add(this.col3Weight);
            this.listView1.Columns.Add(this.col4Del);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(0, 152);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(238, 79);
            this.listView1.TabIndex = 0;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(13, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 20);
            this.label1.Text = "入库单";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(81, 29);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(139, 23);
            this.textBox1.TabIndex = 6;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(81, 53);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(139, 23);
            this.textBox2.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 20);
            this.label2.Text = "RFID卡号";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(81, 77);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(139, 23);
            this.textBox3.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(13, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 20);
            this.label3.Text = "入库箱号";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(81, 101);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(139, 23);
            this.textBox4.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(13, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 20);
            this.label4.Text = "数  量";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(81, 125);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(114, 23);
            this.textBox5.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(13, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(73, 20);
            this.label5.Text = "重  量";
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(201, 127);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 20);
            this.label6.Text = "KG";
            // 
            // frmStockInSuccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(240, 295);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
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
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmStockInSuccess_KeyDown);
            this.plnMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lnlTotal;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Timer timer1;
        internal System.Windows.Forms.Panel plnMenu;
        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.ColumnHeader col0XianHaoNum;
        private System.Windows.Forms.ColumnHeader col1RFIDNo;
        private System.Windows.Forms.ColumnHeader col2Num;
        private System.Windows.Forms.ColumnHeader col3Weight;
        private System.Windows.Forms.ColumnHeader col4Del;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}