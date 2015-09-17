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
using AnXinWH.RFIDScan.MasterTableWHS;


namespace AnXinWH.RFIDScan.Stock
{
    public partial class frmStockOutScan : Form
    {

        /// <summary>
        /// 出库编号 yyyyMMDDHHmmss
        /// </summary>
        public string _stockout_id = string.Empty;
        /// <summary>
        /// 共通数据对象
        /// </summary>
        protected CBaseConnect m_daoCommon;


        StringDictionary _disNull = new StringDictionary();
        private StringDictionary DicData = new StringDictionary();

        //m_Shelf 
        private DataSet _ds_m_Shelf = new DataSet();


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

        public static List<scanMain_stockDetails> _lisCtnNo;
        //has txt
        scanMain_stockDetails initTxtToValue(scanMain_stockDetails value)
        {
            //value.rfid_no = value.rfid_no;
            //value.prdct_no = value.prdct_no;

            //value.shelf_no = txt13Shelf_no.Text.Trim();

            //value.pqty = txt21pqty.Text.Trim();

            value.qty = txt4Qty.Text.Trim();
            value.nwet = txt5nwet.Text.Trim();

            return value;
        }
        void initValueToTxt(scanMain_stockDetails value)
        {
            txt13Shelf_no.Text = value.shelf_no.Trim();

            //txt21pqty.Text = value.pqty.Trim();

            txt4Qty.Text = value.qty.Trim();
            txt5nwet.Text = value.nwet.Trim();

            txt15ReceidNo.Text = value.receiptNo.Trim();

        }
        void addToList(scanMain_stockDetails item, bool select)
        {
            string[] tmpstr = new string[4];

            tmpstr[0] = item.rfid_no;
            tmpstr[1] = item.ctnno_no;
            tmpstr[2] = item.qty;
            tmpstr[3] = item.nwet;

            ListViewItem tmpitems1 = new ListViewItem(tmpstr);
            listView1.Items.Add(tmpitems1);

            //listView1.Items[0].Selected = true;
        }
        //
        void updateInlist(string findValue, string findValue2)
        {
            if (toSetValue)
            {
                return;
            }
            var tmpfind = getInList(findValue, findValue2);

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
        bool checkInList(string findvalue, bool toremove, string findvalue2)
        {
            try
            {
                for (int i = 0; i < _lisCtnNo.Count; i++)
                {

                    if (_lisCtnNo[i].rfid_no.Equals(findvalue) && _lisCtnNo[i].ctnno_no.Equals(findvalue2))
                    {
                        if (toremove)
                        {
                            _lisCtnNo.RemoveAt(i);
                        }
                        return true;
                    }

                    if (!_lisCtnNo[i].rfid_no.Equals(findvalue))
                    {
                        MessageBox.Show("只接收一个RFID号:" + _lisCtnNo[i].rfid_no);
                        return true;
                    }
                }
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }

        }
        scanMain_stockDetails getInList(string findvalue, string findvalue2)
        {
            var dd = new scanMain_stockDetails();
            for (int i = 0; i < _lisCtnNo.Count; i++)
            {
                if (_lisCtnNo[i].rfid_no.Equals(findvalue) && _lisCtnNo[i].ctnno_no.Equals(findvalue2))
                {
                    return _lisCtnNo[i];
                }
            }
            return dd;
        }

        bool editInList(scanMain_stockDetails value)
        {
            for (int i = 0; i < _lisCtnNo.Count; i++)
            {
                if (_lisCtnNo[i].rfid_no.Equals(value.rfid_no) && _lisCtnNo[i].ctnno_no.Equals(value.ctnno_no))
                {

                    _lisCtnNo.RemoveAt(i);

                    value = initTxtToValue(value);

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
            txt21pqty.Text = _lisCtnNo.Count.ToString();

        }
        void addToListView(scanMain_stockDetails selectitem)
        {
            listView1.Items.Clear();

            addToList(selectitem, true);

            foreach (var item in _lisCtnNo)
            {
                addToList(item, false);
            }
            _lisCtnNo.Add(selectitem);

            lbl0Count.Text = _lisCtnNo.Count.ToString();
            txt21pqty.Text = _lisCtnNo.Count.ToString();

            SetMsg(lnlTotal, "add " + selectitem.rfid_no + " success。");

            AllInit(false);

        }


        #endregion
        public frmStockOutScan()
        {
            InitializeComponent();

            //for test new stockin_id
            // _stockout_id = DateTime.Now.ToString("yyyyMMddHHmmss");

            txt11stockout_id.Text = "";// _stockout_id;

            txt11stockout_id.Focus();

            _lisCtnNo = new List<scanMain_stockDetails>();
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

                txt11stockout_id.Focus();

                //设置采集器功率
                SysParam.m_busModule.SetUpdateAntPower(2300);

                //thread1 = new System.Threading.Thread(new System.Threading.ThreadStart(StartDelegate));

                //run timer
                timer1.Enabled = true;
            }
            catch (Exception ex)
            {
                timer1.Enabled = false;

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
        #region function

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
             allTextBox(txt11stockout_id, false) &&
             allTextBox(txt12Rfid_no, false);
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
            toSetValue = true;

            if (isall)
            {
                _lisCtnNo.Clear();
                listView1.Items.Clear();
                lbl0Count.Text = "";

                txt11stockout_id.Text = "";
                txt12Rfid_no.Text = "";
                txt13Shelf_no.Text = "";
                txt15ReceidNo.Text = "";

                txt21pqty.Text = "";

            }

            //txt21pqty.Text = "";
            txt4Qty.Text = "";
            txt5nwet.Text = "";

            toSetValue = false;

            txt21CartonNo.Focus();
        }
        void initRfid(TextBox tb, TextBox tbFocus, string findvalue2)
        {
            try
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

                    if (checkInList(_rfidStrForSet, false, findvalue2))
                    {
                        tb.Focus();

                        tmpmsg = "已扫 RFID：" + _rfidStrForSet;
                    }
                    else
                    {
                        tb.Text = _rfidStrForSet;
                        tb.Focus();
                        if (tbFocus.Text.Length <= 0)
                        {
                            tbFocus.Focus();
                        }

                    }


                    SetMsg(lnlTotal, tmpmsg);

                    tmpmsg += ",RFID:" + tmprfid;

                    //MessageBox.Show(tmpmsg);
                }

                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void setRfid()
        {
            try
            {
                //write rfid code test
                var strtohx = _rfidStrForSet;// txt11stockin_id.Text.Trim() + txt12prdct_no.Text.Trim() + txt13pqty.Text.Trim();


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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

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
        #endregion
        private void button2_Click(object sender, EventArgs e)
        {
            //if (!checkTxt())
            //{
            //    return;
            //}

            Cursor.Current = Cursors.WaitCursor;
            timer1.Enabled = false;
            try
            {


                if (listView1.Items.Count <= 0)
                {
                    //尚未扫描到任何数据！ 
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS008"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    txt12Rfid_no.Focus();
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
                timer1.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }
        private scanMain_stockDetails getRowToModel(DataRow dr)
        {
            var tmpStockDetail = new scanMain_stockDetails();

            tmpStockDetail.shelf_no = dr[MasterTableWHS.t_stockdetail.shelf_no].ToString();
            tmpStockDetail.receiptNo = dr[MasterTableWHS.t_stockdetail.receiptNo].ToString();

            tmpStockDetail.qty = dr[MasterTableWHS.t_stockdetail.qty].ToString();
            tmpStockDetail.nwet = dr[MasterTableWHS.t_stockdetail.nwet].ToString();
            tmpStockDetail.prdct_no = dr[MasterTableWHS.t_stockdetail.prdct_no].ToString();

            tmpStockDetail.ctnno_no = dr[MasterTableWHS.t_stockdetail.ctnno_no].ToString();


            return tmpStockDetail;
        }
        private void txt21ctnno_no_KeyDown(object sender, KeyEventArgs e)
        {
            var tmpmsg = "";
            toSetValue = false;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!timer1.Enabled)
                    {
                        timer1.Enabled = true;
                    }

                    if (!string.IsNullOrEmpty(txt11stockout_id.Text.Trim()) && !string.IsNullOrEmpty(txt12Rfid_no.Text.Trim()) && !string.IsNullOrEmpty(txt21CartonNo.Text.Trim()))
                    {
                        var tmpshelfModel = new scanMain_stockDetails();
                        #region check shelf details

                        //check is in stock deatils
                        //set value

                        StringDictionary dis1WhereValuet_stockdetail = new StringDictionary();
                        //select            
                        StringDictionary dis2ForValuet_stockdetail = new StringDictionary();

                        //t_stockdetail
                        dis1WhereValuet_stockdetail[MasterTableWHS.t_stockdetail.rfid_no] = _rfidStrForSet.Trim();
                        dis2ForValuet_stockdetail[MasterTableWHS.t_stockdetail.rfid_no] = "true";



                        var dt = this.m_daoCommon.GetTableInfo(MasterTableWHS.ViewOrTable.t_stockdetail, dis1WhereValuet_stockdetail, dis2ForValuet_stockdetail, _disNull, "", false);
                        if (dt.Rows.Count <= 0)
                        {
                            AllInit(false);

                            toSetValue = true;
                            txt13Shelf_no.Text = "";
                            txt15ReceidNo.Text = "";
                            txt12Rfid_no.Text = "";
                            toSetValue = false;

                            txt12Rfid_no.Focus();

                            //var tmpshelf = dt.Rows[0][MasterTableWHS.t_stockdetail.shelf_no].ToString();
                            tmpmsg = "RFID：" + _rfidStrForSet + " 未上架。请上架后再出库，谢谢。";
                            SetMsg(lnlTotal, tmpmsg);
                            MessageBox.Show(tmpmsg);
                            return;
                        }
                        else
                        {
                            tmpshelfModel = getRowToModel(dt.Rows[0]);
                            initValueToTxt(tmpshelfModel);
                            tmpshelfModel.ctnno_no = txt21CartonNo.Text.Trim();
                            tmpshelfModel.pqty = dt.Rows.Count.ToString();
                        }


                        //t_stockdetail check carton
                        dis1WhereValuet_stockdetail[MasterTableWHS.t_stockdetail.ctnno_no] = tmpshelfModel.ctnno_no;
                        dis2ForValuet_stockdetail[MasterTableWHS.t_stockdetail.ctnno_no] = "true";

                        var dtctn = this.m_daoCommon.GetTableInfo(MasterTableWHS.ViewOrTable.t_stockdetail, dis1WhereValuet_stockdetail, dis2ForValuet_stockdetail, _disNull, "", false);
                        if (dtctn.Rows.Count <= 0)
                        {

                            AllInit(false);

                            toSetValue = true;

                            txt13Shelf_no.Text = "";
                            txt15ReceidNo.Text = "";

                            //txt12Rfid_no.Text = "";
                            toSetValue = false;
                            txt21CartonNo.Focus();

                            //var tmpshelf = dt.Rows[0][MasterTableWHS.t_stockdetail.shelf_no].ToString();
                            tmpmsg = "RFID：" + _rfidStrForSet + ",箱号：" + tmpshelfModel.ctnno_no + " 不存在。货物编码：" + tmpshelfModel.prdct_no;

                            SetMsg(lnlTotal, tmpmsg);
                            MessageBox.Show(tmpmsg);
                            return;
                        }
                        #endregion


                        #region check t_stockoutctnno


                        StringDictionary dis1WhereValuet_stockoutctnnoDetail = new StringDictionary();
                        StringDictionary dis2ForValuet_stockoutctnnoDetail = new StringDictionary();
                        //t_stockoutctnnoDetail
                        dis1WhereValuet_stockoutctnnoDetail[MasterTableWHS.t_stockoutctnnodetail.rfid_no] = _rfidStrForSet.Trim();
                        dis2ForValuet_stockoutctnnoDetail[MasterTableWHS.t_stockoutctnnodetail.rfid_no] = "true";


                        //dis1WhereValuet_stockoutctnno[MasterTableWHS.t_stockoutctnno.stockout_id] = txt11stockout_id.Text.Trim();
                        //dis2ForValuet_stockoutctnno[MasterTableWHS.t_stockoutctnno.stockout_id] = "true";


                        dis1WhereValuet_stockoutctnnoDetail[MasterTableWHS.t_stockoutctnnodetail.ctnno_no] = tmpshelfModel.ctnno_no;
                        dis2ForValuet_stockoutctnnoDetail[MasterTableWHS.t_stockoutctnnodetail.ctnno_no] = "true";

                        var dtIn = this.m_daoCommon.GetTableInfo(MasterTableWHS.ViewOrTable.t_stockoutctnnodetail, dis1WhereValuet_stockoutctnnoDetail, dis2ForValuet_stockoutctnnoDetail, _disNull, "", false);
                        if (dtIn != null)
                        {
                            if (dtIn.Rows.Count > 0)
                            {
                                AllInit(false);

                                txt21CartonNo.Focus();
                                dtIn = null;

                                tmpmsg = "RFID：" + _rfidStrForSet + ",箱号：" + tmpshelfModel.ctnno_no + " 已出库。货物编码：" + tmpshelfModel.prdct_no;

                                SetMsg(lnlTotal, tmpmsg);
                                MessageBox.Show(tmpmsg);
                                return;
                            }

                        }

                        #endregion


                        if (!checkInList(_rfidStrForSet.Trim(), false, txt21CartonNo.Text.Trim()))
                        {
                            scanMain_stockDetails tmp = new scanMain_stockDetails();

                            tmp.rfid_no = _rfidStrForSet.Trim();

                            tmp.receiptNo = tmpshelfModel.receiptNo;

                            tmp.prdct_no = tmpshelfModel.prdct_no;

                            tmp.ctnno_no = txt21CartonNo.Text.Trim();

                            tmp = initTxtToValue(tmp);

                            addToListView(tmp);

                            txt21CartonNo.Focus();
                        }
                        else
                        {
                            AllInit(false);
                            txt12Rfid_no.Text = "";

                            SetMsg(lnlTotal, "RFID：" + _rfidStrForSet + "," + tmpshelfModel.shelf_no + " 已扫。");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private bool UploadData()
        {

            //test
            //return true;

            var tmpmsg = "";
            bool IsStartTran = false;
            var ErrorMsg = "";

            //user
            StringDictionary dis00UserCollum = new StringDictionary();

            //主表
            DataTable dt = null;

            //log for use
            dis00UserCollum[MasterTableWHS.t_stockinctnno.adduser] = "true";
            dis00UserCollum[MasterTableWHS.t_stockinctnno.addtime] = "true";
            dis00UserCollum[MasterTableWHS.t_stockinctnno.updtime] = "true";
            dis00UserCollum[MasterTableWHS.t_stockinctnno.upduser] = "true";


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

                Common.AdoConnect.Connect.CreateSqlTransaction();
                IsStartTran = true;
                this.lnlTotal.Visible = true;


                //主表
                //get dt stock out

                StringDictionary dis1WhereValuet_stockoutctnno = new StringDictionary();
                StringDictionary dis2ForValuet_stockoutctnno = new StringDictionary();

                //明细出库
                //get dt stock out t_stockoutctnnodetail

                StringDictionary dis1WhereValuet_stockoutctnnodetail = new StringDictionary();
                StringDictionary dis2ForValuet_stockoutctnnodetail = new StringDictionary();

                //明细入库
                //get dt stock out t_stockinctnnodetail

                StringDictionary dis1WhereValuet_stockinctnnodetail = new StringDictionary();
                StringDictionary dis2ForValuet_stockinctnnodetail = new StringDictionary();

                //库存表
                StringDictionary dis2ForValue_t_stock = new StringDictionary();
                StringDictionary dis1WhereValue_t_stock = new StringDictionary();

                //primary key
                StringDictionary dis5ForPrimaryKey_t_stock = new StringDictionary();

                decimal tmpqtysum = 0;
                decimal tmpnwetsum = 0;
                var tmpitem = new scanMain_stockDetails();
                foreach (var item in _lisCtnNo)
                {
                    tmpitem = item;
                    #region save t_stockoutctnnodetail

                    //save t_stockoutctnnodetail
                    dis1WhereValuet_stockoutctnnodetail = new StringDictionary();

                    dis1WhereValuet_stockoutctnnodetail[MasterTableWHS.t_stockoutctnnodetail.rfid_no] = item.rfid_no;
                    dis1WhereValuet_stockoutctnnodetail[MasterTableWHS.t_stockoutctnnodetail.receiptNo] = item.receiptNo;

                    dis1WhereValuet_stockoutctnnodetail[MasterTableWHS.t_stockoutctnnodetail.ctnno_no] = item.ctnno_no;
                    dis1WhereValuet_stockoutctnnodetail[MasterTableWHS.t_stockoutctnnodetail.qty] = item.qty;


                    dis1WhereValuet_stockoutctnnodetail[MasterTableWHS.t_stockoutctnnodetail.nwet] = item.nwet;
                    dis1WhereValuet_stockoutctnnodetail[MasterTableWHS.t_stockoutctnnodetail.gwet] = "0";

                    dis1WhereValuet_stockoutctnnodetail[MasterTableWHS.t_stockoutctnnodetail.status] = "1";

                    this.m_daoCommon.SetInsertDataItem(MasterTableWHS.ViewOrTable.t_stockoutctnnodetail, dis1WhereValuet_stockoutctnnodetail, dis00UserCollum);

                    #endregion

                    tmpqtysum += decimal.Parse(item.qty);
                    tmpnwetsum += decimal.Parse(item.nwet);

                }

                #region save stockOut
                //t_stockoutctnno
                dis1WhereValuet_stockoutctnno[MasterTableWHS.t_stockoutctnno.rfid_no] = tmpitem.rfid_no;
                dis2ForValuet_stockoutctnno[MasterTableWHS.t_stockoutctnno.rfid_no] = "true";


                dis1WhereValuet_stockoutctnno[MasterTableWHS.t_stockoutctnno.stockout_id] = txt11stockout_id.Text.Trim();
                dis2ForValuet_stockoutctnno[MasterTableWHS.t_stockoutctnno.stockout_id] = "true";


                dis1WhereValuet_stockoutctnno[MasterTableWHS.t_stockoutctnno.prdct_no] = tmpitem.prdct_no;
                dis2ForValuet_stockoutctnno[MasterTableWHS.t_stockoutctnno.prdct_no] = "true";

                var dtIn = this.m_daoCommon.GetTableInfo(MasterTableWHS.ViewOrTable.t_stockoutctnno, dis1WhereValuet_stockoutctnno, dis2ForValuet_stockoutctnno, _disNull, "", false);

                if (dtIn.Rows.Count <= 0)
                {
                    //add to stock out

                    dis1WhereValuet_stockoutctnno[MasterTableWHS.t_stockoutctnno.pqty] = _lisCtnNo.Count.ToString();
                    dis1WhereValuet_stockoutctnno[MasterTableWHS.t_stockoutctnno.qty] = tmpqtysum.ToString();
                    dis1WhereValuet_stockoutctnno[MasterTableWHS.t_stockoutctnno.nwet] = tmpnwetsum.ToString();
                    dis1WhereValuet_stockoutctnno[MasterTableWHS.t_stockoutctnno.status] = "1";

                    this.m_daoCommon.SetInsertDataItem(MasterTableWHS.ViewOrTable.t_stockoutctnno, dis1WhereValuet_stockoutctnno, dis00UserCollum);

                }
                else
                {

                    MessageBox.Show(tmpitem.rfid_no + ",货物：" + tmpitem.prdct_no + ",出单号：" + txt11stockout_id.Text + " 有出库记录。");
                    Cursor.Current = Cursors.Default;
                    Common.AdoConnect.Connect.TransactionRollback();
                    IsStartTran = false;
                    return false;
                }
                #endregion
                #region save stock

                //get stock
                dis2ForValue_t_stock = new StringDictionary();
                dis1WhereValue_t_stock = new StringDictionary();

                dis1WhereValue_t_stock[MasterTableWHS.t_stock.prdct_no] = tmpitem.prdct_no;
                dis2ForValue_t_stock[MasterTableWHS.t_stock.prdct_no] = "true";

                var tmpprdct_no = tmpitem.prdct_no;
                var dtStock = this.m_daoCommon.GetTableInfo(MasterTableWHS.ViewOrTable.t_stock, dis1WhereValue_t_stock, dis2ForValue_t_stock, _disNull, "", false);

                if (dtStock.Rows.Count <= 0)
                {
                    dis1WhereValue_t_stock[MasterTableWHS.t_stock.prdct_no] = tmpprdct_no;
                    dis1WhereValue_t_stock[MasterTableWHS.t_stock.pqty] = _lisCtnNo.Count.ToString();
                    dis1WhereValue_t_stock[MasterTableWHS.t_stock.qty] = tmpqtysum.ToString();
                    dis1WhereValue_t_stock[MasterTableWHS.t_stock.nwet] = tmpnwetsum.ToString();
                    dis1WhereValue_t_stock[MasterTableWHS.t_stock.gwet] = "0";
                    dis1WhereValue_t_stock[MasterTableWHS.t_stock.status] = "1";

                    this.m_daoCommon.SetInsertDataItem(MasterTableWHS.ViewOrTable.t_stock, dis1WhereValue_t_stock, dis00UserCollum);

                }
                else
                {
                    //edit data
                    var tmp_pqty_Stock = decimal.Parse(dtStock.Rows[0][MasterTableWHS.t_stock.pqty].ToString());
                    var tmp_pqty_StockOut = _lisCtnNo.Count;

                    var tmp_qty_Stock = decimal.Parse(dtStock.Rows[0][MasterTableWHS.t_stock.qty].ToString());
                    var tmp_qty_StockOut = tmpqtysum;

                    var tmp_nwet_Stock = decimal.Parse(dtStock.Rows[0][MasterTableWHS.t_stock.nwet].ToString());
                    var tmp_nwet_StockOut = tmpnwetsum;

                    dis1WhereValue_t_stock[MasterTableWHS.t_stock.prdct_no] = tmpprdct_no;
                    dis1WhereValue_t_stock[MasterTableWHS.t_stock.pqty] = (tmp_pqty_Stock - tmp_pqty_StockOut).ToString();
                    dis1WhereValue_t_stock[MasterTableWHS.t_stock.qty] = (tmp_qty_Stock - tmp_qty_StockOut).ToString();
                    dis1WhereValue_t_stock[MasterTableWHS.t_stock.nwet] = (tmp_nwet_Stock - tmp_nwet_StockOut).ToString();
                    dis1WhereValue_t_stock[MasterTableWHS.t_stock.status] = "1";

                    //primary ke
                    dis5ForPrimaryKey_t_stock[MasterTableWHS.t_stock.prdct_no] = tmpprdct_no;

                    var dis00UserCollum2 = new StringDictionary();
                    dis00UserCollum2[MasterTableWHS.t_stockinctnno.updtime] = "true";
                    dis00UserCollum2[MasterTableWHS.t_stockinctnno.upduser] = "true";

                    this.m_daoCommon.SetModifyDataItem(MasterTableWHS.ViewOrTable.t_stock, dis1WhereValue_t_stock, dis5ForPrimaryKey_t_stock, dis00UserCollum2);

                }
                #endregion


                Common.AdoConnect.Connect.TransactionCommit();
                tmpmsg = "提交数据成功。";
                SetMsg(lnlTotal, tmpmsg);
                if (ErrorMsg.Length > 0)
                {
                    tmpmsg += "\n" + ErrorMsg;
                }
                MessageBox.Show(tmpmsg);
                IsStartTran = false;
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
                IsStartTran = false;
                Cursor.Current = Cursors.Default;
            }
            return false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            timer1.Enabled = false;
            try
            {
                if (listView1.Items.Count > 0)
                {
                    //是否上传已经扫描的数据？ 
                    if (MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS011"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        if (UploadData())
                        {
                            //MessageBox.Show("Save OK");
                        }

                    }
                }

            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //操作失败,请联系系统管理员！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS003"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            }
            finally
            {
                this.Close();
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
            int index = 0;
            try
            {
                //选中行的索引
                if (listView1.SelectedIndices.Count > 0)
                {
                    index = listView1.SelectedIndices[0];
                    //选中行的值
                    ListViewItem selecteditem = listView1.Items[index];

                    //1列名
                    var colname = listView1.Columns[0].Text;

                    //选中行的第一列的值
                    string onetext = listView1.Items[index].SubItems[0].Text;

                    string onetext2 = listView1.Items[index].SubItems[1].Text;

                    if (MessageBox.Show("您确定要删除：" + colname + ":" + onetext, "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                    {
                        this.listView1.Items.RemoveAt(index);
                        checkInList(onetext, true, onetext2);
                        this.lnlTotal.Text = "成功删除:" + colname + ":" + onetext;
                        lbl0Count.Text = _lisCtnNo.Count.ToString();
                        txt21pqty.Text = _lisCtnNo.Count.ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(index + "," + ex.Message);
            }


        }
        bool toSetValue = false;
        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = 0;
            try
            {

                //选中行的索引
                if (listView1.SelectedIndices.Count > 0)
                {
                    index = listView1.SelectedIndices[0];

                    if (index >= 0)
                    {
                        //选中行的值
                        ListViewItem selecteditem = listView1.Items[index];

                        var dd = getInList(selecteditem.Text, selecteditem.SubItems[1].Text);
                        toSetValue = true;

                        txt12Rfid_no.Text = dd.rfid_no;
                        txt13Shelf_no.Text = dd.shelf_no;
                        //txt21pqty.Text = dd.pqty;
                        txt4Qty.Text = dd.qty;
                        txt5nwet.Text = dd.nwet;

                        toSetValue = false;

                        //txt12Rfid_no.Text = selecteditem.SubItems[0].Text;
                        //txt21pqty.Text = selecteditem.SubItems[1].Text;
                        //txt4Qty.Text = selecteditem.SubItems[2].Text;
                        //txt5nwet.Text = selecteditem.SubItems[3].Text;

                        txt4Qty.Focus();

                        selecteditem.Selected = true;
                        //选中行的第一列的值

                        string onetext = listView1.Items[index].SubItems[1].Text;

                        this.lnlTotal.Text = "selectIndex:" + index + "," + selecteditem.Text + "," + onetext;
                    }
                }



            }
            catch (Exception ex)
            {
                MessageBox.Show(index + "," + ex.Message);
                toSetValue = false;
            }

        }



        private void timer1_Tick(object sender, EventArgs e)
        {
            if (_isRun)
            {
                return;
            }

            if (txt12Rfid_no.Text.Trim().Length <= 0)
            {
                _isRun = true;
                try
                {
                    initRfid(txt12Rfid_no, txt11stockout_id, txt21CartonNo.Text);
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

        private void txt12Rfid_no_TextChanged(object sender, EventArgs e)
        {
            _rfidStrForSet = txt12Rfid_no.Text.Trim();
            txt21CartonNo.Text = "";

        }

        private void txt21pqty_TextChanged(object sender, EventArgs e)
        {
            if (!allTextBox(txt21pqty, true))
            {
                return;
            }
            else
            {

                updateInlist(_rfidStrForSet, txt21CartonNo.Text.Trim());
            }
        }

        private void txt4Qty_TextChanged(object sender, EventArgs e)
        {
            if (!allTextBox(txt4Qty, true))
            {
                return;
            }
            else
            {

                updateInlist(_rfidStrForSet, txt21CartonNo.Text.Trim());
            }
        }

        private void txt5nwet_TextChanged(object sender, EventArgs e)
        {
            if (!allTextBox(txt5nwet, true))
            {
                return;
            }
            else
            {

                updateInlist(_rfidStrForSet, txt21CartonNo.Text.Trim());
            }
        }

        private void txt11stockout_id_KeyDown(object sender, KeyEventArgs e)
        {
            setFouces(e, txt11stockout_id, txt12Rfid_no);
        }

        void setFouces(KeyEventArgs e, TextBox tb, TextBox tbFocus)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (tb.Text.Trim().Length > 0)
                {
                    tbFocus.Focus();
                }
                else
                {
                    tb.Focus();
                }
            }
        }
        private void txt21CartonNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt12Rfid_no_KeyDown(object sender, KeyEventArgs e)
        {
            setFouces(e, txt12Rfid_no, txt21CartonNo);
        }


    }
    public class scanMain_stockDetails
    {
        public string receiptNo { get; set; }

        public string shelf_no { get; set; }
        public string prdct_no { get; set; }


        public string rfid_no { get; set; }
        public string pqty { get; set; }
        public string ctnno_no { get; set; }
        public string qty { get; set; }
        public string nwet { get; set; }

    }

}