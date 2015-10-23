using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Framework.Libs;

namespace AnXinWH.RFIDStockIn.StockIn
{
    public partial class StockInMainFrm : Form
    {
        //扫描的产品及RFID
        #region att
        /// <summary>
        /// key: stockid,productid,rfid,shelf
        /// </summary>
        public Dictionary<string, scanItemDetail> _dicScanItemDetail;

        public static bool _isChangeTxt = false;
        #endregion
        public StockInMainFrm()
        {
            InitializeComponent();

            //
            initfirst();
        }
        public void initfirst()
        {
            _dicScanItemDetail = new Dictionary<string, scanItemDetail>();
        }
        #region basefun
        bool checkTxt()
        {
            return
             allTextBox(txt11stockin_id, false) &&
             allTextBox(txt12prdct_no, false) && allTextBox(txt4XiangHao, false) && allTextBox(txt3RFID, false);//&& allTextBox(txt5qty, true)
        }
        bool allTextBox(TextBox tb, bool isnum)
        {
            if (isnum)
            {
                if (!(PageValidate.IsDecimal(tb.Text) || PageValidate.IsNumber(tb.Text)))
                {
                    tb.Focus();
                    lbl0Msg.Text = "请输入正确数字。谢谢";
                    return false;
                }
            }
            else
            {
                if (tb.Text.Trim().Length <= 0)
                {
                    tb.Focus();
                    lbl0Msg.Text = "请输入正确内容。谢谢";
                    return false;

                }
            }

            return true;
        }
        void SetMsg(Label lb, string msg)
        {
            this.Invoke(new Action(delegate()
            {
                lb.Text = msg;
            }));
        }
        void setFouces(KeyEventArgs e, TextBox tb)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tb.Text.Trim().Length <= 0)
                {
                    tb.Focus();
                }
            }
        }

        void addToListAllView(string tmpKey, scanItemDetail tmpNewValue)
        {
            this.Invoke(new Action(delegate()
            {
                listView1.Items.Clear();

                addToList(tmpNewValue);

                foreach (var item in _dicScanItemDetail.Values)
                {
                    addToList(item);
                }


                _dicScanItemDetail.Add(tmpKey, tmpNewValue);

                //txt13pqty.Text = _lisCtnNo.Count.ToString();
            }));


            SetMsg(lbl0Msg, "add " + tmpNewValue.ctnno_no + " success。");

        }
        void addToListAllView()
        {
            this.Invoke(new Action(delegate()
            {
                listView1.Items.Clear();

                foreach (var item in _dicScanItemDetail.Values)
                {
                    addToList(item);
                }
            }));

        }
        void addToList(scanItemDetail item)
        {
            string[] tmpstr = new string[6];

            tmpstr[0] = item.rfid;
            tmpstr[1] = item.productid;
            tmpstr[2] = item.ctnno_no;
            tmpstr[3] = item.qty;
            tmpstr[4] = item.nwet;
            tmpstr[5] = item.pqty;

            ListViewItem tmpitems1 = new ListViewItem(tmpstr);
            listView1.Items.Add(tmpitems1);
            listView1.Items[0].Selected = true;
        }
        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            var tmpmsg = "";
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                if (listView1.Items.Count <= 0)
                {
                    //尚未扫描到任何数据！ 
                    MessageBox.Show("没有扫到任何记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txt11stockin_id.Focus();
                    return;
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt11stockin_id_KeyDown(object sender, KeyEventArgs e)
        {
            setFouces(e, txt12prdct_no);
        }

        private void txt12prdct_no_KeyDown(object sender, KeyEventArgs e)
        {
            setFouces(e, txt3RFID);
        }

        private void txt3RFID_KeyDown(object sender, KeyEventArgs e)
        {
            setFouces(e, txt4XiangHao);
        }

        private void txt4XiangHao_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!checkTxt())
                {
                    return;
                }
                var tmpkey = txt11stockin_id.Text.Trim() + "," + txt12prdct_no.Text.Trim() + "," + txt3RFID.Text.Trim() + "," + txt4XiangHao.Text.Trim();

                if (_dicScanItemDetail.ContainsKey(tmpkey))
                {
                    _dicScanItemDetail[tmpkey].qty = txt5qty.Text.Trim();
                    _dicScanItemDetail[tmpkey].nwet = txt6nwet.Text.Trim();

                    addToListAllView();
                }
                else
                {
                    scanItemDetail tmpscan = new scanItemDetail();

                    tmpscan.stockid = txt11stockin_id.Text.Trim();
                    tmpscan.productid = txt12prdct_no.Text.Trim();
                    tmpscan.rfid = txt3RFID.Text.Trim();
                    tmpscan.ctnno_no = txt4XiangHao.Text.Trim();
                    tmpscan.pqty = "1";

                    tmpscan.qty = txt5qty.Text.Trim();
                    tmpscan.nwet = txt6nwet.Text.Trim();

                    //_dicScanItemDetail.Add(tmpkey, tmpscan);
                    addToListAllView(tmpkey, tmpscan);
                }

            }
            setFouces(e, txt5qty);
        }

        private void txt5qty_KeyDown(object sender, KeyEventArgs e)
        {
            setFouces(e, txt6nwet);
        }

        private void txt6nwet_KeyDown(object sender, KeyEventArgs e)
        {
            setFouces(e, txt4XiangHao);
        }
        void txtChange(TextBox tb, string attV)
        {
            if (!allTextBox(tb, true))
            {
                return;
            }
            else
            {
                if (!checkTxt())
                {
                    return;
                }
                var tmpkey = txt11stockin_id.Text.Trim() + "," + txt12prdct_no.Text.Trim() + "," + txt3RFID.Text.Trim() + "," + txt4XiangHao.Text.Trim();

                if (_dicScanItemDetail.ContainsKey(tmpkey))
                {
                    switch (attV)
                    {
                        case "qty":
                            _dicScanItemDetail[tmpkey].qty = tb.Text.Trim();
                            break;

                        case "nwet":
                            _dicScanItemDetail[tmpkey].nwet = tb.Text.Trim();
                            break;
                        default:
                            break;
                    }
                    addToListAllView();
                }
            }
        }
        private void txt5qty_TextChanged(object sender, EventArgs e)
        {
            if (!_isChangeTxt)
            {
                txtChange(txt5qty, "qty");
            }

        }

        private void txt6nwet_TextChanged(object sender, EventArgs e)
        {
            if (!_isChangeTxt)
            {
                txtChange(txt6nwet, "nwet");
            }

        }
    }

    public class scanItemDetail
    {
        public string stockid { get; set; }
        public string productid { get; set; }
        public string rfid { get; set; }
        public string ctnno_no { get; set; }
        public string pqty { get; set; }
        public string qty { get; set; }
        public string nwet { get; set; }

    }
}