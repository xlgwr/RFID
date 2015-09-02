using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AnXinWH.RFIDScan
{
    static class Declare
    {

        public const int SW_HIDE = 0x0;

        public const int SW_SHOW = 0x1;
        //'系统名/
        public static string Info_SysName = "AGC图纸管理系统";

        //'系统数据启动加载,请稍候... 
        public static string Info_LoadS = "系统数据启动加载,请稍候... ";
        //'系统数据正在初始化...
        public static string Info_LoadC = "统数据正在初始化...";
        //'系统数据加载成功.
        public static string Info_LoadT = "系统数据加载成功";
        //'系统数据加载失败.
        public static string Info_LoadF = "系统数据加载失败";

        //'服务器连接中,请稍候...
        public static string Info_ConnC = "服务器连接中,请稍候...";
        //'服务器连接成功。
        public static string Info_ConnT = "服务器连接成功";
        //'服务器连接失败,请检查网络或服务器设置。
        public static string Info_ConnF = "服务器连接失败,请检查网络或服务器设置";

        //ErrorMessages
        public static string Err_Hasload = "系统已经启动,不能同时启动多个程序,请您确认。";
        public static string Err_NoSetup = "系统启动出现异常，系统文件可能已损坏，请检查安装文件或网络设置是否正常。";



    }
}
