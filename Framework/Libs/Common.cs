using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Collections;
using System.Data;
using System.Text.RegularExpressions;
using System.Drawing ;
using System.Diagnostics;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using Framework.Properties;
using Framework.DataAccess;

namespace Framework.Libs
{
    public partial class Common
    {

        #region  画面输入控件处理

        #endregion

        #region 控件属性设置

        #endregion

        #region 数据加密处理


        /// <summary>
        /// 数据加密处理
        /// </summary>
        /// <param name="_password"></param>
        /// <returns></returns>
        public static string EncryptPassWord(string _password)
        {
            return Encryption.Encode(_password);
        }

        /// <summary>
        /// 数据解密处理
        /// </summary>
        /// <param name="_password"></param>
        /// <returns></returns>
        public static string DecryptPassWord(string _password)
        {
            return Encryption.Decode(_password);
        }

        #endregion

        #region 获取Guid处理

        /// <summary>
        /// 获取Guid处理
        /// </summary>
        /// <returns></returns>
        public static string GetGuid()
        {
            return System.Guid.NewGuid().ToString().Replace("-", "").ToUpper();
        }

        #endregion
        
        #region 获取无线信号处理

        //***********************************************************************
        //Process   Name : GetWifiStateInfo
        //Introduce　　　: 获取无线信号处理/
        //Parameter　　　: the RSSI value. the normal values for the RSSI value are between -10 and -200
        //Return    Value: 
        //Creat     Date : 2011/08/01 xuxiaohu
        //Update    Date : 
        //Memo　　　　　 : 
        //***********************************************************************
        public static Bitmap GetWifiStateInfo(int RtnFlag)
        {

            Bitmap w_Bitmap = Resources.Default_0_AirPort;

            try
            {
                //-10 and -200
                if (RtnFlag >= -180 && RtnFlag < -120)
                {

                    w_Bitmap = Resources.Default_1_AirPort;
                }
                else if (RtnFlag >= -120 && RtnFlag < -60)
                {

                    w_Bitmap = Resources.Default_2_AirPort;
                }
                else if (RtnFlag >= -60 && RtnFlag <= -10)
                {
                    w_Bitmap = Resources.Default_3_AirPort;
                }
            }
            catch (Exception)
            {
                throw;
            }

            return w_Bitmap;
        }

    #endregion

        #region 获取电池容量处理

    [DllImport("coredll.dll")]
    private static extern uint GetSystemPowerStatusEx(SYSTEM_POWER_STATUS_EX lpSystemPowerStatus,
      bool fUpdate);

    //public struct SYSTEM_POWER_STATUS_EX2
    //{ //c# Windows CE读取电池电量的实现
    //    public byte ACLineStatus;
    //    public byte BatteryFlag;
    //    public byte BatteryLifePercent;
    //    public byte Reserved1;
    //    public uint BatteryLifeTime;
    //    public uint BatteryFullLifeTime;
    //    public byte Reserved2;
    //    public byte BackupBatteryFlag;
    //    public byte BackupBatteryLifePercent;
    //    public byte Reserved3;
    //    public uint BackupBatteryLifeTime;
    //    public uint BackupBatteryFullLifeTime;
    //    public uint BatteryVoltage;
    //    public uint BatteryCurrent;
    //    public uint BatteryAverageCurrent;
    //    public uint BatteryAverageInterval;
    //    public uint BatterymAHourConsumed;
    //    public uint BatteryTemperature;
    //    public uint BackupBatteryVoltage;
    //    public byte BatteryChemistry;
    //} 

    public class SYSTEM_POWER_STATUS_EX
    {
        public byte ACLineStatus;
        public byte BatteryFlag;
        public byte BatteryLifePercent;
        public byte Reserved1;
        public uint BatteryLifeTime;
        public uint BatteryFullLifeTime;
        public byte Reserved2;
        public byte BackupBatteryFlag;
        public byte BackupBatteryLifePercent;
        public byte Reserved3;
        public uint BackupBatteryLifeTime;
        public uint BackupBatteryFullLifeTime;
    }


    //***********************************************************************
    //Process   Name : GetPowerState
    //Introduce　　　: 获取电池容量处理/
    //Parameter　　　: 
    //Return    Value: 
    //Creat     Date : 2011/08/01 xuxiaohu
    //pdate    Date : 
    //Memo　　　　　 : 
    //***********************************************************************
    public static Bitmap GetPowerState()
    {

        Bitmap w_Bitmap = Resources.Default_BatteryLowBG;

        try
        {
          
            SYSTEM_POWER_STATUS_EX status = new SYSTEM_POWER_STATUS_EX();
            if (GetSystemPowerStatusEx(status, false) == 1)
            {

                //0 and 100
                if (status.BatteryLifePercent >= 80 )
                {
                    //电量:80%以上
                    w_Bitmap = Resources.Default_Battery80 ;
                }
                else if (status.BatteryLifePercent >= 60 && status.BatteryLifePercent < 80)
                {
                    //电量:60%以上
                    w_Bitmap = Resources.Default_Battery60;
                }
                else if (status.BatteryLifePercent >= 40 && status.BatteryLifePercent < 60)
                {
                     //电量:40%以上
                    w_Bitmap = Resources.Default_Battery40 ;
                }
                   else if (status.BatteryLifePercent < 40)
                {
                    //电量低：40以下
                    w_Bitmap = Resources.Default_BatteryLowBG;
                }
            }
        }
        catch (Exception)
        {
            throw;
        }

        return w_Bitmap;
    }

    #endregion



    /// <summary>
    /// 获取结束时间处理
    /// </summary>
    /// <param name="strEndTime"></param>
    /// <returns></returns>
    public static string GetBeginTimeBySql(string strEndTime)
    {
        DateTime dtEnd;
        string w_strRtnData;

        try
        {

            w_strRtnData = strEndTime;

            //if (DateTime.TryParse(strEndTime, out dtEnd) == true)
            //{
            //    w_strRtnData = DateTime.Parse(dtEnd.ToString("yyyy/MM/dd HH:mm")).AddSeconds(-1).ToString();
            //}

            //w_strRtnData = DateTime.Parse(strEndTime.ToString("yyyy/MM/dd HH:mm")).AddSeconds(-1).ToString();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return w_strRtnData;
    }


    /// <summary>
    /// 获取结束时间处理
    /// </summary>
    /// <param name="strEndTime"></param>
    /// <returns></returns>
    public static string GetEndTimeBySql(string strEndTime)
    {
        DateTime dtEnd;
        string w_strRtnData;

        try
        {

            w_strRtnData = strEndTime;

            //if (DateTime.TryParse(strEndTime, out dtEnd) == true)
            //{
            //    w_strRtnData = DateTime.Parse(dtEnd.ToString("yyyy/MM/dd HH:mm")).AddMinutes(1).ToString();
            //}

            //w_strRtnData = DateTime.Parse(strEndTime.ToString("yyyy/MM/dd HH:mm")).AddMinutes(1).ToString();

        }
        catch (Exception ex)
        {
            throw ex;
        }
        return w_strRtnData;
    }


    /// <summary>
    /// 获取数据Bit字段内容值
    /// </summary>
    /// <returns></returns>
    public static bool GetBitValue(string CheckedValue)
    {
        bool Value = false;

        switch (Common._datasourcetype)
        {
            case Common.DataSourceType.SQLServer:

                Value = CheckedValue.ToLower() == "true" ? true : false; ;

                break;

            case Common.DataSourceType.MySQL:

                Value = CheckedValue == "1" ? true : false;

                break;
            //case Common.DataSourceType .Oracle:

            //    break;
            //case Common.DataSourceType .Access:
            //    break;

            //case Common.DataSourceType .TXT:
            //    break;

        }

        return Value;

    }

    /// <summary>
    /// 获取数据Bit字段内容值
    /// </summary>
    /// <returns></returns>
    public static string SetBitValue(string CheckedValue)
    {
        string Value = "";

        switch (Common._datasourcetype)
        {
            case Common.DataSourceType.SQLServer:

                Value = CheckedValue;

                break;

            case Common.DataSourceType.MySQL:

                Value = CheckedValue.ToLower() == "true" ? "1" : "0";

                break;
            //case Common.DataSourceType .Oracle:

            //    break;
            //case Common.DataSourceType .Access:
            //    break;

            //case Common.DataSourceType .TXT:
            //    break;

        }

        return Value;

    }

    /// <summary>
    /// 获取数据库业务对象
    /// </summary>
    /// <returns></returns>
    public static void GetDaoCommon(ref CBaseConnect daoCommon)
    {

        switch (Common._datasourcetype)
        {
            case Common.DataSourceType.SQLServer:

                daoCommon = new daoCommonSQLServer();

                break;

            case Common.DataSourceType.MySQL:

                daoCommon = new daoCommonMySql();

                break;
            //case Common.DataSourceType .Oracle:

            //    break;
            //case Common.DataSourceType .Access:
            //    break;

            //case Common.DataSourceType .TXT:
            //    break;

        }
    }

    /// <summary>
    /// 获取绑定多语言字段名
    /// </summary>
    /// <returns></returns>
    public static string GetBindFieldName(string FiledName)
    {
        string FieldName = "";

        if (Common._sysrun.Language == Language.Chinese)
        {
            FieldName = FiledName + "_Cn";

        }
        else if (Common._sysrun.Language == Language.Janpanese)
        {
            FieldName = FiledName + "_Jp";

        }
        else if (Common._sysrun.Language == Language.English)
        {
            FieldName = FiledName + "_En";
        }
        else
        {
            FieldName = FiledName + "_Cn";
        }


        return FieldName;
    }

    /// <summary>
    /// 获取绑定多语言字段名
    /// </summary>
    /// <param name="LanguageKey"></param>
    /// <param name="FiledName"></param>
    /// <returns></returns>
    public static string GetBindFieldName(Language LanguageKey, string FiledName)
    {
        string FieldName = "";

        if (LanguageKey == Language.Chinese)
        {
            FieldName = FiledName + "_Cn";

        }
        else if (LanguageKey == Language.Janpanese)
        {
            FieldName = FiledName + "_Jp";

        }
        else if (LanguageKey == Language.English)
        {
            FieldName = FiledName + "_En";
        }
        else
        {
            FieldName = FiledName + "_Cn";
        }


        return FieldName;
    }
    }
}
