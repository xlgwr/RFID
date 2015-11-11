namespace AnXinWH.RFIDStockIn.StockIn
{
    partial class frmRFIDCheck
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
            this.lblTitle = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.listView1 = new System.Windows.Forms.ListView();
            this.col0RFID = new System.Windows.Forms.ColumnHeader();
            this.colShelf = new System.Windows.Forms.ColumnHeader();
            this.label9 = new System.Windows.Forms.Label();
            this.txt3RFID = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.lbl0Msg = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer();
            this.txt2Shelf = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblTitle
            // 
            this.lblTitle.BackColor = System.Drawing.SystemColors.Highlight;
            this.lblTitle.Font = new System.Drawing.Font("Tahoma", 20F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(3, 4);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(473, 35);
            this.lblTitle.Text = "货物补检";
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Silver;
            this.label7.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(13, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(148, 31);
            this.label7.Text = "RFID号";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.label3.Location = new System.Drawing.Point(13, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(148, 31);
            this.label3.Text = "补检时间";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // listView1
            // 
            this.listView1.Columns.Add(this.col0RFID);
            this.listView1.Columns.Add(this.colShelf);
            this.listView1.Font = new System.Drawing.Font("Tahoma", 11F, System.Drawing.FontStyle.Regular);
            this.listView1.FullRowSelect = true;
            this.listView1.Location = new System.Drawing.Point(13, 207);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(448, 396);
            this.listView1.TabIndex = 4;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemActivate += new System.EventHandler(this.listView1_ItemActivate);
            // 
            // col0RFID
            // 
            this.col0RFID.Text = "RFID号";
            this.col0RFID.Width = 200;
            // 
            // colShelf
            // 
            this.colShelf.Text = "补检时间";
            this.colShelf.Width = 200;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Tahoma", 10F, System.Drawing.FontStyle.Bold);
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(388, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(18, 20);
            this.label9.Text = "*";
            // 
            // txt3RFID
            // 
            this.txt3RFID.Font = new System.Drawing.Font("Tahoma", 16F, System.Drawing.FontStyle.Regular);
            this.txt3RFID.Location = new System.Drawing.Point(167, 48);
            this.txt3RFID.Name = "txt3RFID";
            this.txt3RFID.Size = new System.Drawing.Size(215, 32);
            this.txt3RFID.TabIndex = 0;
            this.txt3RFID.TextChanged += new System.EventHandler(this.txt3RFID_TextChanged);
            this.txt3RFID.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt3RFID_KeyDown);
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button3.Location = new System.Drawing.Point(310, 131);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(96, 48);
            this.button3.TabIndex = 3;
            this.button3.Text = "取消(S2)";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
            this.button2.Location = new System.Drawing.Point(64, 131);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 48);
            this.button2.TabIndex = 2;
            this.button2.Text = "提交(S1)";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lbl0Msg
            // 
            this.lbl0Msg.Font = new System.Drawing.Font("Tahoma", 8F, System.Drawing.FontStyle.Regular);
            this.lbl0Msg.ForeColor = System.Drawing.Color.Red;
            this.lbl0Msg.Location = new System.Drawing.Point(12, 182);
            this.lbl0Msg.Name = "lbl0Msg";
            this.lbl0Msg.Size = new System.Drawing.Size(448, 41);
            this.lbl0Msg.Text = "正在提交数据：";
            // 
            // txt2Shelf
            // 
            this.txt2Shelf.Location = new System.Drawing.Point(167, 88);
            this.txt2Shelf.Name = "txt2Shelf";
            this.txt2Shelf.Size = new System.Drawing.Size(215, 23);
            this.txt2Shelf.TabIndex = 7;
            this.txt2Shelf.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt2Shelf_KeyDown);
            // 
            // frmRFIDCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(478, 615);
            this.ControlBox = false;
            this.Controls.Add(this.txt2Shelf);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt3RFID);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.lbl0Msg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.KeyPreview = true;
            this.Name = "frmRFIDCheck";
            this.Text = "frmStockInSuccess";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.frmRFIDCheck_Load);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader col0RFID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt3RFID;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label lbl0Msg;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ColumnHeader colShelf;
        private System.Windows.Forms.ComboBox txt2Shelf;
    }
}