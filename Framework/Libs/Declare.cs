using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace Framework.Libs
{
    public partial class Common
    {
        
        /// <summary>
        /// 画面查询记录集
        /// </summary>
        public struct dbRecord
        {   
            /// <summary>
            /// 记录集对象
            /// </summary>
            public DataTable AdoDataRst;
            /// <summary>
            /// 记录行数
            /// </summary>
            public int RcdCnt;
        }

        /// <summary>
        /// 画面表格显示的记录集
        /// </summary>
        public struct View
        {
            /// <summary>
            /// 记录集对象
            /// </summary>
            public DataView AdoViewRst;
            /// <summary>
            /// 记录行数
            /// </summary>
            public int RcdCnt;
        }

        /// <summary>
        /// 表格列显示模式
        /// </summary>
        public enum enumGridStyle
        {
            /// <summary>
            /// 输入模式
            /// </summary>
            InputStyle = 0,
            /// <summary>
            /// 显示模式
            /// </summary>
            ViewStyle = 1,
            /// <summary>
            /// 报表显示模式
            /// </summary>
            ViewReportStyle = 2
        };

        /// <summary>
        /// 数据源类型
        /// </summary>
        public enum DataSourceType
        {
            /// <summary>
            /// SQLServer数据库
            /// </summary>
            SQLServer=0,
            /// <summary>
            /// MySQL数据库
            /// </summary>
            MySQL = 1,
            /// <summary>
            /// Oracle数据库
            /// </summary>
            Oracle=2,
            /// <summary>
            /// Access数据库
            /// </summary>
            Access=3,
            /// <summary>
            /// 文本数据库
            /// </summary>
            TXT = 4
        }

        /// <summary>
        /// 数据库执行方式
        /// </summary>
        public enum Choose
        {   
            /// <summary>
            /// 仅有单个返回值
            /// </summary>
            HasAOutput = 0,
            /// <summary>
            /// 仅执行无返回值 
            /// </summary>
            OnlyExecSp,
            /// <summary>
            /// 返回记录集DataTable
            /// </summary>
            RetOneRecord
        };       
        
        /// <summary>
        /// 数据的状态
        /// </summary>
        public enum DataModifyMode
        {
            /// <summary>
            /// 新增模式
            /// </summary>
            add = 1,
            /// <summary>
            /// 修改模式
            /// </summary>
            upd = 2,
            /// <summary>
            /// 删除模式
            /// </summary>
            del = 3,
            /// <summary>
            /// 查询模式
            /// </summary>
            dsp = 4
        };

        /// <summary>
        /// 语言类型
        /// </summary>
        public enum Language
        {
            /// <summary>
            /// 中国语
            /// </summary>
            Chinese = 0,
            /// <summary>
            /// 日本语
            /// </summary>
            Janpanese = 1,
            /// <summary>
            /// 英语
            /// </summary>
            English = 2
        };

        /// <summary>
        /// 皮肤的风格
        /// </summary>
        public enum FormSkin
        {
            Caramel = 0,
            MoneyTwins = 1,
            Lilian = 2,
            TheAsphaltWorld = 3,
            iMaginary = 4,
            Black = 5,
            Blue = 6,
            Office2007Blue = 7,
            Office2007Black = 8,
            Office2007Silver = 9,
            Office2007Green = 10,
            Office2007Pink = 11,
            Coffee = 12,
            LiquidSky = 13,
            LondonLiquidSky = 14,
            GlassOceans = 15,
            Stardust = 16,
            Xmas2008Blue = 17,
            Valentine = 18,
            McSkin = 19,
            Summer2008 = 20,
            Pumpkin = 21,
            DarkSide = 22,
            Springtime = 23,
            Darkroom = 24,
            Foggy = 25,
            HighContrast = 26,
            Seven = 27,
            SevenClassic = 28,
            Sharp = 29,
            SharpPlus = 30

        };

        /// <summary>
        /// 导入的Excel文件数据类型
        /// </summary>
        public enum ExccelFileType
        {
            /// <summary>
            /// 明细数据
            /// </summary>
            Material,
            /// <summary>
            /// 概要数据
            /// </summary>
            SummaryData
        };

        /// <summary>
        /// 基form的工具栏的按钮的可视性
        /// </summary>
        public enum ToolVisible
        {
            BasicEntry = 0,
            BasicDetailEntry = 1,
            MasterData = 2,
            QueryData = 3,
            ImportData = 4,
            Information = 5
        }

        /// <summary>
        /// 存储更新添加信息（操作者，更新时间，创建时间）列名
        /// </summary>
        public static  class UserColum
        {
            //public const string AddUserNo = "adduserno";
            //public const string AddDateTime = "adddatetime";
            //public const string UpdUserNo = "upduserno";
            //public const string UpdDateTime = "upddatetime";

            public const string AddUserNo = "adduser";
            public const string AddDateTime = "addtime";
            public const string UpdUserNo = "upduser";
            public const string UpdDateTime = "updtime";
        }


        /// <summary>
        /// 系统默认值
        /// </summary>
        public static class DefineValue
        {
            public const string DefalutItemAllNo = "-1";
            /// <summary>
            /// 开始字段后缀
            /// </summary>
            public static string FiledBegin = "Begin";
            /// <summary>
            /// 结束字段后缀
            /// </summary>
            public static string FiledEnd = "End";

        }

        /// <summary>
        /// 日志类型
        /// </summary>
        public enum LogFile
        {
            Trace,
            Warning,
            Error,
            SQL
        }
    }
}
