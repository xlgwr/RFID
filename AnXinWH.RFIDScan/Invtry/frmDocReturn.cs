using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ModuleTech;
using System.Runtime.InteropServices;
using System.Collections.Specialized;
using Framework.DataAccess;
using Framework.Libs;

namespace AnXinWH.RFIDScan
{
    public partial class frmDocReturn : Form
    {


        /// <summary>
        /// 共通数据对象
        /// </summary>
        protected CBaseConnect m_daoCommon;

        private StringDictionary DicData = new StringDictionary();
        ///// <summary>
        ///// 存储标签号
        ///// </summary>
        //private string TempDocTag = string.Empty;
        /// <summary>
        /// 存储已经扫描出的图册编号和申请编号 避免重复  
        /// </summary>
        private List<ApplyInfo> DocList = new List<ApplyInfo>();

        private StringDictionary DicUserItem = new StringDictionary();
        private string all = string.Empty;

        /// <summary>
        /// 归还编号
        /// </summary>
        private string m_returnNo = DateTime.Now.ToString("yyMMddHHmmss");
        /// <summary>
        /// 归还时间
        /// </summary>
        private string m_returndate = DateTime.Now.ToString();

        #region 采集器部分

        [DllImport("coredll.dll")]
        public static extern bool MessageBeep(int uType);

        /// <summary>
        /// 画面扫描卡号对象(key: CardNo； Value: ScanTime)
        /// </summary>
        private StringDictionary m_dicCardInfo = new StringDictionary();

        #endregion

        public frmDocReturn()
        {
            InitializeComponent();
        }

        #region 归还

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
          
            try
            {

                if (timer1.Enabled)
                {
                    SetStartOrEnd();
                }

                 UploadData(false);

            }
            catch (Exception ex )
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //数据上传失败,请联系系统管理员！
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FDR001"), 
                    Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// 上传数据
        /// </summary>
        /// <param name="IsBack">判断是否是返回</param>
        private void UploadData(bool IsBack)
        {   
            int SelectCout = 0;
            try 
            {

                if (timer1.Enabled)
                {
                    timer1.Enabled = false;
                    this.comboBox1.Enabled = true;
                    //开始
                    this.BtnStart.Text = Common.GetLanguageWord(this.Name, this.BtnStart.Name);
                }
                if (this.listView1.Items.Count <= 0)
                {
                    //没有可以上传的数据！
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FDR002"),
                        Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return;
                }
                for (int i = 0; i < this.listView1.Items.Count; i++)
                {
                    if (this.listView1.Items[i].Checked)
                    {
                        SelectCout++;
                    }
                }
                if (SelectCout <= 0)
                {
                    //请选择需要上传的数据！
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FDR003"),
                        Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (!IsBack)
                {
                    //确定上传数据？
                    if (MessageBox.Show(Common.GetLanguageWord(this.Name, "FDR004"),
                        Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        UpLoadData();
                    }
                }
                else
                {
                    UpLoadData();
                }

            }
            catch (Exception ex )
            {
        		
                throw ex ;
            }
        
        }

        /// <summary>
        /// 上传数据
        /// </summary>
        private void UpLoadData()
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                string Appno = string.Empty;
                string DocNO = string.Empty;

                 m_returnNo = DateTime.Now.ToString("yyMMddHHmmss");
                 m_returndate = DateTime.Now.ToString();
                for (int i = this.listView1.Items.Count-1; i >=0; i--)
                {
                    if (this.listView1.Items[i].Checked)
                    {

                        Appno = this.listView1.Items[i].SubItems[(int)EnumDocReturn.AppNo].Text.Trim();
                        DocNO = this.listView1.Items[i].SubItems[(int)EnumDocReturn.DocNo].Text.Trim();
                        UpdateDocAppDetail(Appno, DocNO);

                        UpdateDocInfo(DocNO, Appno);


                        InsertDocReturn(Appno, DocNO);

                        this.listView1.Items.RemoveAt(i);
                        this.DocList.Remove(this.DocList.Find(new Predicate<ApplyInfo>(m => m.DocNo == DocNO && m.AppNo == Appno)));
            
                    }

                }
                if (this.listView1.Items.Count <= 0)
                {
                    //this.listView1.Items.Clear();
                    this.m_dicCardInfo.Clear();
                    this.DocList.Clear();
                }

                //数据上传成功,请将图册放回到原来的位置！
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FDR005"),
                    Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
        }

        /// <summary>
        /// 更新图册申请详细信息
        /// </summary>
        /// <param name="dr"></param>
        private void UpdateDocAppDetail(string AppNo,string DocNo)
        {
            StringDictionary DicDataItem = new StringDictionary();
            StringDictionary DicPriItem = new StringDictionary();
          
            try
            {
                //如果是同一个人多次申请了同一个图册 并且审批了 则更新该申请人下那个图册所有的归还状态
                string AppUserNo = DocList.Find(m => m.AppNo == AppNo && m.DocNo == DocNo).AppUserId;
                DicPriItem[MasterTable.T_DocApplicationDetail.ApplicationNo] = "true";
                DicPriItem[MasterTable.T_DocApplicationDetail.DocNo] = "true";
                DicPriItem[MasterTable.T_DocApplicationDetail.ApprvlStatus] = "true";
                DicPriItem[MasterTable.T_DocApplicationDetail.UsedStatus] = "true";

                DicDataItem[MasterTable.T_DocApplicationDetail.ApplicationNo] = AppNo;
                DicDataItem[MasterTable.T_DocApplicationDetail.DocNo] = DocNo;
                DicDataItem[MasterTable.T_DocApplicationDetail.ApprvlStatus] = "1";
                DicDataItem[MasterTable.T_DocApplicationDetail.UsedStatus] = "1";
                DicDataItem[MasterTable.T_DocApplicationDetail.InventStatus] = "2";
                DicDataItem[MasterTable.T_DocApplicationDetail.UpdUserNo] = Common._personid;


                this.m_daoCommon.SetModifyDataItem(MasterTable.T_DocApplicationDetail.TableName, DicDataItem, DicPriItem, DicData);

                //string sql = "update t_docapplicationdetail,t_docapplication ";
                //sql += " set t_docapplicationdetail.InventStatus='2',t_docapplicationdetail.UpdDateTime=Now(),t_docapplicationdetail.UpdUserNo='" + Common._personid + "' ";
                //sql += " where t_docapplicationdetail.ApplicationNo=t_docapplication.ApplicationNo ";
                //sql += " and t_docapplication.AppUserNo='" + AppUserNo + "' and t_docapplicationdetail.ApprvlStatus='1' ";
                //sql += " and t_docapplicationdetail.DocNo='" + DocNo + "' and t_docapplicationdetail.UsedStatus='1' and t_docapplicationdetail.LentEnable='2' and t_docapplicationdetail.InventStatus='1' ";


                //this.m_daoCommon.SetModifyDataItemBySql(sql,DicData,DicData , DicData);


               
            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
        }
        /// <summary>
        /// 更新图册信息
        /// </summary>
        /// <param name="dr"></param>
        private void UpdateDocInfo(string DocNo, string AppNo)
        {
            StringDictionary DicDataItem = new StringDictionary();
            StringDictionary DicPriItem = new StringDictionary();
            try
            {
               // DicDataItem[MasterTable.M_Documents.InventStatus] = "0";

                DicDataItem[MasterTable.M_Documents.InventStatus] = GetInInventStatus(DocNo,AppNo).ToString();
                DicDataItem[MasterTable.M_Documents.DocNo] = DocNo;
                DicPriItem[MasterTable.M_Documents.DocNo] = "true";

                this.m_daoCommon.SetModifyDataItem(MasterTable.M_Documents.TableName, DicDataItem, DicPriItem, DicUserItem);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }


        /// <summary>
        /// 判断在库状态//
        ///  归还时判断该图册是否借出审批通过，审批状态为通过时更新成已借出，未通过更新成已归还//
        /// </summary>
        /// <param name="i_DocNo">图册编号</param>
        /// <returns>0：未借出  ：2：已归还 1：已借出</returns>
        private int GetInInventStatus(string i_DocNo, string i_ApplicationID)
        {

            try
            {


                string sql = "select * from " + MasterTable.ViewOrTable.grid_inventstatus + " where  DocNo='" + i_DocNo + "' and ApplicationNo<>'" + i_ApplicationID + "'";
                // DataTable dt = this.m_daoCommon.GetDataSet(sql,null);
                DataTable dt = this.m_daoCommon.GetTableInfoBySqlNoWhere(sql, new StringDictionary(), new StringDictionary(), new StringDictionary(), "", false);
                string w_strApprvlStatus = string.Empty;

                int i;

                if (dt != null && dt.Rows.Count > 0)
                {
                    for (i = 0; i <= dt.Rows.Count - 1; i++)
                    {
                        w_strApprvlStatus = dt.Rows[i]["ReturnNo"] + string.Empty;

                        if (string.IsNullOrEmpty(w_strApprvlStatus))
                        {
                            return 1;
                        }
                    }


                }
                else
                {
                    return 2;
                }

                return 0;


            }


            catch (Exception ex)
            {

                throw ex;
            }

        }

        /// <summary>
        /// 插入return表数据
        /// </summary>
        /// <param name="Appno"></param>
        /// <param name="DocNo"></param>
        private void InsertDocReturn(string Appno,string DocNo)
        {
            StringDictionary DicDataItem = new StringDictionary();
            try
            {
                string AppUserNo =DocList.Find(m=>m.AppNo ==Appno && m.DocNo ==DocNo).AppUserId;
                string AppId =DocList.Find(m=>m.AppNo ==Appno && m.DocNo ==DocNo).AppID;
               
                
                DicDataItem[MasterTable.T_DocReturn.ReturnID] = Common.GetGuid();
                DicDataItem[MasterTable.T_DocReturn.ReturnNo] = m_returnNo;
                DicDataItem[MasterTable.T_DocReturn.ApplicationID] = AppId;
                DicDataItem[MasterTable.T_DocReturn.DocNo] = DocNo;
                DicDataItem[MasterTable.T_DocReturn.RespUserNo] = Common._personid;
                DicDataItem[MasterTable.T_DocReturn.ReturnUserNo] = AppUserNo;
                DicDataItem[MasterTable.T_DocReturn.ReturnDate] = m_returndate ;
               
                this.m_daoCommon.SetInsertDataItem(MasterTable.T_DocReturn.TableName, DicDataItem, new StringDictionary());


                this.m_daoCommon.WriteLog("frmReturned", (int)MasterTable.OperateTyp.Edit, "手持机操作：用户【" + Common._personid + "】成功操作归还,申请编号【" + Appno + "】,申请人【" + AppUserNo + "】,图册编号【" + DocNo + "】");
            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
        }

        #endregion

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                GetInventNo();
            }
            catch (Exception ex )
            {
                timer1.Enabled = false;
                this.comboBox1.Enabled = true;
                //开始
                this.BtnStart.Text = Common.GetLanguageWord(this.Name,this.BtnStart.Name);
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);

                //扫描标签失败,请联系系统管理员！
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FDR006"), 
                    Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
          
            }
        }

        #region 开始/停止
      
        private void button4_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                SetStartOrEnd();
            }
            catch (Exception ex)
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //操作失败,请联系系统管理员！
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FDR007"), 
                    Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally 
            {
                Cursor.Current = Cursors.Default;
            }
        }
        /// <summary>
        /// 设置停止or开始

        /// </summary>
        private void SetStartOrEnd()
        {
            timer1.Enabled = !timer1.Enabled;
            if (timer1.Enabled)
            {
                if (this.listView1.Items.Count <= 0)
                {
                    this.m_dicCardInfo.Clear();
                    this.DocList.Clear();
                }

                //停止 
                this.BtnStart.Text = Common.GetLanguageWord(this.Name, this.BtnStart.Name + "_");
                this.comboBox1.Enabled = false;

            }
            else
            {
                //开始
                this.BtnStart.Text = Common.GetLanguageWord(this.Name, this.BtnStart.Name);
                this.comboBox1.Enabled = true;
            }
        }

        #endregion

        #region 全选


        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                for (int i = 0; i < this.listView1.Items.Count; i++)
                {
                    if (!this.listView1.Items[i].Checked)
                    {
                        this.listView1.Items[i].Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FDR007"), 
                    Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally 
            {
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion

        #region 返回

        private void btnBack_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                if (timer1.Enabled)
                {
                    SetStartOrEnd();
                }

                if (this.listView1.Items.Count > 0)
                {

                    //是否上传数据？
                    if (MessageBox.Show(Common.GetLanguageWord(this.Name, "FDR008"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        UploadData(true);
                        this.Close();
                    }
                    else
                    {
                        this.Close();
                    }

                }
                else
                {
                    //确定退出图册归还？ 
                    if (MessageBox.Show(Common.GetLanguageWord(this.Name, "FDR009"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                    {
                        this.Close();
                    }
                }


            }
            catch (Exception ex)
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FDR007"),
                     Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
           
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


        #endregion

        #region 扫描

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
                            //去掉重复的标签号
                            if (!this.m_dicCardInfo.ContainsKey(item.EPCString.Trim()))
                            {
                                this.m_dicCardInfo[item.EPCString.Trim()] = DateTime.Now.ToString();

                                ShowDataToListView(item.EPCString.Trim());
                            }

                        }
                    }
                }

            }
            catch (Exception ex)
            {
                //采集器设备连接失败，请及时与管理员联系！ 
                throw new Exception(Common.GetLanguageWord(this.Name, "FDR010") + System.Environment.NewLine + ex.Message.ToString());
            }
        }

        private void ShowDataToListView(string Tag)
        {
            ListViewItem Item = null;
            string[] arrs = null;
            string ColumName = MasterTable.M_Documents.DocName_Cn;
            string DocMainTittle = Common.GetBindFieldName(MasterTable.M_Documents.DocMainTitle);
            try
            {


                if (Common._Language.Trim().ToLower() == Common.Language.Janpanese.ToString().ToLower())
                {
                    ColumName = MasterTable.M_Documents.DocName_Jp;
                }
                string sql = "select * from " + MasterTable.ViewOrTable.grid_rerurnlistformobile + " where 1=1 and now()>DetailLentDate and ( TagNo1='" + Tag.Trim() 
                    + "' or TagNo2='" + Tag.Trim() + "' or TagNo3='" + Tag.Trim() + "') "
                     + " order by  DetailLentDate ";

                DataTable dt = this.m_daoCommon.GetTableInfoBySqlNoWhere(sql, this.DicData, this.DicData, this.DicData, "", false);
                if (dt != null && dt.Rows.Count > 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        //如果没有处理过，则添加
                        if (DocList.Count(new Func<ApplyInfo, bool>(m => m.AppNo == dt.Rows[i][MasterTable.T_DocApplicationDetail.ApplicationNo].ToString() 
                            && m.DocNo == dt.Rows[i][MasterTable.T_DocApplicationDetail.DocNo].ToString())) <= 0)
                        {
                            if (dt.Rows[i][MasterTable.T_DocApplication.AppUserNo].ToString() == comboBox1.SelectedValue.ToString())
                            {
                                arrs = new string[6];
                                //arrs[0] = dt.Rows[i][MasterTable.T_DocApplicationDetail.ApplicationNo].ToString();
                                //arrs[1] = dt.Rows[i][MasterTable.T_DocApplicationDetail.DocNo].ToString();
                                //arrs[2] = dt.Rows[i][MasterTable.M_Users.UserName].ToString();
                                //arrs[3] = dt.Rows[i][ColumName].ToString();
                                //arrs[4] = dt.Rows[i][MasterTable.M_Documents.MakeNumbers].ToString();
                                //arrs[5] = dt.Rows[i][DocMainTittle].ToString();



                                arrs[(int)EnumDocReturn.MakeNumbers] = dt.Rows[i][MasterTable.M_Documents.MakeNumbers].ToString();
                                arrs[(int)EnumDocReturn.DocMainTitle] = dt.Rows[i][DocMainTittle].ToString();
                                arrs[(int)EnumDocReturn.ReturnTime] =DateTime.Parse(dt.Rows[i][MasterTable.T_DocApplicationDetail.DetailReturnDate].ToString()).ToString("MM-dd HH:mm");
                                arrs[(int)EnumDocReturn.DocName] = dt.Rows[i][ColumName].ToString();
                                arrs[(int)EnumDocReturn.AppNo] = dt.Rows[i][MasterTable.T_DocApplicationDetail.ApplicationNo].ToString();
                                arrs[(int)EnumDocReturn.DocNo] = dt.Rows[i][MasterTable.T_DocApplicationDetail.DocNo].ToString();


                                Item = new ListViewItem(arrs);
                                this.listView1.Items.Add(Item);

                                this.DocList.Add(
                                                new ApplyInfo(){ AppNo = arrs[(int)EnumDocReturn.AppNo],
                                                                 DocNo = arrs[(int)EnumDocReturn.DocNo], 
                                                                AppUserId = dt.Rows[i][MasterTable.T_DocApplication.AppUserNo].ToString(),
                                                                AppID = dt.Rows[i][MasterTable.T_DocApplicationDetail.ApplicationID].ToString() }
                                        );
                                System.Threading.Thread.Sleep(50);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        #endregion

        private void frmDocReturn_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                SetLangeage();

                Common.GetDaoCommon(ref this.m_daoCommon);

                LoadComBox();

                if (comboBox1.Items.Count <= 0)
                {
                    BtnStart.Enabled = false;
                }

                DicUserItem[MasterTable.T_DocApplicationDetail.AddDateTime] = "true";
                DicUserItem[MasterTable.T_DocApplicationDetail.UpdDateTime] = "true";
                DicUserItem[MasterTable.T_DocApplicationDetail.UpdUserNo] = "true";
                //设置采集器功率
                SysParam.m_busModule.SetUpdateAntPower(2300);
            }
            catch (Exception ex)
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //初始化失败,请联系系统管理员！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FDR011"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
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
                all = Common.GetLanguageWord(this.Name, "ALL");
                this.lblTitle.Text = Common.GetLanguageWord(this.Name, this.lblTitle.Name);

                this.columnHeader11.Text = Common.GetLanguageWord(this.Name, "columnHeader11");
                this.columnHeader12.Text = Common.GetLanguageWord(this.Name, "columnHeader12");
                this.columnHeader13.Text = Common.GetLanguageWord(this.Name, "columnHeader13");
                this.columnHeader14.Text = Common.GetLanguageWord(this.Name, "columnHeader14");
                this.columnHeader15.Text = Common.GetLanguageWord(this.Name, "columnHeader15");
                this.columnHeader16.Text = Common.GetLanguageWord(this.Name, "columnHeader16");

                this.label1.Text = Common.GetLanguageWord(this.Name, label1.Name);
                this.BtnUpload.Text = Common.GetLanguageWord(this.Name, this.BtnUpload.Name);
                this.BtnStart.Text = Common.GetLanguageWord(this.Name, this.BtnStart.Name);
                this.btnAllSelect.Text = Common.GetLanguageWord(this.Name, this.btnAllSelect.Name);
                this.btnBack.Text = Common.GetLanguageWord(this.Name, this.btnBack.Name);
                this.button1.Text = Common.GetLanguageWord(this.Name, this.button1.Name);
            }
            catch (Exception exd )
            {
                
                throw exd ;
            }
      
        }

        private void frmDocReturn_KeyDown(object sender, KeyEventArgs e)
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
                    btnBack_Click(null, null);
                }
            }
            catch (Exception ex)
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FDR007"),
                     Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (timer1.Enabled)
                {
                    //启动扫描情况
                    timer1.Enabled = false;
                    this.listView1.Items.Clear();
                    this.m_dicCardInfo.Clear();
                    this.DocList.Clear();
                    //timer1.Enabled = true;

                    //停止 
                    this.BtnStart.Text = Common.GetLanguageWord(this.Name, this.BtnStart.Name + "_");
                }
                else
                {
                    //未启动扫描情况
                    this.listView1.Items.Clear();
                    this.m_dicCardInfo.Clear();
                    this.DocList.Clear();
                }
            }
            catch (Exception ex)
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FDR007"),
                     Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
           
            }
            finally 
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void LoadComBox()
        {
            try
            {
                string all = Common.GetLanguageWord(this.Name, "ALL");
                string sql = "select distinct AppUserNo,UserName  from " + MasterTable.ViewOrTable.grid_rerurnlistformobile;
                DataTable dt = this.m_daoCommon.GetTableInfoBySqlNoWhere(sql, DicData, DicData, DicData, "", false);
                if (dt == null) return;

                //DataTable ds = dt.Clone();
                //DataRow dr = ds.NewRow();
                //dr["AppUserNo"] = "-1";
                //dr["UserName"] = all;
                //ds.Rows.Add(dr);
                //ds.AcceptChanges();
                //ds.Merge(dt);
                this.comboBox1.DataSource = dt;
                this.comboBox1.ValueMember = "AppUserNo";
                this.comboBox1.DisplayMember = "UserName";
               
            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                this.listView1.Items.Clear();
                this.m_dicCardInfo.Clear();
                this.DocList.Clear();

            }
            catch (Exception ex)
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FDR007"),
                     Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

    }

    public class ApplyInfo
    {
        public string DocNo=string.Empty ;
        public string AppNo = string.Empty;
        public string AppUserId = string.Empty;
        public string AppID = string.Empty;
    }
    public enum EnumDocReturn
    {
        /// <summary>
        /// 制本番号
        /// </summary>
        MakeNumbers=0,
        /// <summary>
        /// 主标题
        /// </summary>
        DocMainTitle=1,
        /// <summary>
        /// 归还时间
        /// </summary>
        ReturnTime=2,
        /// <summary>
        /// 图册名称
        /// </summary>
        DocName=3,
        /// <summary>
        /// 申请编号
        /// </summary>
        AppNo=4,
        /// <summary>
        /// 图册编号
        /// </summary>
        DocNo=5
 
    }
}