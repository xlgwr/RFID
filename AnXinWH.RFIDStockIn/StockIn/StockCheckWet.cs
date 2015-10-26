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
    public partial class StockCheckWet : Form
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
        public StockCheckWet()
        {
            InitializeComponent();
            //
            this.Closing += new CancelEventHandler(StockCheckWet_Closing);

            //rfid
            initRFID();
            //
            initfirst();
        }
        void StockCheckWet_Closing(object sender, CancelEventArgs e)
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
                msg = "已扫RFID:" + _rfid + "，扫到RFID:" + tmprfid;
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
             allTextBox(txt5PQty, true) && allTextBox(txt5qty, true) && allTextBox(txt6gwet, false) && allTextBox(txt5nWet, false);//&& allTextBox(txt5qty, true)
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
            string[] tmpstr = new string[5];

            tmpstr[0] = item.rfid;
            tmpstr[1] = item.pqty;
            tmpstr[2] = item.qty;
            tmpstr[3] = item.nwet;
            tmpstr[4] = item.gwet;

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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="item"></param>
        /// <param name="notice"></param>
        /// <returns></returns>
        bool InserToNotice(scanItemDetail item, string notice)
        {
            try
            {
                StringDictionary dicItemValue = new StringDictionary();
                //user
                StringDictionary DidUserCollum = new StringDictionary();
                //log for use
                DidUserCollum[t_alarmdata.adduser] = "true";
                DidUserCollum[t_alarmdata.addtime] = "true";
                DidUserCollum[t_alarmdata.updtime] = "true";
                DidUserCollum[t_alarmdata.upduser] = "true";

                dicItemValue[t_alarmdata.recd_id] = DateTime.Now.ToString("yyyyMMddHHmmss") + "R" + item.rfid;
                dicItemValue[t_alarmdata.alarm_type] = "Alarm_03";
                dicItemValue[t_alarmdata.depot_no] = item.rfid;
                dicItemValue[t_alarmdata.cell_no] = item.ctnno_no;
                dicItemValue[t_alarmdata.begin_time] = DateTime.Now.ToString();
                dicItemValue[t_alarmdata.over_time] = DateTime.Now.ToString();
                dicItemValue[t_alarmdata.remark] = "抽检实际重量大于1%。重量：" + item.nwet + ",实际重量：" + item.gwet + ",误差:" + notice;
                dicItemValue[t_alarmdata.status] = "1";


                this.m_daoCommon.SetInsertDataItem(ViewOrTable.t_alarmdata, dicItemValue, DidUserCollum);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            string noticeRFID = "";
            string tmpmsg = "";
            bool IsStartTran = false;
            timer1.Enabled = false;

            try
            {
                Cursor.Current = Cursors.WaitCursor;
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
                        var tmpnwget = double.Parse(item.nwet);
                        var tmpgwet = double.Parse(item.gwet);

                        var tmpabsV = Math.Abs(tmpnwget - tmpgwet);

                        double perNotice = tmpabsV / tmpnwget;
                        double baseV = 0.01;

                        if (perNotice >= baseV)
                        {
                            InserToNotice(item, perNotice.ToString() + "%");
                            noticeRFID += item.rfid + ",";
                            //MessageBox.Show("RFID:" + item.rfid + ",重量不符。>1%");
                        }
                    }

                    Common.AdoConnect.Connect.TransactionCommit();
                    tmpmsg = "上传数据成功。";
                    if (!string.IsNullOrEmpty(noticeRFID))
                    {
                        tmpmsg += "其中 RFID:" + noticeRFID + ",重量不符。>1%";
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
            //else
            //{
            //    KeyEventArgs tmpE = new KeyEventArgs(Keys.Enter);
            //    txt3RFID_KeyDown(sender, tmpE);
            //}
        }

        private void StockCheckWet_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
        }

        private void StockCheckWet_KeyDown(object sender, KeyEventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string getActualWeight()
        {
            StringDictionary disWhereValueItem = new StringDictionary();
            StringDictionary disForValueItem = new StringDictionary();

            //table
            DataTable dt = null;
            disWhereValueItem[m_parameter.paramkey] = "ActualWeight";
            disForValueItem[m_parameter.paramkey] = "true";

            try
            {

                //打开数据库连接
                Common.AdoConnect.Connect.ConnectOpen();
                //主表
                //get dt
                dt = this.m_daoCommon.GetTableInfo(ViewOrTable.m_parameter, disWhereValueItem, disForValueItem, _disNull, "", false);

                if (dt.Rows.Count > 0)
                {
                    var dr = dt.Rows[0];

                    var tmpWet = dr[m_parameter.paramvalue].ToString();

                    return tmpWet;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                SetMsg(lbl0Msg, ex.Message);
                return null;
            }

        }
        public scanItemDetail getRFID_t_stockinctnnodetail(string tmprfid)
        {
            scanItemDetail tmpScan = new scanItemDetail();

            StringDictionary disWhereValueItem = new StringDictionary();
            StringDictionary disForValueItem = new StringDictionary();

            //table
            DataTable dt = null;
            disWhereValueItem[t_stockinctnnodetail.rfid_no] = tmprfid;
            disForValueItem[t_stockinctnnodetail.rfid_no] = "true";

            try
            {

                //打开数据库连接
                Common.AdoConnect.Connect.ConnectOpen();
                //主表
                //get dt
                dt = this.m_daoCommon.GetTableInfo(ViewOrTable.t_stockinctnnodetail, disWhereValueItem, disForValueItem, _disNull, "", false);

                if (dt.Rows.Count > 0)
                {
                    var dr = dt.Rows[0];

                    tmpScan.rfid = dr[t_stockinctnnodetail.rfid_no].ToString();
                    tmpScan.ctnno_no = dr[t_stockinctnnodetail.ctnno_no].ToString();
                    tmpScan.pqty = dr[t_stockinctnnodetail.pqty].ToString();
                    tmpScan.qty = dr[t_stockinctnnodetail.qty].ToString();
                    tmpScan.nwet = dr[t_stockinctnnodetail.nwet].ToString();
                    tmpScan.gwet = dr[t_stockinctnnodetail.gwet].ToString();

                    return tmpScan;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                SetMsg(lbl0Msg, ex.Message);
                return null;
            }

        }
        void initToTxt(scanItemDetail s)
        {
            _currScanItem = s;

            _isChangeTxt = true;
            txt5PQty.Text = s.pqty;
            txt5qty.Text = s.qty;
            txt5nWet.Text = s.nwet;
            _isChangeTxt = false;
        }
        public scanItemDetail _currScanItem { get; set; }
        private void txt3RFID_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt3RFID.Text))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    var tmpScan = getRFID_t_stockinctnnodetail(txt3RFID.Text.Trim());

                    if (tmpScan != null)
                    {
                        timer1.Enabled = false;

                        initToTxt(tmpScan);

                        //get wet

                        string tmpwgt = getActualWeight();

                        if (!string.IsNullOrEmpty(tmpwgt))
                        {
                            _isChangeTxt = true;
                            txt6gwet.Text = tmpwgt;
                            _isChangeTxt = false;

                            if (!string.IsNullOrEmpty(txt6gwet.Text))
                            {
                                KeyEventArgs tmpE = new KeyEventArgs(Keys.Enter);
                                txt6gwet_KeyDown(sender, tmpE);
                            }
                        }
                        else
                        {
                            var msg = "没有找到实际重量.";
                            MessageBox.Show(msg);
                            SetMsg(lbl0Msg, msg);
                        }
                        txt6gwet.Focus();
                    }
                    else
                    {
                        var msg = "没有找到RFID:" + txt3RFID.Text + ",的入库记录.";
                       
                        MessageBox.Show(msg);
                        SetMsg(lbl0Msg, msg); 

                        //txt3RFID.Text = "";
                        //_rfid = "";
                    }
                }
            }
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
            txt5PQty.Text = "";
            txt5qty.Text = "";
            txt5nWet.Text = "";
            txt6gwet.Text = "";
            _isChangeTxt = false;

            txt3RFID.Focus();
        }
        private void txt6gwet_KeyDown(object sender, KeyEventArgs e)
        {

            if (!string.IsNullOrEmpty(txt6gwet.Text))
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
                            _dicScanItemDetail[tmpkey].gwet = txt6gwet.Text.Trim();

                            addToListAllView();

                            SetMsg(lbl0Msg, "RFID:" + txt3RFID.Text + " 已经存在。");
                        }
                        else
                        {
                            scanItemDetail tmpscan = new scanItemDetail();

                            tmpscan.rfid = txt3RFID.Text.Trim();
                            tmpscan.pqty = txt5PQty.Text.Trim();
                            tmpscan.qty = txt5qty.Text.Trim();
                            tmpscan.nwet = txt5nWet.Text.Trim();

                            tmpscan.gwet = txt6gwet.Text.Trim();

                            tmpscan.ctnno_no = _currScanItem.ctnno_no;

                            //_dicScanItemDetail.Add(tmpkey, tmpscan);
                            addToListAllView(tmpkey, tmpscan);

                        }
                        AllInit(false);

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

        private void txt6gwet_TextChanged(object sender, EventArgs e)
        {
            //if (!string.IsNullOrEmpty(txt6gwet.Text))
            //{
            //    KeyEventArgs tmpE = new KeyEventArgs(Keys.Enter);
            //    txt6gwet_KeyDown(sender, tmpE);
            //}
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