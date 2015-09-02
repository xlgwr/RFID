using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace Framework.Libs
{
    [Serializable]
    public class SysRun
    {

        private Common.DataSourceType _strDataSourceType;
        //[Bindable(true), DefaultValueAttribute(Common.DataSourceType.SQLServer), Category("一般参数设定"), DescriptionAttribute("数据源类型")]
        public Common.DataSourceType DataSourceType
        {
            get
            {
                return _strDataSourceType;
            }
            set
            {
                if (_strDataSourceType == value)
                    return;
                _strDataSourceType = value;
            }
        }

        private string _strServerName = "";
        //[Bindable(true), DefaultValueAttribute(""), Category("数据库设定"), DescriptionAttribute("服务器名称")]
        public string ServerName
        {
            get
            {
                if (_strServerName == null)
                    _strServerName = "";
                return _strServerName;
            }
            set
            {
                if (_strServerName == null)
                    _strServerName = "";
                else
                    _strServerName = value;
            }
        }

        private string _strDataBaseName = "";
        //[Bindable(true), DefaultValueAttribute(""), Category("数据库设定"), DescriptionAttribute("数据库名称")]
        public string DataBaseName
        {
            get
            {
                if (_strDataBaseName == null)
                    _strDataBaseName = "";
                return _strDataBaseName;
            }
            set
            {
                if (_strDataBaseName == null)
                    _strDataBaseName = "";
                else
                    _strDataBaseName = value;
            }
        }

        private string _strUserName="";
        //[Bindable(true), DefaultValueAttribute(""), Category("数据库设定"), DescriptionAttribute("登录用户")]
        public string UserName
        {
            get
            {
                if (_strUserName == null)
                    _strUserName = "";
                return _strUserName;
            }
            set
            {
 
                if (_strUserName == null)
                    _strUserName = "";
                else
                    _strUserName = value;
            }
        }

        private string _strPassWord = "";
        //[Bindable(true), DefaultValueAttribute(""), Category("数据库设定"), DescriptionAttribute("密码")]
        public string PassWord
        {
            get
            {

                if (_strPassWord == null)
                    _strPassWord = "";
                return _strPassWord;
            }
            set
            {
                if (_strPassWord == null)
                    _strPassWord = "";
                else
                    _strPassWord = value;
            }
        }

        private Common.Language _Language;
        //[Bindable(true), Category("一般参数设定"), DescriptionAttribute("显示语言")]
        public Common.Language Language
        {
            get
            {
                return _Language;
            }
            set
            {
                if (_Language == value)
                    return;
                _Language = value;
            }
        }

        private string _strMessageInfo;
        //[Bindable(true), DefaultValueAttribute(""), Category("一般参数设定"), DescriptionAttribute("提示信息")]
        public string MessageInfo
        {
            get
            {
                return _strMessageInfo;
            }
            set
            {
                if (_strMessageInfo == value)
                    return;
                _strMessageInfo = value;
            }
        }
    }
}
