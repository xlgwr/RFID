﻿using System;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Forms;
using AnXinWH.RFIDStockIn.StockIn;
using Framework.Libs;
using System.IO;
using Framework.FileOperate;
using Framework.DataAccess;
using System.Collections.Specialized;

namespace AnXinWH.RFIDStockIn
{
    static class Program
    {
        //系统登录画面
        public static frmLogin m_FrmSysLogin = null;
        public static string _tmpMac = SysInfo.GetMac();
        public static string _tmpIp = SysInfo.GetIpAddress();

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [MTAThread]
        static void Main()
        {
            try
            {
                Common._appPath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase);


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
                Common._SysName = "RFID仓库管理系统";
                //SystemParam._strDefaultDBName = Common._sysrun.DataBaseName;

                //================数据库初始化设定_E================/


                //系统数据初始化处理
                Common.AdoConnect = new dbaFactory();
                Common.AdoConnect.Connect.SetParameter();

                m_FrmSysLogin = new frmLogin();
                m_FrmSysLogin.ShowDialog();

                //Application.Run(new StockInMainFrm());

            }
            catch (Exception ex)
            {
                Application.Exit();
                MessageBox.Show(ex.Message);

            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="m_daoCommon"></param>
        /// <param name="message"></param>
        /// <param name="type">0:入库、1：出库、2：上架、3：基本信息</param>
        /// <param name="result"></param>
        /// <param name="mod_id"></param>
        /// <returns></returns>
        
        public static bool InserToLog(CBaseConnect m_daoCommon, string message, string type, string result, string mod_id)
        {
            try
            {
                StringDictionary dicItemValue = new StringDictionary();
                //user
                StringDictionary DidUserCollum = new StringDictionary();
                //log for use
                DidUserCollum[t_syslogrecd.adduser] = "true";
                DidUserCollum[t_syslogrecd.addtime] = "true";
                //DidUserCollum[t_alarmdata.updtime] = "true";
                //DidUserCollum[t_alarmdata.upduser] = "true";

                var guid=Guid.NewGuid();
                var rand= new Random();

                dicItemValue[t_syslogrecd.log_id] = DateTime.Now.ToString("yyyyMMddhhmmss") + "D" + rand.Next(100000).ToString();

                dicItemValue[t_syslogrecd.operatorid] = Common._personid;//Common._personname; //DateTime.Now.ToString("yyyyMMddHHmmss") + "R" + item.rfid;
                dicItemValue[t_syslogrecd.message] = message;
                dicItemValue[t_syslogrecd.type] = type;
                dicItemValue[t_syslogrecd.mod_id] = mod_id;
                dicItemValue[t_syslogrecd.result] = result;
                dicItemValue[t_syslogrecd.org_no] = "RFID";

                m_daoCommon.SetInsertDataItem(ViewOrTable.t_syslogrecd, dicItemValue, DidUserCollum);
                return true;
            }
            catch (Exception ex)
            {
                //throw ex;
                return false;
            }
        }
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
                Common._logThreadPath = Common._appPath + "\\" + w_ReadWriterXml.ReadXml(appPath, "Parameter", "LogThreadFileName") + "\\";

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
                Common._baud = int.Parse(w_ReadWriterXml.ReadXml(appPath, "Parameter", "Baud"));
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