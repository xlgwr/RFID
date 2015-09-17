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


            #region anxinwh
            FiledType["status"] = MySqlDbType.Int16;
            FiledType["trmnstatus"] = MySqlDbType.Bit;
            FiledType["rolestatus"] = MySqlDbType.Bit;
            FiledType["frmstatus"] = MySqlDbType.Bit;
            FiledType["upddatetime"] = MySqlDbType.Datetime;
            FiledType["stockin_date"] = MySqlDbType.Datetime;
            FiledType["updtime"] = MySqlDbType.Datetime;
            FiledType["cash_date"] = MySqlDbType.Datetime;
            FiledType["trmnupdtime"] = MySqlDbType.Datetime;
            FiledType["stockout_date"] = MySqlDbType.Datetime;
            FiledType["checktime"] = MySqlDbType.Datetime;
            FiledType["addtime"] = MySqlDbType.Datetime;
            FiledType["alarmdate"] = MySqlDbType.Datetime;
            FiledType["paramupdtime"] = MySqlDbType.Datetime;
            FiledType["adddatetime"] = MySqlDbType.Datetime;
            FiledType["gwet"] = MySqlDbType.Float;
            FiledType["qty"] = MySqlDbType.Float;
            FiledType["nwet"] = MySqlDbType.Float;
            FiledType["nwgt"] = MySqlDbType.Float;
            FiledType["pqty"] = MySqlDbType.Float;
            FiledType["gwgt"] = MySqlDbType.Float;
            FiledType["terminaltype"] = MySqlDbType.Int32;
            FiledType["readinterval"] = MySqlDbType.Int32;
            FiledType["cls_typno"] = MySqlDbType.Int32;
            FiledType["type"] = MySqlDbType.Int32;
            FiledType["islast"] = MySqlDbType.Int32;
            FiledType["connectflag"] = MySqlDbType.Int32;
            FiledType["downtype"] = MySqlDbType.Int32;
            FiledType["readtime"] = MySqlDbType.Int32;
            FiledType["alarmflag"] = MySqlDbType.Int32;
            FiledType["iconic"] = MySqlDbType.Int32;
            FiledType["log_id"] = MySqlDbType.Int32;
            FiledType["sort"] = MySqlDbType.Int32;
            FiledType["modelflag"] = MySqlDbType.Int32;
            FiledType["sortno"] = MySqlDbType.Int32;
            FiledType["recd_id"] = MySqlDbType.Int32;
            FiledType["result"] = MySqlDbType.Int16;
            FiledType["alarmtype"] = MySqlDbType.Int16;
            FiledType["opr_code"] = MySqlDbType.Int16;
            FiledType["paramtype"] = MySqlDbType.Int16;
            FiledType["flag"] = MySqlDbType.Int16;
            FiledType["type"] = MySqlDbType.Int16;
            FiledType["adjunct_address"] = MySqlDbType.VarChar;
            FiledType["depot_nm"] = MySqlDbType.VarChar;
            FiledType["relationno"] = MySqlDbType.VarChar;
            FiledType["paramval18"] = MySqlDbType.VarChar;
            FiledType["role_id"] = MySqlDbType.VarChar;
            FiledType["checkpointno"] = MySqlDbType.VarChar;
            FiledType["quanlity"] = MySqlDbType.VarChar;
            FiledType["pararmnm2"] = MySqlDbType.VarChar;
            FiledType["relation4"] = MySqlDbType.VarChar;
            FiledType["alarmreason"] = MySqlDbType.VarChar;
            FiledType["package"] = MySqlDbType.VarChar;
            FiledType["shelf_no"] = MySqlDbType.VarChar;
            FiledType["paramval5"] = MySqlDbType.VarChar;
            FiledType["pararmnm7"] = MySqlDbType.VarChar;
            FiledType["formid"] = MySqlDbType.VarChar;
            FiledType["bespeak_date"] = MySqlDbType.VarChar;
            FiledType["checkcode"] = MySqlDbType.VarChar;
            FiledType["pararmnm12"] = MySqlDbType.VarChar;
            FiledType["pickup_user"] = MySqlDbType.VarChar;
            FiledType["paramval10"] = MySqlDbType.VarChar;
            FiledType["paramkey"] = MySqlDbType.VarChar;
            FiledType["carrrier"] = MySqlDbType.VarChar;
            FiledType["pararmnm17"] = MySqlDbType.VarChar;
            FiledType["operator"] = MySqlDbType.VarChar;
            FiledType["paramval15"] = MySqlDbType.VarChar;
            FiledType["prdct_abbr"] = MySqlDbType.VarChar;
            FiledType["coo"] = MySqlDbType.VarChar;
            FiledType["modelname"] = MySqlDbType.VarChar;
            FiledType["relation1"] = MySqlDbType.VarChar;
            FiledType["ciphertext"] = MySqlDbType.VarChar;
            FiledType["remark"] = MySqlDbType.VarChar;
            FiledType["rfid_no"] = MySqlDbType.VarChar;
            FiledType["paramval2"] = MySqlDbType.VarChar;
            FiledType["pararmnm4"] = MySqlDbType.VarChar;
            FiledType["relation6"] = MySqlDbType.VarChar;
            FiledType["user_nm"] = MySqlDbType.VarChar;
            FiledType["shelf_type"] = MySqlDbType.VarChar;
            FiledType["infoval"] = MySqlDbType.VarChar;
            FiledType["in_item_no"] = MySqlDbType.VarChar;
            FiledType["paramval7"] = MySqlDbType.VarChar;
            FiledType["pararmnm9"] = MySqlDbType.VarChar;
            FiledType["formname"] = MySqlDbType.VarChar;
            FiledType["contacter"] = MySqlDbType.VarChar;
            FiledType["parentid"] = MySqlDbType.VarChar;
            FiledType["pararmnm14"] = MySqlDbType.VarChar;
            FiledType["pickup_mobile"] = MySqlDbType.VarChar;
            FiledType["paramval12"] = MySqlDbType.VarChar;
            FiledType["vendorcode"] = MySqlDbType.VarChar;
            FiledType["depot_no"] = MySqlDbType.VarChar;
            FiledType["modelremark"] = MySqlDbType.VarChar;
            FiledType["paramval17"] = MySqlDbType.VarChar;
            FiledType["unit"] = MySqlDbType.VarChar;
            FiledType["item_no"] = MySqlDbType.VarChar;
            FiledType["pararmnm1"] = MySqlDbType.VarChar;
            FiledType["relation3"] = MySqlDbType.VarChar;
            FiledType["ctnno"] = MySqlDbType.VarChar;
            FiledType["org_no"] = MySqlDbType.VarChar;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["stockin_id"] = MySqlDbType.VarChar;
            FiledType["paramval4"] = MySqlDbType.VarChar;
            FiledType["pararmnm6"] = MySqlDbType.VarChar;
            FiledType["relation8"] = MySqlDbType.VarChar;
            FiledType["bespeak_no"] = MySqlDbType.VarChar;
            FiledType["pickidentity"] = MySqlDbType.VarChar;
            FiledType["location"] = MySqlDbType.VarChar;
            FiledType["infoval3"] = MySqlDbType.VarChar;
            FiledType["pararmnm11"] = MySqlDbType.VarChar;
            FiledType["paramval9"] = MySqlDbType.VarChar;
            FiledType["mobile"] = MySqlDbType.VarChar;
            FiledType["address"] = MySqlDbType.VarChar;
            FiledType["upduser"] = MySqlDbType.VarChar;
            FiledType["pararmnm16"] = MySqlDbType.VarChar;
            FiledType["paramval14"] = MySqlDbType.VarChar;
            FiledType["prdct_nm"] = MySqlDbType.VarChar;
            FiledType["adjunct_value"] = MySqlDbType.VarChar;
            FiledType["terminalname"] = MySqlDbType.VarChar;
            FiledType["modelno"] = MySqlDbType.VarChar;
            FiledType["terminalno"] = MySqlDbType.VarChar;
            FiledType["alarmno"] = MySqlDbType.VarChar;
            FiledType["trmnremark"] = MySqlDbType.VarChar;
            FiledType["mod_id"] = MySqlDbType.VarChar;
            FiledType["paramval1"] = MySqlDbType.VarChar;
            FiledType["pararmnm3"] = MySqlDbType.VarChar;
            FiledType["relation5"] = MySqlDbType.VarChar;
            FiledType["user_no"] = MySqlDbType.VarChar;
            FiledType["cash_no"] = MySqlDbType.VarChar;
            FiledType["shelf_nm"] = MySqlDbType.VarChar;
            FiledType["cls_no"] = MySqlDbType.VarChar;
            FiledType["op_no"] = MySqlDbType.VarChar;
            FiledType["paramval6"] = MySqlDbType.VarChar;
            FiledType["pararmnm8"] = MySqlDbType.VarChar;
            FiledType["functiontype"] = MySqlDbType.VarChar;
            FiledType["custorder"] = MySqlDbType.VarChar;
            FiledType["roleid"] = MySqlDbType.VarChar;
            FiledType["mod_nm"] = MySqlDbType.VarChar;
            FiledType["pararmnm13"] = MySqlDbType.VarChar;
            FiledType["pickup_card"] = MySqlDbType.VarChar;
            FiledType["paramval11"] = MySqlDbType.VarChar;
            FiledType["paramvalue"] = MySqlDbType.VarChar;
            FiledType["tanspotno"] = MySqlDbType.VarChar;
            FiledType["downtime"] = MySqlDbType.VarChar;
            FiledType["version"] = MySqlDbType.VarChar;
            FiledType["pararmnm18"] = MySqlDbType.VarChar;
            FiledType["message"] = MySqlDbType.VarChar;
            FiledType["paramval16"] = MySqlDbType.VarChar;
            FiledType["prdct_type"] = MySqlDbType.VarChar;
            FiledType["receiptno"] = MySqlDbType.VarChar;
            FiledType["rolename"] = MySqlDbType.VarChar;
            FiledType["serialnoipaddr"] = MySqlDbType.VarChar;
            FiledType["relation2"] = MySqlDbType.VarChar;
            FiledType["pc"] = MySqlDbType.VarChar;
            FiledType["role_nm"] = MySqlDbType.VarChar;
            FiledType["ctnno_no"] = MySqlDbType.VarChar;
            FiledType["paramval3"] = MySqlDbType.VarChar;
            FiledType["pararmnm5"] = MySqlDbType.VarChar;
            FiledType["relation7"] = MySqlDbType.VarChar;
            FiledType["user_pwd"] = MySqlDbType.VarChar;
            FiledType["contaccter"] = MySqlDbType.VarChar;
            FiledType["area"] = MySqlDbType.VarChar;
            FiledType["infoval2"] = MySqlDbType.VarChar;
            FiledType["pararmnm10"] = MySqlDbType.VarChar;
            FiledType["stockout_id"] = MySqlDbType.VarChar;
            FiledType["paramval8"] = MySqlDbType.VarChar;
            FiledType["tel"] = MySqlDbType.VarChar;
            FiledType["url"] = MySqlDbType.VarChar;
            FiledType["adduser"] = MySqlDbType.VarChar;
            FiledType["pararmnm15"] = MySqlDbType.VarChar;
            FiledType["out_item_no"] = MySqlDbType.VarChar;
            FiledType["paramval13"] = MySqlDbType.VarChar;
            FiledType["prdct_no"] = MySqlDbType.VarChar;
            #endregion


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
            FiledType["addDateTime"] = MySqlDbType.Datetime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["updDateTime"] = MySqlDbType.Datetime;

            //原因表
            FiledType["reasonno"] = MySqlDbType.VarChar;
            FiledType["typeflag"] = MySqlDbType.VarChar;
            FiledType["reasoncontent"] = MySqlDbType.VarChar;
            FiledType["remark"] = MySqlDbType.VarChar;
            FiledType["addDateTime"] = MySqlDbType.Datetime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["updDateTime"] = MySqlDbType.Datetime;


            //T_图册越权报警
            FiledType["alarmno"] = MySqlDbType.VarChar;
            FiledType["docno"] = MySqlDbType.VarChar;
            FiledType["typeflag"] = MySqlDbType.VarChar;
            FiledType["terminalno"] = MySqlDbType.VarChar;
            FiledType["alarmdate"] = MySqlDbType.Datetime;

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
            FiledType["trmnparamupdtime"] = MySqlDbType.Datetime;
            FiledType["trmnstarttime"] = MySqlDbType.Datetime;
            FiledType["trmnrunstatus"] = MySqlDbType.Int32;
            FiledType["trmnupdtime"] = MySqlDbType.Datetime;
            FiledType["define1"] = MySqlDbType.VarChar;
            FiledType["define2"] = MySqlDbType.VarChar;
            FiledType["define3"] = MySqlDbType.VarChar;
            FiledType["define4"] = MySqlDbType.VarChar;
            FiledType["define5"] = MySqlDbType.VarChar;
            FiledType["trmnremark"] = MySqlDbType.VarChar;
            FiledType["trmnstatus"] = MySqlDbType.Bit;
            FiledType["addDateTime"] = MySqlDbType.Datetime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["updDateTime"] = MySqlDbType.Datetime;
            FiledType["gplsignalport1"] = MySqlDbType.Int32;
            FiledType["gplsignalport2"] = MySqlDbType.Int32;
            FiledType["gplsignalport3"] = MySqlDbType.Int32;
            FiledType["gplsignalport4"] = MySqlDbType.Int32;
            FiledType["terminaltype"] = MySqlDbType.Int32;

            //部门信息
            FiledType["deptno"] = MySqlDbType.VarChar;
            FiledType["deptname"] = MySqlDbType.VarChar;
            FiledType["remark"] = MySqlDbType.VarChar;
            FiledType["addDateTime"] = MySqlDbType.Datetime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["updDateTime"] = MySqlDbType.Datetime;

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
            FiledType["begindate"] = MySqlDbType.Datetime;
            FiledType["enddate"] = MySqlDbType.Datetime;
            FiledType["language"] = MySqlDbType.Int16;
            FiledType["approval"] = MySqlDbType.Bit;
            FiledType["remark"] = MySqlDbType.VarChar;
            FiledType["addDateTime"] = MySqlDbType.Datetime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["updDateTime"] = MySqlDbType.Datetime;
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
            FiledType["addDateTime"] = MySqlDbType.Datetime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["updDateTime"] = MySqlDbType.Datetime;

            //系统参数R/3信息
            FiledType["r3ipaddr"] = MySqlDbType.VarChar;
            FiledType["r3port"] = MySqlDbType.Int32;
            FiledType["r3folderpath"] = MySqlDbType.VarChar;
            FiledType["r3username"] = MySqlDbType.VarChar;
            FiledType["r3password"] = MySqlDbType.VarChar;
            FiledType["scanfilename2"] = MySqlDbType.VarChar;
            FiledType["scanmaxcnt2"] = MySqlDbType.Int32;
            FiledType["lcsfilename"] = MySqlDbType.VarChar;
            FiledType["lcstime"] = MySqlDbType.Datetime;
            FiledType["lcsmaxcnt"] = MySqlDbType.Int32;
            FiledType["termtypfilename"] = MySqlDbType.VarChar;
            FiledType["termtyptime"] = MySqlDbType.Datetime;
            FiledType["termtypmaxcnt"] = MySqlDbType.Int32;
            FiledType["cardfiltermaxtime"] = MySqlDbType.Int32;
            FiledType["r3define1"] = MySqlDbType.Datetime;
            FiledType["r3define2"] = MySqlDbType.Datetime;
            FiledType["r3define5"] = MySqlDbType.VarChar;
            FiledType["r3define6"] = MySqlDbType.VarChar;
            FiledType["r3define7"] = MySqlDbType.VarChar;
            FiledType["remark"] = MySqlDbType.VarChar;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["updDateTime"] = MySqlDbType.Datetime;


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
            FiledType["wmsdefine1"] = MySqlDbType.Datetime;
            FiledType["wmsdefine2"] = MySqlDbType.Datetime;
            FiledType["wmsdefine5"] = MySqlDbType.VarChar;
            FiledType["wmsdefine6"] = MySqlDbType.VarChar;
            FiledType["wmsdefine7"] = MySqlDbType.VarChar;
            FiledType["remark"] = MySqlDbType.VarChar;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["updDateTime"] = MySqlDbType.Datetime;

            FiledType["nhuploadfilename"] = MySqlDbType.VarChar;
            FiledType["nhuploadmaxcnt"] = MySqlDbType.Int32;

            //工作时间参数信息
            FiledType["orderno"] = MySqlDbType.Int32;
            FiledType["amtimestart"] = MySqlDbType.Datetime;
            FiledType["amtimeover"] = MySqlDbType.Datetime;
            FiledType["lateenable"] = MySqlDbType.Bit;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["updDateTime"] = MySqlDbType.Datetime;


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
            FiledType["addDateTime"] = MySqlDbType.Datetime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["updDateTime"] = MySqlDbType.Datetime;

            //类型定义
            FiledType["classno"] = MySqlDbType.VarChar;
            FiledType["classtype"] = MySqlDbType.Int32;
            FiledType["classname"] = MySqlDbType.VarChar;
            FiledType["classstatus"] = MySqlDbType.Bit;
            FiledType["addDateTime"] = MySqlDbType.Datetime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["updDateTime"] = MySqlDbType.Datetime;


            //日志信息
            FiledType["recordid"] = MySqlDbType.VarChar;
            FiledType["formid"] = MySqlDbType.VarChar;
            FiledType["functionid"] = MySqlDbType.Int32;
            FiledType["operatetyp"] = MySqlDbType.Int32;
            FiledType["remark"] = MySqlDbType.VarChar;
            FiledType["addDateTime"] = MySqlDbType.Datetime;
            FiledType["adduserno"] = MySqlDbType.VarChar;

            FiledType["updDateTime"] = MySqlDbType.Datetime;


            //配送报警信息
            FiledType["reqwarnrecdno"] = MySqlDbType.VarChar;
            FiledType["prdctid"] = MySqlDbType.VarChar;
            FiledType["terminalno"] = MySqlDbType.VarChar;
            FiledType["rfidcardno"] = MySqlDbType.VarChar;
            FiledType["reqstwarntype"] = MySqlDbType.Int32;
            FiledType["reqwarnseason"] = MySqlDbType.VarChar;
            FiledType["reqwarnremark"] = MySqlDbType.VarChar;
            FiledType["reqststatus"] = MySqlDbType.Int32;
            FiledType["addDateTime"] = MySqlDbType.Datetime;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["updDateTime"] = MySqlDbType.Datetime;

            //历史数据删除管理
            FiledType["historyno"] = MySqlDbType.VarChar;
            FiledType["delovertime"] = MySqlDbType.Datetime;
            FiledType["remark"] = MySqlDbType.VarChar;
            FiledType["status"] = MySqlDbType.Bit;

            //基本数据备份
            FiledType["backupno"] = MySqlDbType.VarChar;
            FiledType["filename"] = MySqlDbType.Datetime;

            //自定义颜色
            FiledType["colorno"] = MySqlDbType.VarChar;
            FiledType["colorvalue"] = MySqlDbType.VarChar;
            FiledType["colorremark"] = MySqlDbType.VarChar;


            FiledType["depltime1"] = MySqlDbType.VarChar;

            FiledType["sortno"] = MySqlDbType.Bit;
            FiledType["nhdelivstatus"] = MySqlDbType.VarChar;
            FiledType["ReqWarnRecdNo"] = MySqlDbType.VarChar;
            FiledType["ReqstWarnType"] = MySqlDbType.Int32;



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

            #region 采集器异常报警

            FiledType["alarmno"] = MySqlDbType.VarChar;
            FiledType["alarmtype"] = MySqlDbType.Int16;
            FiledType["terminalno"] = MySqlDbType.VarChar;
            FiledType["alarmdate"] = MySqlDbType.Datetime;
            FiledType["alarmreason"] = MySqlDbType.Text;

            #endregion
        }

    }

}
