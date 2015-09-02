using Framework.Libs;
using System;

namespace Framework.Libs
{
    public class LogManager
    {
        private static string logPath = string.Empty;
       
        /// <summary>
        /// 保存日志的文件夹
        /// </summary>
        public static string LogPath
        {
            get
            {
                if (logPath == string.Empty)
                {
                    //if (System.Web.HttpContext.Current == null)
                    //    // Windows Forms 应用
                    //    logPath = AppDomain.CurrentDomain.BaseDirectory;
                    //else
                    //    // Web 应用
                    //    logPath = AppDomain.CurrentDomain.BaseDirectory + @"bin\";

                    logPath = Common._logPath;
                }

                return logPath;
            }
            set { logPath = value; }
        }

        private static string logFielPrefix = string.Empty;
        /// <summary>
        /// 日志文件前缀
        /// </summary>
        public static string LogFielPrefix
        {
            get { return logFielPrefix; }
            set { logFielPrefix = value; }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        public static void WriteLog(string logFile, string msg)
        {
            try
            {
                System.IO.StreamWriter sw = System.IO.File.AppendText(
                    LogPath + LogFielPrefix + logFile + " " +
                    DateTime.Now.ToString("yyyyMMdd") + ".Log"
                    );
                sw.WriteLine(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss: ") + msg);
                sw.Close();
            }
            catch
            { }
        }

        /// <summary>
        /// 写日志
        /// </summary>
        public static void WriteLog(Framework.Libs.Common.LogFile logFile, string msg)
        {
            WriteLog(logFile.ToString(), msg);
        }
    }

}

