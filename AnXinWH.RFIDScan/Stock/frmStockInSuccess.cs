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

    public partial class frmStockInSuccess : Form
    {

        /// <summary>
        /// 共通数据对象
        /// </summary>
        protected CBaseConnect m_daoCommon;


        StringDictionary _disNull = new StringDictionary();

        private StringDictionary DicData = new StringDictionary();


        #region 采集器部分
        bool _isRun = false;
        [DllImport("coredll.dll")]
        public static extern bool MessageBeep(int uType);
        /// <summary>
        /// 扫描卡号对象(key: CardNo； Value: ScanTime)
        /// </summary>
        private StringDictionary m_dicCardInfo = new StringDictionary();
        #endregion
        #region 初始化RFID号
        public static string _rfidStrForSet = string.Empty;
        #endregion
        #region list do
        public static List<scanMain_stock> _lisCtnNo;
        bool checkInList(string findvalue, bool toremove)
        {
            for (int i = 0; i < _lisCtnNo.Count; i++)
            {
                if (_lisCtnNo[i].rfid_no.Equals(findvalue))
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
        scanMain_stock getInList(string findvalue)
        {
            var dd = new scanMain_stock();
            for (int i = 0; i < _lisCtnNo.Count; i++)
            {
                if (_lisCtnNo[i].rfid_no.Equals(findvalue))
                {
                    return _lisCtnNo[i];
                }
            }
            return dd;
        }
        //has txt
        bool editInList(scanMain_stock value)
        {
            for (int i = 0; i < _lisCtnNo.Count; i++)
            {
                if (_lisCtnNo[i].rfid_no.Equals(value.rfid_no))
                {

                    _lisCtnNo.RemoveAt(i);
                    value.shelf_no = txt2ShelfNo.Text.Trim();
                    _lisCtnNo.Add(value);
                    return true;
                }
            }
            return false;

        }
        void addToListView()
        {
            listView1.Items.Clear();
            foreach (var item in _lisCtnNo)
            {
                addToList(item, false);
            }
            lbl0Count.Text = _lisCtnNo.Count.ToString();

        }
        void addToListView(scanMain_stock selectitem)
        {
            listView1.Items.Clear();
            addToList(selectitem, true);
            foreach (var item in _lisCtnNo)
            {
                addToList(item, false);
            }
            _lisCtnNo.Add(selectitem);
            lbl0Count.Text = _lisCtnNo.Count.ToString();
            SetMsg(lnlTotal, "add " + selectitem.rfid_no + " success。");

            AllInit(false);

        }
        void addToList(scanMain_stock item, bool select)
        {
            string[] tmpstr = new string[2];

            tmpstr[0] = item.rfid_no;
            tmpstr[1] = item.shelf_no;

            ListViewItem tmpitems1 = new ListViewItem(tmpstr);
            listView1.Items.Add(tmpitems1);
            listView1.Items[0].Selected = true;
        }
        void updateInlist()
        {
            var tmpfind = getInList(txt1RfidNo.Text.Trim());
            if (!string.IsNullOrEmpty(tmpfind.rfid_no))
            {
                if (editInList(tmpfind))
                {
                    addToListView();
                    SetMsg(lnlTotal, tmpfind.rfid_no + " update Success.");
                }
                else
                {
                    SetMsg(lnlTotal, "Update fails.");
                }
            }
        }
        #endregion
        public frmStockInSuccess()
        {
            InitializeComponent();
            _lisCtnNo = new List<scanMain_stock>();
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

                //run timer
                timer1.Enabled = true;
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
        /// 设置的RFID标签号
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
                    var tmpmsg = "设置RFID卡成功, Value:" + strtohx + ",RFID:" + tmptag;
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
                if (!(PageValidate.IsDecimal(tb.Text) || PageValidate.IsNumber(tb.Text)))
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
             allTextBox(txt1RfidNo, false) &&
             allTextBox(txt2ShelfNo, false);
        }
        void SetMsg(Label lb, string msg)
        {
            this.Invoke(new Action(delegate()
            {
                lb.Text = msg;
            }));
        }
        void AllInit(bool isall)
        {
            if (isall)
            {
                _lisCtnNo.Clear();
                listView1.Items.Clear();
            }


            txt1RfidNo.Text = "";
            txt2ShelfNo.Text = "";

            txt1RfidNo.Focus();
        }
        void initRfid(TextBox tb, TextBox tbFocus)
        {

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
                _rfidStrForSet = Encryption.HexStringToString(tmprfid.ToString(), Encoding.UTF8);



                var tmpmsg = "扫到:" + _rfidStrForSet;

                if (checkInList(_rfidStrForSet, false))
                {
                    tb.Focus();
                    tmpmsg = "已扫，并与货架绑定。" + _rfidStrForSet;
                }
                else
                {
                    tb.Text = _rfidStrForSet;
                    tbFocus.Focus();
                }


                SetMsg(lnlTotal, tmpmsg);

                tmpmsg += ",RFID:" + tmprfid;

                //MessageBox.Show(tmpmsg);
            }

            #endregion
        }
        void setRfid()
        {
            //write rfid code test
            var strtohx = _rfidStrForSet;// txt11stockin_no.Text.Trim() + txt12prdct_no.Text.Trim() + txt13pqty.Text.Trim();


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
                    txt1RfidNo.Focus();
                    return;
                }

                //确定上传数据？ 
                if (MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS006"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {
                    if (UploadData())
                    {

                        AllInit(true);
                    }

                }

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
        string toGenSameStr(int len, int Alen, string b)
        {
            var tmpstr = "";
            if (Alen - len == 0)
            {
                return tmpstr;
            }
            for (int i = 0; i < (Alen - len); i++)
            {
                tmpstr += b;
            }
            return tmpstr;
        }


        private bool UploadData()
        {

            //test
            return true;

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
            //user
            StringDictionary DidUserCollum = new StringDictionary();

            //主表
            DataTable dt = null;
            disWhereValueMain[MasterTableWHS.t_stockinctnno.rfid_no] = _rfidStrForSet;
            disForOrderByMain[MasterTableWHS.t_stockinctnno.rfid_no] = "true";

            //log for use
            DidUserCollum[MasterTableWHS.t_stockinctnno.adduser] = "true";
            DidUserCollum[MasterTableWHS.t_stockinctnno.addtime] = "true";
            DidUserCollum[MasterTableWHS.t_stockinctnno.updtime] = "true";
            DidUserCollum[MasterTableWHS.t_stockinctnno.upduser] = "true";


            Cursor.Current = Cursors.WaitCursor;
            try
            {

                if (listView1.Items.Count <= 0)
                {
                    //尚未扫描到任何数据！ 
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS008"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                    Cursor.Current = Cursors.Default;
                    return false;
                }
                //主表
                //get dt
                dt = this.m_daoCommon.GetTableInfo(MasterTableWHS.ViewOrTable.t_stockinctnno, disWhereValueMain, disForOrderByMain, _disNull, "", false);

                Common.AdoConnect.Connect.CreateSqlTransaction();
                IsStartTran = true;
                this.lnlTotal.Visible = true;


                if (dt.Rows.Count <= 0)
                {
                    _rfidStrForSet += "001";

                }
                else
                {
                    var tonextNext = dt.Rows.Count + 1;
                    _rfidStrForSet += toGenSameStr(tonextNext.ToString().Length, 3, "0") + tonextNext.ToString();

                }

                Common.AdoConnect.Connect.TransactionCommit();
                var tmpmsg = "上传数据成功。" + _rfidStrForSet;
                SetMsg(lnlTotal, tmpmsg);
                MessageBox.Show(tmpmsg);


                return true;

            }
            catch (Exception ex)
            {
                if (IsStartTran)
                    Common.AdoConnect.Connect.TransactionRollback();
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                SetMsg(lnlTotal, ex.Message);
                Cursor.Current = Cursors.Default;
                return false;
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (listView1.Items.Count > 0)
                {
                    //是否上传已经扫描的数据？ 
                    if (MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS011"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (UploadData())
                        {
                            MessageBox.Show("Save OK");
                        }

                    }
                }
                timer1.Enabled = false;
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
                timer1.Enabled = false;
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
                lbl0Count.Text = _lisCtnNo.Count.ToString();

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
                if (!string.IsNullOrEmpty(txt1RfidNo.Text.Trim()) && !string.IsNullOrEmpty(txt2ShelfNo.Text.Trim()))
                {


                    if (!checkInList(txt1RfidNo.Text.Trim(), false))
                    {
                        scanMain_stock tmp = new scanMain_stock();
                        tmp.rfid_no = txt1RfidNo.Text.Trim();
                        tmp.shelf_no = txt2ShelfNo.Text.Trim();

                        addToListView(tmp);

                    }
                    else
                    {
                        SetMsg(lnlTotal, "RFID：" + txt1RfidNo.Text + " 已扫。");
                    }
                }
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_isRun)
            {
                return;
            }

            if (txt1RfidNo.Text.Trim().Length <= 0)
            {
                _isRun = true;

                try
                {
                    initRfid(txt1RfidNo, txt2ShelfNo);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    _isRun = false;
                }
            }
        }
    }
    public class scanMain_stock
    {
        public string rfid_no { get; set; }
        public string shelf_no { get; set; }

    }
}