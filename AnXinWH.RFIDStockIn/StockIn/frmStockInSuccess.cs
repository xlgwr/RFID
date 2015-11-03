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
using System.IO.Ports;

namespace AnXinWH.RFIDStockIn.StockIn
{
    public partial class frmStockInSuccess : Form
    {

        //rfid set
        private Action<string> invokeHandler = null;
        SerialPort serialport = null;
        bool isHex = true;
        byte[] buffer = new byte[4096];
        string _rfid = string.Empty;

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
        public frmStockInSuccess()
        {
            InitializeComponent();

            //
            this.Closing += new CancelEventHandler(frmStockInSuccess_Closing);
            this.Load += new EventHandler(frmStockInSuccess_Load);
            this.KeyDown += new KeyEventHandler(frmStockInSuccess_KeyDown);
            //demo
           // initDemo();
            //rfid
            initRFID();
            //
            initfirst();
        }
        void initDemo()
        {
            txt2Shelf.Text = "1";
        }
        void AllInit(bool isall)
        {
            if (isall)
            {
                _dicScanItemDetail.Clear();
                listView1.Items.Clear();

            }
            _rfid = "";

            _isChangeTxt = true;
            txt3RFID.Text = "";
            txt2Shelf.Text = "";
            _isChangeTxt = false;

            txt3RFID.Focus();
        }
        void frmStockInSuccess_Load(object sender, EventArgs e)
        {
            //throw new NotImplementedException();
            timer1.Enabled = true;
        }

        void frmStockInSuccess_KeyDown(object sender, KeyEventArgs e)
        {
            //throw new NotImplementedException();
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

        void frmStockInSuccess_Closing(object sender, CancelEventArgs e)
        {
            //throw new NotImplementedException();
            if (serialport.IsOpen)
            {
                serialport.Close();
            }
            timer1.Enabled = false;
        }
        void initRFID()
        {
            invokeHandler = new Action<string>(SetRFID);
            serialport = new SerialPort("COM1", 9600, Parity.None, 8, StopBits.One);
            serialport.DataReceived += new SerialDataReceivedEventHandler(serialport_DataReceived);
            serialport.Open();
            serialport.DtrEnable = true;
            serialport.RtsEnable = true;
        }
        private void serialport_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            while (serialport.IsOpen && serialport.BytesToRead > 0)
            {
                try
                {
                    int bytesToRead = serialport.BytesToRead;
                    bytesToRead = serialport.BytesToRead > buffer.Length ? buffer.Length : serialport.BytesToRead;
                    int bytesRead = serialport.Read(buffer, 0, bytesToRead);
                    if (bytesRead <= 0)
                        return;

                    string temp = "";
                    if (isHex)
                    {
                        temp = BitConverter.ToString(buffer, 0, bytesRead).Replace("-", " ");
                    }
                    else
                    {
                        temp = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    }
                    if (temp.Length == 0)
                        return;

                    this.BeginInvoke(invokeHandler, temp);
                }
                catch (Exception ex)
                {
                    buffer = new byte[4096];
                }
            }
        }
        void SetRFID(string tmpRFID)
        {
            var msg = "";
            var tmprfid = tmpRFID.Replace(" ", "").Substring(6, 6);
            if (_dicScanItemDetail.Keys.Contains(tmprfid))
            {
                msg = "已扫RFID:" + tmprfid;
            }
            else
            {
                if (string.IsNullOrEmpty(_rfid))
                {
                    _rfid = tmprfid;

                    timer1.Enabled = false;
                    txt3RFID.Text = _rfid;
                    txt3RFID.Focus();
                    msg = "扫到RFID:" + _rfid;
                }
            }

            SetMsg(lbl0Msg, msg);
        }
        public void initfirst()
        {
            Common.GetDaoCommon(ref m_daoCommon);
            _dicScanItemDetail = new Dictionary<string, scanItemDetail>();

            //set focus
            txt3RFID.Focus();
        }
        #region basefun
        bool checkTxt()
        {
            return
             allTextBox(txt3RFID, false) &&
             allTextBox(txt2Shelf, false);
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

            }));


            SetMsg(lbl0Msg, "添加 " + tmpNewValue.rfid + " 成功。");

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
            string[] tmpstr = new string[2];

            tmpstr[0] = item.rfid;
            tmpstr[1] = item.shelf_no;

            ListViewItem tmpitems1 = new ListViewItem(tmpstr);
            listView1.Items.Add(tmpitems1);
            listView1.Items[0].Selected = true;
        }
        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!serialport.IsOpen)
            {
                if (string.IsNullOrEmpty(txt3RFID.Text) || string.IsNullOrEmpty(_rfid))
                {
                    serialport.Open();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txt3RFID_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt3RFID.Text))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    var gettmpScanRFID = getRFID_t_stockinctnnodetail(txt3RFID.Text.Trim(), "1");

                    if (gettmpScanRFID == null)
                    {
                        var tmpmsg = "系统不存在有效的RFID:" + txt3RFID.Text;
                        SetMsg(lbl0Msg, tmpmsg);
                        MessageBox.Show(tmpmsg);
                        txt3RFID.Text = "";
                        txt3RFID.Focus();
                        return;
                    }
                    else
                    {
                        txt2Shelf.Focus();
                    }
                }
            }
            //setFouces(e, txt2Shelf);
        }

        private void txt5PQty_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt2Shelf.Text))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    var tmpmsg = "";

                    Cursor.Current = Cursors.WaitCursor;
                    try
                    {
                        if (!checkTxt())
                        {
                            return;
                        }
                        var tmpkey = txt3RFID.Text.Trim();

                        if (_dicScanItemDetail.ContainsKey(tmpkey))
                        {
                            if (!string.IsNullOrEmpty(txt2Shelf.Text))
                            {
                                _dicScanItemDetail[tmpkey].shelf_no = txt2Shelf.Text.Trim();
                            }
                            addToListAllView();

                            SetMsg(lbl0Msg, "RFID:" + txt3RFID.Text + " 已经存在。");
                        }
                        else
                        {
                            scanItemDetail tmpscan = new scanItemDetail();

                            tmpscan.rfid = txt3RFID.Text.Trim();
                            tmpscan.shelf_no = txt2Shelf.Text.Trim();

                            //_dicScanItemDetail.Add(tmpkey, tmpscan);
                            addToListAllView(tmpkey, tmpscan);

                        }
                        AllInit(false);
                    }
                    catch (Exception ex)
                    {
                        tmpmsg = ex.Message;
                        SetMsg(lbl0Msg, tmpmsg);
                        MessageBox.Show(tmpmsg);
                    }
                    finally
                    {
                        Cursor.Current = Cursors.Default;
                    }
                }
            }
        }
        #region db DAO
        bool InserToT_stockdetail(scanItemDetail item)
        {
            try
            {
                StringDictionary dicItemValue = new StringDictionary();
                //user
                StringDictionary DidUserCollum = new StringDictionary();
                //log for use
                DidUserCollum[t_stockdetail.adduser] = "true";
                DidUserCollum[t_stockdetail.addtime] = "true";
                DidUserCollum[t_stockdetail.updtime] = "true";
                DidUserCollum[t_stockdetail.upduser] = "true";

                dicItemValue[t_stockdetail.prdct_no] = item.productid;
                dicItemValue[t_stockdetail.rfid_no] = item.rfid;
                dicItemValue[t_stockdetail.ctnno_no] = item.ctnno_no;

                dicItemValue[t_stockdetail.shelf_no] = item.shelf_no;
                dicItemValue[t_stockdetail.receiptno] = item.receiptno;

                dicItemValue[t_stockdetail.pqty] = item.pqty;
                dicItemValue[t_stockdetail.qty] = item.qty;
                dicItemValue[t_stockdetail.nwet] = item.nwet;
                dicItemValue[t_stockdetail.gwet] = item.gwet;

                dicItemValue[t_stockdetail.status] = "1";


                this.m_daoCommon.SetInsertDataItem(ViewOrTable.t_stockdetail, dicItemValue, DidUserCollum);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        bool Update_stockdetail(scanItemDetail item)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                StringDictionary dicItemValue = new StringDictionary();


                dicItemValue[t_stockinctnnodetail.stockin_id] = item.stockid;
                dicItemValue[t_stockinctnnodetail.prdct_no] = item.productid;
                dicItemValue[t_stockinctnnodetail.rfid_no] = item.rfid;
                dicItemValue[t_stockinctnnodetail.ctnno_no] = item.ctnno_no;

                //primary key
                StringDictionary disPrimaryKey = new StringDictionary();


                disPrimaryKey[t_stockinctnnodetail.stockin_id] = item.stockid;
                disPrimaryKey[t_stockinctnnodetail.prdct_no] = item.productid;
                disPrimaryKey[t_stockinctnnodetail.rfid_no] = item.rfid;
                disPrimaryKey[t_stockinctnnodetail.ctnno_no] = item.ctnno_no;

                var dis00UserCollum2 = new StringDictionary();
                dis00UserCollum2[t_stockinctnno.updtime] = "true";
                dis00UserCollum2[t_stockinctnno.upduser] = "true";

                //value 

                dicItemValue[t_stockdetail.status] = "0";


                this.m_daoCommon.SetModifyDataItem(ViewOrTable.t_stockinctnnodetail, dicItemValue, disPrimaryKey, dis00UserCollum2);

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {

                Cursor.Current = Cursors.Default;

            }
        }
        public scanItemDetail getRFID_t_stockinctnnodetail(string tmprfid, string isStatus)
        {
            scanItemDetail tmpScan = new scanItemDetail();

            StringDictionary disWhereValueItem = new StringDictionary();
            StringDictionary disForValueItem = new StringDictionary();

            //table
            DataTable dt = null;
            disWhereValueItem[t_stockinctnnodetail.rfid_no] = tmprfid;
            disForValueItem[t_stockinctnnodetail.rfid_no] = "true";

            disWhereValueItem[t_stockinctnnodetail.status] = isStatus;
            disForValueItem[t_stockinctnnodetail.status] = "true";


            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //get dt
                dt = this.m_daoCommon.GetTableInfo(ViewOrTable.t_stockinctnnodetail, disWhereValueItem, disForValueItem, _disNull, "", false);

                if (dt.Rows.Count > 0)
                {
                    var dr = dt.Rows[0];

                    tmpScan.stockid = dr[t_stockinctnnodetail.stockin_id].ToString();
                    tmpScan.productid = dr[t_stockinctnnodetail.prdct_no].ToString();

                    tmpScan.receiptno = dr[t_stockinctnnodetail.receiptno].ToString();


                    tmpScan.rfid = dr[t_stockinctnnodetail.rfid_no].ToString();
                    tmpScan.ctnno_no = dr[t_stockinctnnodetail.ctnno_no].ToString();

                    tmpScan.pqty = dr[t_stockinctnnodetail.pqty].ToString();
                    tmpScan.qty = dr[t_stockinctnnodetail.qty].ToString();
                    tmpScan.nwet = dr[t_stockinctnnodetail.nwet].ToString();
                    tmpScan.gwet = dr[t_stockinctnnodetail.gwet].ToString();

                    Cursor.Current = Cursors.Default;
                    return tmpScan;
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    return null;
                }

            }
            catch (Exception ex)
            {
                var msg = tmprfid + "," + ex.Message;
                LogManager.WriteLog(Common.LogFile.Error, msg);
                SetMsg(lbl0Msg, msg);
                MessageBox.Show(msg);
                Cursor.Current = Cursors.Default;
                return null;
            }
            finally
            {

                Cursor.Current = Cursors.Default;
            }
        }
        public scanItemDetail getRFID_t_stockDetails(scanItemDetail item)
        {
            scanItemDetail tmpScan = new scanItemDetail();

            StringDictionary disWhereValueItem = new StringDictionary();
            StringDictionary disForValueItem = new StringDictionary();

            //table
            DataTable dt = null;
            disWhereValueItem[t_stockdetail.rfid_no] = item.rfid;
            disForValueItem[t_stockdetail.rfid_no] = "true";

            disWhereValueItem[t_stockdetail.prdct_no] = item.productid;
            disForValueItem[t_stockdetail.prdct_no] = "true";


            disWhereValueItem[t_stockdetail.shelf_no] = item.shelf_no;
            disForValueItem[t_stockdetail.shelf_no] = "true";


            disWhereValueItem[t_stockdetail.status] = "1";
            disForValueItem[t_stockdetail.status] = "true";



            disWhereValueItem[t_stockdetail.ctnno_no] = item.ctnno_no;
            disForValueItem[t_stockdetail.ctnno_no] = "true";


            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //get dt
                dt = this.m_daoCommon.GetTableInfo(ViewOrTable.t_stockdetail, disWhereValueItem, disForValueItem, _disNull, "", false);

                if (dt.Rows.Count > 0)
                {
                    var dr = dt.Rows[0];

                    //tmpScan.stockid = dr[t_stockdetail.].ToString();
                    tmpScan.productid = dr[t_stockdetail.prdct_no].ToString();

                    tmpScan.receiptno = dr[t_stockdetail.receiptno].ToString();


                    tmpScan.rfid = dr[t_stockdetail.rfid_no].ToString();
                    tmpScan.shelf_no = dr[t_stockdetail.shelf_no].ToString();

                    tmpScan.ctnno_no = dr[t_stockdetail.ctnno_no].ToString();

                    tmpScan.pqty = dr[t_stockdetail.pqty].ToString();
                    tmpScan.qty = dr[t_stockdetail.qty].ToString();
                    tmpScan.nwet = dr[t_stockdetail.nwet].ToString();
                    tmpScan.gwet = dr[t_stockdetail.gwet].ToString();

                    Cursor.Current = Cursors.Default;
                    return tmpScan;
                }
                else
                {
                    Cursor.Current = Cursors.Default;
                    return null;
                }

            }
            catch (Exception ex)
            {
                var msg = "RFID:"+ item.rfid+",Product:"+item.productid + "," + ex.Message;
                LogManager.WriteLog(Common.LogFile.Error, msg);
                SetMsg(lbl0Msg, msg);
                MessageBox.Show(msg);
                Cursor.Current = Cursors.Default;
                return null;
            }
            finally
            {

                Cursor.Current = Cursors.Default;
            }
        }

        public bool Update_t_Stock(scanItemDetail item)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                StringDictionary dicItemValue = new StringDictionary();

                StringDictionary dicConsValue = new StringDictionary();
                //主表
                DataTable dtStock = null;
                dicItemValue[t_stock.prdct_no] = item.productid;
                dicConsValue[t_stock.prdct_no] = "true";

                //primary key
                StringDictionary disPrimaryKey = new StringDictionary();
                disPrimaryKey[t_stock.prdct_no] = item.productid;

                var dis00UserCollum2 = new StringDictionary();
                dis00UserCollum2[t_stock.updtime] = "true";
                dis00UserCollum2[t_stock.upduser] = "true";

                //user
                StringDictionary dis00UserCollum = new StringDictionary();
                //log for use
                dis00UserCollum[t_stock.adduser] = "true";
                dis00UserCollum[t_stock.addtime] = "true";
                dis00UserCollum[t_stock.updtime] = "true";
                dis00UserCollum[t_stock.upduser] = "true";

                //todo
                //get dt
                dtStock = this.m_daoCommon.GetTableInfo(ViewOrTable.t_stock, dicItemValue, dicConsValue, _disNull, "", false);

                if (dtStock.Rows.Count <= 0)
                {
                    //new
                    dicItemValue[t_stock.prdct_no] = item.productid;
                    dicItemValue[t_stock.pqty] = item.pqty;
                    dicItemValue[t_stock.qty] = item.qty;
                    dicItemValue[t_stock.nwet] =item.nwet;
                    dicItemValue[t_stock.gwet] = item.gwet;
                    dicItemValue[t_stock.status] = "1";

                    this.m_daoCommon.SetInsertDataItem(ViewOrTable.t_stock, dicItemValue, dis00UserCollum);

                }
                else
                {
                    
                    var tmp_pqty_Stock = decimal.Parse(dtStock.Rows[0][t_stock.pqty].ToString());
                    var tmp_pqty_StockIn = decimal.Parse(item.pqty);

                    var tmp_qty_Stock = decimal.Parse(dtStock.Rows[0][t_stock.qty].ToString());
                    var tmp_qty_StockIn = decimal.Parse(item.qty);

                    var tmp_nwet_Stock = decimal.Parse(dtStock.Rows[0][t_stock.nwet].ToString());
                    var tmp_nwet_StockIn = decimal.Parse(item.nwet);

                    var tmp_gwet_Stock = decimal.Parse(dtStock.Rows[0][t_stock.gwet].ToString());
                    var tmp_gwet_StockIn = decimal.Parse(item.gwet);
                    //new
                    dicItemValue[t_stock.prdct_no] = item.productid;
                    dicItemValue[t_stock.pqty] = (tmp_pqty_Stock + tmp_pqty_StockIn).ToString();
                    dicItemValue[t_stock.qty] = (tmp_qty_Stock + tmp_qty_StockIn).ToString();
                    dicItemValue[t_stock.nwet] = (tmp_nwet_Stock + tmp_nwet_StockIn).ToString();
                    dicItemValue[t_stock.gwet] = (tmp_gwet_Stock + tmp_gwet_StockIn).ToString();
                    dicItemValue[t_stock.status] = "1";

                    this.m_daoCommon.SetModifyDataItem(ViewOrTable.t_stock, dicItemValue, disPrimaryKey, dis00UserCollum2);

                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string noticeRFID = "";
            string tmpmsg = "";
            bool IsStartTran = false;
            timer1.Enabled = false;
            var message = "货物上架:";
            var resutl = "0";
            try
            {
                if (listView1.Items.Count <= 0)
                {
                    //尚未扫描到任何数据！ 
                    MessageBox.Show("没有扫到任何记录", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txt3RFID.Focus();
                    return;
                }
                //确定上传数据？ 
                if (MessageBox.Show("确定上传数据？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    //打开数据库连接
                    Common.AdoConnect.Connect.ConnectOpen();
                    Common.AdoConnect.Connect.CreateSqlTransaction();
                    IsStartTran = true;
                    lbl0Msg.Visible = true;

                    foreach (var item in _dicScanItemDetail.Values)
                    {

                        //获取有效的实际入库表rfid,插入库存明细表.
                        var tmpGetStock = getRFID_t_stockinctnnodetail(item.rfid, "1");

                        if (tmpGetStock != null)
                        {
                            tmpGetStock.shelf_no = item.shelf_no;

                            var checkStockDetails = getRFID_t_stockDetails(tmpGetStock);

                            message += tmpGetStock.rfid + ",";

                            if (checkStockDetails!=null)
                            {
                                throw new Exception("库存明细表中存在对应的记录,RFID:" + tmpGetStock.rfid + ",Product:" + tmpGetStock.productid);
                            }


                            InserToT_stockdetail(tmpGetStock);
                            Update_stockdetail(tmpGetStock);
                            //更新库存.
                            Update_t_Stock(tmpGetStock);
                        }
                        else
                        {
                            noticeRFID += item.rfid + ",";
                        }

                    }

                    Common.AdoConnect.Connect.TransactionCommit();
                    resutl = "1";
                    tmpmsg = "上传数据完成。";
                    if (!string.IsNullOrEmpty(noticeRFID))
                    {
                        tmpmsg += "其中 RFID:" + noticeRFID + ",未上传成功.";
                    }
                    SetMsg(lbl0Msg, tmpmsg);
                    MessageBox.Show(tmpmsg);
                    AllInit(true);
                }
                txt3RFID.Focus();

            }
            catch (Exception ex)
            {
                if (IsStartTran)
                    Common.AdoConnect.Connect.TransactionRollback();
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                SetMsg(lbl0Msg, ex.Message);
                Cursor.Current = Cursors.Default;
            }
            finally
            {
                Program.InserToLog(m_daoCommon, message, "1", resutl, "货物上架");
                Cursor.Current = Cursors.Default;
                timer1.Enabled = true;
            }
        }
        private void txt3RFID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt3RFID.Text))
            {
                _rfid = "";
                timer1.Enabled = true;
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

                var tmpkey = rfid;

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

    }
}