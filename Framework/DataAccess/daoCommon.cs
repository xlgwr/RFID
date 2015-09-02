using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using Framework.DataAccess;
using Framework.Libs;

namespace Framework.DataAccess
{
    public class daoCommon
    {

        #region 初始化处理

        #region 变量定义

        #endregion

        #endregion

        #region 数据查询部分

        #region 数据查询

        /// <summary>
        /// 读取表格信息数据
        /// </summary>
        /// <param name="TableName">数据表名称</param>
        /// <param name="dicItemData">检索条件值</param>
        /// <param name="dicConds">精确查询列名</param>
        /// <param name="dicLikeConds">模糊查询列名</param>
        /// <param name="OrderBy">需要排序的列</param>
        /// <returns></returns>
        public DataTable GetTableInfo(String TableName,
                                    StringDictionary dicItemData,
                                    StringDictionary dicConds,
                                    StringDictionary dicLikeConds,
                                    string OrderBy)
        {
            int rowIndex = 0;
            DataTable w_RtnDataTable = null;
            SqlParameter[] cmdParamters=null;
            SqlParameter SqlParameter = null;
            try
            {

                string strSql = "SELECT  CAST('0' AS Bit) AS SlctValue," + TableName + ".* "
                            + " FROM " + TableName
                            + " WHERE 1=1 ";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new SqlParameter[dicConds.Count + dicLikeConds.Count];


                foreach (string strKey in dicConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true)
                    {
                        strSql += " AND " + strKey + " =@" + strKey;

                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);

                        if (SqlParameter.SqlDbType == SqlDbType.Bit)
                        {
                            SqlParameter.Value = bool.Parse(dicItemData[strKey]);
                        }
                        else
                        {
                            SqlParameter.Value = dicItemData[strKey];
                        }

                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
                        rowIndex++;
                    }
                }

                foreach (string strKey in dicLikeConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true
                        && string.IsNullOrEmpty(dicItemData[strKey]) == false)
                    {
                        strSql += " AND " + strKey + " Like @" + strKey;

                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);
                        SqlParameter.Value = "%" + dicItemData[strKey] + "%";
                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
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
        /// <returns></returns>
        public DataTable GetTableInfoBySql(String Sql,
                                    StringDictionary dicItemData,
                                    StringDictionary dicConds,
                                    StringDictionary dicLikeConds,
                                    string OrderBy)
        {
            int rowIndex = 0;
            DataTable w_RtnDataTable = null;
            SqlParameter[] cmdParamters = null;
            SqlParameter SqlParameter = null;
            try
            {

                string strSql = Sql
                            + " WHERE 1=1 ";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new SqlParameter[dicConds.Count + dicLikeConds.Count];


                foreach (string strKey in dicConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true)
                    {
                        strSql += " AND " + strKey + " =@" + strKey;

                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);

                        if (SqlParameter.SqlDbType == SqlDbType.Bit)
                        {
                            SqlParameter.Value = bool.Parse(dicItemData[strKey]);
                        }
                        else
                        {
                            SqlParameter.Value = dicItemData[strKey];
                        }

                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
                        rowIndex++;
                    }
                }

                foreach (string strKey in dicLikeConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true
                        && string.IsNullOrEmpty(dicItemData[strKey]) == false)
                    {
                        strSql += " AND " + strKey + " Like @" + strKey;

                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);
                        SqlParameter.Value = "%" + dicItemData[strKey] + "%";
                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
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
        public DataTable GetTableInfo(String TableName,
                                    StringDictionary dicItemData,
                                    StringDictionary dicConds,
                                    StringDictionary dicBetweenConds,
                                    StringDictionary dicLikeConds,
                                    string OrderBy)
        {
            int rowIndex = 0;
            DataTable w_RtnDataTable = null;
            SqlParameter[] cmdParamters = null;
            SqlParameter SqlParameter = null;
            try
            {

                string strSql = "SELECT  CAST('0' AS Bit) AS SlctValue," + TableName + ".* "
                             + " FROM " + TableName
                             + " WHERE 1=1 ";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new SqlParameter[dicConds.Count + dicLikeConds.Count + dicBetweenConds.Count * 2];


                foreach (string strKey in dicConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true)
                    {
                        strSql += " AND " + strKey + " =@" + strKey;

                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);

                        if (SqlParameter.SqlDbType == SqlDbType.Bit)
                        {
                            SqlParameter.Value = bool.Parse(dicItemData[strKey]);
                        }
                        else
                        {
                            SqlParameter.Value = dicItemData[strKey];
                        }

                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
                        rowIndex++;
                    }
                }


                foreach (string strKey in dicBetweenConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey + Common.DefineValue.FiledBegin) == true
                        && dicItemData.ContainsKey(strKey + Common.DefineValue.FiledEnd) == true)
                    {
                        strSql += " AND " + strKey + " >=@" + strKey + Common.DefineValue.FiledBegin;
                        strSql += " AND " + strKey + " <=@" + strKey + Common.DefineValue.FiledEnd;

                        SqlParameter = new SqlParameter("@" + strKey + Common.DefineValue.FiledBegin, DataFiledType.FiledType[strKey]);
                        SqlParameter.Value = dicItemData[strKey + Common.DefineValue.FiledBegin];
                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
                        rowIndex++;


                        SqlParameter = new SqlParameter("@" + strKey + Common.DefineValue.FiledEnd, DataFiledType.FiledType[strKey]);
                        SqlParameter.Value = dicItemData[strKey + Common.DefineValue.FiledEnd];
                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
                        rowIndex++;
                    }
                }


                foreach (string strKey in dicLikeConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true
                        && string.IsNullOrEmpty(dicItemData[strKey]) == false)
                    {
                        strSql += " AND " + strKey + " Like @" + strKey;

                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);
                        SqlParameter.Value = "%" + dicItemData[strKey] + "%";
                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
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
        /// 获取最大编号
        /// </summary>
        /// <param name="TableName">数据表名称</param>
        /// <param name="FiledName">最大值列名</param>
        /// <returns></returns>
        public String GetMaxNoteNo(String TableName, String FiledName)
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

        /// <summary>
        /// 读取表格信息数据
        /// </summary>
        /// <param name="TableName">Sql语句</param>
        /// <param name="dicItemData">检索条件值</param>
        /// <param name="dicConds">精确查询列名</param>
        /// <returns></returns>
        public object GetFieldValueBySql(String strSql)
        {
            object w_ReturnValue = null ;

            try
            {
                                
                Common.AdoConnect.Connect.ConnectOpen();

                //返回某一个字段的值
                w_ReturnValue = Common.AdoConnect.Connect.GetFieldValue(strSql);

            }
            catch (Exception ex)
            {
                throw ex;
            }

            return w_ReturnValue;
        }

        #region 数据查询(不含Where)

        /// <summary>
        /// 读取表格信息数据
        /// </summary>
        /// <param name="TableName">Sql语句</param>
        /// <param name="dicItemData">检索条件值</param>
        /// <param name="dicConds">精确查询列名</param>
        /// <param name="dicLikeConds">模糊查询列名</param>
        /// <param name="OrderBy">需要排序的列</param>
        /// <returns></returns>
        public DataTable GetTableInfoBySqlNoWhere(String Sql,
                                    StringDictionary dicItemData,
                                    StringDictionary dicConds,
                                    StringDictionary dicLikeConds,
                                    string OrderBy)
        {
            int rowIndex = 0;
            DataTable w_RtnDataTable = null;
            SqlParameter[] cmdParamters = null;
            SqlParameter SqlParameter = null;
            try
            {

                string strSql = Sql;

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new SqlParameter[dicConds.Count + dicLikeConds.Count];


                foreach (string strKey in dicConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true)
                    {
                        strSql += " AND " + strKey + " =@" + strKey;

                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);

                        if (SqlParameter.SqlDbType == SqlDbType.Bit)
                        {
                            SqlParameter.Value = bool.Parse(dicItemData[strKey]);
                        }
                        else
                        {
                            SqlParameter.Value = dicItemData[strKey];
                        }

                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
                        rowIndex++;
                    }
                }

                foreach (string strKey in dicLikeConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true
                        && string.IsNullOrEmpty(dicItemData[strKey]) == false)
                    {
                        strSql += " AND " + strKey + " Like @" + strKey;

                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);
                        SqlParameter.Value = "%" + dicItemData[strKey] + "%";
                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
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
        public DataTable GetTableInfoBySqlNoWhere(String Sql,
                                    StringDictionary dicItemData,
                                    StringDictionary dicConds,
                                    StringDictionary dicBetweenConds,
                                    StringDictionary dicLikeConds,
                                    string OrderBy)
        {
            int rowIndex = 0;
            DataTable w_RtnDataTable = null;
            SqlParameter[] cmdParamters = null;
            SqlParameter SqlParameter = null;
            try
            {

                string strSql = Sql;

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new SqlParameter[dicConds.Count + dicLikeConds.Count + dicBetweenConds.Count *2 ];


                foreach (string strKey in dicConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true)
                    {
                        strSql += " AND " + strKey + " =@" + strKey;

                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);

                        if (SqlParameter.SqlDbType == SqlDbType.Bit)
                        {
                            SqlParameter.Value = bool.Parse(dicItemData[strKey]);
                        }
                        else
                        {
                            SqlParameter.Value = dicItemData[strKey];
                        }

                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
                        rowIndex++;
                    }
                }


                foreach (string strKey in dicBetweenConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey + Common.DefineValue.FiledBegin) == true
                        && dicItemData.ContainsKey(strKey + Common.DefineValue.FiledEnd) == true)
                    {
                        strSql += " AND " + strKey + " >=@" + strKey + Common.DefineValue.FiledBegin;
                        strSql += " AND " + strKey + " <=@" + strKey + Common.DefineValue.FiledEnd;

                        SqlParameter = new SqlParameter("@" + strKey + Common.DefineValue.FiledBegin, DataFiledType.FiledType[strKey]);
                        SqlParameter.Value = dicItemData[strKey + Common.DefineValue.FiledBegin];
                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
                        rowIndex++;


                        SqlParameter = new SqlParameter("@" + strKey + Common.DefineValue.FiledEnd, DataFiledType.FiledType[strKey]);
                        SqlParameter.Value = dicItemData[strKey + Common.DefineValue.FiledEnd];
                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
                        rowIndex++;
                    }
                }

                foreach (string strKey in dicLikeConds.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true
                        && string.IsNullOrEmpty(dicItemData[strKey]) == false)
                    {
                        strSql += " AND " + strKey + " Like @" + strKey;

                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);
                        SqlParameter.Value = "%" + dicItemData[strKey] + "%";
                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
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
        public bool GetRepNameCheck(String TableName,
                                     StringDictionary dicItemData,
                                     StringDictionary dicPrimarName,
                                     String strRepFiledName,
                                     Common.DataModifyMode ScanMode)
        {
            bool IsExist = false;
            DataTable dt = new DataTable();
            int rowIndex = 0;
            SqlParameter[] cmdParamters = null;
            SqlParameter SqlParameter = null;

            string w_strWhere = "";
            strRepFiledName = strRepFiledName.ToLower();

            try
            {
                if (dicItemData == null || dicItemData.Count <= 0
                    || dicPrimarName == null || dicPrimarName.Count <= 0
                    || string.IsNullOrEmpty(strRepFiledName) == true) return false;

                string strSql = "SELECT  CAST('0' AS Bit) AS SlctValue," + TableName + ".* "
                             + " FROM " + TableName
                             + " WHERE 1=1 ";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new SqlParameter[dicPrimarName.Count + 1];

                foreach (string strKey in dicPrimarName.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true && ScanMode == Common.DataModifyMode.upd)
                    {
                        w_strWhere += " AND " + strKey + "<>@" + strKey;

                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);
                        SqlParameter.Value = dicItemData[strKey];
                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
                        rowIndex++;
                    }
                }


               if (dicItemData.ContainsKey(strRepFiledName) == true)
                {
                    w_strWhere += " AND " + strRepFiledName + "=@" + strRepFiledName;

                    SqlParameter = new SqlParameter("@" + strRepFiledName, DataFiledType.FiledType[strRepFiledName]);
                    SqlParameter.Value = dicItemData[strRepFiledName];
                    SqlParameter.Direction = ParameterDirection.Input;
                    cmdParamters[rowIndex] = SqlParameter;
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
        public bool  GetExistDataItem(String TableName,
                                     StringDictionary dicItemData,
                                     StringDictionary dicPrimarName)
        {

            bool IsExist = false;
            DataTable dt = new DataTable();
            int rowIndex = 0;
            SqlParameter[] cmdParamters = null;
            SqlParameter SqlParameter = null;

            string w_strWhere = "";

            try
            {
                if (dicItemData == null || dicItemData.Count <= 0
                    || dicPrimarName == null || dicPrimarName.Count <= 0) return false ;


                string strSql = "SELECT  CAST('0' AS Bit) AS SlctValue," + TableName + ".* "
                             + " FROM " + TableName
                             + " WHERE 1=1 ";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new SqlParameter[dicPrimarName.Count];

                foreach (string strKey in dicPrimarName.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true)
                    {

                        w_strWhere += " AND " + strKey + "=@" + strKey;

                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);
                        SqlParameter.Value = dicItemData[strKey];
                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
                        rowIndex++;
                    }
                }

                strSql += w_strWhere;

                dt = Common.AdoConnect.Connect.GetDataSet(strSql, cmdParamters);
                if (dt != null)
                {
                    if (dt.Rows.Count>0)
                        IsExist = true;
                }
                return IsExist;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        #endregion


        /// <summary>
        /// 获取服务器时间
        /// </summary>
        /// <returns></returns>
        public DateTime GetServiceTime()
        {
            DateTime dt = DateTime.Now;
            DataTable tbl = null;
            try
            {
                string strSql = "select GetDate() AS SysDate ";

                Common.AdoConnect.Connect.ConnectOpen();

                tbl = Common.AdoConnect.Connect.GetDataSet(strSql);

                if (tbl != null && tbl.Rows.Count > 0)
                {

                    dt = DateTime .Parse (tbl.Rows[0]["SysDate"].ToString());
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dt;
        }

        #endregion

        #region 下拉框控件绑定设置

        #endregion

        #region 数据新增部分

        /// <summary>
        /// 新增基本信息数据
        /// </summary>
        /// <param name="TableName">数据表名称</param>
        /// <param name="dicItemData">数据内容</param>
        /// <param name="dicUserColum">操作员信息列名</param>
        /// <returns></returns>
        public int SetInsertDataItem(String TableName, 
                                     StringDictionary dicItemData,
                                     StringDictionary dicUserColum)
        {

            int rowIndex = 0;
            int w_RtnCnt = 0;
            SqlParameter[] cmdParamters = null;
            SqlParameter SqlParameter = null;

            string w_strFileds="";
            string w_strValues = "";

            try
            {
                if (dicItemData == null || dicItemData.Count <= 0) return w_RtnCnt;
    
                string strSql = "INSERT INTO " + TableName + " ( ";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new SqlParameter[dicItemData.Count + dicUserColum.Count + dicUserColum.Count];
                
                foreach (string strKey in dicItemData.Keys)
                {
                    w_strFileds +="," + strKey ;
                    w_strValues += ", @" + strKey;

                    SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);
                    SqlParameter.Value = dicItemData[strKey];
                    SqlParameter.Direction = ParameterDirection.Input;
                    cmdParamters[rowIndex] = SqlParameter;
                    rowIndex++;
                }

                foreach (string strKey in dicUserColum.Keys)
                {
                    if (strKey.Equals(Common.UserColum.AddDateTime) == true || strKey.Equals(Common.UserColum.UpdDateTime) == true)
                    {
                        w_strFileds += "," + strKey;
                        w_strValues += ", CONVERT(VARCHAR, GETDATE(), 20) " ;

                        
                    }
                    else if (strKey.Equals(Common.UserColum.AddUserNo) == true || strKey.Equals(Common.UserColum.UpdUserNo) == true)
                    {
                        w_strFileds += "," + strKey;
                        w_strValues += ", @" + strKey;

                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);
                        SqlParameter.Value = Common._personid;
                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
                        rowIndex++;
                    }            
                }

                strSql += w_strFileds.Substring (1)  +" )  VALUES (";
                strSql +=w_strValues.Substring (1)  +" )";

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
        public int SetInsertDataItem(String TableName,
                                     StringDictionary dicItemFiledNm,
                                     StringDictionary dicItemData,
                                     StringDictionary dicUserColum)
        {
            int rowIndex = 0;
            int w_RtnCnt = 0;
            SqlParameter[] cmdParamters = null;
            SqlParameter SqlParameter = null;

            string w_strFileds = "";
            string w_strValues = "";

            try
            {
                if (dicItemData == null || dicItemData.Count <= 0) return w_RtnCnt;

                string strSql = "INSERT INTO " + TableName + " ( ";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new SqlParameter[dicItemData.Count + dicUserColum.Count + dicUserColum.Count];

                foreach (string strKey in dicItemFiledNm.Keys)
                {              
                    if (dicItemData.ContainsKey (strKey)==true)
                    {
                        w_strFileds += "," + strKey;
                        w_strValues += ", @" + strKey;

                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);
                        SqlParameter.Value = dicItemData[strKey];
                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
                        rowIndex++;
                    }
                }

                foreach (string strKey in dicUserColum.Keys)
                {
                    if (strKey.Equals(Common.UserColum.AddDateTime) == true || strKey.Equals(Common.UserColum.UpdDateTime) == true)
                    {
                        w_strFileds += "," + strKey;
                        w_strValues += ", CONVERT(VARCHAR, GETDATE(), 20) ";


                    }
                    else if (strKey.Equals(Common.UserColum.AddUserNo) == true || strKey.Equals(Common.UserColum.UpdUserNo) == true)
                    {
                        w_strFileds += "," + strKey;
                        w_strValues += ", @" + strKey;

                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);
                        SqlParameter.Value = Common._personid;
                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
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
        public int SetModifyDataItem(String TableName,
                                     StringDictionary dicItemData,
                                     StringDictionary dicPrimarName,
                                     StringDictionary dicUserColum)
        {
            int rowIndex = 0;
            int w_RtnCnt = 0;
            SqlParameter[] cmdParamters = null;
            SqlParameter SqlParameter = null;

            string w_strSetValues = "";
            string w_strWhere = "";

            try
            {
                if (dicItemData == null || dicItemData.Count <= 0 || dicPrimarName == null) return w_RtnCnt;

                string strSql = "UPDATE " + TableName + " Set ";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new SqlParameter[dicItemData.Count + dicUserColum.Count ];

                foreach (string strKey in dicItemData.Keys)
                {
                    if (dicPrimarName.ContainsKey(strKey) != true)
                    {
                        w_strSetValues += "," + strKey + "=@" + strKey;
                    }

                    SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);

                    if (SqlParameter.SqlDbType  == SqlDbType.Bit)
                    {
                        SqlParameter.Value = bool.Parse(dicItemData[strKey]);
                    }
                    else {
                        SqlParameter.Value = dicItemData[strKey];
                    }
                    
                    SqlParameter.Direction = ParameterDirection.Input;
                    cmdParamters[rowIndex] = SqlParameter;
                    rowIndex++;
                }


                foreach (string strKey in dicUserColum.Keys)
                {
                    if (strKey.Equals(Common.UserColum.UpdDateTime) == true)
                    {
                        w_strSetValues += "," + strKey + "=CONVERT(VARCHAR, GETDATE(), 20) ";

                    }
                    else if (strKey.Equals(Common.UserColum.UpdUserNo) == true)
                    {
                        w_strSetValues += "," + strKey + "=@" + strKey;

                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);
                        SqlParameter.Value = Common._personid;
                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
                        rowIndex++;
                    }
                }

                strSql += w_strSetValues.Substring(1) + " WHERE 1=1";

                foreach (string strKey in dicPrimarName.Keys)
                {
                    w_strWhere += " AND " + strKey + "=@" + strKey;
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
        public int SetModifyDataItemBySql(String Sql,
                                     StringDictionary dicItemData,
                                     StringDictionary dicPrimarName,
                                     StringDictionary dicUserColum)
        {
            int rowIndex = 0;
            int w_RtnCnt = 0;
            SqlParameter[] cmdParamters = null;
            SqlParameter SqlParameter = null;

            string w_strSetValues = "";
            string w_strWhere = "";

            try
            {
                if (dicItemData == null || dicPrimarName == null) return w_RtnCnt;

                string strSql = Sql;

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new SqlParameter[dicItemData.Count + dicUserColum.Count];

                foreach (string strKey in dicItemData.Keys)
                {
     
                    SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);

                    if (SqlParameter.SqlDbType == SqlDbType.Bit)
                    {
                        SqlParameter.Value = bool.Parse(dicItemData[strKey]);
                    }
                    else
                    {
                        SqlParameter.Value = dicItemData[strKey];
                    }

                    SqlParameter.Direction = ParameterDirection.Input;
                    cmdParamters[rowIndex] = SqlParameter;
                    rowIndex++;
                }

                foreach (string strKey in dicUserColum.Keys)
                {
                    if (strKey.Equals(Common.UserColum.UpdDateTime) == true)
                    {
                        w_strSetValues += "," + strKey + "=CONVERT(VARCHAR, GETDATE(), 20) ";

                    }
                    else if (strKey.Equals(Common.UserColum.UpdUserNo) == true)
                    {
                        w_strSetValues += "," + strKey + "=@" + strKey;

                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);
                        SqlParameter.Value = Common._personid;
                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
                        rowIndex++;
                    }
                }

                if (w_strSetValues.Length >1)
                strSql += w_strSetValues.Substring(1) + " WHERE 1=1";

                foreach (string strKey in dicPrimarName.Keys)
                {
                    w_strWhere += " AND " + strKey + "=@" + strKey;
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
        public int SetModifyDataItem(String TableName,
                                     StringDictionary dicItemFiledNm,
                                     StringDictionary dicItemData,
                                     StringDictionary dicPrimarName,
                                     StringDictionary dicUserColum)
        {
            int rowIndex = 0;
            int w_RtnCnt = 0;
            SqlParameter[] cmdParamters = null;
            SqlParameter SqlParameter = null;

            string w_strSetValues = "";
            string w_strWhere = "";

            try
            {
                if (dicItemData == null || dicItemData.Count <= 0 || dicPrimarName == null) return w_RtnCnt;

                string strSql = "UPDATE " + TableName + " Set ";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new SqlParameter[dicItemData.Count + dicUserColum.Count];

                foreach (string strKey in dicItemFiledNm.Keys)
                {
                    if (dicPrimarName.ContainsKey(strKey) != true)
                    {
                        w_strSetValues += "," + strKey + "=@" + strKey;
                    }

                    if (dicItemData.ContainsKey(strKey) == true)
                    {
                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);

                        if (SqlParameter.SqlDbType == SqlDbType.Bit)
                        {
                            SqlParameter.Value = bool.Parse(dicItemData[strKey]);
                        }
                        else
                        {
                            SqlParameter.Value = dicItemData[strKey];
                        }

                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
                        rowIndex++;
                    }
                }

                foreach (string strKey in dicUserColum.Keys)
                {
                    if (strKey.Equals(Common.UserColum.UpdDateTime) == true)
                    {
                        w_strSetValues += "," + strKey + "=CONVERT(VARCHAR, GETDATE(), 20) ";

                    }
                    else if (strKey.Equals(Common.UserColum.UpdUserNo) == true)
                    {
                        w_strSetValues += "," + strKey + "=@" + strKey;

                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);
                        SqlParameter.Value = Common._personid;
                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
                        rowIndex++;
                    }
                } 

                strSql += w_strSetValues.Substring(1) + " WHERE 1=1";

                foreach (string strKey in dicPrimarName.Keys)
                {
                    w_strWhere += " AND " + strKey + "=@" + strKey;
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
        public int SetDeleteDataItem(String TableName,
                                     StringDictionary dicItemData,
                                     StringDictionary dicPrimarName)
        {
            int rowIndex = 0;
            int w_RtnCnt = 0;
            SqlParameter[] cmdParamters = null;
            SqlParameter SqlParameter = null;

            string w_strWhere = "";

            try
            {
                if (dicItemData == null || dicPrimarName == null ) return w_RtnCnt;

 
                string strSql = "DELETE " + TableName + " WHERE 1=1";

                Common.AdoConnect.Connect.ConnectOpen();

                cmdParamters = new SqlParameter[dicPrimarName.Count];

                foreach (string strKey in dicPrimarName.Keys)
                {
                    if (dicItemData.ContainsKey(strKey) == true)
                    {

                        w_strWhere += " AND " + strKey + "=@" + strKey;

                        SqlParameter = new SqlParameter("@" + strKey, DataFiledType.FiledType[strKey]);
                        SqlParameter.Value = dicItemData[strKey];
                        SqlParameter.Direction = ParameterDirection.Input;
                        cmdParamters[rowIndex] = SqlParameter;
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

        #region 记录日志
        /// <summary>
        /// 记录日志信息
        /// </summary>
        /// <param name="FrmName">画面名称</param>
        /// <param name="OperateTyp">操作类型</param>
        /// <param name="OperateContent">记录内容</param>
        public void WriteLog(string FrmName, int OperateTyp,string OperateContent)
        {

            StringDictionary w_dicconds =new StringDictionary();
            w_dicconds[M_FuncForm.FormId] = "true";

            StringDictionary w_dataItem=new StringDictionary();
            w_dataItem[M_FuncForm.FormId] = FrmName;


            StringDictionary w_dicUserColum = new StringDictionary();
            w_dicUserColum[Common.UserColum.AddDateTime] = "true";
            w_dicUserColum[Common.UserColum.AddUserNo] = "true";

            string FunctionId = "";
            try
            {
                //取功能分类
                DataTable dt = this.GetTableInfo(M_FuncForm.TableName, w_dataItem, w_dicconds, new StringDictionary(), "");
                if (dt != null && dt.Rows.Count > 0)
                {
                    FunctionId = dt.Rows[0][M_FuncForm.FunctionTyp ].ToString();
                }
                w_dataItem[T_LogRecord.FunctionId] = FunctionId;
                w_dataItem[T_LogRecord.RecordId] = Common.GetGuid();
                w_dataItem[T_LogRecord.OperateTyp] = OperateTyp.ToString();
                w_dataItem[T_LogRecord.Remark] = OperateContent;

                this.SetInsertDataItem(T_LogRecord.TableName, w_dataItem, w_dicUserColum);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        #endregion

    }
}
