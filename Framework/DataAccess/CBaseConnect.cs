using System.Data;
using Framework.Libs;
using System.Collections.Specialized;

namespace Framework.DataAccess
{
   public interface CBaseConnect
   {

       #region 属性设置

       string strConnectString { get; set; }
       string strServerNm { get; set; }
       string strDataBase { get; set; }
       string strUserName { get; set; }
       string strPassWord { get; set; }

       #endregion

       #region 数据库初始化处理

       /// <summary>
       /// 数据库连接参数设置
       /// </summary>
       void SetParameter();

       /// <summary>
       /// 数据库连接参数设置
       /// </summary>
       /// <param name="strServerNm">服务器地址</param>
       /// <param name="strDataBaseNm">数据库名</param>
       /// <param name="strUserNm">用户名</param>
       /// <param name="strPswd">用户密码</param>
       void SetParameter(string strServerNm, string strDataBaseNm, string strUserNm, string strPswd);

       /// <summary>
       /// 数据库连接打开处理
       /// </summary>
       /// <param name="intDBtype">数据源类型</param>
       /// <returns></returns>
       bool ConnectOpen();

       /// <summary>
       /// 数据库连接关闭处理
       /// </summary>
       /// <param name="intDBtype">数据源类型</param>
       /// <returns></returns>
       bool ConnectClose();

       /// <summary>
       /// 数据库创建事务处理
       /// </summary>
       /// <param name="intDBtype">数据源类型</param>
       /// <returns></returns>
       bool CreateSqlTransaction();

       /// <summary>
       /// 数据库事务回滚处理
       /// </summary>
       /// <param name="intDBtype">数据源类型</param>
       /// <returns></returns>
       bool TransactionRollback();

       /// <summary>
       /// 数据库事务提交处理
       /// </summary>
       /// <param name="intDBtype">数据源类型</param>
       /// <returns></returns>
       bool TransactionCommit();

       #endregion

       #region 数据库查询处理

       /// <summary>
       /// 获取数据查询结果集
       /// </summary>
       /// <param name="SQLString">SQL语句</param>
       /// <returns></returns>
       DataTable GetDataSet(string SQLString);

       /// <summary>
       /// 获取数据查询结果集
       /// </summary>
       /// <param name="SQLString">SQL语句</param>
       /// <param name="param">参数对象</param>
       /// <returns></returns>
       DataTable GetDataSet(string SQLString, params object[] param);

       /// <summary>
       /// 返回某一个字段的值
       /// </summary>
       /// <param name="SQLString">SQL语句</param>
       /// <returns></returns>
       object GetFieldValue(string SQLString);

       /// <summary>
       /// 查询获取的记录集
       /// </summary>
       /// <param name="SQLString">SQL语句</param>
       /// <returns></returns>
       Common.dbRecord GetRecord(string SQLString);

       /// <summary>
       /// 查询获取的记录集
       /// </summary>
       /// <param name="SQLString">SQL语句</param>
       /// <param name="param">参数</param>
       /// <returns></returns>
       Common.dbRecord GetRecord(string SQLString, params object[] param);

       /// <summary>
       /// 获取表格显示的记录集
       /// </summary>
       /// <param name="SQLString">SQL语句</param>
       /// <returns></returns>
       Common.View GetView(string SQLString);

       /// <summary>
       /// 获取表格显示的记录集
       /// </summary>
       /// <param name="SQLString">SQL语句</param>
       /// <param name="param">参数</param>
       /// <returns></returns>
       Common.View GetView(string SQLString, params object[] param);

       #endregion

       #region 数据库执行处理

       /// <summary>
       /// 数据执行处理
       /// </summary>
       /// <param name="SQLString">SQL语句</param>
       /// <returns></returns>
       int ExecuteNonQuery(string SQLString);

       /// <summary>
       /// 数据执行处理
       /// </summary>
       /// <param name="SQLString">SQL语句</param>
       /// <param name="param">参数对象</param>
       /// <returns></returns>
       int ExecuteNonQuery(string SQLString, params object[] param);

       /// <summary>
       /// 存储过程执行处理
       /// </summary>
       /// <param name="StoreProcName"></param>
       /// <param name="MyChoose"> HasAOutput：仅有单个返回值;
       ///                         OnlyExecSp：仅执行无返回值;
       ///                         RetOneRecord：返回记录集DataTable</param>
       /// <param name="para"></param>
       /// <returns></returns>
       object SetExecuteSP(string StoreProcName, Common.Choose MyChoose, params object[] para);

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
       DataTable GetTableInfo(string TableName,
                              StringDictionary dicItemData,
                              StringDictionary dicConds,
                              StringDictionary dicLikeConds,
                              string OrderBy,
                              bool readUncommitted);


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
       DataTable GetTableInfoBySql(string Sql,
                                  StringDictionary dicItemData,
                                  StringDictionary dicConds,
                                  StringDictionary dicLikeConds,
                                  string OrderBy,
                                  bool readUncommitted);




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
       DataTable GetTableInfo(string TableName,
                               StringDictionary dicItemData,
                               StringDictionary dicConds,
                               StringDictionary dicBetweenConds,
                               StringDictionary dicLikeConds,
                               string OrderBy,
                               bool readUncommitted);

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
       DataTable GetTableInfoBySql(string Sql,
                              StringDictionary dicItemData,
                              StringDictionary dicConds,
                              StringDictionary dicBetweenConds,
                              StringDictionary dicLikeConds,
                              string OrderBy,
                              bool readUncommitted);


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
       DataTable GetTableInfoBySqlNoWhere(string Sql,
                                  StringDictionary dicItemData,
                                  StringDictionary dicConds,
                                  StringDictionary dicLikeConds,
                                  string OrderBy,
                                  bool readUncommitted);

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
       DataTable GetTableInfoBySqlNoWhere(string Sql,
                                  StringDictionary dicItemData,
                                  StringDictionary dicConds,
                                  StringDictionary dicBetweenConds,
                                  StringDictionary dicLikeConds,
                                  string OrderBy,
                                  bool readUncommitted);


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
       bool GetRepNameCheck(string TableName,
                               StringDictionary dicItemData,
                               StringDictionary dicPrimarName,
                               string strRepFiledName,
                               Common.DataModifyMode ScanMode);


       /// <summary>
       /// 数据存在检查(主键重复)
       /// </summary>
       /// <param name="TableName">数据表名称</param>
       /// <param name="dicItemData">数据内容</param>
       /// <param name="dicPrimarName">主键列名</param>
       /// <returns></returns>
       bool GetExistDataItem(string TableName,
                               StringDictionary dicItemData,
                               StringDictionary dicPrimarName);


       /// <summary>
       /// 获取最大编号
       /// </summary>
       /// <param name="TableName">数据表名称</param>
       /// <param name="FiledName">最大值列名</param>
       /// <returns></returns>
       string GetMaxNoteNo(string TableName, string FiledName);

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
       int SetInsertDataItem(string TableName,
                       StringDictionary dicItemData,
                       StringDictionary dicUserColum);


       /// <summary>
       /// 新增基本信息数据
       /// </summary>
       /// <param name="TableName">数据表名称</param>
       /// <param name="dicItemFiledNm">数据字段名称</param>
       /// <param name="dicItemData">数据内容</param>
       /// <param name="dicUserColum">操作员信息列名</param>
       /// <returns></returns>
       int SetInsertDataItem(string TableName,
                           StringDictionary dicItemFiledNm,
                           StringDictionary dicItemData,
                           StringDictionary dicUserColum);


       /// <summary>
       /// 记录日志信息
       /// </summary>
       /// <param name="FrmName">画面名称</param>
       /// <param name="OperateTyp">操作类型</param>
       /// <param name="OperateContent">记录内容</param>
       void WriteLog(string FrmName, int OperateTyp, string OperateContent);

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
       int SetModifyDataItem(string TableName,
                       StringDictionary dicItemData,
                       StringDictionary dicPrimarName,
                       StringDictionary dicUserColum);



       /// <summary>
       /// 修改基本信息数据
       /// </summary>
       /// <param name="Sql">SQL语句</param>
       /// <param name="dicItemData">数据内容</param>
       /// <param name="dicPrimarName">主键列名</param>
       /// <param name="dicUserColum">操作员信息列名</param>
       /// <returns></returns>
       int SetModifyDataItemBySql(string Sql,
                           StringDictionary dicItemData,
                           StringDictionary dicPrimarName,
                           StringDictionary dicUserColum);


       /// <summary>
       /// 修改基本信息数据
       /// </summary>
       /// <param name="TableName">数据表名称</param>
       /// <param name="dicItemFiledNm">数据字段名称</param>
       /// <param name="dicItemData">数据内容</param>
       /// <param name="dicPrimarName">主键列名</param>
       /// <param name="dicUserColum">操作员信息列名</param>
       /// <returns></returns>
       int SetModifyDataItem(string TableName,
                           StringDictionary dicItemFiledNm,
                           StringDictionary dicItemData,
                           StringDictionary dicPrimarName,
                           StringDictionary dicUserColum);


       #endregion

       #region 数据删除部分

       /// <summary>
       /// 删除基本信息数据
       /// </summary>
       /// <param name="TableName">数据表名称</param>
       /// <param name="dicItemData">数据内容</param>
       /// <param name="dicPrimarName">主键列名</param>
       /// <returns></returns>
       int SetDeleteDataItem(string TableName,
                           StringDictionary dicItemData,
                           StringDictionary dicPrimarName);


       #endregion

       #endregion
    }
}
