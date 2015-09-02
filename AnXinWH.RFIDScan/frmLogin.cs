using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Framework.Libs;
using AnXinWH.RFIDScan.Libs;
using Framework.DataAccess;
using System.Collections.Specialized;
using AnXinWH.RFIDScan.MasterTable;
using System.Runtime.InteropServices;

namespace AnXinWH.RFIDScan
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

        /// <summary>
        /// 采集模块对象
        /// </summary>
        private busModule m_busModule;

        #endregion

        #region 初始化处理

        /// <summary>
        /// 构造函数
        /// </summary>
        public frmLogin()
        {

            InitializeComponent();

            Common.GetDaoCommon(ref m_daoCommon);

            timStatus.Enabled = true;
        }


        private void frmLogin_Load(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;
            try
            {

                //打开wifi
                try
                {
                    if (!Device.EnableWlanModule())
                    {
                        this.btnLogin.Enabled = false;
                        MessageBox.Show(Common.GetLanguageWord(this.Name, "FLG011"), Declare.Info_SysName,
                      MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        return;
                    }
                }
                catch (Exception ex)
                {

                    this.btnLogin.Enabled = false;
                    LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FLG011"), Declare.Info_SysName,
                  MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                }


                Common.GetDaoCommon(ref m_daoCommon);
                //设置多语言 
                SetLangeage();

                //画面数据初始化处理
                SetFormValue();

                //lblDeviceInfo.Text = "采集器：" + Common._terminalName + "(" + Common._terminalNo + "）";

                //设备状态信息显示
                timStatus.Enabled = true;
                timStatus_Tick(null, null);


            }
            catch (Exception ex)
            {
                this.btnLogin.Enabled = false;
                //this.btnScanDoc.Enabled = false;
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FLG007"), Declare.Info_SysName,
                   MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
            }
            finally
            {

                Cursor.Current = Cursors.Default;
            }
        }

        private void SetLangeage()
        {
            this.lblTitle.Text = Common.GetLanguageWord(this.Name, this.lblTitle.Name);
            this.lblUserId.Text = Common.GetLanguageWord(this.Name, this.lblUserId.Name);
            this.lblPswd.Text = Common.GetLanguageWord(this.Name, this.lblPswd.Name);
            //this.btnScanDoc.Text = Common.GetLanguageWord(this.Name,this.btnScanDoc.Name);
            this.btnLogin.Text = Common.GetLanguageWord(this.Name, this.btnLogin.Name);
            this.Label1.Text = Common.GetLanguageWord(this.Name, this.Label1.Name);
        }

        #endregion

        #region 控件处理事件

        /// <summary>
        /// 离线扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLeaveScan_Click(object sender, EventArgs e)
        {

            Cursor.Current = Cursors.WaitCursor;

            try
            {
                //该设备对应采集器运行状态为异常停止时才能使用离线扫描，确定要继续吗？ 
                if (MessageBox.Show(Common.GetLanguageWord(this.Name, "FLG001"), Declare.Info_SysName,
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == DialogResult.No)
                {
                    return;
                }

                Common._authorid = string.Empty;
                Common._authornm = string.Empty;

                //Common._factoryname = string.Empty ;
                //Common._factType = string.Empty ;
                //Common._personid = string.Empty ;
                //Common._personname = string.Empty ;
                //Common._personpswd = string.Empty;

                //Cursor.Current = Cursors.Default;
                //this.m_frmScanning.ShowDialog();

            }
            catch (Exception ex)
            {

                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
            }
        }

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

                    this.txtPaswd.Text = "";
                    //控件设置焦点
                    SetFocsu(this.txtUserId);
                    timStatus.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                //MessageBox.Show(Common.GetLanguageWord("frmDocReturn", "FDR007"),
                //     Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
            finally
            {
                timStatus.Enabled = true;
                this.Enabled = true;
                Cursor.Current = Cursors.Default;
            }
        }


        /// <summary>
        /// 图册定位扫描
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnScanBox_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            try
            {

                Common._authorid = string.Empty;
                Common._authornm = string.Empty;

                //Common._factoryname = string.Empty;
                //Common._factType = string.Empty;
                Common._personid = string.Empty;
                Common._personname = string.Empty;
                Common._personpswd = string.Empty;
                //this.m_frmScanBox.ShowDialog();
                frmScanDoc frm = new frmScanDoc();
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
                    //图册定位扫描
                    // btnScanBox_Click(btnScanDoc, null);
                }
                else if (e.KeyCode == Keys.F12)
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
                MessageBox.Show(Common.GetLanguageWord("frmDocReturn", "FDR007"),
                     Common.GetLanguageWord(Common.COM_SECTION, "MSGTITLE"), MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
            }
        }

        #endregion

        #region 设备状态信息显示

        /// <summary>
        /// 设备状态信息显示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timStatus_Tick(object sender, EventArgs e)
        {
            try
            {

                int RtnFlag = RRU9803WinCE.RWDeviceDll.GetWlanSignalStrength();

                this.picAirPort.Image = Common.GetWifiStateInfo(RtnFlag);

                this.picBattery.Image = Common.GetPowerState();

            }
            catch (Exception ex)
            {
                timStatus.Enabled = false;
                LogManager.WriteLog(Common.LogFile.Error, ex.Message);
            }
        }

        #endregion

        #endregion

        #region 处理方法

        #region 画面数据初始化处理

        /// <summary>
        /// 画面数据初始化处理
        /// </summary>
        private void SetFormValue()
        {
            try
            {
                //系统数据初始化处理
                Common.AdoConnect = new dbaFactory();
                Common.AdoConnect.Connect.SetParameter();

                m_busModule = new busModule();
                SysParam.m_busModule = m_busModule;

                if (!m_busModule.IsSucces)
                {

                    //采集器设备连接失败，请及时与管理员联系！
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FLG002"), Declare.Info_SysName,
                                           MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                    //this.btnScanDoc.Enabled = false;
                    this.btnLogin.Enabled = false;
                }
                else
                {
                    //this.btnScanDoc.Enabled = true;
                    this.btnLogin.Enabled = true;
                }

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        #endregion

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
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FLG003"), Declare.Info_SysName,
                                          MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    //控件设置焦点
                    SetFocsu(this.txtUserId); ;
                    return false;
                }

                if (string.IsNullOrEmpty(this.txtPaswd.Text.Trim()) == true)
                {
                    //用户密码不能输入空！ 
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FLG004"), Declare.Info_SysName,
                      MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                    //控件设置焦点
                    SetFocsu(this.txtPaswd);
                    return false;
                }

                timStatus.Enabled = false;
                Cursor.Current = Cursors.WaitCursor;
                this.Enabled = false;


                int RtnFlag = RRU9803WinCE.RWDeviceDll.GetWlanSignalStrength();


                if (RtnFlag <= 0)
                {
                    //打开wifi
                    try
                    {
                        if (!Device.EnableWlanModule())
                        {
                            MessageBox.Show(Common.GetLanguageWord("frmLogin", "FLG011"), Declare.Info_SysName,
                          MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                        }
                        else
                        {
                            RtnFlag = RRU9803WinCE.RWDeviceDll.GetWlanSignalStrength();
                            this.picAirPort.Image = Common.GetWifiStateInfo(RtnFlag);
                        }
                    }
                    catch (Exception ex)
                    {
                        LogManager.WriteLog(Common.LogFile.Error, ex.Message);
                        MessageBox.Show(Common.GetLanguageWord("frmLogin", "FLG011"), Declare.Info_SysName,
                      MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);

                    }
                }

                //打开数据库连接
                Common.AdoConnect.Connect.ConnectOpen();

                ////================获取采集器信息处理==========                    
                //if (GetTerminalInfo() == false )
                //{
                //    return false;
                //}

                //================登录验证处理==========

                //获取画面控件数据
                GetGrpDataItem();

                dtUser = this.m_daoCommon.GetTableInfo(MasterTable.ViewOrTable.grid_userinfo, this.dicItemData, this.dicConds, this.dicLikeConds, "", false);

                if (dtUser == null || dtUser.Rows.Count <= 0)
                {
                    //用户编号或密码输入错误，请检查！
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FLG005"), Declare.Info_SysName,
                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                    //控件设置焦点
                    SetFocsu(this.txtPaswd);
                    return false;
                }
                else
                {

                    //if (DateTime.Parse(dtUser.Rows[0][MasterTable.M_Users.EndDate].ToString()).CompareTo(DateTime.Now) <= 0 || dtUser.Rows[0][MasterTable.M_Users.EndDate].ToString() == "0")
                    //{
                    //    //该用户已经失效，不能登录系统！
                    //    MessageBox.Show(Common.GetLanguageWord(this.Name, "FLG006"), Declare.Info_SysName,
                    //            MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    //    //控件设置焦点
                    //    SetFocsu(this.txtUserId);
                    //    return false;
                    //}

                    Common._personid = dtUser.Rows[0][MasterTable.M_Users.UserNo].ToString();
                    Common._personname = dtUser.Rows[0][MasterTable.M_Users.UserName].ToString();
                    Common._personpswd = dtUser.Rows[0][MasterTable.M_Users.Passward].ToString();

                    Common._Language = "Chinese";// Enum.Parse(typeof(Common.Language), dtUser.Rows[0][MasterTable.M_Users.Language].ToString(), true).ToString();


                    //获取变换后的语言文件
                    //Common.SetLanguageInfo();

                    //Enum.Parse(Common.Language,

                    ////获取系统R/3参数信息
                    //if (GetSysR3Parameter() == false )
                    //{
                    //    return false;
                    //}

                    ////获取工作时间信息(更新本地参数信息)
                    //if (w_busUploadScan.GetWorkTimeInfo() == false)
                    //{
                    //    return false;
                    //}

                    //操作系统时间同步处理
                    GetServerDate();
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
                MessageBox.Show(Common.GetLanguageWord(this.Name, "FLG008"), Declare.Info_SysName,
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

                this.dicItemData[MasterTableWHS.musers.user_no] = this.txtUserId.Text.Trim();

                //数据加密处理
                this.dicItemData[MasterTableWHS.musers.user_pwd] = this.txtPaswd.Text;// Common.EncryptPassWord(this.txtPaswd.Text);

                this.dicConds[MasterTableWHS.musers.user_no] = "true";
                this.dicConds[MasterTableWHS.musers.user_pwd] = "true";

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 获取系统R/3参数信息
        /// </summary>
        public bool GetSysR3Parameter()
        {

            DataTable tblSysR3Parameter;

            bool isCheck = false;

            try
            {

                //=============获取采集器信息===============

                dicItemData.Clear();
                dicConds.Clear();
                dicLikeConds.Clear();

                //tblSysR3Parameter = this.m_daoCommon.GetTableInfo(M_SysR3Parameter.TableName, dicItemData, dicConds, dicLikeConds, "");

                //if (tblSysR3Parameter == null || tblSysR3Parameter.Rows.Count <= 0)
                //{

                //    MessageBox.Show("系统R/3参数被删除，请与供应商联系！", Declare.Info_SysName,
                //                MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                //    return false;
                //}

                //重复扫描周期
                //Common._upInterval = int.Parse(tblSysR3Parameter.Rows[0][M_SysR3Parameter.CardFilterMaxTime].ToString());

                isCheck = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isCheck;
        }


        /// <summary>
        /// 获取采集器信息
        /// </summary>
        public bool GetTerminalInfo()
        {

            DataTable tblTerminal;

            bool isCheck = false;
            string w_TrmnParamUpdTime;
            //采集器运行状态 0：正常；1：停止；3：通讯异常
            string w_intTrmnRunStatus = "1";

            try
            {

                //=============获取采集器信息===============

                dicItemData.Clear();
                dicConds.Clear();
                dicLikeConds.Clear();
                dicConds[M_TerminalSetting.TerminalNo] = "true";
                dicConds[M_TerminalSetting.TrmnStatus] = "true";

                dicItemData[M_TerminalSetting.TerminalNo] = Common._terminalNo;
                dicItemData[M_TerminalSetting.TrmnStatus] = "true";


                tblTerminal = this.m_daoCommon.GetTableInfo(M_TerminalSetting.TableName, dicItemData, dicConds, dicLikeConds, "", true);


                //tblTerminal = this.m_daoCommon.GetTableInfo(M_TerminalSetting.Grid_TermDeviceInfo, dicItemData, dicConds, dicLikeConds, "");

                if (tblTerminal == null || tblTerminal.Rows.Count <= 0)
                {
                    //已注册采集设备系统中被禁用或删除，请与供应商联系！
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FLG009"), Declare.Info_SysName,
                                MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

                    return false;
                }


                //采集器功能类型区分
                Common._deviceFuncType = int.Parse(tblTerminal.Rows[0][MasterTable.M_TerminalType.TypeFlag].ToString());
                //工厂编号
                //Common._factoryno = tblTerminal.Rows[0][MasterTable.M_Factory.FactoryNo].ToString();

                //参数更新时间
                w_TrmnParamUpdTime = tblTerminal.Rows[0][MasterTable.M_TerminalSetting.TrmnParamUpdTime].ToString();
                if (string.IsNullOrEmpty(w_TrmnParamUpdTime))
                {
                    w_TrmnParamUpdTime = DateTime.MinValue.ToString();
                }

                Common._lastUpdTime = DateTime.Parse(w_TrmnParamUpdTime);
                w_intTrmnRunStatus = tblTerminal.Rows[0][MasterTable.M_TerminalSetting.TrmnRunStatus].ToString();

                if (w_intTrmnRunStatus.Equals("0") == true)
                {
                    //该设备对应采集器处于运行状态不能使用手持机扫描！
                    MessageBox.Show(Common.GetLanguageWord(this.Name, "FLG010"), Declare.Info_SysName,
                    MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
                    return false;
                }

                isCheck = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return isCheck;
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
    }
}