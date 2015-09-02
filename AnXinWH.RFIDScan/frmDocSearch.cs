using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Framework.Libs;
using System.Collections.Specialized;
using Framework.DataAccess;

namespace AnXinWH.RFIDScan
{
    public partial class frmDocSearch : Form
    {


        /// <summary>
        /// 共通数据对象
        /// </summary>
        protected CBaseConnect m_daoCommon;

        private StringDictionary DicData = new StringDictionary();
        private string SelectDocNo = string.Empty;
        public string SelectDoc { get { return this.SelectDocNo; } }
        public frmDocSearch()
        {
            InitializeComponent();
        }

        public frmDocSearch(string LikeDocNo)
        {
            InitializeComponent();
            this.textBox1.Text = LikeDocNo.Trim();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                GetDocData(this.textBox1.Text.Trim());
            }
            catch (Exception ex)
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //数据检索失败,请联系系统管理员！

                MessageBox.Show(Common.GetLanguageWord(this.Name, "MG001"),
                    Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally 
            {
                Cursor.Current = Cursors.Default;
            }
        }
        private void GetDocData(string DocNo)
        {       
            StringDictionary DicLikeItem = new StringDictionary();
            string ColumName = MasterTable.M_Documents.DocName_Cn;
            string[] arrs = null;
            string DocTittle=MasterTable.M_Documents.DocMainTitle;

            try
            {
                this.listView1.Items.Clear();

              DocTittle=  Common.GetBindFieldName(MasterTable.M_Documents.DocMainTitle);
                if (Common._Language.Trim().ToLower() == Common.Language.Janpanese.ToString().ToLower())
                {
                    ColumName = MasterTable.M_Documents.DocName_Jp;
                }

                if (this.textBox1.Text.Trim().Length > 0)
                {
                    DicLikeItem[MasterTable.M_Documents.DocNo] = DocNo;
                }

                string sql = "select * from " + MasterTable.M_Documents.TableName + " where 1=1 and ( MakeNumbers like'%" + DocNo.Trim()
                    + "%' or DocNo like'%" + DocNo + "%') ";
                DataTable dt = this.m_daoCommon.GetTableInfoBySqlNoWhere(sql, DicData, DicData, DicData, "", false);
                if (dt == null || dt.Rows.Count <= 0) return;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    arrs = new string[4];
                    arrs[(int)EnumDocSearch.DocNo] = dt.Rows[i][MasterTable.M_Documents.DocNo].ToString();
                    arrs[(int)EnumDocSearch.DocName] = dt.Rows[i][ColumName].ToString();
                    arrs[(int)EnumDocSearch.MakeNumbers] = dt.Rows[i][MasterTable.M_Documents.MakeNumbers].ToString();
                    arrs[(int)EnumDocSearch.DocMainTitle] = dt.Rows[i][DocTittle].ToString();

                    listView1.Items.Add(new ListViewItem(arrs));
                }

                this.listView1.Items[0].Selected = true;

            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
        }

        private void frmDocSearch_Load(object sender, EventArgs e)
        {
            
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                SetLanguage();

                Common.GetDaoCommon(ref this.m_daoCommon);

            
                GetDocData(this.textBox1.Text.Trim());

            }
            catch (Exception ex)
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //初始化失败,请联系系统管理员！

                MessageBox.Show(Common.GetLanguageWord(this.Name, "MG002"),
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
                for (int i = 0; i < this.listView1.Items.Count; i++)
                {
                    if (this.listView1.Items[i].Selected)
                    {
                        this.SelectDocNo = this.listView1.Items[i].SubItems[(int)EnumDocSearch.DocNo].Text.Trim();
                        break;
                    }
                }
                if (!string.IsNullOrEmpty(this.SelectDocNo))
                {

                    this.DialogResult = DialogResult.OK;
                    this.Close();
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

        private void button3_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                this.Close();
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

        private void frmDocSearch_KeyDown(object sender, KeyEventArgs e)
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

        private void SetLanguage()
        {
            try
            {
                this.label1.Text = Common.GetLanguageWord(this.Name, this.label1.Name);
                this.button1.Text = Common.GetLanguageWord(this.Name, this.button1.Name);
                this.button2.Text = Common.GetLanguageWord(this.Name, this.button2.Name);
                this.button3.Text = Common.GetLanguageWord(this.Name, this.button3.Name);

                columnHeader1.Text = Common.GetLanguageWord(this.Name, "columnHeader1");
                columnHeader2.Text = Common.GetLanguageWord(this.Name, "columnHeader2");
                columnHeader3.Text = Common.GetLanguageWord(this.Name, "columnHeader3");
                columnHeader4.Text = Common.GetLanguageWord(this.Name, "columnHeader4");
            }
            catch (Exception ex )
            {
                
                throw ex ;
            }
          
        }
    }
    public enum EnumDocSearch
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