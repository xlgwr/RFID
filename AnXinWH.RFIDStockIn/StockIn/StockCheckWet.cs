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
            if (string.IsNullOrEmpty(_rfid))
            {
                _rfid = tmprfid;

                timer1.Enabled = false;
                txt3RFID.Text = _rfid;
                txt3RFID.Focus();
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

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void txt3RFID_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt3RFID.Text))
            {
                _rfid = "";
                timer1.Enabled = true;
            }
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
            _isChangeTxt = true;
            txt5PQty.Text = s.pqty;
            txt5qty.Text = s.qty;
            txt5nWet.Text = s.nwet;
            _isChangeTxt = false;
        }
        private void txt3RFID_KeyDown(object sender, KeyEventArgs e)
        {
            if (!string.IsNullOrEmpty(txt3RFID.Text))
            {
                if (e.KeyCode == Keys.Enter)
                {
                    var tmpScan = getRFID_t_stockinctnnodetail(txt3RFID.Text.Trim());

                    if (tmpScan != null)
                    {
                        initToTxt(tmpScan);
                    }
                    else
                    {
                        var msg = "没有找到RFID:" + tmpScan + ",的入库记录.";
                        MessageBox.Show(msg);
                        SetMsg(lbl0Msg, msg);
                    }
                }
            }
        }

    }
}