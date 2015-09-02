using System.Data;
using Framework.Libs;
using System;
using MySql.Data.MySqlClient;
using System.Collections.Specialized;

namespace Framework.DataAccess
{
    class MySQLConnect : CBaseConnect
    {
        #region 变量定义

        private string _strConnectString;
        private string _strServerNm;
        private string _strDataBase;
        private string _strUserName;
        private string _strPassWord;

        /// <summary>
        /// 数据库执行对象
        /// </summary>
        public MySqlConnection m_SqlConn;

        public MySqlTransaction Tran;

        #endregion

        #region CBaseConnect 成员

        #region 属性设置

        string CBaseConnect.strConnectString
        {
            get
            {
                return _strConnectString;
            }
            set
            {
                if (_strConnectString == value)
                    return;
                _strConnectString = value;
            }
        }

        string CBaseConnect.strServerNm
        {
            get
            {
                return _strServerNm;
            }
            set
            {
                if (_strServerNm == value)
                    return;
                _strServerNm = value;
            }
        }

        string CBaseConnect.strDataBase
        {
            get
            {
                return _strDataBase;
            }
            set
            {
                if (_strDataBase == value)
                    return;
                _strDataBase = value;
            }
        }

        string CBaseConnect.strUserName
        {
            get
            {
                return _strUserName;
            }
            set
            {
                if (_strUserName == value)
                    return;
                _strUserName = value;
            }
        }

        string CBaseConnect.strPassWord
        {
            get
            {
                return _strPassWord;
            }
            set
            {
                if (_strPassWord == value)
                    return;
                _strPassWord = value;
            }
        }

        #endregion

        #region 数据库初始化处理

        /// <summary>
        /// 数据库连接参数设置
        /// </summary>
        void CBaseConnect.SetParameter()
        {

            this._strConnectString = "SERVER=" + Common._sysrun .ServerName.Trim() + ";"
                                           + "UID=" + Common._sysrun.UserName.Trim() + ";"
                                           + "PWD=" + Common._sysrun.PassWord .Trim() + ";"
                                           + "DATABASE=" + Common._sysrun.DataBaseName.Trim() + ";"
                                           + "Connect Timeout = 5000 ";

        } 
        
        /// <summary>
        /// 数据库连接参数设置
        /// </summary>
        /// <param name="strServerNm">服务器地址</param>
        /// <param name="strDataBaseNm">数据库名</param>
        /// <param name="strUserNm">用户名</param>
        /// <param name="strPswd">用户密码</param>
        void CBaseConnect.SetParameter(string strServerNm, string strDataBaseNm, string strUserNm, string strPswd)
        {
            this._strServerNm = strServerNm;
            this._strDataBase = strDataBaseNm;
            this._strUserName = strUserNm;
            this._strPassWord = strPswd;

            this._strConnectString = "SERVER=" + this._strServerNm.Trim() + ";"
                                           + "UID=" + this._strUserName.Trim() + ";"
                                           + "PWD=" + this._strPassWord.Trim() + ";"
                                           + "DATABASE=" + this._strDataBase.Trim();
        }

        /// <summary>
        /// 数据库连接打开处理
        /// </summary>
        /// <param name="intDBtype">数据源类型</param>
        /// <returns></returns>
        bool CBaseConnect.ConnectOpen()
        {
            try
            {
                if (this.m_SqlConn == null)
                {
                    this.m_SqlConn = new MySqlConnection(_strConnectString);
                }

                if (this.m_SqlConn.State != ConnectionState.Open)
                {
                    this.m_SqlConn.Open();
                }

                return (this.m_SqlConn == null) || (this.m_SqlConn.State != ConnectionState.Open) ? false : true;

            }
            catch (MySqlException ex)
            {
               throw ex;
            }
        }
        
        /// <summary>
        /// 数据库连接关闭处理
        /// </summary>
        /// <param name="intDBtype">数据源类型</param>
        /// <returns></returns>
        bool CBaseConnect.ConnectClose()
        {
            try
            { 
                if (this.m_SqlConn.State == ConnectionState.Open)
                {
                    this.m_SqlConn.Close();
                }

                return true;

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 数据库创建事务处理
        /// </summary>
        /// <param name="intDBtype">数据源类型</param>
        /// <returns></returns>
        bool CBaseConnect.CreateSqlTransaction()
        {
            try
            {

                this.Tran = this.m_SqlConn.BeginTransaction();

                return true;

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// 数据库事务提交处理
        /// </summary>
        /// <param name="intDBtype">数据源类型</param>
        /// <returns></returns>
        bool CBaseConnect.TransactionCommit()
        {
            try
            {

                this.Tran.Commit();

                return true;

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 数据库事务回滚处理
        /// </summary>
        /// <param name="intDBtype">数据源类型</param>
        /// <returns></returns>
        bool CBaseConnect.TransactionRollback()
        {
            try
            {

                this.Tran.Rollback(); 

                return true;

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }

        #endregion

        #region 数据库查询处理

        /// <summary>
        /// 获取数据查询结果集

        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns></returns>
        DataTable CBaseConnect.GetDataSet(string SQLString)
        {

            try
            {
                return GetDataSetProc(SQLString);

            }
            catch (MySqlException ex)
            {
                throw ex; 
            }
        }

        /// <summary>
        /// 获取数据查询结果集

        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="param">参数对象</param>
        /// <returns></returns>
        DataTable CBaseConnect.GetDataSet(string SQLString, params object[] lstParam)
        {
            try
            {
                return GetDataSetProc(SQLString, lstParam);

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
         
        }

        /// <summary>
        /// 返回某一个字段的值
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns></returns>
        object CBaseConnect.GetFieldValue(string SQLString)
        {
            MySqlDataAdapter MyAdapter; 
            DataSet MyDataSet = new DataSet();
            try
            {
                MyAdapter=new MySqlDataAdapter(SQLString, this.m_SqlConn);
                MyAdapter.Fill(MyDataSet, "User_Data");
               
                if (MyDataSet.Tables[0].Rows.Count >= 1)

                    return MyDataSet.Tables[0].Rows[0][0];
                else
                    return null;
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message + "\n当前执行SQL语句：" + GetSqlFromSqlPara(SQLString, null ));
            }
        }

        /// <summary>
        /// 查询获取的记录集
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns></returns>
        Common.dbRecord CBaseConnect.GetRecord(string SQLString)
        {
            DataTable MyDataTable;
            Common.dbRecord MyRecord ;

            try
            {

                MyDataTable = this.GetDataSetProc(SQLString);

                if (MyDataTable != null)
                {
                    MyRecord.AdoDataRst = MyDataTable;
                    MyRecord.RcdCnt = MyDataTable.Rows.Count;
                }
                else
                {
                    MyRecord.AdoDataRst = null;
                    MyRecord.RcdCnt=0;
                }

                return MyRecord;
                   
            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message + "\n当前执行SQL语句：" + GetSqlFromSqlPara(SQLString, null ));
            }
        }

        /// <summary>
        /// 查询获取的记录集
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        Common.dbRecord CBaseConnect.GetRecord(string SQLString, params object[] lstParam)
        {
            DataTable MyDataTable;
            Common.dbRecord MyRecord;

            try
            {

                MyDataTable = this.GetDataSetProc(SQLString, lstParam);

                if (MyDataTable != null)
                {
                    MyRecord.AdoDataRst = MyDataTable;
                    MyRecord.RcdCnt = MyDataTable.Rows.Count;
                }
                else
                {
                    MyRecord.AdoDataRst = null;
                    MyRecord.RcdCnt = 0;
                }

                return MyRecord;

            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message + "\n当前执行SQL语句：" + GetSqlFromSqlPara(SQLString, lstParam));
            }
        }


        /// <summary>
        /// 获取表格显示的记录集
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns></returns>
        Common.View CBaseConnect.GetView(string SQLString)
        {
            DataTable MyDataTable;
            Common.View MyView;

            try
            {

                MyDataTable = this.GetDataSetProc(SQLString);

                if (MyDataTable != null)
                {
                    MyView.AdoViewRst = MyDataTable.DefaultView;
                    MyView.RcdCnt = MyDataTable.Rows.Count;
                }
                else
                {
                    MyView.AdoViewRst  = null;
                    MyView.RcdCnt = 0;
                }

                return MyView;

            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message + "\n当前执行SQL语句：" + GetSqlFromSqlPara(SQLString, null ));
            }
        }
 
        /// <summary>
        /// 获取表格显示的记录集
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="param">参数</param>
        /// <returns></returns>
        Common.View CBaseConnect.GetView(string SQLString, params object[] lstParam)
        {
            DataTable MyDataTable;
            Common.View MyView;

            try
            {

                MyDataTable = this.GetDataSetProc(SQLString, lstParam);

                if (MyDataTable != null)
                {
                    MyView.AdoViewRst = MyDataTable.DefaultView;
                    MyView.RcdCnt = MyDataTable.Rows.Count;
                }
                else
                {
                    MyView.AdoViewRst = null;
                    MyView.RcdCnt = 0;
                }

                return MyView;

            }
            catch ( MySqlException ex)
            {
                throw new Exception(ex.Message + "\n当前执行SQL语句：" + GetSqlFromSqlPara(SQLString, lstParam));
            }
        }

        #endregion

        #region 数据库执行处理


        /// <summary>
        /// 数据执行处理
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns></returns>
        int CBaseConnect.ExecuteNonQuery(string SQLString)
        {
            MySqlCommand MySqlCommand;
            int w_intRtnValue = -1 ;

            try
            {

                if (this.m_SqlConn.State != ConnectionState.Open)
                {
                    this.m_SqlConn.Open();
                }


                MySqlCommand = new MySqlCommand(SQLString, this.m_SqlConn);

                w_intRtnValue = MySqlCommand.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message + "\n当前执行SQL语句：" + GetSqlFromSqlPara(SQLString, null));
            }

            return w_intRtnValue;
        }


        /// <summary>
        /// 数据执行处理
        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="param">参数对象</param>
        /// <returns></returns>
        int CBaseConnect.ExecuteNonQuery(string SQLString, params object[] lstParam)
        {
            MySqlCommand MySqlCommand;
            int intParaIndex;
            int w_intRtnValue = -1;

            try
            {

                if (this.m_SqlConn.State != ConnectionState.Open)
                {
                    this.m_SqlConn.Open();
                }


                MySqlCommand = new MySqlCommand(SQLString, this.m_SqlConn);
                MySqlCommand.Transaction = this.Tran;

                for (intParaIndex = 0; intParaIndex < lstParam.Length; intParaIndex++)
                {
                    if (lstParam[intParaIndex] != null) 
                    MySqlCommand.Parameters.Add(lstParam[intParaIndex]);
                }

               w_intRtnValue = MySqlCommand.ExecuteNonQuery();

            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message + "\n当前执行SQL语句：" + GetSqlFromSqlPara(SQLString, lstParam));
            }

            return w_intRtnValue;
        }

        /// <summary>
        /// 数据库执行处理
        /// </summary>
        /// <param name="StoreProcName"></param>
        /// <param name="MyChoose"> HasAOutput：仅有单个返回值;
        ///                         OnlyExecSp：仅执行无返回值;
        ///                         RetOneRecord：返回记录集DataTable</param>
        /// <param name="para"></param>
        /// <returns></returns>
        object CBaseConnect.SetExecuteSP(string StoreProcName, Common.Choose MyChoose, params object[] lstParam)
        {
            object RetValue = null;

            MySqlCommand ParaCmd; 
            object[] w_ParaList;

            try
            {
                
                if (this.m_SqlConn.State != ConnectionState.Open)
                {
                    this.m_SqlConn.Open();
                }

                if (string.IsNullOrEmpty(StoreProcName) == true  )
                {
                    return null ;
                }

                ParaCmd = new MySqlCommand(StoreProcName, this.m_SqlConn);
                ParaCmd.Transaction = this.Tran;

                ParaCmd.Prepare();
                ParaCmd.CommandTimeout = 300;
                ParaCmd.CommandType = CommandType.StoredProcedure;

                w_ParaList = GetParaToCommand(StoreProcName, lstParam);
                for (int paraIndex = 0; paraIndex < w_ParaList.Length; paraIndex++)
                {
                    if (w_ParaList[paraIndex] != null)
                        ParaCmd.Parameters.Add(w_ParaList[paraIndex]);
                }

                switch (MyChoose)
                {
                    case Common.Choose.HasAOutput:     
                    
                        //有一个返回值,但定义是最后一个参数
                        ParaCmd.ExecuteNonQuery();

                        RetValue = ParaCmd.Parameters[ParaCmd.Parameters.Count - 1].Value;
                        break;

                    case Common.Choose.OnlyExecSp:   
                    
                        //仅仅进行数据处理，无返回值。  
                        ParaCmd.ExecuteNonQuery();
                        RetValue = 0;
                        break;

                    case Common.Choose.RetOneRecord: 

                        //返回一个MySqlDataReader。.

                        MySqlDataReader reader = ParaCmd.ExecuteReader(CommandBehavior.Default);

                        RetValue = GetConvertDataReaderToDataTable(reader);
                        break;
                }
            }
            catch (MySqlException ex)
            {
                throw ex;
            }

            return RetValue;
        }


        #endregion

        #endregion

        /// <summary>
        /// 获取数据查询结果集

        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <returns></returns>
        private DataTable GetDataSetProc(string SQLString)
        {
            DataTable MyDataTable = null ; 
            DataSet MyDataSet = new DataSet();
            MySqlCommand MySqlCommand = new MySqlCommand ();
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();

            try
            {

                if (this.m_SqlConn.State != ConnectionState.Open)
                {
                    this.m_SqlConn.Open();
                }

                MySqlCommand.Connection = this.m_SqlConn;
                MySqlCommand.CommandText = SQLString;

                if (Tran != null) MySqlCommand.Transaction = Tran;

                MyAdapter.SelectCommand = MySqlCommand;

                MyAdapter.Fill(MyDataSet, "User_Data");

                if (MyDataSet != null)
                {
                    MyDataTable = MyDataSet.Tables[0];
                }

                return MyDataTable;

            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message + "\n当前执行SQL语句：" + GetSqlFromSqlPara(SQLString, null));
            }
        }

        /// <summary>
        /// 获取数据查询结果集

        /// </summary>
        /// <param name="SQLString">SQL语句</param>
        /// <param name="param">参数对象</param>
        /// <returns></returns>
        private DataTable GetDataSetProc(string SQLString, params object[] lstParam)
        {

            DataTable MyDataTable = null; 
            DataSet MyDataSet = new DataSet(); ;
            MySqlCommand MySqlCommand = new MySqlCommand ();
            MySqlDataAdapter MyAdapter = new MySqlDataAdapter();
            int intParaIndex;

            try
            {

                if (this.m_SqlConn.State != ConnectionState.Open)
                {
                    this.m_SqlConn.Open();
                }

                MySqlCommand .Connection =this.m_SqlConn;
                MySqlCommand.CommandText =SQLString;

                if (Tran != null) MySqlCommand.Transaction = Tran;

                for (intParaIndex = 0; intParaIndex < lstParam.Length; intParaIndex++)
                {
                    if (lstParam[intParaIndex] != null)
                        MySqlCommand.Parameters.Add(lstParam[intParaIndex]);
                }

                MyAdapter.SelectCommand = MySqlCommand;
                MyAdapter.Fill(MyDataSet, "User_Data");

                if (MyDataSet != null)
                {
                    MyDataTable = MyDataSet.Tables[0];
                }
                string sql = GetSqlFromSqlPara(SQLString, lstParam);
                return MyDataTable;

            }
            catch (MySqlException ex)
            {
                throw new Exception(ex.Message + "\n当前执行SQL语句：" + GetSqlFromSqlPara(SQLString, lstParam));
            }

        }

        /// <summary>
        /// 存储过程参数取得处理
        /// </summary>
        /// <param name="StoreProcName">存储过程名</param>
        /// <param name="paraValue">参数数组</param>
        /// <returns>返回一个对象数组</returns>
        public object[] GetParaToCommand(string StoreProcName, params object[] lstParam)
        {
            int rowIndex = 0;
            string cmdParaSQL;
            int intParaDirection;

            DataTable tblParaRst;
            MySqlDbType cmdParaType = 0;
            MySqlParameter[] cmdParamters = null;

            cmdParaSQL = "Select P.ParaName,T.Name as ParaType,P.ParaLen,P.ParaDirection From " +
                                 "(Select a.Name as ParaName,c.Name as ParaType,a.Length as ParaLen," +
                                 "a.isOutParam as ParaDirection,a.Colid as ParaID,c.xtype as ParaTypeID " +
                                 "From syscolumns a Left Outer Join sysobjects b On a.ID=b.ID and b.xtype='P' " +
                                 "Left Outer Join systypes c On a.xtype=c.xtype and a.xusertype=c.xusertype " +
                                 "Where b.Name='" + StoreProcName.Trim() + "') P Left Outer Join systypes T On " +
                                 "P.ParaTypeID=T.xtype and P.ParaTypeID=T.xusertype Order by P.ParaID";

            tblParaRst = GetDataSetProc(cmdParaSQL);

            if (tblParaRst != null && tblParaRst.Rows.Count > 0)
            {
                cmdParamters = new MySqlParameter[tblParaRst.Rows.Count];
                foreach (DataRow ParaRow in tblParaRst.Rows)
                {
                    switch (ParaRow["ParaType"].ToString().ToUpper().Trim())
                    {
                        case "INT64":
                            cmdParaType = MySqlDbType.Int64;
                            break;
                        case "BINARY":
                            cmdParaType = MySqlDbType.Binary;
                            break;
                        case "BIT":
                            cmdParaType = MySqlDbType.Bit;
                            break;
                        case "STRING":
                            cmdParaType = MySqlDbType.String;
                            break;
                        case "DATETIME":
                            cmdParaType = MySqlDbType.Datetime;
                            break;
                        case "DECIMAL":
                            cmdParaType = MySqlDbType.Decimal;
                            break;
                        case "FLOAT":
                            cmdParaType = MySqlDbType.Float;
                            break;
                        case "BYTE":
                            cmdParaType = MySqlDbType.Byte;
                            break;
                        case "INT32":
                            cmdParaType = MySqlDbType.Int32;
                            break;
                        case "DOUBLE":
                            cmdParaType = MySqlDbType.Double;
                            break;
                        case "ENUM":
                            cmdParaType = MySqlDbType.Enum;
                            break;
                        case "TINYTEXT":
                            cmdParaType = MySqlDbType.TinyText;
                            break;
                        case "VARSTRING":
                            cmdParaType = MySqlDbType.VarString;
                            break;
                        case "YEAR":
                            cmdParaType = MySqlDbType.Year;
                            break;
                        case "TIME":
                            cmdParaType = MySqlDbType.Time;
                            break;
                        case "INT16":
                            cmdParaType = MySqlDbType.Int16;
                            break;
                        case "DATE":
                            cmdParaType = MySqlDbType.Date;
                            break;
                        case "TEXT":
                            cmdParaType = MySqlDbType.Text;
                            break;
                        case "TIMESTAMP":
                            cmdParaType = MySqlDbType.Timestamp;
                            break;
                        case "INT24":
                            cmdParaType = MySqlDbType.Int24;
                            break;
                        case "BLOB":
                            cmdParaType = MySqlDbType.Blob;
                            break;
                        case "VARBINARY":
                            cmdParaType = MySqlDbType.VarBinary;
                            break;
                        case "VARCHAR":
                            cmdParaType = MySqlDbType.VarChar;
                            break;
                    }
                    cmdParamters[rowIndex] = new MySqlParameter(ParaRow["ParaName"].ToString().Trim()
                                                                                      , cmdParaType
                                                                                      , (System.Int16)(ParaRow["ParaLen"]));

                    //cmdParamters[rowIndex].Direction = ((int)ParaRow["ParaDirection"] == 1 ? ParameterDirection.Output : ParameterDirection.Input);
                    intParaDirection=(int)ParaRow["ParaDirection"];
                   
                    //// 摘要:
                    ////     参数是输入参数。

                    //Input = 1,
                    ////
                    //// 摘要:
                    ////     参数是输出参数。

                    //Output = 2,
                    ////
                    //// 摘要:
                    ////     参数既能输入，也能输出。

                    //InputOutput = 3,
                    ////
                    //// 摘要:
                    ////     参数表示诸如存储过程、内置函数或用户定义函数之类的操作的返回值。

                    //ReturnValue = 6,

                    if (intParaDirection ==0)
                    {
                        cmdParamters[rowIndex].Direction = ParameterDirection.Input;
                    }
                    else if (intParaDirection ==1)
                    {
                        cmdParamters[rowIndex].Direction = ParameterDirection.Output;
                    }
                    else
                    {
                        cmdParamters[rowIndex].Direction = ParameterDirection.ReturnValue;
                    }

                    cmdParamters[rowIndex].Value = lstParam[rowIndex];
                    rowIndex++;
                }

                tblParaRst.Dispose();
            }

            return cmdParamters;
        }

        /// <summary> 
        /// DataReader格式转换成DataTable 
        /// </summary> 
        /// <param name="DataReader">OleDbDataReader</param> 
        private DataTable GetConvertDataReaderToDataTable(MySqlDataReader reader)
        {
            DataTable objDataTable = new DataTable("TmpDataTable");
            int intCounter;

            try
           
            {
                //获取当前行中的列数；

                int intFieldCount = reader.FieldCount;

                for (intCounter = 0; intCounter <= intFieldCount - 1; intCounter++)
                {
                    objDataTable.Columns.Add(reader.GetName(intCounter), reader.GetFieldType(intCounter));
                }

                //populate   datatable   
                objDataTable.BeginLoadData();

                //object[]   objValues   =   new   object[intFieldCount   -1];   
                object[] objValues = new object[intFieldCount];

                while (reader.Read())
                {
                    reader.GetValues(objValues);
                    objDataTable.LoadDataRow(objValues, true);
                }
                reader.Close();

                objDataTable.EndLoadData();

                return objDataTable;

            }
            catch (MySqlException ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// 将带参数的语句转换为sql语句
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="lstParam"></param>
        /// <returns></returns>
        private string GetSqlFromSqlPara(string sql, params object[] lstParam)
        {
            string NewSql = sql;
                  MySqlParameter par;
            try
            {
                if (lstParam == null) return sql;
                for (int i = 0; i < lstParam.Length; i++)
                {
                    if (lstParam[i] == null) continue;
                    par=(MySqlParameter)lstParam[i];
                    if (sql.IndexOf(lstParam[i].ToString()) > 0)
                    {
                        if (par.MySqlDbType == MySqlDbType.Bit)
                        {

                            NewSql = NewSql.Replace(lstParam[i].ToString(), "'" + par.Value.ToString().ToLower()=="true"?"1":"0" + "'");
                        }
                        else
                        {
                            NewSql = NewSql.Replace(lstParam[i].ToString(), "'" + par.Value.ToString() + "'");
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
            return NewSql;

        }

    }
}
