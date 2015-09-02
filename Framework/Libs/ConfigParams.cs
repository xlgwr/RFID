using System;
//using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Framework.Libs
{
    
    public enum ConfigParams
    {
        //[Cfg("192.168.1.200", @"^(((([1]?\d)?\d|2[0-4]\d|25[0-5])\.){3}(([1]?\d)?\d|2[0-4]\d|25[0-5]))|([\da-fA-F]{1,4}(\:[\da-fA-F]{1,4}){7})|(([\da-fA-F]{1,4}:){0,5}::([\da-fA-F]{1,4}:){0,5}[\da-fA-F]{1,4})$", RegexOptions.IgnoreCase)]
        //DeviceAddress,
        //[Cfg("4", @"^\d+$", RegexOptions.None)]
        //AntennasCount,
        //[Cfg("3000,3000,3000,3000", @"^\d+(,\d+)*$", RegexOptions.None)]
        //ReadPower,
        //[Cfg("3000,3000,3000,3000", @"^\d+(,\d+)*$", RegexOptions.None)]
        //WritePower,
        //[Cfg("gen2", @"^(GEN2|ISO180006B|IPX256|IPX64)[,(GEN2|ISO180006B|IPX256|IPX64)]*$", RegexOptions.IgnoreCase)]
        //Protocols,

        //[Cfg("5000", @"^\d+$", RegexOptions.None)]
        //DaInterval,
        //[Cfg("30000", @"^\d+$", RegexOptions.None)]
        //UpInterval,
        //[Cfg("0", "(0|1|2|3)", RegexOptions.None)]
        //Gen2Session,
        //[Cfg("200", @"^\d+$", RegexOptions.None)]
        //ReadTimeout,
        //[Cfg("300", @"^\d+$", RegexOptions.None)]
        //SleepInterval,
        //[Cfg("1", "^(0|1|true|false){1}$", RegexOptions.IgnoreCase)]
        //CheckAntenna,
        //[Cfg("999", @"^\d+$", RegexOptions.None)]
        //RestartCode,
        //[Cfg("192.168.1.4", @"^(((([1]?\d)?\d|2[0-4]\d|25[0-5])\.){3}(([1]?\d)?\d|2[0-4]\d|25[0-5]))|([\da-fA-F]{1,4}(\:[\da-fA-F]{1,4}){7})|(([\da-fA-F]{1,4}:){0,5}::([\da-fA-F]{1,4}:){0,5}[\da-fA-F]{1,4})$", RegexOptions.IgnoreCase)]
        //SqlServerIP,
        //[Cfg("sa", "*", RegexOptions.None)]
        //SqlServerSA,
        //[Cfg("", "*", RegexOptions.None)]
        //SqlServerPW,
        //[Cfg("0", "*", RegexOptions.None)]
        //ServerStatus,

        /// <summary>
        /// 采集器编号
        /// </summary>
        [Cfg("1", "^[a-zA-Z_0-9]+$", RegexOptions.None)]
        DeviceNo,

        /// <summary>
        /// 循环周期(卡循环使用一次最少用时,单位:分钟)
        /// </summary>
        [Cfg("90", @"\d+$", RegexOptions.None)]
        CycInterval,

        /// <summary>
        /// 采集器功能类型
        /// </summary>
        [Cfg("-1", "*", RegexOptions.None)]
        DeviceFuncType
    }

    /// <summary>
    /// 卡的状态
    /// </summary>
    public enum CardStatus : int
    {
        /// <summary>
        /// 新扫描
        /// </summary>
        NewInsert = 0,
        /// <summary>
        /// 准备上传
        /// </summary>
        ForUpload = 1,
        /// <summary>
        /// 已经上传
        /// </summary>
        Uploaded = 2
    }

    public class CfgAttribute : Attribute
    {
        public String DefaultValue { get; set; }
        public String StringMatch { get; set; }
        public RegexOptions RegexOption { get; set; }
        public CfgAttribute(String defVal, String valMatch, RegexOptions regOpt)
        {
            this.DefaultValue = defVal;
            this.StringMatch = valMatch;
            this.RegexOption = regOpt;
        }

        public static T GetAttribute<T>(Enum enumObj)
        where T : Attribute
        {
            System.Reflection.FieldInfo fieldInfo = enumObj.GetType().GetField(enumObj.ToString());
            object[] attribArray = fieldInfo.GetCustomAttributes(false);
            if (attribArray.Length == 0)
                return default(T);
            else
            {
                T attrib = (T)attribArray[0];
                if (attrib != null)
                    return attrib;
                else
                    return default(T);
            }
        }
    }
}
