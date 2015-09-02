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

namespace AnXinWH.RFIDScan
{
    public partial class frmInvtryDetail : Form
    {
        /// <summary>
        /// 盘点单号
        /// </summary>
        private string m_InventoryNo = string.Empty;
        /// <summary>
        /// 盘点状态
        /// </summary>
        private int m_InventoryStatus = 0;
        /// <summary>
        /// 共通数据对象
        /// </summary>
        protected CBaseConnect m_daoCommon;
        private StringDictionary Dic_Null = new StringDictionary();
        /// <summary>
        /// 选择tabpage 记录tab的页码
        /// </summary>
        private List<pages> ListPages = new List<pages>();
        /// <summary>
        /// 用户列
        /// </summary>
        private StringDictionary DicUserCollum = new StringDictionary();
        /// <summary>
        /// 主键列
        /// </summary>
        private StringDictionary DicPri = new StringDictionary();

        #region 页码

        /// <summary>
        /// 第一个页码

        /// </summary>
        private int page1 = 1;
        /// <summary>
        /// 第二个页码

        /// </summary>
        private int page2 = 1;
        /// <summary>
        /// 第三个页码

        /// </summary>
        private int page3 = 1;
        /// <summary>
        /// 每一页的行数
        /// </summary>
        private int m_SinglePageCount = 6;

        #endregion

        public frmInvtryDetail()
        {
            InitializeComponent();
        }

        public frmInvtryDetail(string InventoryNo,int InventStatus)
        {
            InitializeComponent();
            m_InventoryNo = InventoryNo;
            m_InventoryStatus = InventStatus;
         
        }

        public frmInvtryDetail(string InventoryNo)
        {
            InitializeComponent();
            m_InventoryNo = InventoryNo;

        }

        /// <summary>
        /// 显示详细信息
        /// </summary>
        private void ShowDeatilData()
        {
            StringDictionary Dicitem=new StringDictionary();
            try
            {
                if (string.IsNullOrEmpty(this.m_InventoryNo))
                {
                    return;
                }
                Dicitem[MasterTable.T_PlanInventory.InventoryNo]=this.m_InventoryNo;
                DataTable dt = this.m_daoCommon.GetTableInfo(MasterTable.ViewOrTable.grid_inventorydetail, Dicitem, Dicitem, Dic_Null, "", false);


                this.lbltotal.Text = "0";
                this.lblpage.Text = "1/1";

                if (dt == null || dt.Rows.Count <= 0)
                {
                    ShowFirstOrNext(1, 1);
                    return;
                }

                BindData(listView1, dt, page1);
             
            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
        }
        /// <summary>
        /// 显示正常数据
        /// </summary>
        private void ShowRightData()
        {
            StringDictionary Dicitem = new StringDictionary();
            try
            {
                if (string.IsNullOrEmpty(this.m_InventoryNo))
                {
                    return;
                }
                Dicitem[MasterTable.T_PlanInventory.InventoryNo] = this.m_InventoryNo;
                DataTable dt = this.m_daoCommon.GetTableInfo(MasterTable.ViewOrTable.grid_inventorydetail_good, Dicitem, Dicitem, Dic_Null, "", false);


                this.lbltotal.Text = "0";
                this.lblpage.Text = "1/1";


                if (dt == null || dt.Rows.Count <= 0)
                {
                    ShowFirstOrNext(1, 1);
                    return;
                }

                BindData(listView2, dt, page2);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 显示正常数据
        /// </summary>
        private void ShowBadData()
        {
            StringDictionary Dicitem = new StringDictionary();
            try
            {
                if (string.IsNullOrEmpty(this.m_InventoryNo))
                {
                    return;
                }
                Dicitem[MasterTable.T_PlanInventory.InventoryNo] = this.m_InventoryNo;
                DataTable dt = this.m_daoCommon.GetTableInfo(MasterTable.ViewOrTable.grid_inventorydetail_bad, Dicitem, Dicitem, Dic_Null, "", false);

                this.lbltotal.Text = "0";
                this.lblpage.Text = "1/1";
                if (dt == null || dt.Rows.Count <= 0)
                {
                    ShowFirstOrNext(1, 1);
                    return; 
                }


                BindData(listView3, dt, page3);

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 绑定数据
        /// </summary>
        /// <param name="Listx">绑定的控件</param>
        /// <param name="dt">数据项</param>
        /// <param name="CurrentPages">当前页</param>
        private void BindData(ListView Listx,DataTable dt,int CurrentPages)
        {
            try
            {
                Listx.Items.Clear();
                ListViewItem listview = null;
                string[] Iters = null;
                string DocName = Common.GetBindFieldName(MasterTable.M_Documents.DocName);
                string DocMainTittle = Common.GetBindFieldName(MasterTable.M_Documents.DocMainTitle);
                for (int i =(CurrentPages-1) * m_SinglePageCount; i < (CurrentPages)* m_SinglePageCount; i++)
                {
                    if (i >= dt.Rows.Count) break;
                    Iters = new string[5];
                    Iters[(int)EnumInvtryDetail.DocNo] = dt.Rows[i][MasterTable.T_InventoryDetail.DocNo].ToString();
                    Iters[(int)EnumInvtryDetail.MakeNumbers] = dt.Rows[i][MasterTable.M_Documents.MakeNumbers].ToString();
                    Iters[(int)EnumInvtryDetail.DocName] = dt.Rows[i][DocName].ToString();
                    Iters[(int)EnumInvtryDetail.Status] = dt.Rows[i][MasterTable.T_InventoryDetail.InventStatusText + SysParam.EndTag].ToString();
                    Iters[(int)EnumInvtryDetail.DocMainTitle] = dt.Rows[i][DocMainTittle].ToString();

                  //  Iters[3] = dt.Rows[i][MasterTable.T_PlanInventory.InventStatus].ToString();
                    listview = new ListViewItem(Iters);

                    if (dt.Rows[i][MasterTable.T_InventoryDetail.InventStatus].ToString()== ((int)MasterTable.DetailInventStatus.Redundant).ToString())
                    {
                        //多余的盘点为红色
                        listview.ForeColor = Color.Red;
                    }
                    else if (dt.Rows[i][MasterTable.T_InventoryDetail.InventStatus].ToString() == ((int)MasterTable.DetailInventStatus.Lack).ToString())
                    {
                        //缺少的盘点为黄色
                        listview.ForeColor = Color.YellowGreen;
                    }


                    Listx.Items.Add(listview);

                }

                //显示其他信息
                this.lbltotal.Text = dt.Rows.Count.ToString();

                int Totalpage =dt.Rows.Count / m_SinglePageCount+ (dt.Rows.Count % m_SinglePageCount == 0 ? 0 : 1);
                this.lblpage.Text = CurrentPages.ToString() + "/" + Totalpage.ToString();

                ShowFirstOrNext(CurrentPages, Totalpage);
              
            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
        }
        /// <summary>
        /// 禁用或者启用上一页or下一页
        /// </summary>
        /// <param name="CurrentPage"></param>
        /// <param name="TotalPages"></param>
        private void ShowFirstOrNext(int CurrentPage,int TotalPages)
        {
            try
            {
                if (CurrentPage >= TotalPages && CurrentPage >1 )
                {
                    lblnext.Enabled = false;
                    lblmax.Enabled = false;
                    lblfirst.Enabled = true;
                    lblpre.Enabled = true;
                }
                else if (CurrentPage > 1)
                {
                    lblnext.Enabled = true;
                    lblmax.Enabled = true;
                    lblfirst.Enabled = true;
                    lblpre.Enabled = true;
                }
                else if (TotalPages > 1)
                {

                    lblnext.Enabled = true;
                    lblmax.Enabled = true;
                    lblfirst.Enabled = false;
                    lblpre.Enabled = false;
                }
                else
                {
                    lblnext.Enabled = false;
                    lblmax.Enabled = false ;
                    lblfirst.Enabled = false;
                    lblpre.Enabled = false;
                }
            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (this.IsCompeletedIntrv(this.m_InventoryNo))
                {
                    //当前盘点已经完成,请确认！ 
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FID001"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return;
                }
                frmInvtryScan frm = new frmInvtryScan(this.m_InventoryNo);
                frm.ShowDialog();
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

        private void frmInvtryDetail_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                SetLangeage();

                Common.GetDaoCommon(ref m_daoCommon);
                this.lblINvtryNo.Text = this.m_InventoryNo;

                //初始化数据
                DicUserCollum[MasterTable.T_PlanInventory.UpdDateTime] = "true";
                DicUserCollum[MasterTable.T_PlanInventory.UpdUserNo] = "true";

                DicPri[MasterTable.T_PlanInventory.InventoryNo] = "true";
                ShowDeatilData();

                if (IsCompeletedIntrv(this.m_InventoryNo))
                {
                    btnStartInvr.Enabled = false;
                    btnEndIntrv.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //初始化失败,请联系系统管理员！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FID002"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
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
                this.tabControl1.TabPages[0].Text = Common.GetLanguageWord(this.Name, this.tabControl1.TabPages[0].Name);
                this.tabControl1.TabPages[1].Text = Common.GetLanguageWord(this.Name, this.tabControl1.TabPages[1].Name);
                this.tabControl1.TabPages[2].Text = Common.GetLanguageWord(this.Name, this.tabControl1.TabPages[2].Name);
                this.listView1.Columns[(int)EnumInvtryDetail.DocNo].Text = Common.GetLanguageWord(this.Name, "DocNo");
                this.listView1.Columns[(int)EnumInvtryDetail.MakeNumbers].Text = Common.GetLanguageWord(this.Name, "MakeNumbers");
                columnHeader7.Text = Common.GetLanguageWord(this.Name, MasterTable.M_Documents.DocName);
                this.listView1.Columns[(int)EnumInvtryDetail.Status].Text = Common.GetLanguageWord(this.Name, "InventStatus");
                columnHeader8.Text = Common.GetLanguageWord(this.Name, MasterTable.M_Documents.DocMainTitle);

                this.listView2.Columns[(int)EnumInvtryDetail.DocNo].Text = Common.GetLanguageWord(this.Name, "DocNo");
                this.listView2.Columns[(int)EnumInvtryDetail.MakeNumbers].Text = Common.GetLanguageWord(this.Name, "MakeNumbers");
                columnHeader9.Text = Common.GetLanguageWord(this.Name, MasterTable.M_Documents.DocName);
                columnHeader10.Text = Common.GetLanguageWord(this.Name, MasterTable.M_Documents.DocMainTitle);
                this.listView2.Columns[(int)EnumInvtryDetail.Status].Text = Common.GetLanguageWord(this.Name, "InventStatus");

                this.listView3.Columns[(int)EnumInvtryDetail.DocNo].Text = Common.GetLanguageWord(this.Name, "DocNo");
                this.listView3.Columns[(int)EnumInvtryDetail.MakeNumbers].Text = Common.GetLanguageWord(this.Name, "MakeNumbers");
                this.listView3.Columns[(int)EnumInvtryDetail.Status].Text = Common.GetLanguageWord(this.Name, "InventStatus");
                columnHeader11.Text = Common.GetLanguageWord(this.Name, MasterTable.M_Documents.DocName);
                columnHeader12.Text = Common.GetLanguageWord(this.Name, MasterTable.M_Documents.DocMainTitle);

                this.lblgo.Text = Common.GetLanguageWord(this.Name, this.lblgo.Name);
                this.label6.Text = Common.GetLanguageWord(this.Name, this.label6.Name);
                this.label1.Text = Common.GetLanguageWord(this.Name, this.label1.Name);
                this.label4.Text = Common.GetLanguageWord(this.Name, this.label4.Name);
                this.btnStartInvr.Text = Common.GetLanguageWord(this.Name, this.btnStartInvr.Name);
                this.btnEndIntrv.Text = Common.GetLanguageWord(this.Name, this.btnEndIntrv.Name);
                this.btnBack.Text = Common.GetLanguageWord(this.Name, this.btnBack.Name);
            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
        
        }

        /// <summary>
        /// 首页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblfirst_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        page1=1;
                        ShowDeatilData();
                        break;
                    case 1:
                        page2=1;
                        ShowRightData();
                        break;
                    case 2:
                        page3=1;
                        ShowBadData();
                        break;
                }


            }
            catch (Exception  ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //操作失败,请联系系统管理员！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FID003"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
         }

        /// <summary>
        /// 上一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblpre_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        page1--;
                        ShowDeatilData();
                        break;
                    case 1:
                        page2--;
                        ShowRightData();
                        break;
                    case 2:
                        page3--;
                        ShowBadData();
                        break;
                }


            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //操作失败,请联系系统管理员！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FID003"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally 
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// 下一页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblnext_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        page1++;
                        ShowDeatilData();
                        break;
                    case 1:
                        page2++;
                        ShowRightData();
                        break;
                    case 2:
                        page3++;
                        ShowBadData();
                        break;
                }


            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //操作失败,请联系系统管理员！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FID003"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// 尾页
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lblmax_Click(object sender, EventArgs e)
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        page1 = int.Parse(lbltotal.Text.Trim()) / m_SinglePageCount +( int.Parse(lbltotal.Text.Trim())%m_SinglePageCount==0?0:1);
                        ShowDeatilData();
                        break;
                    case 1:
                        page2 = int.Parse(lbltotal.Text.Trim()) / m_SinglePageCount + (int.Parse(lbltotal.Text.Trim()) % m_SinglePageCount == 0 ? 0 : 1);
                        ShowRightData();
                        break;
                    case 2:
                        page3 = int.Parse(lbltotal.Text.Trim()) / m_SinglePageCount + (int.Parse(lbltotal.Text.Trim()) % m_SinglePageCount == 0 ? 0 : 1);
                        ShowBadData();
                        break;
                }


            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //操作失败,请联系系统管理员！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FID003"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //int TempPrePages = 1;
            //记录当前的页码
            int CurrentPage=1;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
       

                //if (TempPrePageIndex == 0)
                //    TempPrePages = page1;
                //else if (TempPrePageIndex == 1)
                //    TempPrePages = page2;
                //else TempPrePages = page3;
                //if (ListPages.Count(new Func<pages, bool>(m => m.PageIndex == TempPrePageIndex)) > 0)
                //{
                //    //记录上一次的页码信息
                //    ListPages.Find(m => m.PageIndex == TempPrePageIndex).Currentpages = TempPrePages;
                //    ListPages.Find(m => m.PageIndex == TempPrePageIndex).PageIndex = TempPrePageIndex;
                //    ListPages.Find(m => m.PageIndex == TempPrePageIndex).TotalCount = int.Parse(lbltotal.Text.Trim());
                //}


                ////显示本次选择的页的页码信息
                ////如果已经显示过，则只需要显示页码信息，没有显示的话，就需要重新加载数据
                //if (ListPages.Count(new Func<pages, bool>(m => m.PageIndex == this.tabControl1.SelectedIndex)) > 0)
                //{
                //    ShowPagesInfo(this.tabControl1.SelectedIndex);
                //}
                //else
                //{
                //    switch (this.tabControl1.SelectedIndex)
                //    {
                //        case 0:
                //         CurrentPage=page1;
                //            ShowDeatilData();
                //            break;
                //        case 1:
                //             CurrentPage=page2;
                //            ShowRightData();
                //            break;
                //        case 2:
                //             CurrentPage=page3;
                //            ShowBadData();
                //            break;
                //    }

                //    ListPages.Add(new pages() { Currentpages = CurrentPage, PageIndex = this.tabControl1.SelectedIndex, TotalCount = int.Parse(lbltotal.Text.Trim()) });
                //}

                //TempPrePageIndex = this.tabControl1.SelectedIndex;


                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        CurrentPage = page1;
                 
                        ShowDeatilData();
                        break;
                    case 1:
                        CurrentPage = page2;
                        ShowRightData();
                        break;
                    case 2:
                        CurrentPage = page3;
                        ShowBadData();
                        break;
                }

            }
            catch (Exception ex )
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //操作失败,请联系系统管理员！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FID003"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// 显示页面详细信息
        /// </summary>
        /// <param name="pageindex"></param>
        private void ShowPagesInfo(int pageindex)
        {
            try
            {
                int TotalCount =this.ListPages.Find(new Predicate<pages>(m=>m.PageIndex==pageindex)).TotalCount;
                int CurrentPage = this.ListPages.Find(new Predicate<pages>(m => m.PageIndex == pageindex)).Currentpages;
                int TotalPage = TotalCount / m_SinglePageCount + (TotalCount % m_SinglePageCount == 0 ? 0 : 1);

             
                if (TotalCount == 0)
                {

                    this.lblpage.Text = "1/1";
                    this.lbltotal.Text = "0";
                }
                else
                {
                    this.lblpage.Text = CurrentPage.ToString() + "/" + TotalPage.ToString();
                    this.lbltotal.Text = TotalCount.ToString();
                }
                ShowFirstOrNext(CurrentPage, TotalPage);


            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
        }

        private void lblgo_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (this.txtPages.Text.Trim().Length <= 0) return;
                if (!IsNumber(this.txtPages.Text.Trim()))
                {
                    //请输入数字！ 
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FID004"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (int.Parse(this.txtPages.Text.Trim()) > (int.Parse(lbltotal.Text.Trim()) / m_SinglePageCount + (int.Parse(lbltotal.Text.Trim()) % m_SinglePageCount == 0 ? 0 : 1)))
                {
                    return;
                }

                switch (this.tabControl1.SelectedIndex)
                {
                    case 0:
                        page1 = int.Parse(this.txtPages.Text.Trim());
                        ShowDeatilData();
                        break;
                    case 1:
                        page2 = int.Parse(this.txtPages.Text.Trim());
                        ShowRightData();
                        break;
                    case 2:
                        page3 = int.Parse(this.txtPages.Text.Trim());
                        ShowBadData();
                        break;
                }
            }
            catch (Exception ex )
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //操作失败,请联系系统管理员！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FID003"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private bool IsNumber(string str)
        {
            string ZZValidInt1 = @"^\d+$";
            return System.Text.RegularExpressions.Regex.IsMatch(str, ZZValidInt1);
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            try
            {
                this.Close();
                this.DialogResult = DialogResult.OK;
            }
            catch (Exception ex )
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show(Common.GetLanguageWord("frmDocReturn", "FDR007"),
                     Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
           
            }
        }

        /// <summary>
        /// 完成盘点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnEndIntrv_Click(object sender, EventArgs e)
        {
            bool IsStart = false;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (this.IsCompeletedIntrv(this.m_InventoryNo))
                {
                    //当前盘点已经完成,请确认！ 
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FID005"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return;
                }

                //确定完成当前盘点？ 
                if (MessageBox.Show(Common.GetLanguageWord(this.Name, "FID006"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"),
                                MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
                {

                    //扫描过程中如何存值   
                    Common.AdoConnect.Connect.CreateSqlTransaction();
                    IsStart = true;
                    //更新盘点状态
                    UpdateIntrvData(this.m_InventoryNo);

                    //更新图册状态
                    UpdateDocStatus(this.m_InventoryNo);

                    this.m_daoCommon.WriteLog("frmInvtryPlanCreat", (int)MasterTable.OperateTyp.Edit, "手持机操作：盘点更新————用户【" + Common._personid + "】完成盘点扫描,盘点编号【" + this.m_InventoryNo + "】");

                    Common.AdoConnect.Connect.TransactionCommit();

                    //操作成功！ 
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FID007"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                    this.Close();
                    this.DialogResult = DialogResult.OK;
                }
            }
            catch (Exception ex )
            {
            
                if (IsStart)
                    Common.AdoConnect.Connect.TransactionRollback();  
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //操作失败,请联系系统管理员！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FID003"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        /// <summary>
        /// 更新盘点数据
        /// </summary>
        /// <param name="IntrvNo">盘点编号</param>
        private void UpdateIntrvData(string IntrvNo)
        {
            StringDictionary DicItem = new StringDictionary();

            StringDictionary DicChildItem = new StringDictionary();
            try
            {

                //子表：盘点区分=0且在库状态=0 在库状态更新成1缺少
                string sql = "update t_inventorydetail set InventFlag='" + (int)MasterTable.InventFlag.Updated + "',InventStatus='" + (int)MasterTable.DetailInventStatus.Lack + "' where InventoryNo='" + IntrvNo + "' and InventFlag='" + (int)MasterTable.InventFlag.plan + "' and InventStatus='" + (int)MasterTable.DetailInventStatus.zaiko + "'";

                this.m_daoCommon.SetModifyDataItemBySql(sql, Dic_Null, Dic_Null, Dic_Null);
                //更新主表盘点状态
                DicItem[MasterTable.T_PlanInventory.InventoryNo] = IntrvNo;
                DicItem[MasterTable.T_PlanInventory.InventUserNo] = Common._personid;
                DicItem[MasterTable.T_PlanInventory.InventStatus] = ((int)MasterTable.InventStatus.Completed).ToString();
                this.m_daoCommon.SetModifyDataItem(MasterTable.T_PlanInventory.TableName, DicItem, DicPri, DicUserCollum);
                
                //更新子表盘点状态
                DicChildItem[MasterTable.T_InventoryDetail.InventoryNo] = IntrvNo;
                DicChildItem[MasterTable.T_InventoryDetail.InventFlag] = ((int)MasterTable.InventFlag.Updated).ToString();
                DicChildItem[MasterTable.T_InventoryDetail.UpdUserNo] = Common._personid;
                this.m_daoCommon.SetModifyDataItem(MasterTable.T_InventoryDetail.TableName, DicChildItem, DicPri, Dic_Null);



            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
        }

        /// <summary>
        /// 根据盘点详细的数据更新图册状态
        /// </summary>
        /// <param name="IntrvNo">盘点编号</param>
        private void UpdateDocStatus(string IntrvNo)
        {
            //盘点详细的盘点状态<>缺少时 ，图册状态为0(在库),
            //盘点详细的盘点状态=缺少时 ，图册状态为借出,
            //盘点状态
            StringDictionary DicItem = new StringDictionary();
            DicItem[MasterTable.T_InventoryDetail.InventoryNo] = IntrvNo;

            //图册数据
            StringDictionary DicItemDoc = new StringDictionary();
            StringDictionary DicPriDco = new StringDictionary();
            DicPriDco[MasterTable.M_Documents.DocNo] = "true";
            //子表的在库状态
            int DetailIntrvStatus = 0;
            try
            {
                DataTable dt = this.m_daoCommon.GetTableInfo(MasterTable.T_InventoryDetail.TableName, DicItem, DicItem, Dic_Null, "", false);
                if (dt == null || dt.Rows.Count<= 0) return;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DetailIntrvStatus = int.Parse(dt.Rows[i][MasterTable.T_InventoryDetail.InventStatus].ToString());
                    DicItemDoc[MasterTable.M_Documents.DocNo] = dt.Rows[i][MasterTable.T_InventoryDetail.DocNo].ToString();
                    //盘点多余or 在库 图册状态为在库
                    if (DetailIntrvStatus == (int)MasterTable.DetailInventStatus.Redundant || DetailIntrvStatus == (int)MasterTable.DetailInventStatus.zaiko)
                    {
                        DicItemDoc[MasterTable.M_Documents.InventStatus] = ((int)MasterTable.DocInventStatus.Zaiko).ToString();
                    }
                    else if (DetailIntrvStatus == (int)MasterTable.DetailInventStatus.Lack)
                    {
                        //盘点缺少 图册状态为借出
                        DicItemDoc[MasterTable.M_Documents.InventStatus] = ((int)MasterTable.DocInventStatus.Lent).ToString();
                    }

                    //更新图册状态
                    this.m_daoCommon.SetModifyDataItem(MasterTable.M_Documents.TableName, DicItemDoc, DicPriDco, Dic_Null);
                }
            }
            catch (Exception ex )
            {
                
                throw ex ;
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
                DataTable dt = this.m_daoCommon.GetTableInfo(MasterTable.T_PlanInventory.TableName, DicItem, DicItem, Dic_Null, "", false);

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (int.Parse(dt.Rows[0][MasterTable.T_PlanInventory.InventStatus].ToString()) == (int)MasterTable.InventStatus.Completed)
                    {
                        IsCompelete = true;
                    }
                }
            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
            return IsCompelete;
        }

        private void txtPages_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void txtPages_KeyUp(object sender, KeyEventArgs e)
        {
            try
            {

                e.Handled = !IsNumber(this.txtPages.Text.Trim());

            }
            catch (Exception ex)
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show(Common.GetLanguageWord("frmDocReturn", "FDR007"),
                     Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
           
            }
        }

        private void frmInvtryDetail_KeyDown(object sender, KeyEventArgs e)
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
                MessageBox.Show(Common.GetLanguageWord("frmDocReturn", "FDR007"),
                     Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }


    }

    public class pages
    {
        /// <summary>
        /// 当前页
        /// </summary>
        public int Currentpages = 0;
        /// <summary>
        /// 总数
        /// </summary>
        public int TotalCount = 0;
        /// <summary>
        /// 记录的tabpage
        /// </summary>
        public int PageIndex = 0;
    }
    public enum EnumInvtryDetail
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
        /// 状态
        /// </summary>
        Status = 3,
        /// <summary>
        /// 图册编号
        /// </summary>
        DocNo = 4
    }
}