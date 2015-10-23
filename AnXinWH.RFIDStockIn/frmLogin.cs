using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Framework.Libs;
using Framework.DataAccess;
using System.Collections.Specialized;
using System.Runtime.InteropServices;


using AnXinWH.RFIDStockIn.StockIn;

namespace AnXinWH.RFIDStockIn
{
    public partial class frmLogin : Form
    {

        #region 变量定义

        /// <summary>
        /// 共通数据对象
        /// </summary>
        protected CBaseConnect m_daoCommon;

        /// <summary>
        /// 精确查询条件列名
        /// </summary>
        protected StringDictionary dicConds = new StringDictionary();

        /// <summary>
        /// 模糊查询条件列名
        /// </summary>
        protected StringDictionary dicLikeConds = new StringDictionary();

        /// <summary>
        /// 数据唯一主键列名
        /// </summary>
        protected StringDictionary dicPrimarName = new StringDictionary();

        /// <summary>
        /// 操作员信息列名
        /// </summary>
        protected StringDictionary dicUserColum = new StringDictionary();

        /// <summary>
        /// 画面可输入数据对象
        /// </summary>
        protected StringDictionary dicItemData = new StringDictionary();

        #endregion

        #region 初始化处理

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmLogin()
        {

            InitializeComponent();

            Common.GetDaoCommon(ref m_daoCommon);
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {
            
        }

        #endregion

        #region 控件处理事件
        /// <summary>
        /// 用户登录处理
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            try
            {

                //用户登录处理
                if (this.GetUserLogin() == true)
                {

                    this.Enabled = true;

                    frmMenu frm = new frmMenu();
                    frm.ShowDialog();

                    //this.Hide();

                    this.txtPaswd.Text = "";
                    //控件设置焦点
                    SetFocsu(this.txtUserId);
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
               
                MessageBox.Show(ex.Message,
                   "Notice", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                this.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }



        #region 画面按下事件

        /// <summary>
        /// 画面按下事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void frmLogin_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {

                if (e.KeyCode == Keys.F11)
                {
                    //用户登录
                    btnLogin_Click(btnLogin, null);
                }
                else if (e.KeyCode == Keys.Escape)
                {
                    Close();
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show(ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        #endregion

        #endregion

        #region 处理方法

        #region 登录处理设置

        /// <summary>
        /// 用户登录处理
        /// </summary>
        /// <returns></returns>
        public bool GetUserLogin()
        {
            bool RtnValue = false;
            DataTable dtUser = null;

            try
            {


                //================画面输入检查处理==========

                if (string.IsNullOrEmpty(this.txtUserId.Text.Trim()) == true)
                {
                    //用户编号不能输入空！ 
                    MessageBox.Show("用户编号不能输入空！", Declare.Info_SysName,
                                          MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    //控件设置焦点
                    SetFocsu(this.txtUserId); ;
                    return false;
                }

                if (string.IsNullOrEmpty(this.txtPaswd.Text.Trim()) == true)
                {
                    //用户密码不能输入空！ 
                    MessageBox.Show("用户密码不能输入空！", Declare.Info_SysName,
                      MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                    //控件设置焦点
                    SetFocsu(this.txtPaswd);
                    return false;
                }

                Cursor.Current = Cursors.WaitCursor;
                this.Enabled = false;

                //打开数据库连接
                Common.AdoConnect.Connect.ConnectOpen();

              
                //================登录验证处理==========

                //获取画面控件数据
                GetGrpDataItem();

                dtUser = this.m_daoCommon.GetTableInfo(ViewOrTable.m_users, this.dicItemData, this.dicConds, this.dicLikeConds, "", false);

                if (dtUser == null || dtUser.Rows.Count <= 0)
                {
                    //用户编号或密码输入错误，请检查！
                    MessageBox.Show("用户编号或密码输入错误，请检查！", Declare.Info_SysName,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                    //控件设置焦点
                    SetFocsu(this.txtPaswd);
                    return false;
                }
                else
                {

                    Common._personid = dtUser.Rows[0][m_users.user_no].ToString();
                    Common._personname = dtUser.Rows[0][m_users.user_nm].ToString();
                    Common._personpswd = dtUser.Rows[0][m_users.user_pwd].ToString();

                    Common._Language = "Chinese";// Enum.Parse(typeof(Common.Language), dtUser.Rows[0][MasterTable.M_Users.Language].ToString(), true).ToString();

                    //操作系统时间同步处理
                    //GetServerDate();
                }

                RtnValue = true;

            }
            catch (Exception ex)
            {

                //系统登录失败，请检查网络是否正常连接！
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FLG007"), Declare.Info_SysName,
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                throw ex;
            }

            return RtnValue;
        }

        /// <summary>
        /// 操作系统时间同步处理
        /// </summary>
        private void GetServerDate()
        {

            try
            {

                DateTime w_dtSysTime = this.GetServiceTime();
                //DateTime w_dtSysTime = DateTime.Now;
                SystemTime sysTime = new SystemTime();

                sysTime.wYear = Convert.ToUInt16(w_dtSysTime.Year);
                sysTime.wMonth = Convert.ToUInt16(w_dtSysTime.Month);
                sysTime.wDay = Convert.ToUInt16(w_dtSysTime.Day);


                //using System.Runtime.InteropServices;在加载DLL时需要用到该命名空间.
                //[StructLayout(LayoutKind.Sequential)]:
                //直接设置时间时,操作系统会再加上一个地区的时差值,所以首先要把时差时减出来.
                //控制当导出到非托管代码时对象的布局。
                sysTime.wHour = Convert.ToUInt16(w_dtSysTime.Hour - TimeZone.CurrentTimeZone.GetUtcOffset(new DateTime(2001, 09, 01)).Hours);
                sysTime.wMinute = Convert.ToUInt16(w_dtSysTime.Minute);
                sysTime.wSecond = Convert.ToUInt16(w_dtSysTime.Second);
                sysTime.wMiliseconds = Convert.ToUInt16(w_dtSysTime.Millisecond);

                Win32.SetSystemTime(ref sysTime);

            }
            catch (Exception ex)
            {
                //服务器时间同步处理失败！
                MessageBox.Show("服务器时间同步处理失败！", Declare.Info_SysName,
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
            }


        }

        /// <summary>
        /// 获取服务时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetServiceTime()
        {
            DateTime dtnow = DateTime.Now;
            StringDictionary NUlldic = new StringDictionary();

            try
            {


                string strSql = "select NOW() ";


                DataTable dt = this.m_daoCommon.GetTableInfoBySqlNoWhere(strSql, NUlldic, NUlldic, NUlldic, "", false);
                if (dt != null && dt.Rows.Count > 0)
                    dtnow = DateTime.Parse(dt.Rows[0][0].ToString());

                return dtnow;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 获取画面控件数据
        /// </summary>
        protected void GetGrpDataItem()
        {
            try
            {
                dicItemData.Clear();
                dicConds.Clear();
                dicLikeConds.Clear();

                this.dicItemData[m_users.user_no] = this.txtUserId.Text.Trim();

                //数据加密处理  this.txtPaswd.Text;
               // var dd = Common.DecryptPassWord("FP81WJidZmk=");

                this.dicItemData[m_users.user_pwd] = Common.EncryptPassWord(this.txtPaswd.Text);

                this.dicConds[m_users.user_no] = "true";
                this.dicConds[m_users.user_pwd] = "true";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 控件设置焦点
        /// </summary>
        /// <param name="txt"></param>
        private void SetFocsu(TextBox txt)
        {

            if (!this.Enabled) this.Enabled = true;

            txt.Focus();
            txt.SelectAll();
        }

        #endregion


        [StructLayout(LayoutKind.Sequential)]
        public struct SystemTime
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMiliseconds;
        }

        public class Win32
        {
            [DllImport("CoreDll.dll")]
            public static extern bool SetSystemTime(ref SystemTime sysTime);
            [DllImport("CoreDll.dll")]
            public static extern void GetSystemTime(ref SystemTime sysTime);
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserId_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtUserId.Text.Trim().Length >= 0)
                {
                    txtPaswd.Focus();
                }
            }
        }
    }
}