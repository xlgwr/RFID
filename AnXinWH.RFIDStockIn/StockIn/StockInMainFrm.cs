using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Framework.Libs;
using Framework.DataAccess;
using System.Collections.Specialized;

namespace AnXinWH.RFIDStockIn.StockIn
{
    public partial class StockInMainFrm : Form
    {

        /// <summary>
        /// 入库编号 yyyyMMDDHHmmss
        /// </summary>
        public string _stockin_id = string.Empty;

        /// <summary>
        /// 共通数据对象
        /// </summary>
        protected CBaseConnect m_daoCommon;
        StringDictionary _disNull = new StringDictionary();
        StringDictionary DicData = new StringDictionary();

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
            Common.GetDaoCommon(ref m_daoCommon);
            _dicScanItemDetail = new Dictionary<string, scanItemDetail>();

            //set focus
            txt11stockin_id.Focus();
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

                txt5PQty.Text = _dicScanItemDetail.Count.ToString();

                //txt13pqty.Text = _lisCtnNo.Count.ToString();
            }));


            SetMsg(lbl0Msg, "添加 " + tmpNewValue.ctnno_no + " 成功。");

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

                txt5PQty.Text = _dicScanItemDetail.Count.ToString();
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
        void AllInit()
        {
            _dicScanItemDetail.Clear();
            listView1.Items.Clear();

            _isChangeTxt = true;
            txt11stockin_id.Text = "";
            txt12prdct_no.Text = "";
            txt3RFID.Text = "";
            txt4XiangHao.Text = "";
            txt5PQty.Text = "";
            txt5qty.Text = "";
            txt6nwet.Text = "";
            _isChangeTxt = false;

            txt11stockin_id.Focus();
        }
        decimal[] calQtyNwet()
        {
            decimal[] tmpSum = new decimal[3];

            decimal tmpqty = 0;
            decimal tmpPqty = 0;
            decimal tmpnwet = 0;

            foreach (var item in _dicScanItemDetail.Values)
            {
                if (string.IsNullOrEmpty(item.pqty))
                {
                    item.pqty = "1";
                }
                if (string.IsNullOrEmpty(item.qty))
                {
                    item.qty = "0";
                }
                if (string.IsNullOrEmpty(item.nwet))
                {
                    item.nwet = "0";
                }

                tmpPqty += decimal.Parse(item.pqty);
                tmpqty += decimal.Parse(item.qty);
                tmpnwet += decimal.Parse(item.nwet);
            }
            tmpSum[0] = tmpPqty;
            tmpSum[1] = tmpqty;
            tmpSum[2] = tmpnwet;
            return tmpSum;
        }
        private bool UploadData()
        {
            string tmpmsg = "";
            bool IsStartTran = false;

            //test
            //return true;

            //set value
            StringDictionary disWhereValueMain = new StringDictionary();
            var dis5ForPrimaryKey_t_stock = new StringDictionary();
            StringDictionary disWhereValueItem = new StringDictionary();
            //select            
            StringDictionary disForValueMain = new StringDictionary();
            StringDictionary disForValueItem = new StringDictionary();
            //order by            
            StringDictionary disForOrderByMain = new StringDictionary();
            StringDictionary disForOrderByItem = new StringDictionary();
            //user
            StringDictionary DidUserCollum = new StringDictionary();

            //主表
            DataTable dt = null;
            disWhereValueMain[t_stockinctnno.stockin_id] = txt11stockin_id.Text.Trim();
            disWhereValueMain[t_stockinctnno.prdct_no] = txt12prdct_no.Text.Trim();


            //primary key
            dis5ForPrimaryKey_t_stock[t_stockinctnno.stockin_id] = txt11stockin_id.Text.Trim();
            dis5ForPrimaryKey_t_stock[t_stockinctnno.prdct_no] = txt12prdct_no.Text.Trim();

            disForOrderByMain[t_stockinctnno.stockin_id] = "true";
            disForOrderByMain[t_stockinctnno.prdct_no] = "true";

            //log for use
            DidUserCollum[t_stockinctnno.adduser] = "true";
            DidUserCollum[t_stockinctnno.addtime] = "true";
            DidUserCollum[t_stockinctnno.updtime] = "true";
            DidUserCollum[t_stockinctnno.upduser] = "true";


            Cursor.Current = Cursors.WaitCursor;
            try
            {

                //打开数据库连接
                Common.AdoConnect.Connect.ConnectOpen();
                //主表
                //get dt
                dt = this.m_daoCommon.GetTableInfo(ViewOrTable.t_stockinctnno, disWhereValueMain, disForOrderByMain, _disNull, "", false);

                Common.AdoConnect.Connect.CreateSqlTransaction();
                IsStartTran = true;
                lbl0Msg.Visible = true;

                var tmpsum = calQtyNwet();

                var _rfidStrForSet = txt3RFID.Text.Trim();

                if (dt.Rows.Count <= 0)
                {

                    disWhereValueMain[t_stockinctnno.pqty] = tmpsum[0].ToString();
                    disWhereValueMain[t_stockinctnno.qty] = tmpsum[1].ToString();
                    disWhereValueMain[t_stockinctnno.nwet] = tmpsum[2].ToString();
                    disWhereValueMain[t_stockinctnno.gwet] = "0";
                    disWhereValueMain[t_stockinctnno.status] = "1";

                    //上传主表
                    this.m_daoCommon.SetInsertDataItem(ViewOrTable.t_stockinctnno, disWhereValueMain, DidUserCollum);
                }
                else
                {
                    tmpmsg = "订单号：" + txt11stockin_id.Text + ",货物编码：" + txt12prdct_no.Text + " 已存在入库记录，是否继续。";

                    if (MessageBox.Show(tmpmsg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        var dr = dt.Rows[0];
                        //edit data
                        var tmp_pqty_StockIn = decimal.Parse(dr[t_stockinctnno.pqty].ToString());
                        var tmp_qty_StockIn = decimal.Parse(dr[t_stockinctnno.qty].ToString());
                        var tmp_nwet_StockIn = decimal.Parse(dr[t_stockinctnno.nwet].ToString());
                        var tmp_gwet_StockIn = decimal.Parse(dr[t_stockinctnno.gwet].ToString());

                        disWhereValueMain[t_stock.pqty] = (tmpsum[0] + tmp_pqty_StockIn).ToString();
                        disWhereValueMain[t_stock.qty] = (tmpsum[1] + tmp_qty_StockIn).ToString();
                        disWhereValueMain[t_stock.nwet] = (tmpsum[2] + tmp_nwet_StockIn).ToString();
                        disWhereValueMain[t_stock.status] = "1";


                        var dis00UserCollum2 = new StringDictionary();
                        dis00UserCollum2[t_stockinctnno.updtime] = "true";
                        dis00UserCollum2[t_stockinctnno.upduser] = "true";

                        this.m_daoCommon.SetModifyDataItem(ViewOrTable.t_stockinctnno, disWhereValueMain, dis5ForPrimaryKey_t_stock, dis00UserCollum2);

                    }
                    else
                    {
                        if (IsStartTran)
                            Common.AdoConnect.Connect.TransactionRollback();
                        Cursor.Current = Cursors.Default;
                        return false;
                    }

                }


                //上传scan

                //次表


                foreach (var item in _dicScanItemDetail.Values)
                {

                    //次表 primary key
                    disWhereValueItem[t_stockinctnnodetail.stockin_id] = item.stockid;
                    disWhereValueItem[t_stockinctnnodetail.prdct_no] = item.productid;

                    disWhereValueItem[t_stockinctnnodetail.rfid_no] = item.rfid;
                    disWhereValueItem[t_stockinctnnodetail.ctnno_no] = item.ctnno_no;

                    //仓单号
                    disWhereValueItem[t_stockinctnnodetail.receiptno] = "";

                    disWhereValueItem[t_stockinctnnodetail.pqty] = item.pqty.Length <= 0 ? "1" : item.pqty;
                    disWhereValueItem[t_stockinctnnodetail.qty] = item.qty.Length <= 0 ? "0" : item.qty;
                    disWhereValueItem[t_stockinctnnodetail.nwet] = item.nwet.Length <= 0 ? "0" : item.nwet;
                    disWhereValueItem[t_stockinctnnodetail.status] = "1";

                    this.m_daoCommon.SetInsertDataItem(ViewOrTable.t_stockinctnnodetail, disWhereValueItem, DidUserCollum);

                }

                Common.AdoConnect.Connect.TransactionCommit();
                tmpmsg = "上传数据成功。" + _rfidStrForSet;
                SetMsg(lbl0Msg, tmpmsg);
                MessageBox.Show(tmpmsg);


                return true;

            }
            catch (Exception ex)
            {
                if (IsStartTran)
                    Common.AdoConnect.Connect.TransactionRollback();
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                SetMsg(lbl0Msg, ex.Message);
                Cursor.Current = Cursors.Default;
                return false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
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
                //确定上传数据？ 
                if (MessageBox.Show("确定上传数据？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    if (UploadData())
                    {
                        // AllInit();
                    }
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                AllInit();
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
            var tmpmsg = "";

            Cursor.Current = Cursors.WaitCursor;
            try
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

                        SetMsg(lbl0Msg, "RFID:" + txt3RFID.Text + ",托盘号：" + txt4XiangHao.Text + " 已经存在。");
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
            catch (Exception ex)
            {
                tmpmsg = ex.Message;
                MessageBox.Show(ex.Message);
                SetMsg(lbl0Msg, tmpmsg);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }

        }

        private void txt5qty_KeyDown(object sender, KeyEventArgs e)
        {

            if (!allTextBox(txt5qty, true))
            {
                return;
            }
            setFouces(e, txt6nwet);
        }

        private void txt6nwet_KeyDown(object sender, KeyEventArgs e)
        {
            if (!allTextBox(txt6nwet, true))
            {
                return;
            }
            if (e.KeyCode == Keys.Enter)
            {
                txt3RFID.Focus();
                txt4XiangHao.Text = "";
            }
            //setFouces(e, txt4XiangHao);

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

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            var tmpmsg = "";

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //选中行的索引
                int index = listView1.SelectedIndices[0];
                //选中行的值
                ListViewItem selecteditem = listView1.Items[index];

                //1列名
                var colname = listView1.Columns[0].Text;

                //选中行的第一列的值
                string rfid = listView1.Items[index].SubItems[0].Text;
                string pruductid = listView1.Items[index].SubItems[1].Text;
                string cton = listView1.Items[index].SubItems[2].Text;

                var tmpkey = txt11stockin_id.Text.Trim() + "," + pruductid + "," + rfid + "," + cton;

                if (MessageBox.Show("您确定要删除：" + tmpkey, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                {
                    this.listView1.Items.RemoveAt(index);

                    //
                    if (_dicScanItemDetail.ContainsKey(tmpkey))
                    {
                        _dicScanItemDetail.Remove(tmpkey);

                        addToListAllView();
                    }

                    tmpmsg = "成功删除:" + tmpkey;
                    SetMsg(lbl0Msg, tmpmsg);


                }
                else
                {
                    SetMsg(lbl0Msg, tmpmsg);
                }

            }
            catch (Exception ex)
            {
                tmpmsg = ex.Message;
                MessageBox.Show(ex.Message);
                SetMsg(lbl0Msg, tmpmsg);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void StockInMainFrm_KeyDown(object sender, KeyEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (e.KeyCode == Keys.F11)
                {
                    button2_Click(null, null);
                }
                else if (e.KeyCode == Keys.F12)
                {
                    button3_Click(null, null);
                }
            }
            catch (Exception ex)
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void StockInMainFrm_Load(object sender, EventArgs e)
        {
            //this.TopMost = true;
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