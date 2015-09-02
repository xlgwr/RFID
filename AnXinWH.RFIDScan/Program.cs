//************************************************
//Class     Name: Program
//Class Function: 系统启动模块/
//Creat     Date: 2011/11/21 xuxiaohu
//Update    Date: 
//************************************************
using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using Framework.Libs;
using Framework.FileOperate;
using System.Xml;
using System.IO;
using AnXinWH.RFIDScan.Libs;
using Framework.DataAccess;
using AGCSystem;

namespace AnXinWH.RFIDScan
{
    static class Program
    {

        #region 变量定义

        private static int Hwnd;

        //系统登录画面
        public static frmLogin m_FrmSysLogin = null;
        //public static frmMenu m_FrmSysLogin = null;

        #endregion

        #region 属性设置

        //[DllImport("coredll.dll", EntryPoint = "FindWindow")]
        //private extern static int FindWindow(string lpClassName, string lpWindowName);
        
        // [DllImport("coredll.dll", EntryPoint = "EnableWindow")]
        //private extern static bool EnableWindow(int hwnd, int fEnable);
          
        // [DllImport("coredll.dll", EntryPoint = "ShowWindow")]
        // private extern static bool ShowWindow(int hwnd, int nCmdShow);

         #endregion

         /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [MTAThread]
        static void Main()
        {
            
            try 
            {

                Common._appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);
                Common.SetLanguageInfo(); 

      
                //读取配置信息
                if (ReadXmlFileSet() == false)
                {
                    MessageBox.Show("读取配置信息失败，请与供应商联系！", Declare.Info_SysName,
                               MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1);
                    return;
                }


                //==================================================/
                //================数据库初始化设定_S================/
                //==================================================/
                Common._datasourcetype = Common.DataSourceType.MySQL;
                Common._dicFiledTypeMySql = DataFiledTypeMySql.FiledType;
                //Common._dicFiledTypeSQLServer = DataFiledTypeSQLServer.FiledType;

                Common._Administrator = "admin";
                Common._SysName = "RFID图纸管理系统";
                //SystemParam._strDefaultDBName = Common._sysrun.DataBaseName;

                //================数据库初始化设定_E================/


                //系统数据初始化处理
                Common.AdoConnect = new dbaFactory();
                Common.AdoConnect.Connect.SetParameter();

                ////判断采集是否注册
                //if (WinceReg.IsExistKey(WinceReg.HKEY.HKEY_LOCAL_MACHINE, "HandSetSystem\\", "TerminalNo") != 0)
                //{

                //    MessageBox.Show("该采集设备未被注册，请与供应商联系！", Declare.Info_SysName ,
                //                    MessageBoxButtons.OK,MessageBoxIcon.Exclamation,MessageBoxDefaultButton .Button1);
                //    return;
                //}

                //Common._terminalNo = WinceReg.ReadValue(WinceReg.HKEY.HKEY_LOCAL_MACHINE, "HandSetSystem\\", "TerminalNo");
                //Common._terminalName = WinceReg.ReadValue(WinceReg.HKEY.HKEY_LOCAL_MACHINE, "HandSetSystem\\", "TerminalName");
                
                //隐藏任务栏设置
                SetHideTaskbar_Click();

                m_FrmSysLogin = new frmLogin();
                m_FrmSysLogin.ShowDialog();

                //m_FrmSysLogin = new frmMenu();
                //m_FrmSysLogin.ShowDialog();

                //Application.Run(new frmLogin());

	        }
	        catch (Exception ex)
	        {

                MessageBox.Show(ex.Message);
		        throw ex;

	        }finally
            {
                 //RWDeviceDll.DisconnectReader();

                //显示任务栏设置/
                 SetShowTaskbar_Click();
            }
        }

        #region 显示任务栏设置

        //***********************************************************************
        //Process   Name : SetShowTaskbar_Click
        //Introduce　　　: 显示任务栏设置/
        //Parameter　　　: 
        //Return    Value: 
        //Creat     Date : 2011/06/27 xuxiaohu
        //Update    Date : 
        //Memo　　　　　 : 
        //***********************************************************************
        private static void SetShowTaskbar_Click()
        {
            bool w_isFlag;

            try
            {

                //Hwnd = FindWindow("HHTaskBar", "");

                //w_isFlag = ShowWindow(Hwnd, Declare.SW_SHOW);

                //w_isFlag = EnableWindow(Hwnd, 1);

            }
            catch (Exception)
            {             
                //throw;
            }
        }

        #endregion

        #region 显示任务栏设置

        //***********************************************************************
        //Process   Name : SetShowTaskbar_Click
        //Introduce　　　: 隐藏任务栏设置/
        //Parameter　　　: 
        //Return    Value: 
        //Creat     Date : 2011/06/27 xuxiaohu
        //Update    Date : 
        //Memo　　　　　 : 
        //***********************************************************************
        private static void SetHideTaskbar_Click()
        {
            bool w_isFlag;

            try
            {

                //Hwnd = FindWindow("HHTaskBar", "");

                //w_isFlag = ShowWindow(Hwnd, Declare.SW_HIDE);

                //w_isFlag = EnableWindow(Hwnd, 0);

            }
            catch (Exception)
            {
                //throw;
            }
        }

        #endregion

        #region 读取配置信息

        //***********************************************************************
        //Process   Name : ReadXmlFileSet
        //Introduce　　　: 读取配置信息/
        //Parameter　　　: 
        //Return    Value: 
        //Creat     Date : 2011/06/27 xuxiaohu
        //Update    Date : 
        //Memo　　　　　 : 
        //***********************************************************************
        private static bool ReadXmlFileSet()
        {

            bool ReadXmlFileSet = false;
            string appPath = "";

            //读取Xml数据信息
            ReadWriterXml w_ReadWriterXml = new ReadWriterXml();
            
            try
            {

                //取得程序根目录/
                appPath = Common._appPath + "\\" + "SysConfig.xml";

                ////Config文件初始化处理
                //w_ReadWriterXml.WriterXml(appPath);

                //数据库类型
                Common._sysrun.DataSourceType = Common.DataSourceType.SQLServer;
            
                //日志文件路径
                Common._logPath = Common._appPath + "\\" + w_ReadWriterXml.ReadXml(appPath, "Parameter", "LogFileName") + "\\";
               
                //日志文件路径
                Common._logThreadPath  = Common._appPath + "\\" + w_ReadWriterXml.ReadXml(appPath, "Parameter", "LogThreadFileName") + "\\";

                if (Directory.Exists(Common._logPath) == false)
                {
                    Directory.CreateDirectory(Common._logPath);
                }

                if (Directory.Exists(Common._logThreadPath) == false)
                {
                    Directory.CreateDirectory(Common._logThreadPath);
                }

                Common._sysrun.DataBaseName = w_ReadWriterXml.ReadXml(appPath, "Parameter", "Database");

                Common._sysrun.ServerName = w_ReadWriterXml.ReadXml(appPath, "Parameter", "Server");

                Common._sysrun.UserName = w_ReadWriterXml.ReadXml(appPath, "Parameter", "User");

                Common._sysrun.PassWord = w_ReadWriterXml.ReadXml(appPath, "Parameter", "Password");


                //手持设备参数
                Common._baud = int.Parse ( w_ReadWriterXml.ReadXml(appPath, "Parameter", "Baud"));
                Common._dminfre = int.Parse(w_ReadWriterXml.ReadXml(appPath, "Parameter", "Dminfre"));
                Common._dmaxfre = int.Parse(w_ReadWriterXml.ReadXml(appPath, "Parameter", "Dmaxfre"));
                Common._powerDbm = int.Parse(w_ReadWriterXml.ReadXml(appPath, "Parameter", "PowerDbm"));
                //数据上传更新间隔
                Common._upInterval = int.Parse(w_ReadWriterXml.ReadXml(appPath, "Parameter", "UpInterval"));

                ReadXmlFileSet = true;

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return ReadXmlFileSet;
        }

        #endregion
    }
}