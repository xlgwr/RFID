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
        /// 盘点编号
        /// </summary>
        private string m_InventNo = string.Empty;

        /// <summary>
        /// 共通数据对象
        /// </summary>
        protected CBaseConnect m_daoCommon;

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
        public static List<string> _lisCtnNo;
        #endregion
        public frmStockInScan()
        {
            InitializeComponent();
            tmpTestData();
            _lisCtnNo = new List<string>();
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
        private void setInventNo(string tmptag)
        {

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
                    MessageBox.Show("设置RFID卡成功。：" + tmptag);
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
                lnlTotal.Text = ex.Message + " :" + msg;
                //采集器设备连接失败，请及时与管理员联系！ 
                throw new Exception(Common.GetLanguageWord(this.Name, "FIS001") + System.Environment.NewLine + ex.Message.ToString());
            }
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
                throw new Exception(Common.GetLanguageWord(this.Name, "FIS001") + System.Environment.NewLine + ex.Message.ToString());
            }
        }
        bool allTextBox(TextBox tb, bool isnum)
        {
            if (isnum)
            {
                if (!PageValidate.IsNumber(tb.Text))
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
        void msg(Label lb, string msg)
        {
            lb.Invoke(new Action(delegate()
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
                    UpLoadData();

                }

                #region write/get rfid
                //read rfid code text
                var tmprfid = "";
                m_dicCardInfo.Clear();

                msg(lnlTotal, "开始获取RFID号。");
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
                    tmprfid = Encryption.HexStringToString(item.ToString(), Encoding.UTF8);
                }
                if (tmprfid.Length > 0)
                {
                    msg(lnlTotal, "读到RFID:" + tmprfid);
                    MessageBox.Show("读到RFID:" + tmprfid);
                }
                //write rfid code test
                var tmpRFID = txt11stockin_no.Text.Trim() + txt12prdct_no.Text.Trim() + txt13pqty.Text.Trim();

                var strtohx = Encryption.StringToHexString(tmpRFID, Encoding.UTF8);


                msg(lnlTotal, "开始设置RFID号：" + strtohx);
                setInventNo(strtohx);

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

        /// <summary>
        /// 上传数据
        /// </summary>
        private void UpLoadData()
        {
            bool IsStartTran = false;
            ////存储已经处理过的图册编号
            //List<string> TempList = new List<string>();
            StringDictionary DicItem = new StringDictionary();
            StringDictionary DicPri = new StringDictionary();
            //记录当次盘点的数据
            DataTable dt = null;
            StringDictionary DicItemInvt = new StringDictionary();
            DicItemInvt[MasterTable.T_InventoryDetail.InventoryNo] = this.m_InventNo;
            //记录查询的数据
            DataRow[] drs = null;
            //记录listview的图册编号
            string DocNo = string.Empty;

            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (listView1.Items.Count <= 0)
                {
                    //尚未扫描到任何数据！ 
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS008"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                    return;
                }

                //如果扫描到的图册编号不在盘点计划里面 则添加该图册数据状态为多余
                //如果存在一个图册编号,则显示图册的状态为在库
                //状态为已经盘点的数据不做处理

                DicPri[MasterTable.T_InventoryDetail.DocNo] = "true";
                DicPri[MasterTable.T_InventoryDetail.InventoryNo] = this.m_InventNo;

                //取出档次盘点的数据
                dt = this.m_daoCommon.GetTableInfo(MasterTable.T_InventoryDetail.TableName, DicItemInvt, DicItemInvt, DicNull, "", false);
                Common.AdoConnect.Connect.CreateSqlTransaction();
                IsStartTran = true;
                this.lnlTotal.Visible = true;
                //正在上传数据: 
                this.lnlTotal.Text = Common.GetLanguageWord(this.Name, this.lnlTotal.Name) + "0/" + listView1.Items.Count;


                if (this.IsCompeletedIntrv(this.m_InventNo))
                {
                    //当前盘点已经完成,请确认！ 
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS009"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return;
                }
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    //正在上传数据: 
                    this.lnlTotal.Text = Common.GetLanguageWord(this.Name, this.lnlTotal.Name) + (i + 1).ToString() + "/" + listView1.Items.Count;

                    DocNo = listView1.Items[i].SubItems[(int)EnumInvtryScan.DocNo].Text.Trim();

                    DicItem[MasterTable.T_InventoryDetail.InventoryNo] = this.m_InventNo;
                    DicItem[MasterTable.T_InventoryDetail.DocNo] = DocNo;
                    DicItem[MasterTable.T_InventoryDetail.InventFlag] = ((int)MasterTable.InventFlag.Invented).ToString();

                    //判断图册编号是否存在于当前的盘点中
                    drs = dt.Select(MasterTable.T_InventoryDetail.DocNo + "='" + DocNo + "'");
                    if (drs.Length > 0)
                    {
                        //如果存在,且状态=计划 则进行更新处理
                        //等于盘点 则不处理
                        if (drs[0][MasterTable.T_InventoryDetail.InventFlag].ToString() == ((int)MasterTable.InventFlag.Invented).ToString())
                            continue;
                        DicItem[MasterTable.T_InventoryDetail.InventStatus] = ((int)MasterTable.DetailInventStatus.zaiko).ToString();
                        this.m_daoCommon.SetModifyDataItem(MasterTable.T_InventoryDetail.TableName, DicItem, DicPri, DidUserCollum);
                    }
                    else
                    {
                        //不存在 则盘点状态为多余，添加数据
                        DicItem[MasterTable.T_InventoryDetail.InventStatus] = ((int)MasterTable.DetailInventStatus.Redundant).ToString();
                        this.m_daoCommon.SetInsertDataItem(MasterTable.T_InventoryDetail.TableName, DicItem, DidUserCollum);
                    }
                    this.m_daoCommon.WriteLog("frmInvtryPlanCreat", (int)MasterTable.OperateTyp.Edit, "手持机操作：盘点更新————用户【" + Common._personid + "】成功上传数据,盘点编号【" + this.m_InventNo + "】,图册编号【" + DocNo + "】,图册状态【" + DicItem[MasterTable.T_InventoryDetail.InventStatus] + "】");
                }
                Common.AdoConnect.Connect.TransactionCommit();

                //上传成功 清空数据
                this.listView1.Items.Clear();

                this.lnlTotal.Visible = false;
                //清空数据 避免从新开始时不能扫描
                DocList.Clear();
                this.m_dicCardInfo.Clear();

                //数据上传成功！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS010"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"));
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

        /// <summary>
        /// 判断盘点是否已经完成
        /// </summary>
        /// <param name="InventoryNo">盘点编号</param>
        /// <returns></returns>
        private bool IsCompeletedIntrv(string InventoryNo)
        {
            bool IsCompelete = false;
            StringDictionary DicItem = new StringDictionary();
            try
            {
                DicItem[MasterTable.T_PlanInventory.InventoryNo] = InventoryNo;
                DataTable dt = this.m_daoCommon.GetTableInfo(MasterTable.T_PlanInventory.TableName, DicItem, DicItem, DicNull, "", false);

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (int.Parse(dt.Rows[0][MasterTable.T_PlanInventory.InventStatus].ToString()) == (int)MasterTable.InventStatus.Completed)
                    {
                        IsCompelete = true;
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return IsCompelete;
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
                _lisCtnNo.Remove(colname);                 
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
            if (e.KeyCode== Keys.Enter)
            {
                if (string.IsNullOrEmpty(txt21ctnno_no.Text.Trim()))
                {
                    if (!_lisCtnNo.Contains(txt21ctnno_no.Text.Trim()))
                    {
                        _lisCtnNo.Add(txt21ctnno_no.Text.Trim());
                        addToListView();
                    }
                }
            }
        }
        void addToListView() 
        {
            string[] tmpstr = new string[3];

            tmpstr[0] = txt21ctnno_no.Text.Trim();
            tmpstr[1] = txt22qty.Text.Trim();
            tmpstr[2] = txt22qty.Text.Trim();

            ListViewItem tmpitems1 = new ListViewItem(tmpstr);
            listView1.Items.Add(tmpitems1);

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