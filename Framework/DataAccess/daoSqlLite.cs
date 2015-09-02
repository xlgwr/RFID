using System.Text;
using System.Diagnostics;
using System.Data.SQLite;
using System.Data;
using System.Configuration;
using System;
using System.Collections.Generic;
using System.Data.Common;
using Framework.Entity;
using System.Text.RegularExpressions;
using Framework.Libs;

namespace Framework.DataAccess
{
    /// <summary>
    /// 循环切换时间点的定义： RFID卡有一个最小的循环时间长度（按分钟计算），
    /// 我们将整个时间按此长度分段，认为每张卡在每个时间段内只有第一次扫描是有效扫描，
    /// 为了确定多次扫描到的卡是同一时间段，我们把这个时间段的起始时间作为区分标志，
    /// 就是循环切换时间点，简称切换点
    /// </summary>
    public class daoSqlLite : IDisposable
    {

        private static daoSqlLite MySelf = null;

       // private DbHelper SqlSrvHelper = null;
       private SQLiteHelper SqliteHelper = null;

        //private MyConfig myCfg = null;
       public daoSqlLite()
        {
            try
            {
                //string dbConnectionString = "Data Source=|DataDirectory|\\DAData.db;Pooling=true;FailIfMissing=false";
                string dbConnectionString = "Data Source=D35FLASH\\rfid.dll;Pooling=true;FailIfMissing=false";
                SqliteHelper = new SQLiteHelper(dbConnectionString);
            }
            catch (Exception ex)
            {

                LogManager.WriteLog(Framework.Libs.Common.LogFile.Error, ex.Message);
            }
        
        }
       public static daoSqlLite Instance
        {
            get
            {
                try
                {

               
                if (MySelf == null)
                {
                    MySelf = new daoSqlLite();

                    MySelf.InitDB();
                }
             
                }
                catch (Exception ex)
                {

                    LogManager.WriteLog(Framework.Libs.Common.LogFile.Error, ex.Message);
                }

                return MySelf;
            }
        }
        public void close()
        {
            try
            {
                if (MySelf != null)
                    MySelf = null;
            }
            catch (Exception e)
            {
                //log.WriteLog("close   " + e.Message);
                LogManager.WriteLog(Framework.Libs.Common.LogFile.Error, e.Message);
            }

        }
        /// <summary>
        /// 初始化数据库
        /// </summary>
        public void InitDB()
        {

            try
            {

                string CommandText = "SELECT COUNT(*) as cnt FROM sqlite_master where type='table' and name='{0}'";
                object count = this.SqliteHelper.ExecuteScalar(CommandType.Text, String.Format(CommandText, "cards"));
                if (count == null || count.ToString() == "0")
                {
                    CommandText = "CREATE TABLE [cards] (kdt integer,epc nvarchar(200),dt integer,flag int,PRIMARY KEY(kdt,epc))";
                    int x = this.SqliteHelper.ExecuteNonQuery(CommandType.Text, CommandText);
                }

                CommandText = "SELECT COUNT(*) as cnt FROM sqlite_master where type='table' and name='{0}'";
                count = this.SqliteHelper.ExecuteScalar(CommandType.Text, String.Format(CommandText, "WorkTimeList"));
                if (count == null || count.ToString() == "0")
                {
                    CommandText = "CREATE TABLE [WorkTimeList] (ID varchar(32),LatestTime integer,FromTime integer,ToTime integer,Flag int ,PRIMARY KEY(ID,LatestTime))";
                    this.SqliteHelper.ExecuteNonQuery(CommandType.Text, CommandText);
                }

                CommandText = "SELECT COUNT(*) as cnt FROM sqlite_master where type='table' and name='{0}';";
                count = this.SqliteHelper.ExecuteScalar(CommandType.Text, String.Format(CommandText, "params"));
                if (count == null || count.ToString() == "0")
                {
                    CommandText = "CREATE TABLE [params] (pkey nvarchar(200),pvalue nvarchar(200),PRIMARY KEY(pkey))";
                    this.SqliteHelper.ExecuteNonQuery(CommandType.Text, CommandText);

                    CommandText = "";
                    CfgAttribute cfgAttr = null;

                    //Array Arrays = Enum.GetValues(typeof(ConfigParams));

                    ///// <summary>
                    ///// 采集器编号
                    ///// </summary>
                    //[Cfg("1", "^[a-zA-Z_0-9]+$", RegexOptions.None)]
                    //DeviceNo,

                    ///// <summary>
                    ///// 循环周期(卡循环使用一次最少用时,单位:分钟)
                    ///// </summary>
                    //[Cfg("90", @"\d+$", RegexOptions.None)]
                    //CycInterval,

                    ///// <summary>
                    ///// 采集器功能类型
                    ///// </summary>
                    //[Cfg("-1", "*", RegexOptions.None)]
                    //DeviceFuncType

                    Array Arrays = new Enum[] { 
                        //采集器编号
                        ConfigParams.DeviceNo,
                        //循环周期(卡循环使用一次最少用时,单位:分钟)
                        ConfigParams.CycInterval, 
                        //采集器功能类型
                        ConfigParams.DeviceFuncType 
                        };

                    for (int i = 0; i < Arrays.Length; i++)
                    {
                        ConfigParams cp = (ConfigParams)Arrays.GetValue(i);
                        cfgAttr = CfgAttribute.GetAttribute<CfgAttribute>(cp);
                        CommandText += String.Format("insert into [params] (pkey,pvalue) values('{0}','{1}');", cp.ToString(), cfgAttr.DefaultValue);
                    }
                    this.SqliteHelper.ExecuteNonQuery(CommandType.Text, CommandText);
                }

            }
            catch (Exception ex)
            {
                LogManager.WriteLog(Framework.Libs.Common.LogFile.Error, ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// 插入卡记录
        /// </summary>
        /// <param name="card"></param>
        /// <returns></returns>
        public bool InsertCard(Card card)
        {
            bool ok = false;
           
            try
            {

                //String CommandText = "select kdt from [cards] where kdt=@kdt and epc=@epc ";
              
                //Parameters[] p = new Parameters[]{
                //new Parameters("@kdt", card.Kdt, DbType.Int64),
                //new Parameters("@epc", card.EPC, DbType.String),
                //};
               
                //Object obj =  this.SqliteHelper.ExecuteScalar (CommandType.Text, CommandText, p);

                //if (obj != null && obj != DBNull.Value) return true;

                String CommandText = "insert or ignore into [cards] (kdt,epc ,dt,flag) values(@kdt,@epc,@dt,@flag)";
                Parameters[] p = new Parameters[]{
                new Parameters("@kdt", card.Kdt, DbType.Int64),
                new Parameters("@epc", card.EPC, DbType.String),
                new Parameters("@dt", card.Dt, DbType.Int64),
                new Parameters("@flag",card.Flag, DbType.Int32) //falg=0 新插入
                };
                this.SqliteHelper.ExecuteNonQuery(CommandType.Text, CommandText, p);

                ok = true;
            }
            catch (Exception e)
            {
                //log.ErrorFormat("InsertCard:{0},{1}", e.ToString(), card.ToString());
                LogManager.WriteLog(Framework.Libs.Common.LogFile.Error,string.Format ("InsertCard:{0},{1}", e.ToString(), card.ToString()));
            }
            return ok;
        }

        /// <summary>
        /// 删除切换点(包括以前)已经上传的数据
        /// </summary>
        /// <param name="kdt">切换点</param>
        /// <returns></returns>
        public bool DeleteCards(long kdt)
        {
            bool ok = false;
            try
            {
                string CommandText = "delete from [cards]  where  kdt<=@kdt and flag = @flag";
                Parameters[] p = new Parameters[]{
                new Parameters( "@kdt", kdt, DbType.Int64),
                new Parameters( "@flag", (int)CardStatus.Uploaded, DbType.Int32) //falg=2 已经上传的
                };
                this.SqliteHelper.ExecuteNonQuery(CommandType.Text, CommandText, p);
                ok = true;
            }
            catch (Exception e)
            {
                //log.ErrorFormat("{0},DeleteCards kdt={1}", e.ToString(), kdt);

                LogManager.WriteLog(Framework.Libs.Common.LogFile.Error, string.Format("{0},DeleteCards kdt={1}", e.ToString(), kdt));
                
            }
            return ok;
        }

        /// <summary>
        /// 将已经上传的数据标记为已经上传（标记为2）!
        /// </summary>
        /// <param name="kdt">切换点</param>
        /// <param name="epc">卡号</param>
        /// <returns></returns>
        public bool UpdateFlagAfterUploaded(long kdt, string epc)
        {
            bool ok = false;
            try
            {
                string CommandText = "update [cards]  set flag = @flag  where  kdt=@kdt and epc=@epc";
                Parameters[] p = new Parameters[]{
                new Parameters( "@kdt", kdt, DbType.Int64),
                new Parameters( "@epc", epc, DbType.String),
                new Parameters( "@flag", (int)CardStatus.Uploaded, DbType.Int32) //falg=2 标记已上传
                };
                ok = this.SqliteHelper.ExecuteNonQuery(CommandType.Text, CommandText, p) > 0;
            }
            catch (Exception e)
            {
                //log.ErrorFormat("UpdateFlagAfterUploaded:{0},delete kdt={1}", e.ToString(), kdt);

                LogManager.WriteLog(Framework.Libs.Common.LogFile.Error, string.Format ("UpdateFlagAfterUploaded:{0},delete kdt={1}", e.ToString(), kdt));

            }
            return ok;
        }

        /// <summary>
        /// 服务重启动时，加载当前时间对应的切换点已经存储的卡
        /// </summary>
        /// <param name="kdt">切换点</param>
        /// <returns></returns>
        public List<Card> FetchCardsForRestart(long kdt)
        {
            List<Card> ret = new List<Card>();
            try
            {
                DataSet ds = null;
                String CommandText = "select * from [cards] where  kdt=@kdt";
                Parameters[] p = new Parameters[]{
                                new Parameters( "@kdt", kdt, DbType.String)
                };
                ds = this.SqliteHelper.ExecuteDataSet(CommandType.Text, CommandText, p);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    long _kdt = (dr["kdt"] as long?).Value;
                    long _dt = (dr["dt"] as long?).Value;
                    ret.Add(new Card(_kdt, dr["epc"] as String, _dt));
                }
                ds.Clear();
                ds = null;
            }
            catch (Exception e)
            {
                //log.ErrorFormat("FetchCardsForRestart:{0}", e.ToString());

                LogManager.WriteLog(Framework.Libs.Common.LogFile.Error, string.Format("FetchCardsForRestart:{0}", e.ToString()));

            }

            return ret;
        }


        /// <summary>
        /// 获得参数表的所有数据
        /// </summary>
        /// <returns></returns>
        public Dictionary<string, string> FetchParams()
        {
            Dictionary<string, string> ret = new Dictionary<string, string>();
            try
            {
                DataSet ds = null;
                String CommandText = "select * from [params]";
                ds = this.SqliteHelper.ExecuteDataSet(CommandType.Text, CommandText);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    string pkey = dr["pkey"] as string;
                    string pvalue = dr["pvalue"] as string;
                    ret.Add(pkey, pvalue);
                }
                ds.Clear();
                ds = null;
            }
            catch (Exception e)
            {
                //log.ErrorFormat("FetchParams:{0}", e.StackTrace);
                LogManager.WriteLog(Framework.Libs.Common.LogFile.Error, string.Format("FetchParams:{0}", e.StackTrace));

            }

            return ret;
        }

        /// <summary>
        /// 获取指定名称的参数
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string SelectParam(string key)
        {
            try
            {
                string CommandText = "SELECT pvalue cnt FROM [params] WHERE pkey = @pkey";
                Parameters[] p = new Parameters[]{
                new Parameters( "@pkey", key, DbType.String)
                };
                object pvalue = this.SqliteHelper.ExecuteScalar(CommandType.Text, CommandText, p);
                if (pvalue != null)
                    return (string)pvalue;
            }
            catch (Exception e)
            {
                //log.Error("SelectParam:" + e.ToString());
                LogManager.WriteLog(Framework.Libs.Common.LogFile.Error, "SelectParam:" + e.ToString());

            }

            return null;
        }




        /// <summary>
        /// 获取未上传卡数量
        /// </summary>
        /// <returns></returns>
        public int GetCardsCount()
        {
            int CardsCount = 0 ;
            try
            {
                string CommandText = "";

                CommandText = String.Format("select count(*) from [cards] where flag <> {0}", (int)CardStatus.Uploaded );
                object obj = this.SqliteHelper.ExecuteScalar(CommandType.Text, CommandText);

                if (obj != null && obj != DBNull.Value && Convert.ToInt32(obj) > 0)

                    CardsCount = Convert.ToInt32(obj);
                else
                {
                    CardsCount = 0;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return CardsCount;
        }

        /// <summary>
        /// 从sqlite数据库中提取要上传的数据，
        /// 上传前将每行状态标记为1，表示可以上传
        /// </summary>
        /// <returns></returns>
        public List<Card> FetchCardsForUpload()
        {
            List<Card> ret = new List<Card>();
            try
            {
                string CommandText = "";

                CommandText = String.Format("select count(*) from [cards] where flag = {0}", (int)CardStatus.ForUpload);
                object obj = this.SqliteHelper.ExecuteScalar(CommandType.Text, CommandText);
                if (obj != null && obj != DBNull.Value && Convert.ToInt32(obj) > 0)
                    //log.InfoFormat("上次循环有{0}条上传失败！", obj);

                    LogThreadManager.WriteLog(Framework.Libs.Common.LogFile.Error, string.Format("上次循环有{0}条上传失败！", obj));

                else
                {    }
                CommandText = String.Format("update [cards]  set flag = {0} where flag = {1}", (int)CardStatus.ForUpload, (int)CardStatus.NewInsert); //falg=1 标记准备上传
                this.SqliteHelper.ExecuteNonQuery(CommandType.Text, CommandText);
            

                DataSet ds = null;
                CommandText = String.Format("select * from [cards] where flag = {0}", (int)CardStatus.ForUpload);
                ds = this.SqliteHelper.ExecuteDataSet(CommandType.Text, CommandText);
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    long kdt = Convert.ToInt64(dr["kdt"]);
                    long dt = Convert.ToInt64(dr["dt"]);
                    ret.Add(new Card(kdt, dr["epc"] as String, dt));
                }
                ds.Clear();
                ds = null;
            }
            catch (Exception e)
            {
                //log.ErrorFormat("FetchCardsForUpload:{0}", e.ToString());
                LogThreadManager.WriteLog(Framework.Libs.Common.LogFile.Error, string.Format ("FetchCardsForUpload:{0}", e.ToString()));

            }

            return ret;
        }

        /// <summary>
        /// 获取当前已经采集到的但未上传的卡的数量
        /// </summary>
        /// <returns></returns>
        public int CountCard()
        {
            int ret = -1;
            try
            {
                string CommandText = String.Format("SELECT COUNT(*) as cnt FROM [cards] where flag <{0}", (int)CardStatus.Uploaded);
                object count = this.SqliteHelper.ExecuteScalar(CommandType.Text, CommandText);
                if (count != null)
                    return Convert.ToInt32(count);
            }
            catch (Exception e)
            {
                //log.Error("CountCard:" + e.ToString());

                LogManager.WriteLog(Framework.Libs.Common.LogFile.Error, "CountCard:" + e.ToString());

            }

            return ret;
        }

        /// <summary>
        /// 将工作列表加载到对象
        /// </summary>
        /// <returns></returns>
        //public WorkTimeExtent GetWorkTimeExtent()
        //{
        //    WorkTimeExtent wte = null;
        //    try
        //    {
        //        string CommandText = "select FromTime,ToTime from  WorkTimeList where Flag=1";
        //        DataSet ds = this.SqliteHelper.ExecuteDataSet(CommandType.Text, CommandText);
        //        if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
        //        {
        //            wte = new WorkTimeExtent();
        //            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
        //            {
        //                long k = Convert.ToInt64(ds.Tables[0].Rows[i]["FromTime"]);
        //                long v = Convert.ToInt64(ds.Tables[0].Rows[i]["ToTime"]);
        //                wte.Add(k, v);
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        //log.Error("GetWorkTimeExtent:" + ex.StackTrace);
        //        LogManager.WriteLog(Framework.Libs.Common.LogFile.Error, "GetWorkTimeExtent:" + ex.StackTrace);
        //    }
        //    return wte;
        //}

        /// <summary>
        /// 更新参数表
        /// </summary>
        /// <param name="key">键(不操过200的字符串)</param>
        /// <param name="value">值(不操过200的字符串)</param>
        /// <returns></returns>
        public int UpdateParam(string key, object value)
        {
            try
            {
                string CommandText = "update [params]  set pvalue = @pvalue  where  pkey = @pkey";
                Parameters[] p = new Parameters[]{
                new Parameters( "@pkey", key, DbType.String),
                new Parameters( "@pvalue", value, DbType.Object)
            };
                return this.SqliteHelper.ExecuteNonQuery(CommandType.Text, CommandText, p);
            }
            catch (Exception e)
            {
                //log.ErrorFormat("UpdateParam:{0}", e.StackTrace);

                LogManager.WriteLog(Framework.Libs.Common.LogFile.Error, string.Format("UpdateParam:{0}", e.StackTrace));

            }
            return -1;
        }

        ///// <summary>
        ///// 获得参数最新更新时间(这个时间启动时加载到本地，
        ///// 一旦改变，要重新下载【工作时间表】和【部品超时表】到本地)
        ///// </summary>
        ///// <param name="deviceNo">设备编号</param>
        ///// <returns>返回NULL，获取失败，不更新参数</returns>
        //public DateTime? GetParamUpdateTime(string deviceNo)
        //{
        //    try
        //    {
        //        string CommandText = "select TrmnParamUpdTime from M_TerminalSetting where TerminalNo=@TerminalNo";
        //        Parameters[] p = new Parameters[]{
        //        new Parameters("@TerminalNo", deviceNo, DbType.String)
        //        };

        //           object dt = this.SqlSrvHelper.ExecuteScalar(CommandType.Text, CommandText, p);
        //        if (dt != null)
        //            return Convert.ToDateTime(dt);
        //    }
        //    catch (Exception ex)
        //    {
        //        //log.Error("GetParamUpdateTime:" + ex.StackTrace);
        //        LogManager.WriteLog(Framework.Libs.Common.LogFile.Error, "GetParamUpdateTime:"+ ex.StackTrace);

        //    }
        //    return null;
        //}

        /// <summary>
        /// 更新工作时间到本地
        /// </summary>
        /// <param name="dt">参数最新更新时间</param>
        public bool FectchWorkTime(DateTime dt, DataTable tblSysWork)
        {
            bool ok = false;
            try
            {
                string CommandText;

                if (tblSysWork != null && tblSysWork.Rows.Count > 0)
                {
                    for (int i = 0; i < tblSysWork.Rows.Count; i++)
                    {
                        CommandText = "insert into WorkTimeList(ID,LatestTime,FromTime,ToTime,Flag) values(@ID,@LatestTime,@FromTime,@ToTime,0)"; 
                        Parameters[] p = new Parameters[]{
                        new Parameters( "@ID", System.Guid.NewGuid().ToString().Replace("-", ""), DbType.String),
                        new Parameters( "@LatestTime", dt.Ticks, DbType.Int64),
                        new Parameters( "@FromTime", Convert.ToDateTime(tblSysWork.Rows[i]["AMTimeStart"]).Ticks, DbType.Int64),
                        new Parameters( "@ToTime", Convert.ToDateTime(tblSysWork.Rows[i]["AMTimeOver"]).Ticks, DbType.Int64)
                        };
                        this.SqliteHelper.ExecuteNonQuery(CommandType.Text, CommandText, p);
                    }

                    CommandText = "update WorkTimeList set Flag=Flag+1 where 1=1";
                    this.SqliteHelper.ExecuteNonQuery(CommandType.Text, CommandText);
                    ok = true;
                }
            }
            catch (Exception ex)
            {
                //log.Error("FectchWorkTime:" + ex.StackTrace);
                 LogManager.WriteLog(Framework.Libs.Common.LogFile.Error, "FectchWorkTime:" + ex.StackTrace);
            }
            finally
            {
                try
                {
                    string CommandText = "delete from WorkTimeList where Flag <> 1";
                    this.SqliteHelper.ExecuteNonQuery(CommandType.Text, CommandText);
                }
                catch (Exception) 
                {

                }
            }
            return ok;
        }

        #region IDisposable Members

        public void Dispose()
        {
            this.close();
        }

        #endregion
    }


}
