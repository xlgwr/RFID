using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace AGCSystem
{

    public static class DataFiledTypeMySql
    {

        public static Dictionary<string, MySqlDbType> FiledType = new Dictionary<string, MySqlDbType>();

        static DataFiledTypeMySql()
        {


            //=========================================/
            //=========共通业务字段列数据类型==========/
            //=========================================/
            FiledType["slctvalue"] = MySqlDbType.Bit;
            FiledType["language"] = MySqlDbType.Int16;

            FiledType["emergtype"] = MySqlDbType.VarChar;
            FiledType["emergreason"] = MySqlDbType.VarChar;


            FiledType["classname_cn"] = MySqlDbType.VarChar;
            FiledType["classname_jp"] = MySqlDbType.VarChar;
            FiledType["classname_en"] = MySqlDbType.VarChar;


            // 区域表【M_Area】
            FiledType["areano"] = MySqlDbType.VarChar;
            FiledType["areaname"] = MySqlDbType.VarChar;
            FiledType["areatype"] = MySqlDbType.VarChar;
            FiledType["areatypenm"] = MySqlDbType.VarChar;
            FiledType["arearemark"] = MySqlDbType.VarChar;
            FiledType["areastatus"] = MySqlDbType.Bit;
            FiledType["adddatetime"] = MySqlDbType.DateTime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["upddatetime"] = MySqlDbType.DateTime;

            //原因表
            FiledType["reasonno"] = MySqlDbType.VarChar;
            FiledType["typeflag"] = MySqlDbType.VarChar;
            FiledType["reasoncontent"] = MySqlDbType.VarChar;
            FiledType["remark"] = MySqlDbType.VarChar;
            FiledType["adddatetime"] = MySqlDbType.DateTime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["upddatetime"] = MySqlDbType.DateTime;


            //T_图册越权报警
            FiledType["alarmno"] = MySqlDbType.VarChar;
            FiledType["docno"] = MySqlDbType.VarChar;
            FiledType["typeflag"] = MySqlDbType.VarChar;
            FiledType["terminalno"] = MySqlDbType.VarChar;
            FiledType["alarmdate"] = MySqlDbType.DateTime;

            //RFID采集器信息
            FiledType["terminalno"] = MySqlDbType.VarChar;
            FiledType["terminalname"] = MySqlDbType.VarChar;
            FiledType["areano"] = MySqlDbType.VarChar;
            FiledType["terminaltypeno"] = MySqlDbType.VarChar;
            FiledType["connectflag"] = MySqlDbType.Int32;
            FiledType["serialnoipaddr"] = MySqlDbType.VarChar;
            FiledType["agreement"] = MySqlDbType.Int32;
            FiledType["sessionfalg"] = MySqlDbType.Int32;
            FiledType["readtime"] = MySqlDbType.Int32;
            FiledType["readinterval"] = MySqlDbType.Int32;
            FiledType["antrdpower1"] = MySqlDbType.Int32;
            FiledType["antrdpower2"] = MySqlDbType.Int32;
            FiledType["antrdpower3"] = MySqlDbType.Int32;
            FiledType["antrdpower4"] = MySqlDbType.Int32;
            FiledType["antwrpower1"] = MySqlDbType.Int32;
            FiledType["antwrpower2"] = MySqlDbType.Int32;
            FiledType["antwrpower3"] = MySqlDbType.Int32;
            FiledType["antwrpower4"] = MySqlDbType.Int32;
            FiledType["antstartstatus1"] = MySqlDbType.Int32;
            FiledType["antstartstatus2"] = MySqlDbType.Int32;
            FiledType["antstartstatus3"] = MySqlDbType.Int32;
            FiledType["antstartstatus4"] = MySqlDbType.Int32;
            FiledType["trmnparamupdtime"] = MySqlDbType.DateTime;
            FiledType["trmnstarttime"] = MySqlDbType.DateTime;
            FiledType["trmnrunstatus"] = MySqlDbType.Int32;
            FiledType["trmnupdtime"] = MySqlDbType.DateTime;
            FiledType["define1"] = MySqlDbType.VarChar;
            FiledType["define2"] = MySqlDbType.VarChar;
            FiledType["define3"] = MySqlDbType.VarChar;
            FiledType["define4"] = MySqlDbType.VarChar;
            FiledType["define5"] = MySqlDbType.VarChar;
            FiledType["trmnremark"] = MySqlDbType.VarChar;
            FiledType["trmnstatus"] = MySqlDbType.Bit;
            FiledType["adddatetime"] = MySqlDbType.DateTime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["upddatetime"] = MySqlDbType.DateTime;
            FiledType["gplsignalport1"] = MySqlDbType.Int32;
            FiledType["gplsignalport2"] = MySqlDbType.Int32;
            FiledType["gplsignalport3"] = MySqlDbType.Int32;
            FiledType["gplsignalport4"] = MySqlDbType.Int32;
            FiledType["terminaltype"] = MySqlDbType.Int32;

            //部门信息
            FiledType["deptno"] = MySqlDbType.VarChar;
            FiledType["deptname"] = MySqlDbType.VarChar;
            FiledType["remark"] = MySqlDbType.VarChar;
            FiledType["adddatetime"] = MySqlDbType.DateTime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["upddatetime"] = MySqlDbType.DateTime;

            //用户信息
            FiledType["userno"] = MySqlDbType.VarChar;
            FiledType["deptno"] = MySqlDbType.VarChar;
            FiledType["username"] = MySqlDbType.VarChar;
            FiledType["passward"] = MySqlDbType.VarChar;
            FiledType["tel"] = MySqlDbType.VarChar;
            FiledType["status"] = MySqlDbType.Bit;
            FiledType["roleid"] = MySqlDbType.VarChar;
            FiledType["mobile"] = MySqlDbType.VarChar;
            FiledType["receivemsg"] = MySqlDbType.Bit;
            FiledType["begindate"] = MySqlDbType.DateTime;
            FiledType["enddate"] = MySqlDbType.DateTime;
            FiledType["language"] = MySqlDbType.Int16;
            FiledType["approval"] = MySqlDbType.Bit;
            FiledType["remark"] = MySqlDbType.VarChar;
            FiledType["adddatetime"] = MySqlDbType.DateTime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["upddatetime"] = MySqlDbType.DateTime;
            FiledType["mobile"] = MySqlDbType.VarChar;
            FiledType["position"] = MySqlDbType.VarChar;
            FiledType["emergtel1"] = MySqlDbType.VarChar;
            FiledType["emergtel2"] = MySqlDbType.VarChar;
            FiledType["emergtel3"] = MySqlDbType.VarChar;

            //画面定义
            FiledType["formid"] = MySqlDbType.VarChar;
            FiledType["functiontyp"] = MySqlDbType.VarChar;
            FiledType["formname"] = MySqlDbType.VarChar;
            FiledType["sortno"] = MySqlDbType.Int32;
            FiledType["frmstatus"] = MySqlDbType.Bit;


            //角色信息
            FiledType["roleid"] = MySqlDbType.VarChar;
            FiledType["rolename"] = MySqlDbType.VarChar;
            FiledType["remark"] = MySqlDbType.VarChar;
            FiledType["adddatetime"] = MySqlDbType.DateTime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["upddatetime"] = MySqlDbType.DateTime;

            //系统参数R/3信息
            FiledType["r3ipaddr"] = MySqlDbType.VarChar;
            FiledType["r3port"] = MySqlDbType.Int32;
            FiledType["r3folderpath"] = MySqlDbType.VarChar;
            FiledType["r3username"] = MySqlDbType.VarChar;
            FiledType["r3password"] = MySqlDbType.VarChar;
            FiledType["scanfilename2"] = MySqlDbType.VarChar;
            FiledType["scanmaxcnt2"] = MySqlDbType.Int32;
            FiledType["lcsfilename"] = MySqlDbType.VarChar;
            FiledType["lcstime"] = MySqlDbType.DateTime;
            FiledType["lcsmaxcnt"] = MySqlDbType.Int32;
            FiledType["termtypfilename"] = MySqlDbType.VarChar;
            FiledType["termtyptime"] = MySqlDbType.DateTime;
            FiledType["termtypmaxcnt"] = MySqlDbType.Int32;
            FiledType["cardfiltermaxtime"] = MySqlDbType.Int32;
            FiledType["r3define1"] = MySqlDbType.DateTime;
            FiledType["r3define2"] = MySqlDbType.DateTime;
            FiledType["r3define5"] = MySqlDbType.VarChar;
            FiledType["r3define6"] = MySqlDbType.VarChar;
            FiledType["r3define7"] = MySqlDbType.VarChar;
            FiledType["remark"] = MySqlDbType.VarChar;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["upddatetime"] = MySqlDbType.DateTime;


            //系统参数(WMS)信息
            FiledType["wmsipaddr"] = MySqlDbType.VarChar;
            FiledType["wmsport"] = MySqlDbType.Int32;
            FiledType["delivername"] = MySqlDbType.VarChar;
            FiledType["delivmaxcnt"] = MySqlDbType.Int32;
            FiledType["edelivfilename"] = MySqlDbType.VarChar;
            FiledType["edelivmaxcnt"] = MySqlDbType.Int32;
            FiledType["nhstatusfilename"] = MySqlDbType.VarChar;
            FiledType["nhstatusmaxcnt"] = MySqlDbType.Int32;
            FiledType["delivfrequency"] = MySqlDbType.Int32;
            FiledType["wmsdefine1"] = MySqlDbType.DateTime;
            FiledType["wmsdefine2"] = MySqlDbType.DateTime;
            FiledType["wmsdefine5"] = MySqlDbType.VarChar;
            FiledType["wmsdefine6"] = MySqlDbType.VarChar;
            FiledType["wmsdefine7"] = MySqlDbType.VarChar;
            FiledType["remark"] = MySqlDbType.VarChar;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["upddatetime"] = MySqlDbType.DateTime;

            FiledType["nhuploadfilename"] = MySqlDbType.VarChar;
            FiledType["nhuploadmaxcnt"] = MySqlDbType.Int32;

            //工作时间参数信息
            FiledType["orderno"] = MySqlDbType.Int32;
            FiledType["amtimestart"] = MySqlDbType.DateTime;
            FiledType["amtimeover"] = MySqlDbType.DateTime;
            FiledType["lateenable"] = MySqlDbType.Bit;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["upddatetime"] = MySqlDbType.DateTime;


            //配送超时参数信息
            FiledType["areatype"] = MySqlDbType.VarChar;
            FiledType["bigovertime"] = MySqlDbType.Int32;
            FiledType["midovertime"] = MySqlDbType.Int32;
            FiledType["smallovertime"] = MySqlDbType.Int32;
            FiledType["dinyovertime"] = MySqlDbType.Int32;
            FiledType["nhdelivovertime"] = MySqlDbType.Int32;
            FiledType["nhdelivremind"] = MySqlDbType.Bit;
            FiledType["areainstovertime"] = MySqlDbType.Int32;
            FiledType["productprintovertime"] = MySqlDbType.Int32;
            FiledType["edelivdelaytime"] = MySqlDbType.Int32;
            FiledType["againalarmtime"] = MySqlDbType.Int32;


            //RFID卡绑定信息
            FiledType["rfidcardno"] = MySqlDbType.VarChar;
            FiledType["prdctid"] = MySqlDbType.VarChar;
            FiledType["itemid"] = MySqlDbType.VarChar;
            FiledType["requestnum"] = MySqlDbType.Decimal;
            FiledType["cardstatus"] = MySqlDbType.Bit;
            FiledType["adddatetime"] = MySqlDbType.DateTime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["upddatetime"] = MySqlDbType.DateTime;

            //类型定义
            FiledType["classno"] = MySqlDbType.VarChar;
            FiledType["classtype"] = MySqlDbType.Int32;
            FiledType["classname"] = MySqlDbType.VarChar;
            FiledType["classstatus"] = MySqlDbType.Bit;
            FiledType["adddatetime"] = MySqlDbType.DateTime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["upddatetime"] = MySqlDbType.DateTime;


            //日志信息
            FiledType["recordid"] = MySqlDbType.VarChar;
            FiledType["formid"] = MySqlDbType.VarChar;
            FiledType["functionid"] = MySqlDbType.Int32;
            FiledType["operatetyp"] = MySqlDbType.Int32;
            FiledType["remark"] = MySqlDbType.VarChar;
            FiledType["adddatetime"] = MySqlDbType.DateTime;
            FiledType["adduserno"] = MySqlDbType.VarChar;

            FiledType["upddatetime"] = MySqlDbType.DateTime;


            //配送报警信息
            FiledType["reqwarnrecdno"] = MySqlDbType.VarChar;
            FiledType["prdctid"] = MySqlDbType.VarChar;
            FiledType["terminalno"] = MySqlDbType.VarChar;
            FiledType["rfidcardno"] = MySqlDbType.VarChar;
            FiledType["reqstwarntype"] = MySqlDbType.Int32;
            FiledType["reqwarnseason"] = MySqlDbType.VarChar;
            FiledType["reqwarnremark"] = MySqlDbType.VarChar;
            FiledType["reqststatus"] = MySqlDbType.Int32;
            FiledType["adddatetime"] = MySqlDbType.DateTime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["upddatetime"] = MySqlDbType.DateTime;

            //历史数据删除管理
            FiledType["historyno"] = MySqlDbType.VarChar;
            FiledType["delovertime"] = MySqlDbType.DateTime;
            FiledType["remark"] = MySqlDbType.VarChar;
            FiledType["status"] = MySqlDbType.Bit;

            //基本数据备份
            FiledType["backupno"] = MySqlDbType.VarChar;
            FiledType["filename"] = MySqlDbType.DateTime;

            //自定义颜色
            FiledType["colorno"] = MySqlDbType.VarChar;
            FiledType["colorvalue"] = MySqlDbType.VarChar;
            FiledType["colorremark"] = MySqlDbType.VarChar;


            FiledType["depltime1"] = MySqlDbType.VarChar;

            FiledType["sortno"] = MySqlDbType.Bit;
            FiledType["nhdelivstatus"] = MySqlDbType.VarChar;
            FiledType["ReqWarnRecdNo"] = MySqlDbType.VarChar;
            FiledType["ReqstWarnType"] = MySqlDbType.Int32;

            #region 图纸
            FiledType["docno"] = MySqlDbType.VarChar;
            FiledType["docname_cn"] = MySqlDbType.VarChar;
            FiledType["docname_jp"] = MySqlDbType.VarChar;
            FiledType["makenumbers"] = MySqlDbType.VarChar;
            FiledType["pages"] = MySqlDbType.Int32;
            FiledType["docmaintitle_jp"] = MySqlDbType.VarChar;
            FiledType["docmaintitle_cn"] = MySqlDbType.VarChar;
            FiledType["docsubtitle_cn1"] = MySqlDbType.VarChar;
            FiledType["docsubtitle_jp1"] = MySqlDbType.VarChar;
            FiledType["docsubtitle_cn3"] = MySqlDbType.VarChar;
            FiledType["docsubtitle_cn2"] = MySqlDbType.VarChar;
            FiledType["docsubtitle_jp2"] = MySqlDbType.VarChar;
            FiledType["docsubtitle_jp3"] = MySqlDbType.VarChar;
            FiledType["tagno1"] = MySqlDbType.VarChar;
            FiledType["tagno2"] = MySqlDbType.VarChar;
            FiledType["tagno3"] = MySqlDbType.VarChar;
            FiledType["readenable"] = MySqlDbType.Bit;
            FiledType["copyenable"] = MySqlDbType.Bit;
            FiledType["lentenable"] = MySqlDbType.Bit;
            FiledType["remark"] = MySqlDbType.VarChar;
            FiledType["inventstatus"] = MySqlDbType.Int16;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["adddatetime"] = MySqlDbType.DateTime;
            FiledType["upddatetime"] = MySqlDbType.DateTime;
            //FiledType["usedstatus"] = MySqlDbType.Int16;
            #endregion

            #region 图册借出申请

            FiledType["applicationno"] = MySqlDbType.VarChar;
            FiledType["lentdate"] = MySqlDbType.DateTime;
            FiledType["returndate"] = MySqlDbType.DateTime;
            FiledType["appuserno"] = MySqlDbType.VarChar;
            //FiledType["usedstatus"] = MySqlDbType.Int16;
            FiledType["adddatetime"] = MySqlDbType.DateTime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["upddatetime"] = MySqlDbType.DateTime;
            FiledType["auditdesiguserno"] = MySqlDbType.VarChar;

            #endregion

            #region 图册借出申请详细

            FiledType["applicationid"] = MySqlDbType.VarChar;
            FiledType["applicationno"] = MySqlDbType.VarChar;
            FiledType["auditdesiguserno"] = MySqlDbType.VarChar;
            FiledType["docno"] = MySqlDbType.VarChar;
            FiledType["readenable"] = MySqlDbType.Int16;
            FiledType["copyenable"] = MySqlDbType.Int16;
            FiledType["lentenable"] = MySqlDbType.Int16;
            FiledType["lentremark"] = MySqlDbType.VarChar;
            FiledType["apprvlstatus"] = MySqlDbType.Int16;
            FiledType["auditremark"] = MySqlDbType.VarChar;
            FiledType["audituserno"] = MySqlDbType.VarChar;
            FiledType["inventstatus"] = MySqlDbType.Int16;
            FiledType["usedstatus"] = MySqlDbType.Bit;
            FiledType["adddatetime"] = MySqlDbType.DateTime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["upddatetime"] = MySqlDbType.DateTime;
            FiledType["detaillentdate"] = MySqlDbType.DateTime;
            FiledType["detailreturndate"] = MySqlDbType.DateTime;

            #endregion

            #region 代理审批
            FiledType["agentno"] = MySqlDbType.VarChar;
            FiledType["userno"] = MySqlDbType.VarChar;
            FiledType["agenteduserno"] = MySqlDbType.VarChar;
            FiledType["begindate"] = MySqlDbType.DateTime;
            FiledType["enddate"] = MySqlDbType.DateTime;

            #endregion

            #region 短信发送

            FiledType["recdno"] = MySqlDbType.VarChar;
            FiledType["userno"] = MySqlDbType.VarChar;
            FiledType["mobile"] = MySqlDbType.VarChar;
            FiledType["messageinfo"] = MySqlDbType.Text;
            FiledType["status"] = MySqlDbType.Bit;
            FiledType["sendtime"] = MySqlDbType.DateTime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["upddatetime"] = MySqlDbType.DateTime;

            #endregion

            #region 借出原因采集器关联
            FiledType["terminalno"] = MySqlDbType.VarChar;
            FiledType["reasonno"] = MySqlDbType.VarChar;
            FiledType["adddatetime"] = MySqlDbType.DateTime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["upddatetime"] = MySqlDbType.DateTime;
            #endregion

            #region 图册归还
            FiledType["returnno"] = MySqlDbType.VarChar;
            FiledType["applicationid"] = MySqlDbType.VarChar;
            FiledType["docno"] = MySqlDbType.VarChar;
            FiledType["respuserno"] = MySqlDbType.VarChar;
            FiledType["returnuserno"] = MySqlDbType.VarChar;
            FiledType["returndate"] = MySqlDbType.DateTime;
            FiledType["returnid"] = MySqlDbType.VarChar;
            #endregion

            #region 盘点计划

            FiledType["inventoryno"] = MySqlDbType.VarChar;
            FiledType["inventbegindate"] = MySqlDbType.DateTime;
            FiledType["inventenddate"] = MySqlDbType.DateTime;
            FiledType["inventstatus"] = MySqlDbType.Int16;
            FiledType["inventuserno"] = MySqlDbType.VarChar;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["upddatetime"] = MySqlDbType.DateTime;

            #endregion

            #region 盘点详细

            FiledType["inventoryno"] = MySqlDbType.VarChar;
            FiledType["docno"] = MySqlDbType.VarChar;
            FiledType["inventstatus"] = MySqlDbType.Int16;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["inventflag"] = MySqlDbType.Int16;

            #endregion

            #region 系统设置

            FiledType["parmano"] = MySqlDbType.VarChar;
            FiledType["reconnectinterval"] = MySqlDbType.Int32;
            FiledType["updinterval"] = MySqlDbType.Int32;
            FiledType["repeatscaninterval"] = MySqlDbType.Int32;
            FiledType["dooracccomport"] = MySqlDbType.VarChar;
            FiledType["messagecomport"] = MySqlDbType.VarChar;
            FiledType["doormaxcnt"] = MySqlDbType.Int32;
            FiledType["alarminterval"] = MySqlDbType.Int32;

            #endregion

            #region  采集器对应关系表

            FiledType["relationno"] = MySqlDbType.VarChar;
            FiledType["terminalno"] = MySqlDbType.VarChar;
            FiledType["relation1"] = MySqlDbType.VarChar;
            FiledType["relation2"] = MySqlDbType.VarChar;
            FiledType["relation3"] = MySqlDbType.VarChar;
            FiledType["relation4"] = MySqlDbType.VarChar;
            FiledType["relation5"] = MySqlDbType.VarChar;
            FiledType["relation6"] = MySqlDbType.VarChar;
            FiledType["relation7"] = MySqlDbType.VarChar;
            FiledType["relation8"] = MySqlDbType.VarChar;

            #endregion

            #region 图册移动履历

            FiledType["resumeid"] = MySqlDbType.VarChar;
            FiledType["docno"] = MySqlDbType.VarChar;
            FiledType["terminalno"] = MySqlDbType.VarChar;
            FiledType["scantag"] = MySqlDbType.VarChar;
            FiledType["movietyp"] = MySqlDbType.Int32;
            FiledType["remark"] = MySqlDbType.VarChar;
            FiledType["moviedatetime"] = MySqlDbType.DateTime;

            #endregion

            #region 采集器异常报警

            FiledType["alarmno"] = MySqlDbType.VarChar;
            FiledType["alarmtype"] = MySqlDbType.Int16;
            FiledType["terminalno"] = MySqlDbType.VarChar;
            FiledType["alarmdate"] = MySqlDbType.DateTime;
            FiledType["alarmreason"] = MySqlDbType.Text;

            #endregion
        }

    }

}
