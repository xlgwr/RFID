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

            lbl0Count.Text = "";

            txt1RfidNo.Focus();
        }
        void initRfid(TextBox tb, TextBox tbFocus)
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
                timer1.Enabled = true;
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
        private void txt21ctnno_no_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (!string.IsNullOrEmpty(txt1RfidNo.Text.Trim()) && !string.IsNullOrEmpty(txt2ShelfNo.Text.Trim()))
                    {
                        //check is in stock deatils
                        //set value
                        StringDictionary dis1WhereValuet_stockinctnno = new StringDictionary();

                        StringDictionary dis1WhereValuet_stockdetail = new StringDictionary();
                        //select            
                        StringDictionary dis2ForValuet_stockdetail = new StringDictionary();
                        StringDictionary dis2ForValuet_stockinctnno = new StringDictionary();

                        dis1WhereValuet_stockdetail[MasterTableWHS.t_stockdetail.rfid_no] = txt1RfidNo.Text.Trim();
                        dis2ForValuet_stockdetail[MasterTableWHS.t_stockdetail.rfid_no] = "true";

                        //t_stockinctnno
                        dis1WhereValuet_stockinctnno[MasterTableWHS.t_stockinctnno.rfid_no] = txt1RfidNo.Text.Trim();
                        dis2ForValuet_stockinctnno[MasterTableWHS.t_stockinctnno.rfid_no] = "true";

                        dis1WhereValuet_stockinctnno[MasterTableWHS.t_stockinctnno.status] = "0";
                        dis2ForValuet_stockinctnno[MasterTableWHS.t_stockinctnno.status] = "true";

                        #region check shelf details

                        var dtIn = this.m_daoCommon.GetTableInfo(MasterTableWHS.ViewOrTable.t_stockinctnno, dis1WhereValuet_stockinctnno, dis2ForValuet_stockinctnno, _disNull, "", false);
                        if (dtIn != null)
                        {
                            if (dtIn.Rows.Count > 0)
                            {
                                var tmpstockin_id = dtIn.Rows[0][MasterTableWHS.t_stockinctnno.stockin_id].ToString();
                                var tmpshelf = dtIn.Rows[0][MasterTableWHS.t_stockinctnno.prdct_no].ToString();
                                var tmpmsg = "RFID：" + txt1RfidNo.Text + " 已失效。货物编码：" + tmpshelf + ",入库单:" + tmpstockin_id;

                                SetMsg(lnlTotal, tmpmsg);
                                MessageBox.Show(tmpmsg);
                                AllInit(false);
                                return;
                            }
                        }
                        #endregion

                        #region check shelf details

                        var dt = this.m_daoCommon.GetTableInfo(MasterTableWHS.ViewOrTable.t_stockdetail, dis1WhereValuet_stockdetail, dis2ForValuet_stockdetail, _disNull, "", false);
                        if (dt != null)
                        {
                            if (dt.Rows.Count > 0)
                            {
                                var tmpshelf = dt.Rows[0][MasterTableWHS.t_stockdetail.shelf_no].ToString();
                                var tmpmsg = "RFID：" + txt1RfidNo.Text + " 已上架。货架：" + tmpshelf;
                                SetMsg(lnlTotal, tmpmsg);
                                MessageBox.Show(tmpmsg);
                                AllInit(false);
                                return;
                            }
                        }
                        #endregion

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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private bool UploadData()
        {

            //test
            // return true;

            bool IsStartTran = false;
            var ErrorMsg = "";

            //set value
            StringDictionary dis1WhereValueMain = new StringDictionary();
            StringDictionary dis1WhereValueItem = new StringDictionary();

            StringDictionary dis1WhereValue_t_stock = new StringDictionary();
            StringDictionary dis1WhereValue_t_stockdetail = new StringDictionary();
            //select            
            StringDictionary dis2ForValueMain = new StringDictionary();
            StringDictionary dis2ForValueItem = new StringDictionary();

            StringDictionary dis2ForValue_t_stock = new StringDictionary();
            StringDictionary dis2ForValue_t_stockdetail = new StringDictionary();

            //primary key       
            StringDictionary dis5ForPrimaryKeyMain = new StringDictionary();
            StringDictionary dis5ForPrimaryKeyItem = new StringDictionary();

            StringDictionary dis5ForPrimaryKey_t_stock = new StringDictionary();
            StringDictionary dis5ForPrimaryKey_t_stockdetail = new StringDictionary();
            //order by            
            StringDictionary dis3ForOrderByMain = new StringDictionary();
            StringDictionary dis3ForOrderByItem = new StringDictionary();

            StringDictionary dis3ForOrderBy_t_stock = new StringDictionary();
            StringDictionary dis3ForOrderBy_t_stockdetail = new StringDictionary();
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



                foreach (var item in _lisCtnNo)
                {
                    //主表
                    //get dt stock in

                    dis1WhereValueMain[MasterTableWHS.t_stockinctnno.rfid_no] = item.rfid_no;
                    dis2ForValueMain[MasterTableWHS.t_stockinctnno.rfid_no] = "true";

                    dis1WhereValueMain[MasterTableWHS.t_stockinctnno.status] = "1";
                    dis2ForValueMain[MasterTableWHS.t_stockinctnno.status] = "true";

                    dt = this.m_daoCommon.GetTableInfo(MasterTableWHS.ViewOrTable.t_stockinctnno, dis1WhereValueMain, dis2ForValueMain, _disNull, "", false);

                    if (dt.Rows.Count <= 0)
                    {
                        if (string.IsNullOrEmpty(ErrorMsg))
                        {
                            ErrorMsg = item.rfid_no + "," + item.shelf_no;
                        }
                        else
                        {
                            ErrorMsg += "\n" + item.rfid_no + "," + item.shelf_no;
                        }
                    }
                    else
                    {
                        //save to stock
                        foreach (DataRow dr in dt.Rows)
                        {
                            var tmpprdct_no = dr[MasterTableWHS.t_stockinctnno.prdct_no].ToString();

                            if (string.IsNullOrEmpty(tmpprdct_no))
                            {
                                ErrorMsg += "\n" + item.rfid_no + ": product no is null.";
                                continue;
                            }
                            #region save stock
                            //get stock
                            dis2ForValue_t_stock = new StringDictionary();
                            dis1WhereValue_t_stock = new StringDictionary();

                            dis1WhereValue_t_stock[MasterTableWHS.t_stock.prdct_no] = tmpprdct_no;
                            dis2ForValue_t_stock[MasterTableWHS.t_stock.prdct_no] = "true";

                            var dtStock = this.m_daoCommon.GetTableInfo(MasterTableWHS.ViewOrTable.t_stock, dis1WhereValue_t_stock, dis2ForValue_t_stock, _disNull, "", false);

                            if (dtStock.Rows.Count <= 0)
                            {
                                dis1WhereValue_t_stock[MasterTableWHS.t_stock.prdct_no] = tmpprdct_no;
                                dis1WhereValue_t_stock[MasterTableWHS.t_stock.pqty] = dr[MasterTableWHS.t_stockinctnno.pqty].ToString();
                                dis1WhereValue_t_stock[MasterTableWHS.t_stock.qty] = dr[MasterTableWHS.t_stockinctnno.qty].ToString();
                                dis1WhereValue_t_stock[MasterTableWHS.t_stock.nwet] = dr[MasterTableWHS.t_stockinctnno.nwet].ToString();
                                dis1WhereValue_t_stock[MasterTableWHS.t_stock.gwet] = dr[MasterTableWHS.t_stockinctnno.gwet].ToString();
                                dis1WhereValue_t_stock[MasterTableWHS.t_stock.status] = "1";

                                this.m_daoCommon.SetInsertDataItem(MasterTableWHS.ViewOrTable.t_stock, dis1WhereValue_t_stock, dis00UserCollum);

                            }
                            else
                            {
                                //edit data
                                var tmp_pqty_Stock = decimal.Parse(dtStock.Rows[0][MasterTableWHS.t_stock.pqty].ToString());
                                var tmp_pqty_StockIn = decimal.Parse(dr[MasterTableWHS.t_stockinctnno.pqty].ToString());

                                var tmp_qty_Stock = decimal.Parse(dtStock.Rows[0][MasterTableWHS.t_stock.qty].ToString());
                                var tmp_qty_StockIn = decimal.Parse(dr[MasterTableWHS.t_stockinctnno.qty].ToString());

                                var tmp_nwet_Stock = decimal.Parse(dtStock.Rows[0][MasterTableWHS.t_stock.nwet].ToString());
                                var tmp_nwet_StockIn = decimal.Parse(dr[MasterTableWHS.t_stockinctnno.nwet].ToString());

                                var tmp_gwet_Stock = decimal.Parse(dtStock.Rows[0][MasterTableWHS.t_stock.gwet].ToString());
                                var tmp_gwet_StockIn = decimal.Parse(dr[MasterTableWHS.t_stockinctnno.gwet].ToString());

                                dis1WhereValue_t_stock[MasterTableWHS.t_stock.prdct_no] = tmpprdct_no;
                                dis1WhereValue_t_stock[MasterTableWHS.t_stock.pqty] = (tmp_pqty_Stock + tmp_pqty_StockIn).ToString();
                                dis1WhereValue_t_stock[MasterTableWHS.t_stock.qty] = (tmp_qty_Stock + tmp_qty_StockIn).ToString();
                                dis1WhereValue_t_stock[MasterTableWHS.t_stock.nwet] = (tmp_nwet_Stock + tmp_nwet_StockIn).ToString();
                                dis1WhereValue_t_stock[MasterTableWHS.t_stock.gwet] = (tmp_gwet_Stock + tmp_gwet_StockIn).ToString();
                                dis1WhereValue_t_stock[MasterTableWHS.t_stock.status] = "1";

                                //primary ke
                                dis5ForPrimaryKey_t_stock[MasterTableWHS.t_stock.prdct_no] = tmpprdct_no;

                                var dis00UserCollum2 = new StringDictionary();
                                dis00UserCollum2[MasterTableWHS.t_stockinctnno.updtime] = "true";
                                dis00UserCollum2[MasterTableWHS.t_stockinctnno.upduser] = "true";

                                this.m_daoCommon.SetModifyDataItem(MasterTableWHS.ViewOrTable.t_stock, dis1WhereValue_t_stock, dis5ForPrimaryKey_t_stock, dis00UserCollum2);

                            }
                            #endregion


                            #region save stockdetail
                            //get stock
                            dis1WhereValue_t_stockdetail = new StringDictionary();
                            dis2ForValue_t_stockdetail = new StringDictionary();

                            dis1WhereValue_t_stockdetail[MasterTableWHS.t_stockdetail.prdct_no] = tmpprdct_no;
                            dis2ForValue_t_stockdetail[MasterTableWHS.t_stockdetail.prdct_no] = "true";


                            dis1WhereValue_t_stockdetail[MasterTableWHS.t_stockdetail.rfid_no] = item.rfid_no;
                            dis2ForValue_t_stockdetail[MasterTableWHS.t_stockdetail.rfid_no] = "true";

                            var dtStockDetails = this.m_daoCommon.GetTableInfo(MasterTableWHS.ViewOrTable.t_stockdetail, dis1WhereValue_t_stockdetail, dis1WhereValue_t_stockdetail, _disNull, "", false);

                            dis1WhereValue_t_stockdetail[MasterTableWHS.t_stockdetail.prdct_no] = tmpprdct_no;
                            dis1WhereValue_t_stockdetail[MasterTableWHS.t_stockdetail.rfid_no] = item.rfid_no;
                            dis1WhereValue_t_stockdetail[MasterTableWHS.t_stockdetail.shelf_no] = item.shelf_no;
                            dis1WhereValue_t_stockdetail[MasterTableWHS.t_stockdetail.pqty] = dr[MasterTableWHS.t_stockinctnno.pqty].ToString();
                            dis1WhereValue_t_stockdetail[MasterTableWHS.t_stockdetail.qty] = dr[MasterTableWHS.t_stockinctnno.qty].ToString();
                            dis1WhereValue_t_stockdetail[MasterTableWHS.t_stockdetail.nwet] = dr[MasterTableWHS.t_stockinctnno.nwet].ToString();
                            dis1WhereValue_t_stockdetail[MasterTableWHS.t_stockdetail.gwet] = dr[MasterTableWHS.t_stockinctnno.gwet].ToString();
                            dis1WhereValue_t_stockdetail[MasterTableWHS.t_stockdetail.status] = dr[MasterTableWHS.t_stockinctnno.status].ToString();

                            if (dtStockDetails.Rows.Count <= 0)
                            {
                                this.m_daoCommon.SetInsertDataItem(MasterTableWHS.ViewOrTable.t_stockdetail, dis1WhereValue_t_stockdetail, dis00UserCollum);
                            }
                            else
                            {

                                //primary ke
                                dis5ForPrimaryKey_t_stockdetail[MasterTableWHS.t_stockdetail.prdct_no] = tmpprdct_no;
                                dis5ForPrimaryKey_t_stockdetail[MasterTableWHS.t_stockdetail.rfid_no] = item.rfid_no;

                                var dis00UserCollum2 = new StringDictionary();
                                dis00UserCollum2[MasterTableWHS.t_stockinctnno.updtime] = "true";
                                dis00UserCollum2[MasterTableWHS.t_stockinctnno.upduser] = "true";

                                this.m_daoCommon.SetModifyDataItem(MasterTableWHS.ViewOrTable.t_stockdetail, dis1WhereValue_t_stockdetail, dis5ForPrimaryKey_t_stockdetail, dis00UserCollum2);

                            }
                            #endregion

                        }

                    }

                }

                Common.AdoConnect.Connect.TransactionCommit();
                var tmpmsg = "提交数据成功。";
                SetMsg(lnlTotal, tmpmsg);
                if (ErrorMsg.Length > 0)
                {
                    tmpmsg += "\n" + ErrorMsg;
                }
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
                            MessageBox.Show("Save OK");
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
            try
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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