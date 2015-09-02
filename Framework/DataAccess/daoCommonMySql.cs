using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using Framework.DataAccess;
using Framework.Libs;
using MySql.Data.MySqlClient;
using System;

namespace Framework.DataAccess
{
    public class daoCommonMySql : CBaseConnect
    {

        #region 初始化处理

        #region 变量定义
        //private static readonly log4net.ILog Log = log4net.LogManager.GetLogger(typeof(daoCommonMySql));
        #endregion

        #endregion

        #region 数据业务操作

        #region 数据查询部分

        #region 查询表数据【BySql】

        ///==============================================///
        ///============GetTableInfo（BySql）============///
        ///==============================================///

        /// <summary>
        /// 读取表格信息数据
        /// </summary>
        /// <param name="TableName">数据表名称</param>
        /// <param name="dicItemData">检索条件值</param>
        /// <param name="dicConds">精确查询列名</param>
        /// <param name="dicLikeConds">模糊查询列名</param>
        /// <param name="OrderBy">需要排序的列</param> 
        /// <param name="readUncommitted">允许读未提交查询</param>
        /// <returns></returns>
        public DataTable GetTableInfo(string TableName,
                                StringDictionary dicItemData,
                                StringDictionary dicConds,
                                StringDictionary dicLikeConds,
                                string OrderBy,
                                bool readUncommitted)
        {
            int rowIndex = 0;
            DataTable w_RtnDataTable = null;
            MySqlParameter[] cmdParamters = null;
            MySqlParameter MySqlParameter = null;
            try
            {

                string strSql = (readUncommitted ? "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;" : "")
                       + " SELECT  " + TableName + ".* "
                       + " FROM " + TableName
                       + " WHERE 1=1 ";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new MySqlParameter[dicConds.Count + dicLikeConds.Count];


                foreach (string strKey in dicConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true)
                    {
                        strSql += " AND " + strKey + " =?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);

                        if (MySqlParameter.MySqlDbType == MySqlDbType.Bit)
                        {
                            MySqlParameter.Value = Common.GetBitValue(dicItemData[strKey]);
                        }
                        else
                        {
                            MySqlParameter.Value = dicItemData[strKey];
                        }

                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }

                foreach (string strKey in dicLikeConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true
                        && string.IsNullOrEmpty(dicItemData[strKey]) == false)
                    {
                        strSql += " AND " + strKey + " Like ?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);
                        MySqlParameter.Value = "%" + dicItemData[strKey] + "%";
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }

                if (!string.IsNullOrEmpty(OrderBy))
                {
                    strSql += " ORDER BY " + OrderBy;
                }

                w_RtnDataTable = Common.AdoConnect.Connect.GetDataSet(strSql, cmdParamters);

                return w_RtnDataTable;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 读取表格信息数据
        /// </summary>
        /// <param name="TableName">Sql语句</param>
        /// <param name="dicItemData">检索条件值</param>
        /// <param name="dicConds">精确查询列名</param>
        /// <param name="dicLikeConds">模糊查询列名</param>
        /// <param name="OrderBy">需要排序的列</param>
        /// <param name="readUncommitted">允许读未提交查询</param>
        /// <returns></returns>
        public DataTable GetTableInfoBySql(string Sql,
                                    StringDictionary dicItemData,
                                    StringDictionary dicConds,
                                    StringDictionary dicLikeConds,
                                    string OrderBy,
                                    bool readUncommitted)
        {
            int rowIndex = 0;
            DataTable w_RtnDataTable = null;
            MySqlParameter[] cmdParamters = null;
            MySqlParameter MySqlParameter = null;
            try
            {
                string strSql = (readUncommitted ? "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;" : "")
                            + Sql
                            + " WHERE 1=1 ";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new MySqlParameter[dicConds.Count + dicLikeConds.Count];


                foreach (string strKey in dicConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true)
                    {
                        strSql += " AND " + strKey + " =?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);

                        if (MySqlParameter.MySqlDbType == MySqlDbType.Bit)
                        {
                            MySqlParameter.Value = Common.GetBitValue(dicItemData[strKey]);
                        }
                        else
                        {
                            MySqlParameter.Value = dicItemData[strKey];
                        }

                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }

                foreach (string strKey in dicLikeConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true
                        && string.IsNullOrEmpty(dicItemData[strKey]) == false)
                    {
                        strSql += " AND " + strKey + " Like ?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);
                        MySqlParameter.Value = "%" + dicItemData[strKey] + "%";
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }


                if (!string.IsNullOrEmpty(OrderBy))
                {
                    strSql += " ORDER BY " + OrderBy;
                }

                w_RtnDataTable = Common.AdoConnect.Connect.GetDataSet(strSql, cmdParamters);

                return w_RtnDataTable;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }




        /// <summary>
        /// 读取表格信息数据
        /// </summary>
        /// <param name="TableName">数据表名称</param>
        /// <param name="dicItemData">检索条件值</param>
        /// <param name="dicConds">精确查询列名</param>
        /// <param name="dicBetweenConds">时间段查询列名</param>
        /// <param name="dicLikeConds">模糊查询列名</param>
        /// <param name="OrderBy">需要排序的列</param>
        /// <returns></returns>
        public DataTable GetTableInfo(string TableName,
                                StringDictionary dicItemData,
                                StringDictionary dicConds,
                                StringDictionary dicBetweenConds,
                                StringDictionary dicLikeConds,
                                string OrderBy,
                                bool readUncommitted)
        {
            int rowIndex = 0;
            DataTable w_RtnDataTable = null;
            MySqlParameter[] cmdParamters = null;
            MySqlParameter MySqlParameter = null;
            try
            {

                string strSql = (readUncommitted ? "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;" : "") + " SELECT  false AS SlctValue," + TableName + ".* "
                             + " FROM " + TableName
                             + " WHERE 1=1 ";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new MySqlParameter[dicConds.Count + dicLikeConds.Count + dicBetweenConds.Count * 2];


                foreach (string strKey in dicConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true)
                    {
                        strSql += " AND " + strKey + " =?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);

                        if (MySqlParameter.MySqlDbType == MySqlDbType.Bit)
                        {
                            MySqlParameter.Value = Common.GetBitValue(dicItemData[strKey]);
                        }
                        else
                        {
                            MySqlParameter.Value = dicItemData[strKey];
                        }

                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }


                foreach (string strKey in dicBetweenConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey + Common.DefineValue.FiledBegin) == true
                        && dicItemData.ContainsKey(strKey + Common.DefineValue.FiledEnd) == true)
                    {
                        strSql += " AND " + strKey + "  between  ?" + strKey + Common.DefineValue.FiledBegin;
                        strSql += " AND ?" + strKey + Common.DefineValue.FiledEnd;

                        MySqlParameter = new MySqlParameter("?" + strKey + Common.DefineValue.FiledBegin, Common._dicFiledTypeMySql[strKey]);
                        MySqlParameter.Value = Common.GetBeginTimeBySql(dicItemData[strKey + Common.DefineValue.FiledBegin]);
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;


                        MySqlParameter = new MySqlParameter("?" + strKey + Common.DefineValue.FiledEnd, Common._dicFiledTypeMySql[strKey]);
                        //获取结束时间处理
                        MySqlParameter.Value = Common.GetEndTimeBySql(dicItemData[strKey + Common.DefineValue.FiledEnd]);
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }


                foreach (string strKey in dicLikeConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true
                        && string.IsNullOrEmpty(dicItemData[strKey]) == false)
                    {
                        strSql += " AND " + strKey + " Like ?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);
                        MySqlParameter.Value = "%" + dicItemData[strKey] + "%";
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }


                if (!string.IsNullOrEmpty(OrderBy))
                {
                    strSql += " ORDER BY " + OrderBy;
                }

                w_RtnDataTable = Common.AdoConnect.Connect.GetDataSet(strSql, cmdParamters);

                return w_RtnDataTable;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 读取表格信息数据
        /// </summary>
        /// <param name="TableName">Sql语句</param>
        /// <param name="dicItemData">检索条件值</param>
        /// <param name="dicConds">精确查询列名</param>
        /// <param name="dicBetweenConds">时间段查询列名</param>
        /// <param name="dicLikeConds">模糊查询列名</param>
        /// <param name="OrderBy">需要排序的列</param>
        /// <returns></returns>
        public DataTable GetTableInfoBySql(string Sql,
                                StringDictionary dicItemData,
                                StringDictionary dicConds,
                                StringDictionary dicBetweenConds,
                                StringDictionary dicLikeConds,
                                string OrderBy,
                                bool readUncommitted)
        {
            int rowIndex = 0;
            DataTable w_RtnDataTable = null;
            MySqlParameter[] cmdParamters = null;
            MySqlParameter MySqlParameter = null;

            try
            {

                string strSql = (readUncommitted ? "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;" : "")
                            + Sql
                            + " WHERE 1=1 ";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new MySqlParameter[dicConds.Count + dicLikeConds.Count + dicBetweenConds.Count * 2];


                foreach (string strKey in dicConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true)
                    {
                        strSql += " AND " + strKey + " =?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);

                        if (MySqlParameter.MySqlDbType == MySqlDbType.Bit)
                        {
                            MySqlParameter.Value = Common.GetBitValue(dicItemData[strKey]);
                        }
                        else
                        {
                            MySqlParameter.Value = dicItemData[strKey];
                        }

                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }


                foreach (string strKey in dicBetweenConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey + Common.DefineValue.FiledBegin) == true
                        && dicItemData.ContainsKey(strKey + Common.DefineValue.FiledEnd) == true)
                    {
                        strSql += " AND " + strKey + "  between  ?" + strKey + Common.DefineValue.FiledBegin;
                        strSql += " AND ?" + strKey + Common.DefineValue.FiledEnd;

                        MySqlParameter = new MySqlParameter("?" + strKey + Common.DefineValue.FiledBegin, Common._dicFiledTypeMySql[strKey]);
                        MySqlParameter.Value = Common.GetBeginTimeBySql(dicItemData[strKey + Common.DefineValue.FiledBegin]);
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;


                        MySqlParameter = new MySqlParameter("?" + strKey + Common.DefineValue.FiledEnd, Common._dicFiledTypeMySql[strKey]);
                        //获取结束时间处理
                        MySqlParameter.Value = Common.GetEndTimeBySql(dicItemData[strKey + Common.DefineValue.FiledEnd]);
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }


                foreach (string strKey in dicLikeConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true
                        && string.IsNullOrEmpty(dicItemData[strKey]) == false)
                    {
                        strSql += " AND " + strKey + " Like ?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);
                        MySqlParameter.Value = "%" + dicItemData[strKey] + "%";
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }


                if (!string.IsNullOrEmpty(OrderBy))
                {
                    strSql += " ORDER BY " + OrderBy;
                }

                w_RtnDataTable = Common.AdoConnect.Connect.GetDataSet(strSql, cmdParamters);

                return w_RtnDataTable;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 查询不含Where表数据

        ///==============================================///
        ///===========GetTableInfoBySqlNoWhere===========///
        ///==============================================///

        /// <summary>
        /// 读取表格信息数据
        /// </summary>
        /// <param name="TableName">Sql语句</param>
        /// <param name="dicItemData">检索条件值</param>
        /// <param name="dicConds">精确查询列名</param>
        /// <param name="dicLikeConds">模糊查询列名</param>
        /// <param name="OrderBy">需要排序的列</param>
        /// <param name="readUncommitted">允许读未提交查询</param>
        /// <returns></returns>
        public DataTable GetTableInfoBySqlNoWhere(string Sql,
                                   StringDictionary dicItemData,
                                   StringDictionary dicConds,
                                   StringDictionary dicLikeConds,
                                   string OrderBy,
                                   bool readUncommitted)
        {
            int rowIndex = 0;
            DataTable w_RtnDataTable = null;
            MySqlParameter[] cmdParamters = null;
            MySqlParameter MySqlParameter = null;
            try
            {

                string strSql = (readUncommitted ? "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;" : "")
                               + Sql;

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new MySqlParameter[dicConds.Count + dicLikeConds.Count];


                foreach (string strKey in dicConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true)
                    {
                        strSql += " AND " + strKey + " =?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);

                        if (MySqlParameter.MySqlDbType == MySqlDbType.Bit)
                        {
                            MySqlParameter.Value = Common.GetBitValue(dicItemData[strKey]);
                        }
                        else
                        {
                            MySqlParameter.Value = dicItemData[strKey];
                        }

                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }

                foreach (string strKey in dicLikeConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true
                        && string.IsNullOrEmpty(dicItemData[strKey]) == false)
                    {
                        strSql += " AND " + strKey + " Like ?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);
                        MySqlParameter.Value = "%" + dicItemData[strKey] + "%";
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }


                if (!string.IsNullOrEmpty(OrderBy))
                {
                    strSql += " ORDER BY " + OrderBy;
                }

                w_RtnDataTable = Common.AdoConnect.Connect.GetDataSet(strSql, cmdParamters);

                return w_RtnDataTable;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 读取表格信息数据
        /// </summary>
        /// <param name="TableName">Sql语句</param>
        /// <param name="dicItemData">检索条件值</param>
        /// <param name="dicConds">精确查询列名</param>
        /// <param name="dicBetweenConds">时间段查询列名</param>
        /// <param name="dicLikeConds">模糊查询列名</param>
        /// <param name="OrderBy">需要排序的列</param>
        /// <param name="readUncommitted">允许读未提交查询</param>
        /// <returns></returns>
        public DataTable GetTableInfoBySqlNoWhere(string Sql,
                                    StringDictionary dicItemData,
                                    StringDictionary dicConds,
                                    StringDictionary dicBetweenConds,
                                    StringDictionary dicLikeConds,
                                    string OrderBy,
                                    bool readUncommitted)
        {
            int rowIndex = 0;
            DataTable w_RtnDataTable = null;
            MySqlParameter[] cmdParamters = null;
            MySqlParameter MySqlParameter = null;
            try
            {
                string strSql = (readUncommitted ? "SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;" : "")
                                   + Sql;

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new MySqlParameter[dicConds.Count + dicLikeConds.Count + dicBetweenConds.Count * 2];


                foreach (string strKey in dicConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true)
                    {
                        strSql += " AND " + strKey + " =?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);

                        if (MySqlParameter.MySqlDbType == MySqlDbType.Bit)
                        {
                            MySqlParameter.Value = Common.GetBitValue(dicItemData[strKey]);
                        }
                        else
                        {
                            MySqlParameter.Value = dicItemData[strKey];
                        }

                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }


                foreach (string strKey in dicBetweenConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey + Common.DefineValue.FiledBegin) == true
                        && dicItemData.ContainsKey(strKey + Common.DefineValue.FiledEnd) == true)
                    {
                        strSql += " AND " + strKey + "  between  ?" + strKey + Common.DefineValue.FiledBegin;
                        strSql += " AND ?" + strKey + Common.DefineValue.FiledEnd;

                        MySqlParameter = new MySqlParameter("?" + strKey + Common.DefineValue.FiledBegin, Common._dicFiledTypeMySql[strKey]);
                        MySqlParameter.Value = Common.GetBeginTimeBySql(dicItemData[strKey + Common.DefineValue.FiledBegin]);
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;


                        MySqlParameter = new MySqlParameter("?" + strKey + Common.DefineValue.FiledEnd, Common._dicFiledTypeMySql[strKey]);
                        //获取结束时间处理
                        MySqlParameter.Value = Common.GetEndTimeBySql(dicItemData[strKey + Common.DefineValue.FiledEnd]);
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }

                foreach (string strKey in dicLikeConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true
                        && string.IsNullOrEmpty(dicItemData[strKey]) == false)
                    {
                        strSql += " AND " + strKey + " Like ?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);
                        MySqlParameter.Value = "%" + dicItemData[strKey] + "%";
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }


                if (!string.IsNullOrEmpty(OrderBy))
                {
                    strSql += " ORDER BY " + OrderBy;
                }

                w_RtnDataTable = Common.AdoConnect.Connect.GetDataSet(strSql, cmdParamters);

                return w_RtnDataTable;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        #endregion

        #region 数据检查查询(重复检查)

        /// <summary>
        /// 数据重名检查(主键重复)
        /// </summary>
        /// <param name="TableName">数据表名称</param>
        /// <param name="dicItemData">数据内容</param>
        /// <param name="dicPrimarName">主键列名</param>
        /// <param name="strRepFiledName">重名检测列名</param>
        /// <param name="ScanMode">画面模式</param>
        /// <returns></returns>
        public bool GetRepNameCheck(string TableName,
                                StringDictionary dicItemData,
                                StringDictionary dicPrimarName,
                                string strRepFiledName,
                                Common.DataModifyMode ScanMode)
        {
            bool IsExist = false;
            DataTable dt = new DataTable();
            int rowIndex = 0;
            MySqlParameter[] cmdParamters = null;
            MySqlParameter MySqlParameter = null;

            string w_strWhere = "";
            strRepFiledName = strRepFiledName.ToLower();

            try
            {
                if (dicItemData == null || dicItemData.Count <= 0
                    || dicPrimarName == null || dicPrimarName.Count <= 0
                    || string.IsNullOrEmpty(strRepFiledName) == true) return false;

                string strSql = "SELECT  false AS SlctValue," + TableName + ".* "
                             + " FROM " + TableName
                             + " WHERE 1=1 ";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new MySqlParameter[dicPrimarName.Count + 1];

                foreach (string strKey in dicPrimarName.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true && ScanMode == Common.DataModifyMode.upd)
                    {
                        w_strWhere += " AND " + strKey + "<>?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);
                        MySqlParameter.Value = dicItemData[strKey];
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }


                if (dicItemData.ContainsKey(strRepFiledName) == true)
                {
                    w_strWhere += " AND " + strRepFiledName + "=?" + strRepFiledName;

                    MySqlParameter = new MySqlParameter("?" + strRepFiledName, Common._dicFiledTypeMySql[strRepFiledName]);
                    MySqlParameter.Value = dicItemData[strRepFiledName];
                    MySqlParameter.Direction = ParameterDirection.Input;
                    cmdParamters[rowIndex] = MySqlParameter;
                }

                strSql += w_strWhere;

                dt = Common.AdoConnect.Connect.GetDataSet(strSql, cmdParamters);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                        IsExist = true;
                }
                return IsExist;


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 数据存在检查(主键重复)
        /// </summary>
        /// <param name="TableName">数据表名称</param>
        /// <param name="dicItemData">数据内容</param>
        /// <param name="dicPrimarName">主键列名</param>
        /// <returns></returns>
        public bool GetExistDataItem(string TableName,
                                StringDictionary dicItemData,
                                StringDictionary dicPrimarName)
        {
            bool IsExist = false;
            DataTable dt = new DataTable();
            int rowIndex = 0;
            MySqlParameter[] cmdParamters = null;
            MySqlParameter MySqlParameter = null;

            string w_strWhere = "";

            try
            {
                if (dicItemData == null || dicItemData.Count <= 0
                    || dicPrimarName == null || dicPrimarName.Count <= 0) return false;


                string strSql = "SELECT  false AS SlctValue," + TableName + ".* "
                             + " FROM " + TableName
                             + " WHERE 1=1 ";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new MySqlParameter[dicPrimarName.Count];

                foreach (string strKey in dicPrimarName.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true)
                    {

                        w_strWhere += " AND " + strKey + "=?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);
                        MySqlParameter.Value = dicItemData[strKey];
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }

                strSql += w_strWhere;

                dt = Common.AdoConnect.Connect.GetDataSet(strSql, cmdParamters);
                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                        IsExist = true;
                }
                return IsExist;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 获取最大编号
        /// </summary>
        /// <param name="TableName">数据表名称</param>
        /// <param name="FiledName">最大值列名</param>
        /// <returns></returns>
        public string GetMaxNoteNo(string TableName, string FiledName)
        {
            int iniItem = 1000000;
            DataTable dt = new DataTable();
            int MaxNo = 1;

            try
            {
                if (string.IsNullOrEmpty(TableName) || string.IsNullOrEmpty(FiledName)) return "";
                string strSql = "SELECT ISNULL(MAX( CONVERT(INT," + FiledName + ")), 1) AS MaxNo "
                             + " FROM " + TableName;

                Common.AdoConnect.Connect.ConnectOpen();

                dt = Common.AdoConnect.Connect.GetDataSet(strSql);

                if (dt != null)
                {
                    if (dt.Rows.Count > 0)
                    {
                        //if (int.TryParse(dt.Rows[0]["MaxNo"].ToString(), out MaxNo) == true)
                        //{

                        //}

                        MaxNo = int.Parse(dt.Rows[0]["MaxNo"].ToString());
                    }
                }

                MaxNo = iniItem + MaxNo + 1;

                return MaxNo.ToString().Substring(1, iniItem.ToString().Length - 1);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #region 下拉框控件绑定设置


        #endregion

        #endregion

        #region 数据新增部分

        /// <summary>
        /// 新增基本信息数据
        /// </summary>
        /// <param name="TableName">数据表名称</param>
        /// <param name="dicItemData">数据内容</param>
        /// <param name="dicUserColum">操作员信息列名</param>
        /// <returns></returns>
        public int SetInsertDataItem(string TableName,
                            StringDictionary dicItemData,
                            StringDictionary dicUserColum)
        {

            int rowIndex = 0;
            int w_RtnCnt = 0;
            MySqlParameter[] cmdParamters = null;
            MySqlParameter MySqlParameter = null;

            string w_strFileds = "";
            string w_strValues = "";

            try
            {
                if (dicItemData == null || dicItemData.Count <= 0) return w_RtnCnt;

                string strSql = "INSERT INTO " + TableName + " ( ";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new MySqlParameter[dicItemData.Count + dicUserColum.Count + dicUserColum.Count];

                foreach (string strKey in dicItemData.Keys)
                {
                    w_strFileds += "," + strKey;
                    w_strValues += ", ?" + strKey;

                    MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);
                    MySqlParameter.Value = dicItemData[strKey];
                    MySqlParameter.Direction = ParameterDirection.Input;
                    cmdParamters[rowIndex] = MySqlParameter;
                    rowIndex++;
                }

                foreach (string strKey in dicUserColum.Keys)
                {
                    if (strKey.Equals(Common.UserColum.AddDateTime) == true || strKey.Equals(Common.UserColum.UpdDateTime) == true)
                    {
                        w_strFileds += "," + strKey;
                        w_strValues += ", NOW() ";


                    }
                    else if (strKey.Equals(Common.UserColum.AddUserNo) == true || strKey.Equals(Common.UserColum.UpdUserNo) == true)
                    {
                        w_strFileds += "," + strKey;
                        w_strValues += ", ?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);
                        MySqlParameter.Value = Common._personid;
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }

                strSql += w_strFileds.Substring(1) + " )  VALUES (";
                strSql += w_strValues.Substring(1) + " )";

                w_RtnCnt = Common.AdoConnect.Connect.ExecuteNonQuery(strSql, cmdParamters);

                return w_RtnCnt;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 新增基本信息数据
        /// </summary>
        /// <param name="TableName">数据表名称</param>
        /// <param name="dicItemFiledNm">数据字段名称</param>
        /// <param name="dicItemData">数据内容</param>
        /// <param name="dicUserColum">操作员信息列名</param>
        /// <returns></returns>
        public int SetInsertDataItem(string TableName,
                                StringDictionary dicItemFiledNm,
                                StringDictionary dicItemData,
                                StringDictionary dicUserColum)
        {
            int rowIndex = 0;
            int w_RtnCnt = 0;
            MySqlParameter[] cmdParamters = null;
            MySqlParameter MySqlParameter = null;

            string w_strFileds = "";
            string w_strValues = "";

            try
            {
                if (dicItemData == null || dicItemData.Count <= 0) return w_RtnCnt;

                string strSql = "INSERT INTO " + TableName + " ( ";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new MySqlParameter[dicItemData.Count + dicUserColum.Count + dicUserColum.Count];

                foreach (string strKey in dicItemFiledNm.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true)
                    {
                        w_strFileds += "," + strKey;
                        w_strValues += ", ?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);
                        MySqlParameter.Value = dicItemData[strKey];
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }

                foreach (string strKey in dicUserColum.Keys)
                {
                    if (strKey.Equals(Common.UserColum.AddDateTime) == true || strKey.Equals(Common.UserColum.UpdDateTime) == true)
                    {
                        w_strFileds += "," + strKey;
                        w_strValues += ", NOW() ";


                    }
                    else if (strKey.Equals(Common.UserColum.AddUserNo) == true || strKey.Equals(Common.UserColum.UpdUserNo) == true)
                    {
                        w_strFileds += "," + strKey;
                        w_strValues += ", ?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);
                        MySqlParameter.Value = Common._personid;
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }

                strSql += w_strFileds.Substring(1) + " )  VALUES (";
                strSql += w_strValues.Substring(1) + " )";

                w_RtnCnt = Common.AdoConnect.Connect.ExecuteNonQuery(strSql, cmdParamters);

                return w_RtnCnt;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 记录日志信息
        /// </summary>
        /// <param name="FrmName">画面名称</param>
        /// <param name="OperateTyp">操作类型</param>
        /// <param name="OperateContent">记录内容</param>
        public void WriteLog(string FrmName, int OperateTyp, string OperateContent)
        {

            StringDictionary w_dicconds = new StringDictionary();
            w_dicconds[M_FuncForm.FormId] = "true";

            StringDictionary w_dataItem = new StringDictionary();
            w_dataItem[M_FuncForm.FormId] = FrmName;


            StringDictionary w_dicUserColum = new StringDictionary();
            w_dicUserColum[Common.UserColum.AddDateTime] = "true";
            w_dicUserColum[Common.UserColum.AddUserNo] = "true";

            string FunctionId = "";
            try
            {
                //取功能分类
                DataTable dt = this.GetTableInfo(M_FuncForm.TableName, w_dataItem, w_dicconds, new StringDictionary(), "", false);
                if (dt != null && dt.Rows.Count > 0)
                {
                    FunctionId = dt.Rows[0][M_FuncForm.FunctionTyp].ToString();
                }
                w_dataItem[T_LogRecord.FunctionId] = FunctionId;
                w_dataItem[T_LogRecord.RecordId] = Common.GetGuid();
                w_dataItem[T_LogRecord.OperateTyp] = OperateTyp.ToString();
                w_dataItem[T_LogRecord.Remark] = OperateContent;

                this.SetInsertDataItem(T_LogRecord.TableName, w_dataItem, w_dicUserColum);
            }
            catch (Exception ex)
            {

                //Log.Error(ex);
            }
        }

        #endregion

        #region 数据修改部分

        /// <summary>
        /// 修改基本信息数据
        /// </summary>
        /// <param name="TableName">数据表名称</param>
        /// <param name="dicItemData">数据内容</param>
        /// <param name="dicPrimarName">主键列名</param>
        /// <param name="dicUserColum">操作员信息列名</param>
        /// <returns></returns>
        public int SetModifyDataItem(string TableName,
                            StringDictionary dicItemData,
                            StringDictionary dicPrimarName,
                            StringDictionary dicUserColum)
        {
            int rowIndex = 0;
            int w_RtnCnt = 0;
            MySqlParameter[] cmdParamters = null;
            MySqlParameter MySqlParameter = null;

            string w_strSetValues = "";
            string w_strWhere = "";

            try
            {
                if (dicItemData == null || dicItemData.Count <= 0 || dicPrimarName == null) return w_RtnCnt;

                string strSql = "UPDATE " + TableName + " Set ";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new MySqlParameter[dicItemData.Count + dicUserColum.Count];

                foreach (string strKey in dicItemData.Keys)
                {
                    if (dicPrimarName.ContainsKey(strKey) != true)
                    {
                        w_strSetValues += "," + strKey + "=?" + strKey;
                    }

                    MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);

                    if (MySqlParameter.MySqlDbType == MySqlDbType.Bit)
                    {
                        MySqlParameter.Value = Common.GetBitValue(dicItemData[strKey]);
                    }
                    else
                    {
                        MySqlParameter.Value = dicItemData[strKey];
                    }

                    MySqlParameter.Direction = ParameterDirection.Input;
                    cmdParamters[rowIndex] = MySqlParameter;
                    rowIndex++;
                }


                foreach (string strKey in dicUserColum.Keys)
                {
                    if (strKey.Equals(Common.UserColum.UpdDateTime) == true)
                    {
                        w_strSetValues += "," + strKey + "=NOW() ";

                    }
                    else if (strKey.Equals(Common.UserColum.UpdUserNo) == true)
                    {
                        w_strSetValues += "," + strKey + "=?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);
                        MySqlParameter.Value = Common._personid;
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }

                strSql += w_strSetValues.Substring(1) + " WHERE 1=1";

                foreach (string strKey in dicPrimarName.Keys)
                {
                    w_strWhere += " AND " + strKey + "=?" + strKey;
                }

                strSql += w_strWhere;

                w_RtnCnt = Common.AdoConnect.Connect.ExecuteNonQuery(strSql, cmdParamters);

                return w_RtnCnt;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        /// <summary>
        /// 修改基本信息数据
        /// </summary>
        /// <param name="Sql">SQL语句</param>
        /// <param name="dicItemData">数据内容</param>
        /// <param name="dicPrimarName">主键列名</param>
        /// <param name="dicUserColum">操作员信息列名</param>
        /// <returns></returns>
        public int SetModifyDataItemBySql(string Sql,
                                 StringDictionary dicItemData,
                                 StringDictionary dicPrimarName,
                                 StringDictionary dicUserColum)
        {

            int rowIndex = 0;
            int w_RtnCnt = 0;
            MySqlParameter[] cmdParamters = null;
            MySqlParameter MySqlParameter = null;

            string w_strSetValues = "";
            string w_strWhere = "";

            try
            {
                if (dicItemData == null || dicPrimarName == null) return w_RtnCnt;

                string strSql = Sql;

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new MySqlParameter[dicItemData.Count + dicUserColum.Count];

                foreach (string strKey in dicItemData.Keys)
                {

                    MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);

                    if (MySqlParameter.MySqlDbType == MySqlDbType.Bit)
                    {
                        MySqlParameter.Value = Common.GetBitValue(dicItemData[strKey]);
                    }
                    else
                    {
                        MySqlParameter.Value = dicItemData[strKey];
                    }

                    MySqlParameter.Direction = ParameterDirection.Input;
                    cmdParamters[rowIndex] = MySqlParameter;
                    rowIndex++;
                }

                foreach (string strKey in dicUserColum.Keys)
                {
                    if (strKey.Equals(Common.UserColum.UpdDateTime) == true)
                    {
                        w_strSetValues += "," + strKey + "=NOW() ";

                    }
                    else if (strKey.Equals(Common.UserColum.UpdUserNo) == true)
                    {
                        w_strSetValues += "," + strKey + "=?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);
                        MySqlParameter.Value = Common._personid;
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }

                if (w_strSetValues.Length > 1)
                    strSql += w_strSetValues.Substring(1) + " WHERE 1=1";

                foreach (string strKey in dicPrimarName.Keys)
                {
                    w_strWhere += " AND " + strKey + "=?" + strKey;
                }

                strSql += w_strWhere;

                w_RtnCnt = Common.AdoConnect.Connect.ExecuteNonQuery(strSql, cmdParamters);

                return w_RtnCnt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 修改基本信息数据
        /// </summary>
        /// <param name="TableName">数据表名称</param>
        /// <param name="dicItemFiledNm">数据字段名称</param>
        /// <param name="dicItemData">数据内容</param>
        /// <param name="dicPrimarName">主键列名</param>
        /// <param name="dicUserColum">操作员信息列名</param>
        /// <returns></returns>
        public int SetModifyDataItem(string TableName,
                                StringDictionary dicItemFiledNm,
                                StringDictionary dicItemData,
                                StringDictionary dicPrimarName,
                                StringDictionary dicUserColum)
        {
            int rowIndex = 0;
            int w_RtnCnt = 0;
            MySqlParameter[] cmdParamters = null;
            MySqlParameter MySqlParameter = null;

            string w_strSetValues = "";
            string w_strWhere = "";

            try
            {
                if (dicItemData == null || dicItemData.Count <= 0 || dicPrimarName == null) return w_RtnCnt;

                string strSql = "UPDATE " + TableName + " Set ";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new MySqlParameter[dicItemData.Count + dicUserColum.Count];

                foreach (string strKey in dicItemFiledNm.Keys)
                {
                    if (dicPrimarName.ContainsKey(strKey) != true)
                    {
                        w_strSetValues += "," + strKey + "=?" + strKey;
                    }

                    if (dicItemData.ContainsKey(strKey) == true)
                    {
                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);

                        if (MySqlParameter.MySqlDbType == MySqlDbType.Bit)
                        {
                            MySqlParameter.Value = Common.GetBitValue(dicItemData[strKey]);
                        }
                        else
                        {
                            MySqlParameter.Value = dicItemData[strKey];
                        }

                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }

                foreach (string strKey in dicUserColum.Keys)
                {
                    if (strKey.Equals(Common.UserColum.UpdDateTime) == true)
                    {
                        w_strSetValues += "," + strKey + "=NOW() ";

                    }
                    else if (strKey.Equals(Common.UserColum.UpdUserNo) == true)
                    {
                        w_strSetValues += "," + strKey + "=?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);
                        MySqlParameter.Value = Common._personid;
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }

                strSql += w_strSetValues.Substring(1) + " WHERE 1=1";

                foreach (string strKey in dicPrimarName.Keys)
                {
                    w_strWhere += " AND " + strKey + "=?" + strKey;
                }

                strSql += w_strWhere;

                w_RtnCnt = Common.AdoConnect.Connect.ExecuteNonQuery(strSql, cmdParamters);

                return w_RtnCnt;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 数据删除部分

        /// <summary>
        /// 删除基本信息数据
        /// </summary>
        /// <param name="TableName">数据表名称</param>
        /// <param name="dicItemData">数据内容</param>
        /// <param name="dicPrimarName">主键列名</param>
        /// <returns></returns>
        public int SetDeleteDataItem(string TableName,
                                StringDictionary dicItemData,
                                StringDictionary dicPrimarName)
        {
            int rowIndex = 0;
            int w_RtnCnt = 0;
            MySqlParameter[] cmdParamters = null;
            MySqlParameter MySqlParameter = null;

            string w_strWhere = "";

            try
            {
                if (dicItemData == null || dicPrimarName == null) return w_RtnCnt;


                string strSql = "DELETE FROM " + TableName + " WHERE 1=1";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new MySqlParameter[dicPrimarName.Count];

                foreach (string strKey in dicPrimarName.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true)
                    {

                        w_strWhere += " AND " + strKey + "=?" + strKey;

                        MySqlParameter = new MySqlParameter("?" + strKey, Common._dicFiledTypeMySql[strKey]);
                        MySqlParameter.Value = dicItemData[strKey];
                        MySqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = MySqlParameter;
                        rowIndex++;
                    }
                }

                strSql += w_strWhere;

                w_RtnCnt = Common.AdoConnect.Connect.ExecuteNonQuery(strSql, cmdParamters);

                return w_RtnCnt;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion

        #endregion
      

        #region CBaseConnect 成员

        public string strConnectString
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public string strServerNm
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public string strDataBase
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public string strUserName
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public string strPassWord
        {
            get
            {
                throw new Exception("The method or operation is not implemented.");
            }
            set
            {
                throw new Exception("The method or operation is not implemented.");
            }
        }

        public void SetParameter()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public void SetParameter(string strServerNm, string strDataBaseNm, string strUserNm, string strPswd)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool ConnectOpen()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool ConnectClose()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool CreateSqlTransaction()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool TransactionRollback()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public bool TransactionCommit()
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DataTable GetDataSet(string SQLString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public DataTable GetDataSet(string SQLString, params object[] param)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public object GetFieldValue(string SQLString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Common.dbRecord GetRecord(string SQLString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Common.dbRecord GetRecord(string SQLString, params object[] param)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Common.View GetView(string SQLString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public Common.View GetView(string SQLString, params object[] param)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ExecuteNonQuery(string SQLString)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public int ExecuteNonQuery(string SQLString, params object[] param)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        public object SetExecuteSP(string StoreProcName, Common.Choose MyChoose, params object[] para)
        {
            throw new Exception("The method or operation is not implemented.");
        }

        #endregion
    }
}
