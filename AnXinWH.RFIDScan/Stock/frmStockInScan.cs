using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Collections.Specialized;
using Framework.DataAccess;
using Framework.Libs;
using RRU9803WinCE;
using System.Runtime.InteropServices;
using AnXinWH.RFIDScan.Libs;
using ModuleTech;
using ClassLibraryDKG;
using ModuleLibrary;

namespace AnXinWH.RFIDScan.Stock
{
    public partial class frmStockInScan : Form
    {

        /// <summary>
        /// 入库编号 yyyyMMDDHHmmss
        /// </summary>
        private string _stockin_no = DateTime.Now.ToString("yyyyMMddHHmmss");

        /// <summary>
        /// 共通数据对象
        /// </summary>
        protected CBaseConnect m_daoCommon;


        StringDictionary _disNull = new StringDictionary();

        private StringDictionary DicData = new StringDictionary();
        /// <summary>
        /// 存储标签号
        /// </summary>
        private string TempDocTag = string.Empty;
        /// <summary>
        /// 存储已经扫描出的图册编号
        /// </summary>
        private List<string> DocList = new List<string>();

        //private delegate void DelegateEvent();
        //private DelegateEvent delegateevent;
        //private System.Threading.Thread thread1 = null;

        private StringDictionary DidUserCollum = new StringDictionary();

        private StringDictionary DicNull = new StringDictionary();
        /// <summary>
        /// 存储该盘点单号下的图册信息；key--标签号；value--图册编号
        /// </summary>
        private StringDictionary m_DocInfo = new StringDictionary();

        #region 采集器部分

        [DllImport("coredll.dll")]
        public static extern bool MessageBeep(int uType);
        /// <summary>
        /// 画面扫描卡号对象(key: CardNo； Value: ScanTime)
        /// </summary>
        private StringDictionary m_dicCardInfo = new StringDictionary();

        #endregion
        #region 初始化RFID号
        public static string _rfidNo = string.Empty;
        public static List<scanItemDetail> _lisCtnNo;
        #endregion
        public frmStockInScan()
        {
            InitializeComponent();
            txt11stockin_no.Text = _stockin_no;
            //tmpTestData();
            _lisCtnNo = new List<scanItemDetail>();
        }
        void tmpTestData()
        {
            var strs = "1,2,3".Split(',');
            var strs2 = "4,5,6".Split(',');
            var strs3 = "7,8,9".Split(',');

            ListViewItem item = new ListViewItem(strs);
            ListViewItem item2 = new ListViewItem(strs2);
            ListViewItem item3 = new ListViewItem(strs3);

            this.listView1.Items.Add(item);
            this.listView1.Items.Add(item2);
            this.listView1.Items.Add(item3);
        }
        private void frmInvtryScan_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                //SetLangeage();

                Common.GetDaoCommon(ref m_daoCommon);

                lnlTotal.Visible = true;
                lnlTotal.Text = "";


                //设置采集器功率
                SysParam.m_busModule.SetUpdateAntPower(2300);

                //thread1 = new System.Threading.Thread(new System.Threading.ThreadStart(StartDelegate));

            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //初始化失败,请联系系统管理员！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS002"),
                    Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void SetLangeage()
        {
            try
            {
                this.lblTitle.Text = Common.GetLanguageWord(this.Name, this.lblTitle.Name);
                this.listView1.Columns[(int)EnumInvtryScan.DocNo].Text = Common.GetLanguageWord(this.Name, "CradNo");
                this.label1.Text = Common.GetLanguageWord(this.Name, this.label1.Name);
                this.lnlTotal.Text = Common.GetLanguageWord(this.Name, this.lnlTotal.Name);
                //this.button1.Text = Common.GetLanguageWord(this.Name, //this.button1.Name);
                this.button2.Text = Common.GetLanguageWord(this.Name, this.button2.Name);
                this.button3.Text = Common.GetLanguageWord(this.Name, this.button3.Name);

                col0XianHaoNum.Text = Common.GetLanguageWord(this.Name, "columnHeader1");
                col2Num.Text = Common.GetLanguageWord(this.Name, "columnHeader2");
            }
            catch (Exception wx)
            {

                throw wx;
            }

        }
        public static int IsValidHexstr(string str, int len)
        {
            if (str == "")
                return -3;
            if (str.Length % 4 != 0)
                return -2;
            if (str.Length > len)
                return -4;
            string lowstr = str.ToLower();
            byte[] hexchars = Encoding.ASCII.GetBytes(lowstr);

            foreach (byte a in hexchars)
            {
                if (!((a >= 48 && a <= 57) || (a >= 97 && a <= 102)))
                    return -1;
            }
            return 0;
        }

        /// <summary>
        /// 设得的RFID标签号
        /// </summary>
        private bool setInventNo(string strtohx)
        {
            var tmptag = Encryption.StringToHexString(strtohx, Encoding.UTF8);
            // var TempDocTag = "1234567890";

            try
            {

                if (SysParam.m_busModule.IsSucces)
                {
                    SysParam.m_busModule.Reader.ParamSet("TagopAntenna", 1);
                    //if (IsValidHexstr(tmptag, 600) != 0)
                    //{
                    //    throw new Exception("将要写入的数据是16进制的字符,且长度为4字符的整数倍");

                    //}
                    TagData epccode = new TagData(tmptag);
                    SysParam.m_busModule.Reader.WriteTag(null, epccode);
                    var tmpmsg = "设置RFID卡成功:" + tmptag + ",Value:" + strtohx;
                    SetMsg(lnlTotal, tmpmsg);
                    MessageBox.Show(tmpmsg);
                    return true;
                    //lnlTotal.Text += "," + tmptag;
                }

            }
            catch (Exception ex)
            {
                string msg = string.Empty;
                if (ex is ModuleLibrary.FatalInternalException)
                    msg = Convert.ToString(((ModuleLibrary.FatalInternalException)ex).ErrCode, 16);
                if (ex is ModuleLibrary.HardwareAlertException)
                    msg = ((ModuleLibrary.HardwareAlertException)ex).ErrCode.ToString();
                if (ex is ModuleLibrary.ModuleException)
                    msg = ((ModuleLibrary.ModuleException)ex).ErrCode.ToString();
                if (ex is ModuleLibrary.OpFaidedException)
                    msg = ((ModuleLibrary.OpFaidedException)ex).ErrCode.ToString();
                msg = "设置RFID卡失败." + ex.Message + " :" + msg;
                SetMsg(lnlTotal, msg);
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Hand, MessageBoxDefaultButton.Button1);

                return false;

                //采集器设备连接失败，请及时与管理员联系！ 
                //throw new Exception(Common.GetLanguageWord(this.Name, "FIS001") + System.Environment.NewLine + ex.Message.ToString());
            }
            return false;
        }

        /// <summary>
        /// 获取取得的RFID标签号
        /// </summary>
        private void GetInventNo()
        {
            //TempDocTag = "1234567890";

            try
            {

                if (SysParam.m_busModule.IsSucces)
                {
                    TagReadData[] reads = SysParam.m_busModule.Reader.Read(100);

                    foreach (TagReadData item in reads)
                    {
                        //卡号为八位
                        //if (item.EPCString.Trim().Length == 8)
                        //{
                        MessageBeep(10);
                        if (!this.m_dicCardInfo.ContainsKey(item.EPCString.Trim()))
                        {
                            this.m_dicCardInfo[item.EPCString.Trim()] = DateTime.Now.ToString();
                        }

                        //}
                    }
                }

            }
            catch (Exception ex)
            {
                //采集器设备连接失败，请及时与管理员联系！ 
                //throw new Exception(Common.GetLanguageWord(this.Name, "FIS001") + System.Environment.NewLine + ex.Message.ToString());
            }
        }
        bool allTextBox(TextBox tb, bool isnum)
        {
            if (isnum)
            {
                if (!PageValidate.IsDecimal(tb.Text))
                {
                    tb.Focus();
                    lnlTotal.Text = "请输入正确数字。谢谢";
                    return false;
                }
            }
            else
            {
                if (tb.Text.Trim().Length <= 0)
                {
                    tb.Focus();
                    lnlTotal.Text = "请输入正确内容。谢谢";
                    return false;

                }
            }

            return true;
        }
        bool checkTxt()
        {
            return
             allTextBox(txt11stockin_no, false) &&
             allTextBox(txt12prdct_no, false) && allTextBox(txt13pqty, true);
        }
        void SetMsg(Label lb, string msg)
        {
            this.Invoke(new Action(delegate()
            {
                lb.Text = msg;
            }));
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (!checkTxt())
            {
                return;
            }
            Cursor.Current = Cursors.WaitCursor;
            try
            {


                if (listView1.Items.Count <= 0)
                {
                    //尚未扫描到任何数据！ 
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS008"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                    return;
                }

                //确定上传数据？ 
                if (MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS006"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    UploadData();
                }

                #region write/get rfid
                //read rfid code text
                var tmprfid = "";
                m_dicCardInfo.Clear();

                SetMsg(lnlTotal, "开始获取RFID号。");
                for (int i = 0; i < 5; i++)
                {
                    GetInventNo();
                    if (m_dicCardInfo.Count > 0)
                    {
                        break;
                    }
                }

                foreach (var item in this.m_dicCardInfo.Keys)
                {
                    tmprfid = item.ToString();
                }
                if (tmprfid.Length > 0)
                {
                    var tmpmsg = "读到RFID:" + tmprfid + ",value:" + Encryption.HexStringToString(tmprfid.ToString(), Encoding.UTF8);
                    SetMsg(lnlTotal, tmpmsg);
                    MessageBox.Show(tmpmsg);
                }
                //write rfid code test
                var strtohx = txt11stockin_no.Text.Trim() + txt12prdct_no.Text.Trim() + txt13pqty.Text.Trim();


                SetMsg(lnlTotal, "开始设置RFID号");
                var tmpset = setInventNo(strtohx);
                while (!tmpset)
                {

                    //确定重新设置RFID号
                    if (MessageBox.Show("确定重新设置RFID号", "Notice", MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        tmpset = setInventNo(strtohx);
                    }
                    else
                    {
                        tmpset = true;
                    }

                }

                #endregion
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //数据上传失败,请联系系统管理员！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS007"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void UploadData()
        {
            bool IsStartTran = false;


            //set value
            StringDictionary disWhereValueMain = new StringDictionary();
            StringDictionary disWhereValueItem = new StringDictionary();
            //select            
            StringDictionary disForValueMain = new StringDictionary();
            StringDictionary disForValueItem = new StringDictionary();
            //order by            
            StringDictionary disForOrderByMain = new StringDictionary();
            StringDictionary disForOrderByItem = new StringDictionary();

            //主表
            DataTable dt = null;
            disWhereValueMain[MasterTableWHS.t_stockinctnno.stockin_no] = this._stockin_no;
            disWhereValueMain[MasterTableWHS.t_stockinctnno.prdct_no] = txt12prdct_no.Text.Trim();
            disForOrderByMain[MasterTableWHS.t_stockinctnno.stockin_no] = "true";
            disForOrderByMain[MasterTableWHS.t_stockinctnno.prdct_no] = "true";



            Cursor.Current = Cursors.WaitCursor;
            try
            {

                if (listView1.Items.Count <= 0)
                {
                    //尚未扫描到任何数据！ 
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS008"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                    return;
                }
                //主表
                //get dt
                dt = this.m_daoCommon.GetTableInfo(MasterTableWHS.ViewOrTable.t_stockinctnno, disWhereValueMain, disForOrderByMain, _disNull, "", false);

                if (dt.Rows.Count <= 0)
                {
                    _rfidNo = _lisCtnNo + txt12prdct_no.Text.Trim() + txt13pqty.Text.Trim() + "001";
                }
                else
                {

                }


            }
            catch (Exception ex)
            {
                if (IsStartTran)
                    Common.AdoConnect.Connect.TransactionRollback();
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {


                //是否上传已经扫描的数据？ 
                if (MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS011"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                {
                    //UpLoadData();

                }

                this.Close();

            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //操作失败,请联系系统管理员！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS003"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;

            }
        }

        private void frmInvtryScan_KeyDown(object sender, KeyEventArgs e)
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
                MessageBox.Show(Common.GetLanguageWord("frmDocReturn", "FDR007"),
                     Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void listView1_ItemActivate(object sender, EventArgs e)
        {
            //选中行的索引
            int index = listView1.SelectedIndices[0];
            //选中行的值
            ListViewItem selecteditem = listView1.Items[index];

            //1列名
            var colname = listView1.Columns[0].Text;

            //选中行的第一列的值
            string onetext = listView1.Items[index].SubItems[0].Text;

            if (MessageBox.Show("您确定要删除：" + colname + ":" + onetext, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                this.listView1.Items.RemoveAt(index);
                checkInList(onetext, true);
                this.lnlTotal.Text = "成功删除:" + colname + ":" + onetext;

            }

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //选中行的索引
            int index = listView1.SelectedIndices[0];
            //选中行的值
            ListViewItem selecteditem = listView1.Items[index];
            //选中行的第一列的值
            string onetext = listView1.Items[index].SubItems[1].Text;

            this.lnlTotal.Text = "selectIndex:" + index + "," + selecteditem.Text + "," + onetext;

        }

        private void txt21ctnno_no_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!string.IsNullOrEmpty(txt21ctnno_no.Text.Trim()))
                {


                    if (!checkInList(txt21ctnno_no.Text.Trim(), false))
                    {
                        scanItemDetail tmp = new scanItemDetail();
                        tmp.ctnno_no = txt21ctnno_no.Text.Trim();
                        tmp.qty = txt22qty.Text.Trim();
                        tmp.nwet = txt23nwet.Text.Trim();

                        addToListView(tmp);
                    }
                }
            }
        }
        bool checkInList(string findvalue, bool toremove)
        {
            for (int i = 0; i < _lisCtnNo.Count; i++)
            {
                if (_lisCtnNo[i].ctnno_no.Equals(findvalue))
                {
                    if (toremove)
                    {
                        _lisCtnNo.RemoveAt(i);
                    }
                    return true;
                }
            }
            return false;
        }
        scanItemDetail getInList(string findvalue)
        {
            var dd = new scanItemDetail();
            for (int i = 0; i < _lisCtnNo.Count; i++)
            {
                if (_lisCtnNo[i].ctnno_no.Equals(findvalue))
                {
                    return _lisCtnNo[i];
                }
            }
            return dd;
        }
        bool editInList(scanItemDetail value)
        {
            for (int i = 0; i < _lisCtnNo.Count; i++)
            {
                if (_lisCtnNo[i].ctnno_no.Equals(value.ctnno_no))
                {

                    _lisCtnNo.RemoveAt(i);
                    _lisCtnNo.Add(value);
                    return true;
                }
            }
            return false;

        }
        void addToListView(scanItemDetail selectitem)
        {
            listView1.Items.Clear();
            addToList(selectitem, true);
            foreach (var item in _lisCtnNo)
            {
                addToList(item, false);
            }
            _lisCtnNo.Add(selectitem);
            lblCount.Text = _lisCtnNo.Count.ToString();

        }
        void addToList(scanItemDetail item, bool select)
        {
            string[] tmpstr = new string[3];

            tmpstr[0] = item.ctnno_no;
            tmpstr[1] = item.qty;
            tmpstr[2] = item.nwet;

            ListViewItem tmpitems1 = new ListViewItem(tmpstr);
            listView1.Items.Add(tmpitems1);
            listView1.Items[0].Selected = true;
        }
        void updateInlist()
        {
            var tmpfind = getInList(txt21ctnno_no.Text.Trim());
            if (!string.IsNullOrEmpty(tmpfind.ctnno_no))
            {
                if (editInList(tmpfind))
                {
                    addToList(tmpfind, true);
                    SetMsg(lnlTotal, tmpfind.ctnno_no + " update Success.");
                }
                else
                {
                    SetMsg(lnlTotal, "Update fails.");
                }
            }
        }
        private void txt22qty_TextChanged(object sender, EventArgs e)
        {
            if (!allTextBox(txt22qty, true))
            {
                return;
            }
            else
            {

                updateInlist();
            }
        }

        private void txt23nwet_TextChanged(object sender, EventArgs e)
        {
            if (!allTextBox(txt23nwet, true))
            {
                return;
            }
            else
            {
                updateInlist();
            }
        }
    }
    public class scanMain
    {
        public string stockin_no { get; set; }
        public string prdct_no { get; set; }
        public string pqty { get; set; }

    }
    public class scanItemDetail
    {
        public string ctnno_no { get; set; }
        public string qty { get; set; }
        public string nwet { get; set; }

    }
}