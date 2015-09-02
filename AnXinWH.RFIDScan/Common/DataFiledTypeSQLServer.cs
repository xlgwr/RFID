using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
//using System.Data.SqlClient;

namespace AGCSystem
{

    public static class DataFiledTypeSQLServer
    {

        public static Dictionary<string, SqlDbType> FiledType = new Dictionary<string, SqlDbType>();

        static DataFiledTypeSQLServer()
        {


            //=========================================/
            //=========共通业务字段列数据类型==========/
            //=========================================/
            FiledType["slctvalue"] = SqlDbType.Bit;


            FiledType["emergtype"] = SqlDbType.VarChar;
            FiledType["emergreason"] = SqlDbType.NVarChar;

            // 区域表【M_Area】
            FiledType["areano"] = SqlDbType.NVarChar;
            FiledType["areaname"] = SqlDbType.NVarChar;
            FiledType["areatype"] = SqlDbType.NVarChar;
            FiledType["areatypenm"] = SqlDbType.NVarChar;
            FiledType["arearemark"] = SqlDbType.NVarChar;
            FiledType["areastatus"] = SqlDbType.Bit;
            FiledType["adddatetime"] = SqlDbType.DateTime;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;

            //原因表
            FiledType["reasonno"] = SqlDbType.NVarChar;
            FiledType["typeflag"] = SqlDbType.NVarChar;
            FiledType["reasoncontent"] = SqlDbType.NVarChar;
            FiledType["remark"] = SqlDbType.NVarChar;
            FiledType["adddatetime"] = SqlDbType.DateTime;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;


            //RFID采集器类型设定(采集器类型区分)
            FiledType["terminaltypeno"] = SqlDbType.NVarChar;
            FiledType["tertypenm"] = SqlDbType.NVarChar;
            FiledType["typeflag"] = SqlDbType.NVarChar;
            FiledType["typeflagname"] = SqlDbType.NVarChar;
            FiledType["terremark"] = SqlDbType.NVarChar;
            FiledType["adddatetime"] = SqlDbType.DateTime;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;

            //RFID采集器信息
            FiledType["terminalno"] = SqlDbType.NVarChar;
            FiledType["terminalname"] = SqlDbType.NVarChar;
            FiledType["Areano"] = SqlDbType.NVarChar;
            FiledType["terminaltypeno"] = SqlDbType.NVarChar;
            FiledType["connectflag"] = SqlDbType.Int;
            FiledType["serialnoipaddr"] = SqlDbType.NVarChar;
            FiledType["agreement"] = SqlDbType.Int;
            FiledType["sessionfalg"] = SqlDbType.Int;
            FiledType["readtime"] = SqlDbType.Int;
            FiledType["readinterval"] = SqlDbType.Int;
            FiledType["antrdpower1"] = SqlDbType.Int;
            FiledType["antrdpower2"] = SqlDbType.Int;
            FiledType["antrdpower3"] = SqlDbType.Int;
            FiledType["antrdpower4"] = SqlDbType.Int;
            FiledType["antwrpower1"] = SqlDbType.Int;
            FiledType["antwrpower2"] = SqlDbType.Int;
            FiledType["antwrpower3"] = SqlDbType.Int;
            FiledType["antwrpower4"] = SqlDbType.Int;
            FiledType["antstartstatus1"] = SqlDbType.Int;
            FiledType["antstartstatus2"] = SqlDbType.Int;
            FiledType["antstartstatus3"] = SqlDbType.Int;
            FiledType["antstartstatus4"] = SqlDbType.Int;
            FiledType["trmnparamupdtime"] = SqlDbType.DateTime;
            FiledType["trmnstarttime"] = SqlDbType.DateTime;
            FiledType["trmnrunstatus"] = SqlDbType.Int;
            FiledType["trmnupdtime"] = SqlDbType.DateTime;
            FiledType["define1"] = SqlDbType.NVarChar;
            FiledType["define2"] = SqlDbType.NVarChar;
            FiledType["define3"] = SqlDbType.NVarChar;
            FiledType["define4"] = SqlDbType.NVarChar;
            FiledType["define5"] = SqlDbType.NVarChar;
            FiledType["trmnremark"] = SqlDbType.NVarChar;
            FiledType["trmnstatus"] = SqlDbType.Bit;
            FiledType["adddatetime"] = SqlDbType.DateTime;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;


            //部门信息
            FiledType["deptno"] = SqlDbType.NVarChar;
            FiledType["deptname"] = SqlDbType.NVarChar;
            FiledType["remark"] = SqlDbType.NVarChar;
            FiledType["adddatetime"] = SqlDbType.DateTime;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;

            //用户信息
            FiledType["userno"] = SqlDbType.NVarChar;
            FiledType["deptno"] = SqlDbType.NVarChar;
            FiledType["username"] = SqlDbType.NVarChar;
            FiledType["passward"] = SqlDbType.NVarChar;
            FiledType["phone"] = SqlDbType.NVarChar;
            FiledType["status"] = SqlDbType.Bit;
            FiledType["authorone"] = SqlDbType.NVarChar;
            FiledType["authortwo"] = SqlDbType.NVarChar;
            FiledType["authorthree"] = SqlDbType.NVarChar;

            FiledType["remark"] = SqlDbType.NVarChar;
            FiledType["adddatetime"] = SqlDbType.DateTime;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;

            //画面定义
            FiledType["formid"] = SqlDbType.NVarChar;
            FiledType["functiontyp"] = SqlDbType.NVarChar;
            FiledType["formname"] = SqlDbType.NVarChar;
            FiledType["sortno"] = SqlDbType.Int;
            FiledType["frmstatus"] = SqlDbType.Bit;


            //角色信息
            FiledType["roleid"] = SqlDbType.NVarChar;
            FiledType["rolename"] = SqlDbType.NVarChar;
            FiledType["remark"] = SqlDbType.NVarChar;
            FiledType["adddatetime"] = SqlDbType.DateTime;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;


            //部品信息(LCS)
            FiledType["prdctcd"] = SqlDbType.NVarChar;
            FiledType["vendercd"] = SqlDbType.NVarChar;
            FiledType["pushpull"] = SqlDbType.NVarChar;
            FiledType["propertytype"] = SqlDbType.NVarChar;
            FiledType["membernum"] = SqlDbType.NVarChar;
            FiledType["minlotnum"] = SqlDbType.Decimal;
            FiledType["standardnum"] = SqlDbType.NVarChar;
            FiledType["checktype"] = SqlDbType.NVarChar;
            FiledType["directiontype"] = SqlDbType.NVarChar;
            FiledType["lines"] = SqlDbType.NVarChar;
            FiledType["sentdpos"] = SqlDbType.NVarChar;
            FiledType["strappingway"] = SqlDbType.NVarChar;
            FiledType["prdcttyp"] = SqlDbType.NVarChar;
            FiledType["packagetyp"] = SqlDbType.NVarChar;
            FiledType["containertyp"] = SqlDbType.NVarChar;
            FiledType["cards"] = SqlDbType.Int;
            FiledType["warer3area"] = SqlDbType.NVarChar;
            FiledType["warer3areasub"] = SqlDbType.NVarChar;
            FiledType["warefloor"] = SqlDbType.NVarChar;
            FiledType["waregrp"] = SqlDbType.NVarChar;
            FiledType["warearea"] = SqlDbType.NVarChar;
            FiledType["warepos"] = SqlDbType.NVarChar;
            FiledType["define1"] = SqlDbType.NVarChar;
            FiledType["define2"] = SqlDbType.NVarChar;
            FiledType["define3"] = SqlDbType.NVarChar;
            FiledType["define4"] = SqlDbType.NVarChar;
            FiledType["define5"] = SqlDbType.NVarChar;
            FiledType["define6"] = SqlDbType.NVarChar;
            FiledType["define7"] = SqlDbType.NVarChar;
            FiledType["define8"] = SqlDbType.NVarChar;
            FiledType["define9"] = SqlDbType.NVarChar;
            FiledType["define10"] = SqlDbType.NVarChar;
            FiledType["prdctremark"] = SqlDbType.NVarChar;
            FiledType["adddatetime"] = SqlDbType.DateTime;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;
            FiledType["prdctstatus"] = SqlDbType.Bit;

            //部品生产线信息
            FiledType["prdctid"] = SqlDbType.NVarChar;
            FiledType["Arearysl"] = SqlDbType.NVarChar;
            FiledType["itemid"] = SqlDbType.NVarChar;
            FiledType["Arearyfloor"] = SqlDbType.NVarChar;
            FiledType["Arearymachgrp"] = SqlDbType.NVarChar;
            FiledType["Arearyproj"] = SqlDbType.NVarChar;
            FiledType["Arearydesk"] = SqlDbType.NVarChar;
            FiledType["Arearyorder"] = SqlDbType.NVarChar;


            //系统参数R/3信息
            FiledType["r3ipaddr"] = SqlDbType.NVarChar;
            FiledType["r3port"] = SqlDbType.Int;
            FiledType["r3folderpath"] = SqlDbType.NVarChar;
            FiledType["r3username"] = SqlDbType.NVarChar;
            FiledType["r3password"] = SqlDbType.NVarChar;
            FiledType["scanfilename2"] = SqlDbType.NVarChar;
            FiledType["scanmaxcnt2"] = SqlDbType.Int;
            FiledType["lcsfilename"] = SqlDbType.NVarChar;
            FiledType["lcstime"] = SqlDbType.DateTime;
            FiledType["lcsmaxcnt"] = SqlDbType.Int;
            FiledType["termtypfilename"] = SqlDbType.NVarChar;
            FiledType["termtyptime"] = SqlDbType.DateTime;
            FiledType["termtypmaxcnt"] = SqlDbType.Int;
            FiledType["cardfiltermaxtime"] = SqlDbType.Int;
            FiledType["r3define1"] = SqlDbType.DateTime;
            FiledType["r3define2"] = SqlDbType.DateTime;
            FiledType["r3define5"] = SqlDbType.NVarChar;
            FiledType["r3define6"] = SqlDbType.NVarChar;
            FiledType["r3define7"] = SqlDbType.NVarChar;
            FiledType["remark"] = SqlDbType.NVarChar;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;


            //系统参数(WMS)信息
            FiledType["wmsipaddr"] = SqlDbType.NVarChar;
            FiledType["wmsport"] = SqlDbType.Int;
            FiledType["delivername"] = SqlDbType.NVarChar;
            FiledType["delivmaxcnt"] = SqlDbType.Int;
            FiledType["edelivfilename"] = SqlDbType.NVarChar;
            FiledType["edelivmaxcnt"] = SqlDbType.Int;
            FiledType["nhstatusfilename"] = SqlDbType.NVarChar;
            FiledType["nhstatusmaxcnt"] = SqlDbType.Int;
            FiledType["delivfrequency"] = SqlDbType.Int;
            FiledType["wmsdefine1"] = SqlDbType.DateTime;
            FiledType["wmsdefine2"] = SqlDbType.DateTime;
            FiledType["wmsdefine5"] = SqlDbType.NVarChar;
            FiledType["wmsdefine6"] = SqlDbType.NVarChar;
            FiledType["wmsdefine7"] = SqlDbType.NVarChar;
            FiledType["remark"] = SqlDbType.NVarChar;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;

            FiledType["nhuploadfilename"] = SqlDbType.NVarChar;
            FiledType["nhuploadmaxcnt"] = SqlDbType.Int;

            //工作时间参数信息
            FiledType["orderno"] = SqlDbType.Int;
            FiledType["amtimestart"] = SqlDbType.DateTime;
            FiledType["amtimeover"] = SqlDbType.DateTime;
            FiledType["lateenable"] = SqlDbType.Bit;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;

            //LCS上传时间定义表
            FiledType["order"] = SqlDbType.Int;
            FiledType["lcsuploadtime"] = SqlDbType.DateTime;

            //LCS自定义字段信息
            FiledType["fileddefinenm1"] = SqlDbType.NVarChar;
            FiledType["readonly"] = SqlDbType.Bit;
            FiledType["fileddefinenm2"] = SqlDbType.NVarChar;
            FiledType["readonly2"] = SqlDbType.Bit;
            FiledType["fileddefinenm3"] = SqlDbType.NVarChar;
            FiledType["readonly3"] = SqlDbType.Bit;
            FiledType["fileddefinenm4"] = SqlDbType.NVarChar;
            FiledType["readonly4"] = SqlDbType.Bit;
            FiledType["fileddefinenm5"] = SqlDbType.NVarChar;
            FiledType["readonly5"] = SqlDbType.Bit;
            FiledType["fileddefinenm6"] = SqlDbType.NVarChar;
            FiledType["readonly6"] = SqlDbType.Bit;
            FiledType["fileddefinenm7"] = SqlDbType.NVarChar;
            FiledType["readonly7"] = SqlDbType.Bit;
            FiledType["fileddefinenm8"] = SqlDbType.NVarChar;
            FiledType["readonly8"] = SqlDbType.Bit;
            FiledType["fileddefinenm9"] = SqlDbType.NVarChar;
            FiledType["readonly9"] = SqlDbType.Bit;
            FiledType["fileddefinenm10"] = SqlDbType.NVarChar;
            FiledType["readonly10"] = SqlDbType.Bit;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;



            //配送超时参数信息
            FiledType["Areatype"] = SqlDbType.NVarChar;
            FiledType["bigovertime"] = SqlDbType.Int;
            FiledType["midovertime"] = SqlDbType.Int;
            FiledType["smallovertime"] = SqlDbType.Int;
            FiledType["dinyovertime"] = SqlDbType.Int;
            FiledType["nhdelivovertime"] = SqlDbType.Int;
            FiledType["nhdelivremind"] = SqlDbType.Bit;
            FiledType["Areainstovertime"] = SqlDbType.Int;
            FiledType["productprintovertime"] = SqlDbType.Int;
            FiledType["edelivdelaytime"] = SqlDbType.Int;
            FiledType["againalarmtime"] = SqlDbType.Int;


            //RFID卡绑定信息
            FiledType["rfidcardno"] = SqlDbType.NVarChar;
            FiledType["prdctid"] = SqlDbType.NVarChar;
            FiledType["itemid"] = SqlDbType.NVarChar;
            FiledType["requestnum"] = SqlDbType.Decimal;
            FiledType["cardstatus"] = SqlDbType.Bit;
            FiledType["adddatetime"] = SqlDbType.DateTime;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;

            //类型定义
            FiledType["classno"] = SqlDbType.NVarChar;
            FiledType["classtype"] = SqlDbType.Int;
            FiledType["classname"] = SqlDbType.NVarChar;
            FiledType["classstatus"] = SqlDbType.Bit;
            FiledType["adddatetime"] = SqlDbType.DateTime;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;


            //部品数量修改
            FiledType["rcdid"] = SqlDbType.NVarChar;
            FiledType["rfidcardno"] = SqlDbType.NVarChar;
            FiledType["standnum"] = SqlDbType.Decimal;
            FiledType["delivnum"] = SqlDbType.Decimal;
            FiledType["updseason"] = SqlDbType.NVarChar;
            FiledType["adddatetime"] = SqlDbType.DateTime;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;

            //配送追踪信息
            FiledType["reqstrecdno"] = SqlDbType.NVarChar;
            FiledType["prdctid"] = SqlDbType.NVarChar;
            FiledType["reqsttime"] = SqlDbType.DateTime;
            FiledType["nhdelivtime"] = SqlDbType.DateTime;
            FiledType["delivflag"] = SqlDbType.Bit;
            FiledType["reqstcases"] = SqlDbType.Int;
            FiledType["reqstnum"] = SqlDbType.Decimal;
            FiledType["reqststatus"] = SqlDbType.Int;
            FiledType["wmsuploadstatus"] = SqlDbType.Int;
            FiledType["delivcases"] = SqlDbType.Decimal;
            FiledType["delivnum"] = SqlDbType.Decimal;
            FiledType["delivstatus"] = SqlDbType.Int;
            FiledType["instrcases"] = SqlDbType.Int;
            FiledType["instrnum"] = SqlDbType.Decimal;
            FiledType["instrstatus"] = SqlDbType.Int;
            FiledType["r3uploadstatus"] = SqlDbType.Int;
            FiledType["wmssendstatus"] = SqlDbType.Int;
            FiledType["printflag"] = SqlDbType.Bit;
            FiledType["nhprintflag"] = SqlDbType.Bit;
            FiledType["nhprintflag2"] = SqlDbType.Bit;
            FiledType["Areaprintflag"] = SqlDbType.Bit;

            //配送信息（拆包）
            FiledType["reqstrecdno"] = SqlDbType.NVarChar;
            FiledType["prdctid"] = SqlDbType.NVarChar;
            FiledType["terminalno"] = SqlDbType.NVarChar;
            FiledType["rfidcardno"] = SqlDbType.NVarChar;
            FiledType["reqstcases"] = SqlDbType.Int;
            FiledType["procuserno"] = SqlDbType.NVarChar;
            FiledType["reqstproctype"] = SqlDbType.Int;

            FiledType["warnprocseason"] = SqlDbType.NVarChar;
            FiledType["reqstnum"] = SqlDbType.Decimal;
            FiledType["reqsttime"] = SqlDbType.DateTime;
            FiledType["reqstupdstatus"] = SqlDbType.Int;
            FiledType["scantime"] = SqlDbType.DateTime;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;

            //紧急配送信息
            FiledType["emgdelivrecdno"] = SqlDbType.NVarChar;
            FiledType["prdctid"] = SqlDbType.NVarChar;
            FiledType["requesttime"] = SqlDbType.DateTime;
            FiledType["updstatus"] = SqlDbType.Int;
            FiledType["delivstatus"] = SqlDbType.Int;
            FiledType["adddatetime"] = SqlDbType.DateTime;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;

            //生产调配信息

            FiledType["deplrecdno"] = SqlDbType.NVarChar;
            FiledType["prdctid"] = SqlDbType.NVarChar;
            FiledType["terminalno"] = SqlDbType.NVarChar;
            FiledType["rfidcardno"] = SqlDbType.NVarChar;
            FiledType["deplcases"] = SqlDbType.Int;
            FiledType["deplnum"] = SqlDbType.Decimal;
            FiledType["depltime"] = SqlDbType.DateTime;
            FiledType["sendplace"] = SqlDbType.NVarChar;
            FiledType["receivepalce"] = SqlDbType.NVarChar;
            FiledType["deplupdstatus"] = SqlDbType.Int;
            FiledType["deplremark"] = SqlDbType.NVarChar;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;
            FiledType["printtime"] = SqlDbType.DateTime;

            //日志信息
            FiledType["recordid"] = SqlDbType.NVarChar;
            FiledType["formid"] = SqlDbType.NVarChar;
            FiledType["functionid"] = SqlDbType.Int;
            FiledType["operatetyp"] = SqlDbType.Int;
            FiledType["remark"] = SqlDbType.NVarChar;
            FiledType["adddatetime"] = SqlDbType.DateTime;
            FiledType["adduserno"] = SqlDbType.NVarChar;


            //南华送货(拆包)
            FiledType["reqstrecdno"] = SqlDbType.NVarChar;
            FiledType["prdctid"] = SqlDbType.NVarChar;
            FiledType["terminalno"] = SqlDbType.NVarChar;
            FiledType["rfidcardno"] = SqlDbType.NVarChar;
            FiledType["delivcases"] = SqlDbType.Int;
            FiledType["delivnum"] = SqlDbType.Decimal;
            FiledType["procuserno"] = SqlDbType.NVarChar;
            FiledType["delivproctype"] = SqlDbType.Int;
            FiledType["delivprocseason"] = SqlDbType.NVarChar;
            FiledType["scantime"] = SqlDbType.DateTime;
            FiledType["delivupdstatus"] = SqlDbType.Int;
            FiledType["upddatetime"] = SqlDbType.DateTime;
            FiledType["instrdelivtime"] = SqlDbType.DateTime;



            //南华送货报警信息
            FiledType["extwarnrecdno"] = SqlDbType.NVarChar;
            FiledType["reqstrecdno"] = SqlDbType.NVarChar;
            FiledType["prdctid"] = SqlDbType.NVarChar;
            FiledType["terminalno"] = SqlDbType.NVarChar;
            FiledType["rfidcardno"] = SqlDbType.NVarChar;
            FiledType["extwarntype"] = SqlDbType.Int;
            FiledType["extwarnseason"] = SqlDbType.NVarChar;
            FiledType["extwarnremark"] = SqlDbType.NVarChar;
            FiledType["extstatus"] = SqlDbType.Int;
            FiledType["adddatetime"] = SqlDbType.DateTime;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;


            //部品入库报警信息
            FiledType["instwarnrecdno"] = SqlDbType.NVarChar;
            FiledType["reqstrecdno"] = SqlDbType.NVarChar;
            FiledType["prdctid"] = SqlDbType.NVarChar;
            FiledType["terminalno"] = SqlDbType.NVarChar;
            FiledType["rfidcardno"] = SqlDbType.NVarChar;
            FiledType["instwarntype"] = SqlDbType.Int;
            FiledType["instwarnseason"] = SqlDbType.NVarChar;
            FiledType["instwarnremark"] = SqlDbType.NVarChar;
            FiledType["inststatus"] = SqlDbType.Int;
            FiledType["adddatetime"] = SqlDbType.DateTime;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;



            //部品入库(拆包)
            FiledType["reqstrecdno"] = SqlDbType.NVarChar;
            FiledType["prdctid"] = SqlDbType.NVarChar;
            FiledType["terminalno"] = SqlDbType.NVarChar;
            FiledType["rfidcardno"] = SqlDbType.NVarChar;
            FiledType["instrcases"] = SqlDbType.Int;
            FiledType["instrnum"] = SqlDbType.Decimal;
            FiledType["scantime"] = SqlDbType.DateTime;
            FiledType["instrupdstatus"] = SqlDbType.Int;
            FiledType["upddatetime"] = SqlDbType.DateTime;


            //配送报警信息
            FiledType["reqwarnrecdno"] = SqlDbType.NVarChar;
            FiledType["prdctid"] = SqlDbType.NVarChar;
            FiledType["terminalno"] = SqlDbType.NVarChar;
            FiledType["rfidcardno"] = SqlDbType.NVarChar;
            FiledType["reqstwarntype"] = SqlDbType.Int;
            FiledType["reqwarnseason"] = SqlDbType.NVarChar;
            FiledType["reqwarnremark"] = SqlDbType.NVarChar;
            FiledType["reqststatus"] = SqlDbType.Int;
            FiledType["adddatetime"] = SqlDbType.DateTime;
            FiledType["upduserno"] = SqlDbType.NVarChar;
            FiledType["upddatetime"] = SqlDbType.DateTime;

            //历史数据删除管理
            FiledType["historyno"] = SqlDbType.NVarChar;
            FiledType["delovertime"] = SqlDbType.DateTime;
            FiledType["remark"] = SqlDbType.NVarChar;
            FiledType["status"] = SqlDbType.Bit;

            //基本数据备份
            FiledType["backupno"] = SqlDbType.NVarChar;
            FiledType["filename"] = SqlDbType.DateTime;

            //自定义颜色
            FiledType["colorno"] = SqlDbType.VarChar;
            FiledType["colorvalue"] = SqlDbType.VarChar;
            FiledType["colorremark"] = SqlDbType.NVarChar;


            FiledType["depltime1"] = SqlDbType.NVarChar;

            FiledType["sortno"] = SqlDbType.Bit;
            FiledType["nhdelivstatus"] = SqlDbType.NVarChar;
            FiledType["ReqWarnRecdNo"] = SqlDbType.NVarChar;
            FiledType["ReqstWarnType"] = SqlDbType.Int;
        }


    }

}
