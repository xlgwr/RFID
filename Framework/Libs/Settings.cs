using System;
using System.Collections.Generic;
using System.Text;
using Framework.FileOperate;
using System.Windows.Forms;

namespace Framework.Libs
{
    public partial class Common
    {
        #region 配置信息处理

        public static String COM_SECTION = "COMMON";

        /// <summary>
        /// 取得当前程序的当前路径
        /// </summary>
        /// <param name="_Path">路径字符串</param>
        /// <returns>当前路径</returns>
        public static string GetSolutionPath(string _Path)
        {
            return (_Path.Substring(_Path.Length - 1, 1) != @"\") ? _Path + @"\" : _Path;
        }

        /// <summary>
        /// 读取系统配置信息
        /// </summary>
        public static void GetIniData()
        {
            //try
            //{
            //SysRun sysSetup = (SysRun)Serial.DeserializeBinary(Application.StartupPath + @"\" + Common._settingfilename);

           //_rwconfig = new RWConfig(Common.GetSolutionPath(Application) + @"Language\" + Common._sysrun.Language.ToString() + ".ini");
            //RWLang = new rwconfig(@"G:\Qouter 的副本\Quoter\Quoter\bin\Debug\Language");
            //RWLang = new rwconfig(Common.GetSolutionPath(Application.StartupPath) + @"Language\chinese.ini");
            //sysSetup = null;
            //}
            //catch (Exception ex)
            //{
            //    XtraMsgBox.Show(ex.Message, "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //}

        }

        /// <summary>
        /// 获取变换后的语言文件
        /// </summary>
        public static void SetLanguageInfo()
        {
            string path1 = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
            string path2=Common.GetSolutionPath(path1) + @"Language\" + Common._Language.ToString() + ".ini";
            Common._rwconfig = new RWConfig(path2);
           Common._rwconfig._FilePath = Common.GetSolutionPath(path1) + @"Language\" + Common._Language.ToString() + ".ini";
        }

        /// <summary>
        /// 取得Ini文件所对应的项目的值
        /// </summary>
        /// <param name="_Section">区域</param>
        /// <param name="_Key">项目</param>
        /// <returns>返回项目所对应的值</returns>
        public static string GetLanguageWord(string _Section, string _Key)
        {
            //return _rwconfig.ReadTextFile(_Section, _Key);
            return _rwconfig.INICommon(true, _Section, _Key, "", _rwconfig._FilePath);
        }

        #endregion

    }
}
