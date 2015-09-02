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

namespace AnXinWH.RFIDScan
{
    public partial class frmInvtryScan : Form
    {
        /// <summary>
        /// 盘点编号
        /// </summary>
        private string m_InventNo = string.Empty;
        private bool IsStart = false;

        /// <summary>
        /// 共通数据对象
        /// </summary>
        protected CBaseConnect m_daoCommon;

        private StringDictionary DicData=new StringDictionary();
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
        public frmInvtryScan()
        {
            InitializeComponent();
        }

        public frmInvtryScan(string InventNO)
        {
            InitializeComponent();
            m_InventNo = InventNO;
        }

        /// <summary>
        /// 获取取得的标签号
        /// </summary>
        private void GetInventNo()
        {
            //TempDocTag = "1313144";

            try
            {
             
                if (SysParam.m_busModule.IsSucces)
                {
                    TagReadData[] reads = SysParam.m_busModule.Reader.Read(100);

                    foreach (TagReadData item in reads)
                    {
                        //卡号为八位
                        if (item.EPCString.Trim().Length == 8)
                        {
                            MessageBeep(10);
                            if (!this.m_dicCardInfo.ContainsKey(item.EPCString.Trim()))
                            {
                                this.m_dicCardInfo[item.EPCString.Trim()] = DateTime.Now.ToString();
                            }

                        }
                    }
                }

            }
            catch ( Exception ex )
            {
                //采集器设备连接失败，请及时与管理员联系！ 
                throw new Exception(Common.GetLanguageWord(this.Name, "FIS001") + System.Environment.NewLine + ex.Message.ToString());
            }
        }

        private void frmInvtryScan_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                SetLangeage();

                Common.GetDaoCommon(ref m_daoCommon);
                this.lblInventryNo.Text = this.m_InventNo;
                //如果扫描到其他盘点计划里面的图册编号，则怎么处理？
                //如果一个盘点计划没有扫描完成，上传数据后再重新扫描，怎么处理
                DidUserCollum[MasterTable.T_InventoryDetail.UpdUserNo] = "true";

                GetInvtryDocInfo();


                lnlTotal.Visible = false;


                //设置采集器功率
                SysParam.m_busModule.SetUpdateAntPower(2300);

                //thread1 = new System.Threading.Thread(new System.Threading.ThreadStart(StartDelegate));
                
            }
            catch (Exception ex )
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
                this.button1.Text = Common.GetLanguageWord(this.Name, this.button1.Name);
                this.button2.Text = Common.GetLanguageWord(this.Name, this.button2.Name);
                this.button3.Text = Common.GetLanguageWord(this.Name, this.button3.Name);
                columnHeader1.Text = Common.GetLanguageWord(this.Name, "columnHeader1");
                columnHeader2.Text = Common.GetLanguageWord(this.Name, "columnHeader2");
                columnHeader3.Text = Common.GetLanguageWord(this.Name, "columnHeader3");
            }
            catch (Exception wx)
            {
                
                throw wx;
            }
         
        }

        /// <summary>
        /// 获取图册标签key--标签号；value--图册编号
        /// </summary>
        private void GetInvtryDocInfo()
        {
            StringDictionary DicItem = new StringDictionary();
            try
            {
                //DicItem[MasterTable.T_InventoryDetail.InventoryNo] = this.m_InventNo;
                DataTable dt = this.m_daoCommon.GetTableInfo(MasterTable.M_Documents.TableName, DicItem, DicItem, DicItem, "", false);
                if (dt == null || dt.Rows.Count <= 0) return;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    m_DocInfo[dt.Rows[i][MasterTable.M_Documents.TagNo1].ToString()] = dt.Rows[i][MasterTable.M_Documents.DocNo].ToString();
                    m_DocInfo[dt.Rows[i][MasterTable.M_Documents.TagNo2].ToString()] = dt.Rows[i][MasterTable.M_Documents.DocNo].ToString();
                    m_DocInfo[dt.Rows[i][MasterTable.M_Documents.TagNo3].ToString()] = dt.Rows[i][MasterTable.M_Documents.DocNo].ToString();
                }

            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
        }
        ///// <summary>
        /////启动委托
        ///// </summary>
        //private void StartDelegate()
        //{
        //    delegateevent = new DelegateEvent(ShowInfo);
        //    this.BeginInvoke(delegateevent);
        //}
        /// <summary>
        /// 显示信息
        /// </summary>
        private void ShowInfo()
        {
            try
            {
                //System.Threading.Monitor.Enter(this);
                //while (IsStart)
                //{
                    GetInventNo();
                    //for (int i = 0; i < this.m_dicCardInfo.Keys.Count; i++)
                    //{
                    //    //ShowListView(this.m_dicCardInfo.);
                    //}

                    foreach (var item in this.m_dicCardInfo.Keys)
                    {
                        ShowListView(item.ToString());
                    }

                    lblInvtNum.Text = listView1.Items .Count. ToString();

                    //System.Threading.Thread.Sleep(500);
                //}
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally 
            {
                //System.Threading.Monitor.Exit(this);
            }
          
        }

        private void ShowListView(string DocTag)
        {
            StringDictionary DicItem=new StringDictionary();
            try
            {

                //根据标签号码获取图册的图册编号
                //标签号必须存在于图册信息中
                //列表中只能显示唯一的图册号
                if (m_DocInfo.ContainsKey(DocTag))
                {
                    if (DocList.Count(new Func<string, bool>(m => m.Trim() == m_DocInfo[DocTag].Trim())) <= 0)
                    {
                        //MessageBeep(10);

                        DataTable dt = GetDocInfoByDocNO(m_DocInfo[DocTag].Trim());
                         string[] strs=null ;
                         string DocTittle = Common.GetBindFieldName(MasterTable.M_Documents.DocMainTitle);
                         string DocName = Common.GetBindFieldName(MasterTable.M_Documents.DocName);
                        if (dt != null && dt.Rows.Count > 0)
                        {
                            strs = new string[4];
                            strs[(int)EnumInvtryScan.DocNo] = m_DocInfo[DocTag].Trim();
                            strs[(int)EnumInvtryScan.MakeNumbers] = dt.Rows[0][MasterTable.M_Documents.MakeNumbers].ToString();
                            strs[(int)EnumInvtryScan.DocName] = dt.Rows[0][DocName].ToString();
                            strs[(int)EnumInvtryScan.DocMainTitle] = dt.Rows[0][DocTittle].ToString();
                        }
                        ListViewItem item = new ListViewItem(strs);
                        this.listView1.Items.Add(item);
                        DocList.Add(m_DocInfo[DocTag].Trim());
                    }
                }
   

            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
        }

        private DataTable GetDocInfoByDocNO(string DocNO)
        {
            DataTable dt = new DataTable();
            try
            {
                StringDictionary DicItem = new StringDictionary();
                DicItem[MasterTable.M_Documents.DocNo] = DocNO;
                dt = this.m_daoCommon.GetTableInfo(MasterTable.M_Documents.TableName, DicItem, DicItem, DicNull, "", false);

            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
            return dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (!IsStart)
                {
                    IsStart = true;
                    //停止S1
                    this.button1.Text = Common.GetLanguageWord(this.Name, this.button1.Name + "_");
                    //thread1.IsBackground = true;
                    //thread1.Start();
                    lnlTotal.Visible = false;
                    timer1.Enabled = true;
                    if (this.listView1.Items.Count <= 0)
                    {
                        DocList.Clear();
                        this.m_dicCardInfo.Clear();
                    }
                }
                else
                {
                    IsStart = false;
                    //开始(S1) 
                    this.button1.Text = Common.GetLanguageWord(this.Name, this.button1.Name);
                    lnlTotal.Visible = false;
                    timer1.Enabled = false;
                    //thread1.Abort();
                    //System.Threading.Thread.Sleep(1000);
                }

            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //操作失败,请联系系统管理员！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS003"),
                    Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                if (listView1.Items.Count <= 0)
                {
                    //尚未扫描到任何数据！ 
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS008"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                    return;
                }
                //如果正在扫描，则提示先停止扫描
                if (timer1.Enabled)
                {
                    //当前正在扫描!+  +确定停止扫描上传数据？
                    if (MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS004") + System.Environment.NewLine 
                        + Common.GetLanguageWord(this.Name, "FIS005"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), 
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        //IsStart = false;
                        //thread1.Abort();
                        //开始(S1) 
                        this.button1.Text = Common.GetLanguageWord(this.Name, this.button1.Name);
                        timer1.Enabled = false;
                        UpLoadData();

                    }
                }
                else
                {
                    //确定上传数据？ 
                    if (MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS006"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        UpLoadData();

                    }
                }


            }
            catch (Exception ex )
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
            string DocNo=string.Empty ;

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
            catch (Exception ex )
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

                if (timer1.Enabled)
                    timer1.Enabled = false;

                //如果已经扫描到数据，且没有上传的话 提示是否上传数据
                if ( this.listView1.Items.Count > 0)
                {
                    //是否上传已经扫描的数据？ 
                    if (MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS011"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.Yes)
                    {
                        UpLoadData();

                    }
                }

                this.Close();

            }
            catch (Exception ex )
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

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                ShowInfo();
            }
            catch (Exception ex )
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                timer1.Enabled = false;
                              this.button1.Text = Common.GetLanguageWord(this.Name, this.button1.Name);
                MessageBox.Show(Common.GetLanguageWord("frmDocReturn", "FDR007"),
                     Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
           
            }
        
        }

        private void frmInvtryScan_KeyDown(object sender, KeyEventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (e.KeyCode == Keys.F11)
                {
                    button1_Click(null, null);
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
    }
    public enum EnumInvtryScan
    {  
        /// <summary>
        /// 制本番号
        /// </summary>
        MakeNumbers = 0,
        /// <summary>
        /// 主标题
        /// </summary>
        DocMainTitle = 1,
        /// <summary>
        /// 图册名称
        /// </summary>
        DocName = 2,
        /// <summary>
        /// 图册编号
        /// </summary>
        DocNo = 3
    }
}