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
    public partial class StockOutMainFrm : Form
    {
        //rfid set
        private Action<string> invokeHandler = null;
        SerialPort serialport = null;
        bool isHex = true;
        byte[] buffer = new byte[4096];
        string _rfid = string.Empty;

        /// <summary>
        /// 入库编号 yyyyMMddHHmmss
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

        public static scanItemDetail _currStockInDetails = new scanItemDetail();
        #endregion
        public StockOutMainFrm()
        {
            InitializeComponent();


            //
            this.Closing += new CancelEventHandler(StockInMainFrm_Closing);

            //initdemo
            //initTestDemo();

            //rfid
            initRFID();
            //
            initfirst();
        }
        void initTestDemo()
        {
            _isChangeTxt = true;
            txt11stockin_id.Text = DateTime.Now.ToString("yyyyMMddHHmmss");
            txt12prdct_no.Text = "1";
            txt3RFID.Text = "";
            txt4XiangHao.Text = "1";
            txt5PQty.Text = "0";
            txt5qty.Text = "100";
            txt6nwet.Text = "100";
            _isChangeTxt = false;
        }
        void StockInMainFrm_Closing(object sender, CancelEventArgs e)
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
            if (string.IsNullOrEmpty(_rfid))
            {
                _rfid = tmprfid;

                timer1.Enabled = false;
                txt3RFID.Text = _rfid;
                txt11stockin_id.Focus();
                msg = "扫到RFID:" + _rfid;
            }
            else
            {
                msg = "已扫RFID:" + _rfid + "，扫到RFID:" + tmprfid;
            }
            SetMsg(lbl0Msg, msg);
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
            _rfid = "";

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
        public scanItemDetail getRFID_t_stockDetails(string stockid, string productid)
        {
            if (string.IsNullOrEmpty(stockid) || string.IsNullOrEmpty(productid))
            {
                return null;
            }


            scanItemDetail tmpScan = new scanItemDetail();

            StringDictionary disWhereValueItem = new StringDictionary();
            StringDictionary disForValueItem = new StringDictionary();

            //table
            DataTable dt = null;
            disWhereValueItem[t_stockindetail.stockin_id] = stockid;
            disForValueItem[t_stockindetail.stockin_id] = "true";

            disWhereValueItem[t_stockindetail.prdct_no] = productid;
            disForValueItem[t_stockindetail.prdct_no] = "true";

            disWhereValueItem[t_stockindetail.status] = "1";
            disForValueItem[t_stockindetail.status] = "true";

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //get dt
                dt = this.m_daoCommon.GetTableInfo(ViewOrTable.t_stockindetail, disWhereValueItem, disForValueItem, _disNull, "", false);

                if (dt.Rows.Count > 0)
                {
                    var dr = dt.Rows[0];

                    tmpScan.stockid = dr[t_stockindetail.stockin_id].ToString();
                    tmpScan.productid = dr[t_stockindetail.prdct_no].ToString();

                    tmpScan.receiptno = dr[t_stockindetail.bespeak_no].ToString();


                    //tmpScan.rfid = dr[t_stockindetail.rfid_no].ToString();

                    //tmpScan.shelf_no = dr[t_stockindetail.shelf_no].ToString();

                    //tmpScan.ctnno_no = dr[t_stockindetail.ctnno_no].ToString();

                    tmpScan.pqty = dr[t_stockindetail.pqty].ToString();
                    tmpScan.qty = dr[t_stockindetail.qty].ToString();
                    tmpScan.nwet = dr[t_stockindetail.nwet].ToString();
                    tmpScan.gwet = dr[t_stockindetail.gwet].ToString();

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
                var msg = "订单号:" + stockid + ",Product:" + productid + "," + ex.Message;
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
        bool Update_stockdetail(scanItemDetail item)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                StringDictionary dicItemValue = new StringDictionary();


                dicItemValue[t_stockdetail.prdct_no] = item.productid;
                dicItemValue[t_stockdetail.rfid_no] = item.rfid;


                //primary key
                StringDictionary disPrimaryKey = new StringDictionary();


                disPrimaryKey[t_stockdetail.prdct_no] = item.productid;
                disPrimaryKey[t_stockdetail.rfid_no] = item.rfid;

                var dis00UserCollum2 = new StringDictionary();
                dis00UserCollum2[t_stockdetail.updtime] = "true";
                dis00UserCollum2[t_stockdetail.upduser] = "true";

                //value 

                dicItemValue[t_stockdetail.status] = "0";


                this.m_daoCommon.SetModifyDataItem(ViewOrTable.t_stockdetail, dicItemValue, disPrimaryKey, dis00UserCollum2);

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
        public bool Update_t_StockOut(scanItemDetail item)
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
                    throw new Exception("不存在：" + item.productid + " 的库存记录。");

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

                    if (tmp_qty_StockIn > tmp_qty_Stock)
                    {
                        throw new Exception(item.productid + " 出库数大于库存数。");
                    }
                    //new
                    dicItemValue[t_stock.prdct_no] = item.productid;
                    dicItemValue[t_stock.pqty] = (tmp_pqty_Stock - tmp_pqty_StockIn).ToString();
                    dicItemValue[t_stock.qty] = (tmp_qty_Stock - tmp_qty_StockIn).ToString();
                    dicItemValue[t_stock.nwet] = (tmp_nwet_Stock - tmp_nwet_StockIn).ToString();
                    //dicItemValue[t_stock.gwet] = (tmp_gwet_Stock - tmp_gwet_StockIn).ToString();
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
        private bool UploadData()
        {
            string tmpmsg = "";
            bool IsStartTran = false;

            var message = "货物出货:";
            var resutl = "0";

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
            disWhereValueMain[t_stockoutctnno.stockout_id] = txt11stockin_id.Text.Trim();
            disWhereValueMain[t_stockoutctnno.prdct_no] = txt12prdct_no.Text.Trim();


            //primary key
            dis5ForPrimaryKey_t_stock[t_stockoutctnno.stockout_id] = txt11stockin_id.Text.Trim();
            dis5ForPrimaryKey_t_stock[t_stockoutctnno.prdct_no] = txt12prdct_no.Text.Trim();

            disForOrderByMain[t_stockoutctnno.stockout_id] = "true";
            disForOrderByMain[t_stockoutctnno.prdct_no] = "true";

            //log for use
            DidUserCollum[t_stockoutctnno.adduser] = "true";
            DidUserCollum[t_stockoutctnno.addtime] = "true";
            DidUserCollum[t_stockoutctnno.updtime] = "true";
            DidUserCollum[t_stockoutctnno.upduser] = "true";


            message += "订单号：" + txt11stockin_id.Text;
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                //打开数据库连接
                Common.AdoConnect.Connect.ConnectOpen();
                Common.AdoConnect.Connect.CreateSqlTransaction();

                IsStartTran = true;
                lbl0Msg.Visible = true;

                var tmpsum = calQtyNwet();

                var _rfidStrForSet = txt3RFID.Text.Trim();



                #region  保存记录


                //主表
                //get dt
                dt = this.m_daoCommon.GetTableInfo(ViewOrTable.t_stockoutctnno, disWhereValueMain, disForOrderByMain, _disNull, "", false);


                if (dt.Rows.Count <= 0)
                {

                    disWhereValueMain[t_stockoutctnno.pqty] = tmpsum[0].ToString();
                    disWhereValueMain[t_stockoutctnno.qty] = tmpsum[1].ToString();
                    disWhereValueMain[t_stockoutctnno.nwet] = tmpsum[2].ToString();
                    disWhereValueMain[t_stockoutctnno.gwet] = "0";
                    disWhereValueMain[t_stockoutctnno.status] = "1";

                    //上传主表
                    this.m_daoCommon.SetInsertDataItem(ViewOrTable.t_stockoutctnno, disWhereValueMain, DidUserCollum);
                }
                else
                {
                    tmpmsg = "订单号：" + txt11stockin_id.Text + ",货物编码：" + txt12prdct_no.Text + " 已存在出库记录.无法出库。";//，是否继续。";

                    MessageBox.Show(tmpmsg);
                    return false;

                    if (MessageBox.Show(tmpmsg, "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        var dr = dt.Rows[0];
                        //edit data
                        var tmp_pqty_StockIn = decimal.Parse(dr[t_stockoutctnno.pqty].ToString());
                        var tmp_qty_StockIn = decimal.Parse(dr[t_stockoutctnno.qty].ToString());
                        var tmp_nwet_StockIn = decimal.Parse(dr[t_stockoutctnno.nwet].ToString());
                        var tmp_gwet_StockIn = decimal.Parse(dr[t_stockoutctnno.gwet].ToString());

                        disWhereValueMain[t_stockoutctnno.pqty] = (tmpsum[0] + tmp_pqty_StockIn).ToString();
                        disWhereValueMain[t_stockoutctnno.qty] = (tmpsum[1] + tmp_qty_StockIn).ToString();
                        disWhereValueMain[t_stockoutctnno.nwet] = (tmpsum[2] + tmp_nwet_StockIn).ToString();
                        disWhereValueMain[t_stockoutctnno.status] = "1";


                        var dis00UserCollum2 = new StringDictionary();
                        dis00UserCollum2[t_stockoutctnno.updtime] = "true";
                        dis00UserCollum2[t_stockoutctnno.upduser] = "true";

                        this.m_daoCommon.SetModifyDataItem(ViewOrTable.t_stockoutctnno, disWhereValueMain, dis5ForPrimaryKey_t_stock, dis00UserCollum2);

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
                    disWhereValueItem[t_stockoutctnnodetail.stockout_id] = item.stockid;
                    disWhereValueItem[t_stockoutctnnodetail.prdct_no] = item.productid;

                    disWhereValueItem[t_stockoutctnnodetail.rfid_no] = item.rfid;
                    disWhereValueItem[t_stockoutctnnodetail.ctnno_no] = item.ctnno_no;

                    //仓单号
                    disWhereValueItem[t_stockoutctnnodetail.receiptno] = item.receiptno;

                    disWhereValueItem[t_stockoutctnnodetail.pqty] = item.pqty.Length <= 0 ? "1" : item.pqty;
                    disWhereValueItem[t_stockoutctnnodetail.qty] = item.qty.Length <= 0 ? "0" : item.qty;
                    disWhereValueItem[t_stockoutctnnodetail.nwet] = item.nwet.Length <= 0 ? "0" : item.nwet;
                    disWhereValueItem[t_stockoutctnnodetail.status] = "1";

                    this.m_daoCommon.SetInsertDataItem(ViewOrTable.t_stockoutctnnodetail, disWhereValueItem, DidUserCollum);


                    //更新库存
                    #region save stock

                    Update_stockdetail(item);
                    //更新库存.
                    Update_t_StockOut(item);
                    #endregion

                }

                //
                #endregion

                Common.AdoConnect.Connect.TransactionCommit();
                resutl = "1";
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

                Program.InserToLog(m_daoCommon, message, "1", resutl, "货物出货");

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
                        AllInit();
                    }
                    else
                    {
                        timer1.Enabled = false;
                    }
                }
            }
            catch (Exception ex)
            {
                timer1.Enabled = false;
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show(ex.Message);
            }
            finally
            {
                //AllInit();
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
            if (e.KeyCode == Keys.Enter)
            {
                setFouces(e, txt3RFID);

                if (!string.IsNullOrEmpty(txt3RFID.Text))
                {
                    txt4XiangHao.Focus();
                }
            }

        }

        private void txt3RFID_KeyDown(object sender, KeyEventArgs e)
        {
            timer1.Enabled = true;
            setFouces(e, txt4XiangHao);
        }
        public scanItemDetail Check_RFID_t_stockinctnnodetail(string tmprfid, string isStatus)
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


        public scanItemDetail Check_RFID_t_stockOutdetail(string tmprfid, string stockId, string productno)
        {
            scanItemDetail tmpScan = new scanItemDetail();

            StringDictionary disWhereValueItem = new StringDictionary();
            StringDictionary disForValueItem = new StringDictionary();

            //table
            DataTable dt = null;
            disWhereValueItem[t_stockoutdetail.stockout_id] = stockId;
            disForValueItem[t_stockoutdetail.stockout_id] = "true";

            disWhereValueItem[t_stockoutdetail.prdct_no] = productno;
            disForValueItem[t_stockoutdetail.prdct_no] = "true";

            disWhereValueItem[t_stockoutdetail.rfid_no] = tmprfid;
            disForValueItem[t_stockoutdetail.rfid_no] = "true";

            disWhereValueItem[t_stockoutdetail.status] = "1";
            disForValueItem[t_stockoutdetail.status] = "true";


            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //get dt
                dt = this.m_daoCommon.GetTableInfo(ViewOrTable.t_stockoutdetail, disWhereValueItem, disForValueItem, _disNull, "", false);

                if (dt.Rows.Count > 0)
                {
                    var dr = dt.Rows[0];

                    tmpScan.stockid = dr[t_stockoutdetail.stockout_id].ToString();
                    tmpScan.productid = dr[t_stockoutdetail.prdct_no].ToString();

                    tmpScan.receiptno = dr[t_stockoutdetail.receiptno].ToString();


                    tmpScan.rfid = dr[t_stockoutdetail.rfid_no].ToString();
                    tmpScan.ctnno_no = dr[t_stockoutdetail.pc].ToString();

                    tmpScan.pqty = dr[t_stockoutdetail.pqty].ToString();
                    tmpScan.qty = dr[t_stockoutdetail.qty].ToString();
                    tmpScan.nwet = dr[t_stockoutdetail.nwet].ToString();
                    tmpScan.gwet = dr[t_stockoutdetail.gwet].ToString();

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

        public scanItemDetail Check_RFID_t_stockdetail(string tmprfid, string productno)
        {
            scanItemDetail tmpScan = new scanItemDetail();

            StringDictionary disWhereValueItem = new StringDictionary();
            StringDictionary disForValueItem = new StringDictionary();

            //table
            DataTable dt = null;

            disWhereValueItem[t_stockdetail.prdct_no] = productno;
            disForValueItem[t_stockdetail.prdct_no] = "true";

            disWhereValueItem[t_stockdetail.rfid_no] = tmprfid;
            disForValueItem[t_stockdetail.rfid_no] = "true";

            //disWhereValueItem[t_stockdetail.remark] = stockId;
            //disForValueItem[t_stockdetail.remark] = "true";

            disWhereValueItem[t_stockdetail.status] = "1";
            disForValueItem[t_stockdetail.status] = "true";


            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //get dt
                dt = this.m_daoCommon.GetTableInfo(ViewOrTable.t_stockdetail, disWhereValueItem, disForValueItem, _disNull, "", false);

                if (dt.Rows.Count > 0)
                {
                    var dr = dt.Rows[0];

                    tmpScan.stockid = dr[t_stockdetail.remark].ToString();
                    tmpScan.productid = dr[t_stockdetail.prdct_no].ToString();

                    tmpScan.receiptno = dr[t_stockdetail.receiptno].ToString();


                    tmpScan.rfid = dr[t_stockdetail.rfid_no].ToString();
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



                    var tmpCheckScan1 = Check_RFID_t_stockOutdetail(txt3RFID.Text.Trim(), txt11stockin_id.Text.Trim(), txt12prdct_no.Text.Trim());


                    if (tmpCheckScan1 == null)
                    {
                        tmpmsg = "不存在对应的 出库号：" + txt11stockin_id.Text + ",货物编号：" + txt12prdct_no.Text + ",RFID:" + txt3RFID.Text;
                        SetMsg(lbl0Msg, tmpmsg);
                        MessageBox.Show(tmpmsg);
                        txt3RFID.Text = "";
                        _rfid = "";
                        return;
                    }

                    var tmpCheckStockDetails = Check_RFID_t_stockdetail(txt3RFID.Text.Trim(), txt12prdct_no.Text.Trim());


                    if (tmpCheckStockDetails == null)
                    {
                        tmpmsg = "出库号：" + txt11stockin_id.Text + ", 货物编号：" + txt12prdct_no.Text + ",RFID:" + txt3RFID.Text + " 早已出库。";
                        SetMsg(lbl0Msg, tmpmsg);
                        MessageBox.Show(tmpmsg);
                        txt3RFID.Text = "";
                        _rfid = "";
                        return;
                    }

                    var tmpkey = txt3RFID.Text.Trim();// txt11stockin_id.Text.Trim() + "," + txt12prdct_no.Text.Trim() + "," + txt3RFID.Text.Trim() + "," + txt4XiangHao.Text.Trim();

                    if (_dicScanItemDetail.ContainsKey(tmpkey))
                    {
                        _dicScanItemDetail[tmpkey].qty = txt5qty.Text.Trim();
                        _dicScanItemDetail[tmpkey].nwet = txt6nwet.Text.Trim();

                        addToListAllView();

                        SetMsg(lbl0Msg, "RFID:" + txt3RFID.Text + ", 已经存在。");//托盘号：" + txt4XiangHao.Text + "
                    }
                    else
                    {
                        scanItemDetail tmpscan = new scanItemDetail();

                        tmpscan.receiptno = tmpCheckScan1.receiptno;

                        _isChangeTxt = true;
                        tmpscan.stockid = txt11stockin_id.Text.Trim();
                        tmpscan.productid = txt12prdct_no.Text.Trim();
                        tmpscan.rfid = txt3RFID.Text.Trim();
                        tmpscan.ctnno_no = txt4XiangHao.Text.Trim();
                        tmpscan.pqty = "1";

                        txt5qty.Text = tmpCheckScan1.qty;
                        txt6nwet.Text = tmpCheckScan1.nwet;

                        tmpscan.qty = txt5qty.Text.Trim();
                        tmpscan.nwet = txt6nwet.Text.Trim();
                        tmpscan.gwet = (tmpCheckScan1.gwet == null || tmpCheckScan1.gwet == "") ? "0" : tmpCheckScan1.gwet;

                        _isChangeTxt = false;
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
                var tmpkey = txt3RFID.Text.Trim();// txt11stockin_id.Text.Trim() + "," + txt12prdct_no.Text.Trim() + "," + txt3RFID.Text.Trim() + "," + txt4XiangHao.Text.Trim();

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

                var tmpkey = rfid;// txt11stockin_id.Text.Trim() + "," + pruductid + "," + rfid + "," + cton;

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
            timer1.Enabled = true;
        }

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

        private void txt3RFID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt3RFID.Text))
            {
                _rfid = "";
                timer1.Enabled = true;
            }
        }

        private void txt12prdct_no_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt4XiangHao_TextChanged(object sender, EventArgs e)
        {

        }
    }
}