using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Text;
using Framework.DataAccess;
using Framework.Libs;
using System.Windows.Forms;

namespace AnXinWH.RFIDScan.Libs
{
    public class busUploadScan
    {

        //#region 变量定义

        //public CBaseConnect m_daoCommon ;

        //private StringDictionary dicItemData = new StringDictionary();
        //private StringDictionary dicConds = new StringDictionary();
        //private StringDictionary dicLikeConds = new StringDictionary();
   
        //#endregion

        //#region 初始化处理

   
        //#endregion

        ///// <summary>
        ///// 获取部品信息
        ///// </summary>
        ///// <returns></returns>
        //public void GetPrdctDefInfo(string RFIDCardNo , ref string PrdctCd , ref string RequestNum )
        //{

        //    DataTable tblProductInfo;

        //    try
        //    {
        //        PrdctCd = "";
        //        RequestNum = "";

        //        //=============获取部品信息===============

        //        dicItemData.Clear();
        //        dicConds.Clear();
        //        dicLikeConds.Clear();
        //        dicConds[T_RFIDDefine.RFIDCardNo] = "true";
        //        dicItemData[T_RFIDDefine.RFIDCardNo] = RFIDCardNo;

        ////        //tblProductInfo = this.m_daoCommon.GetTableInfo(T_RFIDDefine.Grid_PrdctDefInfo , dicItemData, dicConds, dicLikeConds, "");

        //        if (tblProductInfo != null && tblProductInfo.Rows.Count > 0)
        //        {

        //            PrdctCd = tblProductInfo.Rows[0][M_ProductInfo.PrdctCd].ToString();
        //            RequestNum = tblProductInfo.Rows[0][T_RFIDDefine.RequestNum].ToString();
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("获取部品信息失败，请检查网络是否正常连接！", Declare.Info_SysName,
        //                      MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        //        throw ex;
        //    }
        //}

        ///// <summary>
        ///// 获取工作时间信息(更新本地参数信息)
        ///// </summary>
        ///// <returns></returns>
        //public bool GetWorkTimeInfo()
        //{

        //    DataTable tblWorkTime;
        //    bool isCheck = false;

        //    try
        //    {

        //        //=============获取工作时间信息===============

        //        dicItemData.Clear();
        //        dicConds.Clear();
        //        dicLikeConds.Clear();
             
        //        dicConds[M_SysWorkParameter.LateEnable] = "true";
        //        dicItemData[M_SysWorkParameter.LateEnable] = "true";

        //        //tblWorkTime = this.m_daoCommon.GetTableInfo(M_SysWorkParameter.TableName, dicItemData, dicConds, dicLikeConds, "");
               
        //        if (tblWorkTime == null || tblWorkTime.Rows.Count <= 0)
        //        {

        //            MessageBox.Show("系统工作时间未设定，请与供应商联系！", Declare.Info_SysName,
        //                        MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);

        //            return false;
        //        }

        //        //=================更新工作时间到本地===================
        //        daoSqlLite.Instance.FectchWorkTime(Common._lastUpdTime, tblWorkTime);

        //        //LogManager.WriteLog(Common.LogFile.Trace, "FectchWorkTime End ");

        //        //更新参数信息到本地
        //        daoSqlLite.Instance.UpdateParam(ConfigParams.DeviceNo.ToString(), Common._terminalNo);
        //        daoSqlLite.Instance.UpdateParam(ConfigParams.DeviceFuncType.ToString(), Common._deviceFuncType.ToString());
        //        daoSqlLite.Instance.UpdateParam(ConfigParams.CycInterval.ToString(), Common._card_filter_maxtime.ToString());

        //        //LogManager.WriteLog(Common.LogFile.Trace, "UpdateParam End ");

        //        isCheck = true;

        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    return isCheck;
        //}


        ///// <summary>
        ///// 南华送货运输超时
        ///// </summary>
        ///// <param name="device_no"></param>
        ///// <param name="epc"></param>
        ///// <param name="overtime"></param>
        ///// <returns>如果获取超时时长失败存储过程返回负数，overtime都返回0</returns>
        //public int GetNHOverTime(string epc, ref int overtime)
        //{

        //    int ret = -1;
        //    //SqlCommand w_cmdRet;
        //    //SqlParameter[] cmdParamters = null;
        //    //SqlParameter SqlParameter = null;

        //    //try
        //    //{
        //    //    string CommandText = "GetNHOverTime";
        //    //    cmdParamters = new SqlParameter[3];

        //    //    SqlParameter = new SqlParameter("@epc", SqlDbType.NVarChar);
        //    //    SqlParameter.Value = epc;
        //    //    SqlParameter.Direction = ParameterDirection.Input;
        //    //    cmdParamters[0] = SqlParameter;

        //    //    SqlParameter = new SqlParameter("@out_overtime", SqlDbType.Int);
        //    //    SqlParameter.Value = 0;
        //    //    SqlParameter.Direction = ParameterDirection.Output;
        //    //    cmdParamters[1] = SqlParameter;

        //    //    SqlParameter = new SqlParameter("@returnValue", SqlDbType.Int);
        //    //    SqlParameter.Value = 0;
        //    //    SqlParameter.Direction = ParameterDirection.ReturnValue;
        //    //    cmdParamters[2] = SqlParameter;

        //    //    //w_cmdRet = Common.AdoConnect.Connect.SetExecuteSP(CommandText, cmdParamters);

        //    //    //if (w_cmdRet != null)
        //    //    //{
        //    //    //    ret =(int) w_cmdRet.Parameters["@returnValue"].Value;

        //    //    //    if (ret > 0)
        //    //    //    {
        //    //    //        overtime = Convert.ToInt32(w_cmdRet.Parameters["@out_overtime"].Value);
        //    //    //    }
        //    //    //}   

        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;
        //    //}

        //    return ret;
        //}


        ///// <summary>
        ///// 获取部品送货超时时长
        ///// </summary>
        ///// <param name="device_no"></param>
        ///// <param name="epc"></param>
        ///// <returns>如果获取超时时长失败存储过程返回负数，overtime和overtime_nh都返回0</returns>
        //public int GetOverTime(string epc, ref int overtime, ref int overtime_nh)
        //{
        //    int ret = -1;
        //    //SqlCommand w_cmdRet;
        //    //SqlParameter[] cmdParamters = null;
        //    //SqlParameter SqlParameter = null;

        //    //try
        //    //{
        //    //    string CommandText = "GetOverTime";
        //    //    cmdParamters = new SqlParameter[4];

        //    //    SqlParameter = new SqlParameter("@epc", SqlDbType.NVarChar);
        //    //    SqlParameter.Value = epc ;
        //    //    SqlParameter.Direction = ParameterDirection.Input;
        //    //    cmdParamters[0] = SqlParameter;

        //    //    SqlParameter = new SqlParameter("@out_overtime", SqlDbType.Int);
        //    //    SqlParameter.Value = 0;
        //    //    SqlParameter.Direction = ParameterDirection.Output;
        //    //    cmdParamters[1] = SqlParameter;

        //    //    SqlParameter = new SqlParameter("@out_overtime_nh", SqlDbType.Int);
        //    //    SqlParameter.Value = 0;
        //    //    SqlParameter.Direction = ParameterDirection.Output;
        //    //    cmdParamters[2] = SqlParameter;

        //    //    SqlParameter = new SqlParameter("@returnValue", SqlDbType.Int);
        //    //    SqlParameter.Value = 0;
        //    //    SqlParameter.Direction = ParameterDirection.ReturnValue ;
        //    //    cmdParamters[3] = SqlParameter;

        //    //    //w_cmdRet = Common.AdoConnect.Connect.SetExecuteSP(CommandText, cmdParamters);

        //    //    //if (w_cmdRet != null )
        //    //    //{
        //    //    //    ret = (int)w_cmdRet.Parameters["@returnValue"].Value;

        //    //    //    if (ret > 0)
        //    //    //    {
        //    //    //        overtime = Convert.ToInt32(w_cmdRet.Parameters["@out_overtime"].Value);
        //    //    //        overtime_nh = Convert.ToInt32(w_cmdRet.Parameters["@out_overtime_nh"].Value);
        //    //    //    }
        //    //    //}   
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    throw ex;
        //    //}

        //    return ret;
        //}

        ///// <summary>
        ///// 将采集信息保存到SQL Server
        ///// </summary>
        ///// <param name="device_no"></param>
        ///// <param name="epc"></param>
        ///// <param name="dadatetime"></param>
        ///// <param name="expireTime"></param>
        ///// <param name="expireTime_nh"></param>
        ///// <returns></returns>
        //public int UploadDaRecord(int idx, string device_no, string epc, DateTime dadatetime, DateTime? expireTime, DateTime? expireTime_nh)
        //{
        //    //log.DebugFormat("采集时间：{0},入库限期：{1},出库限期：{2}", dadatetime, expireTime, expireTime_nh);
        //    int ret = 0;

        //    //SqlCommand w_cmdRet;
        //    //SqlParameter[] cmdParamters = null;
        //    //SqlParameter SqlParameter = null;

        //    //try
        //    //{
        //    //    string CommandText = "StoreDaRecord";
        //    //    cmdParamters = new SqlParameter[7];

        //    //    SqlParameter = new SqlParameter("@idx", SqlDbType.Int);
        //    //    SqlParameter.Value = idx;
        //    //    SqlParameter.Direction = ParameterDirection.Input;
        //    //    cmdParamters[0] = SqlParameter;

        //    //    SqlParameter = new SqlParameter("@device_no", SqlDbType.NVarChar);
        //    //    SqlParameter.Value = device_no;
        //    //    SqlParameter.Direction = ParameterDirection.Input;
        //    //    cmdParamters[1] = SqlParameter;

        //    //    SqlParameter = new SqlParameter("@epc", SqlDbType.NVarChar);
        //    //    SqlParameter.Value = epc;
        //    //    SqlParameter.Direction = ParameterDirection.Input;
        //    //    cmdParamters[2] = SqlParameter;

        //    //    SqlParameter = new SqlParameter("@da_datetime", SqlDbType.DateTime );
        //    //    SqlParameter.Value = dadatetime;
        //    //    SqlParameter.Direction = ParameterDirection.Input;
        //    //    cmdParamters[3] = SqlParameter;
                   
        //    //    SqlParameter = new SqlParameter("@expireTime", SqlDbType.DateTime);
        //    //    SqlParameter.Value = expireTime??(object)DBNull.Value;
        //    //    SqlParameter.Direction = ParameterDirection.Input;
        //    //    cmdParamters[4] = SqlParameter;

        //    //    SqlParameter = new SqlParameter("@expireTime_nh", SqlDbType.DateTime);
        //    //    SqlParameter.Value = expireTime_nh??(object)DBNull.Value;
        //    //    SqlParameter.Direction = ParameterDirection.Input;
        //    //    cmdParamters[5] = SqlParameter;

        //    //    SqlParameter = new SqlParameter("@returnValue", SqlDbType.Int);
        //    //    SqlParameter.Value = 0;
        //    //    SqlParameter.Direction = ParameterDirection.ReturnValue;
        //    //    cmdParamters[6] = SqlParameter;

        //    //    //w_cmdRet = Common.AdoConnect.Connect.SetExecuteSP(CommandText, cmdParamters);

        //    //    //if (w_cmdRet != null)
        //    //    //{
        //    //    //    ret = (int) w_cmdRet.Parameters["@returnValue"].Value;
        //    //    //}   
        //    //}
        //    //catch (Exception ex)
        //    //{

        //    //    ret = -9999;
        //    //    throw ex;
        
        //    //    //log.Error("UploadDaRecord:" + e.Message);
        //    //}
        //    return ret;
        //}
    }
}
