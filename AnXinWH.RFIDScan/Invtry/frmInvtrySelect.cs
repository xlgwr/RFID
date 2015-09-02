using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Framework.DataAccess;
using System.Collections.Specialized;
using Framework.Libs;

namespace AnXinWH.RFIDScan
{
    public partial class frmInvtrySelect : Form
    {

        /// <summary>
        /// 共通数据对象
        /// </summary>
        protected CBaseConnect m_daoCommon;
        private StringDictionary Dic_Null = new StringDictionary();

        /// <summary>
        /// 每一页的行数
        /// </summary>
        private int m_SinglePageCount = 8;
        /// <summary>
        /// 页码
        /// </summary>
        private int page1 = 1;
       
        public frmInvtrySelect()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                if (this.listView1.Items.Count <= 0) return;
                if (this.listView1.FocusedItem == null)
                {
                    return;
                }
                string intrvNo = this.listView1.FocusedItem.SubItems[(int)EnumInvtrySelect.InventoryNo].Text.Trim();
                
                frmInvtryDetail frm = new frmInvtryDetail(intrvNo);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    //获取盘点数据
                    GetInvTryData();
                }
            }
            catch (Exception ex )
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //操作失败,请联系系统管理员！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS001"), 
                    Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
            
        }

        private void frmInvtrySelect_Load(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                SetLangeage();

                Common.GetDaoCommon(ref m_daoCommon);
                //获取盘点数据
                GetInvTryData();
            }
            catch (Exception ex)
            {
                //初始化盘点数据失败，请检查网络！
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS002"), Declare.Info_SysName,
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
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
                this.listView1.Columns[(int)EnumInvtrySelect.InventoryNo].Text = Common.GetLanguageWord(this.Name, "InventoryNo");
                this.listView1.Columns[(int)EnumInvtrySelect.TotalCout ].Text = Common.GetLanguageWord(this.Name, "totalcount");
                this.listView1.Columns[(int)EnumInvtrySelect.InventStatus].Text = Common.GetLanguageWord(this.Name, "InventStatus");
                this.listView1.Columns[(int)EnumInvtrySelect.InventBeginDate].Text = Common.GetLanguageWord(this.Name, "InventBeginDate");
                this.listView1.Columns[(int)EnumInvtrySelect.InventEndDate].Text = Common.GetLanguageWord(this.Name, "InventEndDate");

                this.lblgo.Text = Common.GetLanguageWord(this.Name, this.lblgo.Name);
                this.label6.Text = Common.GetLanguageWord(this.Name, this.label6.Name);
                this.label1.Text = Common.GetLanguageWord(this.Name, this.label1.Name);
                this.label4.Text = Common.GetLanguageWord(this.Name, this.label4.Name);
                this.button1.Text = Common.GetLanguageWord(this.Name, this.button1.Name);
                this.button2.Text = Common.GetLanguageWord(this.Name, this.button2.Name);
            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
           
        }

        /// <summary>
        /// 获取盘点数据
        /// </summary>
        private void GetInvTryData()
        {
            try
            {

                this.listView1.Items.Clear();
                DataTable dt = this.m_daoCommon.GetTableInfo(MasterTable.ViewOrTable.grid_planinventoryinfo, Dic_Null, Dic_Null, Dic_Null, "",false);

                if (dt == null || dt.Rows.Count <= 0)
                    return;

                    //ListViewItem listview = null;
                    //string[] Iters = null;
                    //for (int i = 0; i < dt.Rows.Count; i++)
                    //{
                    //    Iters = new string[5];
                    //    Iters[0] = dt.Rows[i][MasterTable.T_PlanInventory.InventoryNo].ToString();
                    //    Iters[1] = dt.Rows[i][MasterTable.T_PlanInventory.totalcount].ToString();
                    //    Iters[2] = dt.Rows[i][MasterTable.T_PlanInventory.InventBeginDate].ToString();
                    //    Iters[3] = dt.Rows[i][MasterTable.T_PlanInventory.InventEndDate].ToString();
                    //    Iters[4] = dt.Rows[i][MasterTable.T_PlanInventory.InventStatusText + SysParam.EndTag].ToString();

                    //    listview = new ListViewItem(Iters);

                    //    if (dt.Rows[i][MasterTable.T_PlanInventory.InventStatus].ToString() == ((int)MasterTable.InventStatus.NoComplete).ToString())
                    //    {
                    //        //未完成的盘点为红色
                    //        listview.ForeColor = Color.Red;
                    //    }
                    //    this.listView1.Items.Add(listview);

                    //}
                BindData(this.listView1, dt, page1);


            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //确定退出盘点？
            if (MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS003"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OKCancel, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                this.Close();

            }
            
        }

        private void frmInvtrySelect_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.F11)
                {
                    button1_Click(null, null);
                }
                else if (e.KeyCode == Keys.F12)
                {
                    button2_Click(null, null);
                }

            }
            catch (Exception ex )
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show(Common.GetLanguageWord("frmDocReturn", "FDR007"),
                     Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
           
            }
        }

        #region 分页

        /// <summary>
        /// 禁用或者启用上一页or下一页
        /// </summary>
        /// <param name="CurrentPage"></param>
        /// <param name="TotalPages"></param>
        private void ShowFirstOrNext(int CurrentPage, int TotalPages)
        {
            try
            {
                if (CurrentPage >= TotalPages && CurrentPage > 1)
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
                    lblmax.Enabled = false;
                    lblfirst.Enabled = false;
                    lblpre.Enabled = false;
                }
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
        private void BindData(ListView Listx, DataTable dt, int CurrentPages)
        {
            try
            {
                Listx.Items.Clear();
                ListViewItem listview = null;
                string[] Iters = null;
                for (int i = (CurrentPages - 1) * m_SinglePageCount; i < (CurrentPages) * m_SinglePageCount; i++)
                {
                    if (i >= dt.Rows.Count) break;
                    Iters = new string[5];
                    Iters[(int)EnumInvtrySelect.InventoryNo] = dt.Rows[i][MasterTable.T_PlanInventory.InventoryNo].ToString();
                    Iters[(int)EnumInvtrySelect.TotalCout ] = dt.Rows[i][MasterTable.T_PlanInventory.totalcount].ToString();
                    Iters[(int)EnumInvtrySelect.InventStatus] = dt.Rows[i][MasterTable.T_PlanInventory.InventStatusText + SysParam.EndTag].ToString();
                    Iters[(int)EnumInvtrySelect.InventBeginDate] = DateTime.Parse(dt.Rows[i][MasterTable.T_PlanInventory.InventBeginDate].ToString()).ToString("yyyy-MM-dd HH:mm");
                    Iters[(int)EnumInvtrySelect.InventEndDate] = DateTime.Parse(dt.Rows[i][MasterTable.T_PlanInventory.InventEndDate].ToString()).ToString("yyyy-MM-dd HH:mm");


                    listview = new ListViewItem(Iters);

                    if (dt.Rows[i][MasterTable.T_PlanInventory.InventStatus].ToString() == ((int)MasterTable.InventStatus.NoComplete).ToString())
                    {
                        //未完成的盘点为红色
                        listview.ForeColor = Color.Red;
                    }
                    Listx.Items.Add(listview);

                }

                //显示其他信息
                this.lbltotal.Text = dt.Rows.Count.ToString();

                int Totalpage = dt.Rows.Count / m_SinglePageCount + (dt.Rows.Count % m_SinglePageCount == 0 ? 0 : 1);
                this.lblpage.Text = CurrentPages.ToString() + "/" + Totalpage.ToString();
                if (!this.listView1.Items[0].Selected)
                {

                    this.listView1.Items[0].Selected = true;
                    this.listView1.Items[0].Focused = true;
                }
                this.lblINvtryNo.Text = this.listView1.FocusedItem.SubItems[0].Text.Trim();

                ShowFirstOrNext(CurrentPages, Totalpage);

            }
            catch (Exception ex)
            {

                throw ex;
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
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS004"), 
                        Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return;
                }
                if (int.Parse(this.txtPages.Text.Trim()) > (int.Parse(lbltotal.Text.Trim()) / m_SinglePageCount + (int.Parse(lbltotal.Text.Trim()) % m_SinglePageCount == 0 ? 0 : 1)))
                {
                    return;
                }

                page1 = int.Parse(this.txtPages.Text.Trim());
                GetInvTryData();
            }
            catch (Exception ex)
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //操作失败,请联系系统管理员！
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS001"), 
                    Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
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

        private void lblnext_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                page1++;
                GetInvTryData();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //操作失败,请联系系统管理员！ 
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS001"), 
                    Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void lblmax_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                 page1 = int.Parse(lbltotal.Text.Trim()) / m_SinglePageCount + (int.Parse(lbltotal.Text.Trim()) % m_SinglePageCount == 0 ? 0 : 1);
                GetInvTryData();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //操作失败,请联系系统管理员！
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS001"),
                    Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void lblpre_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                page1 --;
                GetInvTryData();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //操作失败,请联系系统管理员！
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS001"),
                    Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void lblfirst_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
             
                        page1 = 1;
                        GetInvTryData();
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //操作失败,请联系系统管理员！
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS001"),
                    Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }
        #endregion

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.listView1.FocusedItem !=null &&
                    this.listView1.FocusedItem.SubItems[(int)EnumInvtrySelect.InventoryNo] != null)
                {
                    this.lblINvtryNo.Text = this.listView1.FocusedItem.SubItems[(int)EnumInvtrySelect.InventoryNo].Text.Trim();
                }
            }
            catch ( Exception  ex )
            {
                
                 LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //  //操作失败,请联系系统管理员！
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FIS001"), Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }
    }
    public enum EnumInvtrySelect
    {   
        /// <summary>
        /// 盘点号
        /// </summary>
        InventoryNo = 0,
        /// <summary>
        /// 总数
        /// </summary>
        TotalCout = 1,
        /// <summary>
        /// 状态
        /// </summary>
        InventStatus = 2,
        /// <summary>
        /// 开始时间
        /// </summary>
        InventBeginDate = 3,
        /// <summary>
        /// 结束时间
        /// </summary>
        InventEndDate = 4
     
    }
}