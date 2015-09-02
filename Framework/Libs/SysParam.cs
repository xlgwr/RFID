using System;
using System.Collections.Generic;
using System.Text;
using Framework.FileOperate;
using System.Data;
using Framework.DataAccess;
using System.Collections.Specialized;
using MySql.Data.MySqlClient;

namespace Framework.Libs
{
    public partial class Common 
    {

        #region 系统参数设置

        /// <summary>
        /// 权限功能画面
        /// </summary>
        public static StringDictionary _dicRoleInfo;

        /// <summary>
        /// 权限Id
        /// </summary>
        public static string _authorid = "";

        /// <summary>
        /// 权限名称
        /// </summary>
        public static string _authornm = "";

        #endregion

        #region 共通参数设置

        //注意了，是8个字符，64位
        public const string KEY_64 = "RIFIDApp";
        public const string IV_64 = "RIFIDApp";

        /// <summary>
        /// SQLServer数据字段类型
        /// </summary>
        public static Dictionary<string, SqlDbType> _dicFiledTypeSQLServer = new Dictionary<string, SqlDbType>();

        /// <summary>
        /// MySql数据字段类型
        /// </summary>
        public static Dictionary<string, MySqlDbType> _dicFiledTypeMySql = new Dictionary<string, MySqlDbType>();

        /// <summary>
        /// 系统配置文件名称
        /// </summary>
        public static String _settingfilename = "SysConfig.xml";

        /// <summary>
        /// 系统名称
        /// </summary>
        public static string _SysName = "";

        /// <summary>
        /// 系统默认超级管理员ID
        /// </summary>
        public static string _Administrator = "admin";
   
        /// <summary>
        /// 登录用户编号
        /// </summary>
        public static string _personid = "";

        /// <summary>
        /// 登录用户密码
        /// </summary>
        public static string _personpswd = "";
        /// <summary>
        /// 登录用户名称
        /// </summary>
        public static string _personname = "";
        /// <summary>
        /// 登录语言
        /// </summary>
        public static string _Language = "Chinese";
 
        //系统参数
        public static SysRun _sysrun = new SysRun ();

        //系统参数提取变量
        public static RWConfig _rwconfig;

        public static DataSourceType _datasourcetype = DataSourceType.SQLServer;

        //系统数据库对象
        public static dbaFactory AdoConnect;

        /// <summary>
        /// 系统应用程序全路径
        /// </summary>
        public static string _appPath = "";

        /// <summary>
        /// 系统日志文件路径(控制)
        /// </summary>
        public static string _logPath = "";

        /// <summary>
        /// 系统日志文件路径(线程)
        /// </summary>
        public static string _logThreadPath = "";


        public static int _baud = 5;

        public static int _dminfre = 0;

        public static int _dmaxfre = 62;

        /// <summary>
        /// 卡重复扫描周期(Min)
        /// </summary>
        public static int _card_filter_maxtime = 90;

        /// <summary>
        /// 采集器读取功率
        /// </summary>
        public static int _powerDbm = 30;

        /// <summary>
        /// 数据上传更新间隔
        /// </summary>
        public static int _upInterval = 20000;

        /// <summary>
        /// 采集器编号
        /// </summary>
        public static string _terminalNo = "";
        /// <summary>
        /// 采集器名称
        /// </summary>
        public static string _terminalName = "";
        /// <summary>
        /// 采集器功能类型区分
        /// </summary>
        public static int _deviceFuncType;

        /// <summary>
        /// 参数更新时间
        /// </summary>
        public static DateTime _lastUpdTime = DateTime.Now;

        #endregion

    }
}
