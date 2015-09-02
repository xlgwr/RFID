using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace Framework.Libs
{
    public static class WinceReg
    {

        public enum HKEY
        {
            HKEY_LOCAL_MACHINE = 0,
            HKEY_CLASSES_ROOT = 1,
            HKEY_CURRENT_USER = 2,
            HKEY_USERS = 3
        };

        private static RegistryKey[] reg = new RegistryKey[4] { Registry.LocalMachine, 
                                                                Registry.ClassesRoot, 
                                                                Registry.CurrentUser, 
                                                                Registry.Users };

        //读指定变量值 
        public static string ReadValue(HKEY Root, string SubKey, string ValueName)
        {
            RegistryKey subKey = reg[(int)Root];
            if (ValueName.Length == 0) return "[ERROR]";
            try
            {
                if (SubKey.Length > 0)
                {
                    string[] strSubKey = SubKey.Split('\\');
                    foreach (string strKeyName in strSubKey)
                    {
                        subKey = subKey.OpenSubKey(strKeyName);
                    }
                }
                string strKey = subKey.GetValue(ValueName).ToString();
                subKey.Close();
                return strKey;
            }
            catch
            {
                return "[ERROR]";
            }
        }

        //读指定变量的类型 
        public static RegistryValueKind ReadValueType(HKEY Root, string SubKey, string ValueName)
        {
            RegistryKey subKey = reg[(int)Root];
            if (ValueName.Length == 0) return RegistryValueKind.Unknown;
            try
            {
                if (SubKey.Length > 0)
                {
                    string[] strSubKey = SubKey.Split('\\');
                    foreach (string strKeyName in strSubKey)
                    {
                        subKey = subKey.OpenSubKey(strKeyName);
                    }
                }
                RegistryValueKind valueType = subKey.GetValueKind(ValueName);
                subKey.Close();
                return valueType;
            }
            catch
            {
                return RegistryValueKind.Unknown;
            }
        }

        //写指定变量值 
        public static int WriteValue(HKEY Root, string SubKey, string ValueName, string ValueData)
        {
            return WriteValue(Root, SubKey, ValueName, ValueData, RegistryValueKind.String);
        }

        //写指定变量值 
        public static int WriteValue(HKEY Root, string SubKey, string ValueName, object ValueData, RegistryValueKind ValueType)
        {
            RegistryKey subKey = reg[(int)Root];
            if (ValueName.Length == 0) return 2;
            try
            {
                if (SubKey.Length > 0)
                {
                    string[] strSubKey = SubKey.Split('\\');
                    foreach (string strKeyName in strSubKey)
                    {
                        subKey = subKey.CreateSubKey(strKeyName);
                    }
                }
                subKey.SetValue(ValueName, ValueData, ValueType);
                subKey.Close();
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        //删除指定变量 
        public static int DeleteValue(HKEY Root, string SubKey, string ValueName)
        {
            RegistryKey subKey = reg[(int)Root];
            try
            {
                if (SubKey.Length > 0)
                {
                    string[] strSubKey = SubKey.Split('\\');
                    foreach (string strKeyName in strSubKey)
                    {
                        subKey = subKey.OpenSubKey(strKeyName, true);
                    }
                }
                subKey.DeleteValue(ValueName, true);
                subKey.Close();
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        //创建指定的键 
        public static int CreateKey(HKEY Root, string SubKey, string KeyName)
        {
            RegistryKey subKey = reg[(int)Root];
            if (KeyName.Length == 0) return 2;
            try
            {
                if (SubKey.Length > 0)
                {
                    string[] strSubKey = SubKey.Split('\\');
                    foreach (string strKeyName in strSubKey)
                    {
                        subKey = subKey.CreateSubKey(strKeyName);
                    }
                }
                subKey.CreateSubKey(KeyName);
                subKey.Close();
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        //删除指定的键 
        public static int DeleteKey(HKEY Root, string SubKey, string KeyName)
        {
            RegistryKey subKey = reg[(int)Root];
            try
            {
                if (SubKey.Length > 0)
                {
                    string[] strSubKey = SubKey.Split('\\');
                    foreach (string strKeyName in strSubKey)
                    {
                        subKey = subKey.OpenSubKey(strKeyName, true);
                    }
                }
                subKey.DeleteSubKeyTree(KeyName);
                subKey.Close();
                return 0;
            }
            catch
            {
                return 1;
            }
        }

        //判断指定的键是否存在 
        public static int IsExistKey(HKEY Root, string SubKey, string KeyName)
        {
            RegistryKey subKey = reg[(int)Root];
            try
            {
                if (SubKey.Length > 0)
                {
                    string[] strSubKey = SubKey.Split('\\');
                    foreach (string strKeyName in strSubKey)
                    {
                        subKey = subKey.OpenSubKey(strKeyName);
                    }
                }
                string[] strSubKey1 = subKey.GetSubKeyNames();
                foreach (string strKeyName in strSubKey1)
                {
                    if (strKeyName == KeyName) return 0;
                }
                return 1;
            }
            catch
            {
                return 2;
            }
        }

        //枚举指定的键的子键 
        public static string[] EnumKeyName(HKEY Root, string SubKey)
        {
            RegistryKey subKey = reg[(int)Root];
            if (SubKey.Length == 0) return null;
            try
            {
                string[] strSubKey = SubKey.Split('\\');
                foreach (string strKeyName in strSubKey)
                {
                    subKey = subKey.OpenSubKey(strKeyName);
                }
                string[] strKey = subKey.GetSubKeyNames();
                subKey.Close();
                return strKey;
            }
            catch
            {
                return null;
            }
        }

        //枚举指定的键的值 
        public static string[] EnumValueName(HKEY Root, string SubKey)
        {
            RegistryKey subKey = reg[(int)Root];
            if (SubKey.Length == 0) return null;
            try
            {
                string[] strSubKey = SubKey.Split('\\');
                foreach (string strKeyName in strSubKey)
                {
                    subKey = subKey.OpenSubKey(strKeyName);
                }
                string[] strValue = subKey.GetValueNames();
                subKey.Close();
                return strValue;
            }
            catch
            {
                return null;
            }
        }
    }
}
