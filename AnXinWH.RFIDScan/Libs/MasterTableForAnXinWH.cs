using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AnXinWH.RFIDScan.MasterTableWHS
{

    #region  表属性
    public class m_checkpoint
    {
        public const string CheckPointNo = "CheckPointNo";
        public const string CheckTime = "CheckTime";
        public const string Remark = "Remark";
        public const string AddDateTime = "AddDateTime";
        public const string UpdUserNo = "UpdUserNo";
        public const string UpdDateTime = "UpdDateTime";
    }
    public class m_classinfo
    {
        public const string cls_no = "cls_no";
        public const string cls_typno = "cls_typno";
        public const string infoval = "infoval";
        public const string infoval2 = "infoval2";
        public const string infoval3 = "infoval3";
        public const string sort = "sort";
        public const string status = "status";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string updtime = "updtime";
        public const string addtime = "addtime";
    }
    public class m_depot
    {
        public const string depot_no = "depot_no";
        public const string depot_nm = "depot_nm";
        public const string remark = "remark";
        public const string status = "status";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
    }
    public class m_devicemodel
    {
        public const string ModelNo = "ModelNo";
        public const string ModelName = "ModelName";
        public const string ModelFlag = "ModelFlag";
        public const string PararmNm1 = "PararmNm1";
        public const string PararmNm2 = "PararmNm2";
        public const string PararmNm3 = "PararmNm3";
        public const string PararmNm4 = "PararmNm4";
        public const string PararmNm5 = "PararmNm5";
        public const string PararmNm6 = "PararmNm6";
        public const string PararmNm7 = "PararmNm7";
        public const string PararmNm8 = "PararmNm8";
        public const string PararmNm9 = "PararmNm9";
        public const string PararmNm10 = "PararmNm10";
        public const string PararmNm11 = "PararmNm11";
        public const string PararmNm12 = "PararmNm12";
        public const string PararmNm13 = "PararmNm13";
        public const string PararmNm14 = "PararmNm14";
        public const string PararmNm15 = "PararmNm15";
        public const string PararmNm16 = "PararmNm16";
        public const string PararmNm17 = "PararmNm17";
        public const string PararmNm18 = "PararmNm18";
        public const string ModelRemark = "ModelRemark";
        public const string AddDateTime = "AddDateTime";
        public const string UpdDateTime = "UpdDateTime";
        public const string UpdUserNo = "UpdUserNo";
    }
    public class m_devicerelation
    {
        public const string RelationNo = "RelationNo";
        public const string TerminalNo = "TerminalNo";
        public const string Relation1 = "Relation1";
        public const string Relation2 = "Relation2";
        public const string Relation3 = "Relation3";
        public const string Relation4 = "Relation4";
        public const string Relation5 = "Relation5";
        public const string Relation6 = "Relation6";
        public const string Relation7 = "Relation7";
        public const string Relation8 = "Relation8";
    }
    public class m_parameter
    {

        public const string paramkey = "paramkey";
        public const string paramvalue = "paramvalue";
        public const string remark = "remark";
        public const string paramtype = "paramtype";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
        public const string depot_no = "depot_no";
    }
    public class m_roledetail
    {
        public const string role_id = "role_id";
        public const string mod_id = "mod_id";
        public const string opr_code = "opr_code";
    }
    public class m_roles
    {

        public const string role_id = "role_id";
        public const string role_nm = "role_nm";
        public const string depot_no = "depot_no";
        public const string remark = "remark";
        public const string status = "status";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
        public const string org_no = "org_no";

    }
    public class m_shelf
    {
        public const string shelf_no = "shelf_no";
        public const string shelf_nm = "shelf_nm";
        public const string depot_no = "depot_no";
        public const string shelf_type = "shelf_type";
        public const string area = "area";
        public const string location = "location";
        public const string remark = "remark";
        public const string status = "status";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
    }
    public class m_sysmodule
    {
        public const string mod_id = "mod_id";
        public const string mod_nm = "mod_nm";
        public const string parentid = "parentid";
        public const string url = "url";
        public const string iconic = "iconic";
        public const string islast = "islast";
        public const string version = "version";
        public const string flag = "flag";
        public const string status = "status";
        public const string remark = "remark";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
    }
    public class m_sysmoduledetail
    {
        public const string mod_id = "mod_id";
        public const string opr_code = "opr_code";
        public const string sort = "sort";
        public const string status = "status";
        public const string upduser = "upduser";
        public const string updtime = "updtime";

    }
    public class m_terminaldevice
    {

        public const string TerminalNo = "TerminalNo";
        public const string ModelNo = "ModelNo";
        public const string TerminalType = "TerminalType";
        public const string TerminalName = "TerminalName";
        public const string shelf_no = "shelf_no";
        public const string ConnectFlag = "ConnectFlag";
        public const string SerialNoIPAddr = "SerialNoIPAddr";
        public const string ReadTime = "ReadTime";
        public const string ReadInterval = "ReadInterval";
        public const string ParamVal1 = "ParamVal1";
        public const string ParamVal2 = "ParamVal2";
        public const string ParamVal3 = "ParamVal3";
        public const string ParamVal4 = "ParamVal4";
        public const string ParamVal5 = "ParamVal5";
        public const string ParamVal6 = "ParamVal6";
        public const string ParamVal7 = "ParamVal7";
        public const string ParamVal8 = "ParamVal8";
        public const string ParamVal9 = "ParamVal9";
        public const string ParamVal10 = "ParamVal10";
        public const string ParamVal11 = "ParamVal11";
        public const string ParamVal12 = "ParamVal12";
        public const string ParamVal13 = "ParamVal13";
        public const string ParamVal14 = "ParamVal14";
        public const string ParamVal15 = "ParamVal15";
        public const string ParamVal16 = "ParamVal16";
        public const string ParamVal17 = "ParamVal17";
        public const string ParamVal18 = "ParamVal18";
        public const string TrmnRemark = "TrmnRemark";
        public const string CipherText = "CipherText";
        public const string ParamUpdTime = "ParamUpdTime";
        public const string TrmnUpdTime = "TrmnUpdTime";
        public const string TrmnStatus = "TrmnStatus";
        public const string AddDateTime = "AddDateTime";
        public const string UpdDateTime = "UpdDateTime";
        public const string UpdUserNo = "UpdUserNo";
        public const string depot_no = "depot_no";
    }
    public class m_users
    {
        public const string user_no = "user_no";
        public const string user_nm = "user_nm";
        public const string depot_no = "depot_no";
        public const string user_pwd = "user_pwd";
        public const string remark = "remark";
        public const string role_id = "role_id";
        public const string status = "status";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
        public const string org_no = "org_no";
    }
    public class t_interface
    {

        public const string recd_id = "recd_id";
        public const string address = "address";
        public const string type = "type";
        public const string downtime = "downtime";
        public const string downtype = "downtype";
        public const string adjunct_address = "adjunct_address";
        public const string adjunct_value = "adjunct_value";
        public const string remark = "remark";
        public const string status = "status";
    }
    public class t_stockin
    {
        public const string stockin_no = "stockin_no";
        public const string stockin_date = "stockin_date";
        public const string user_no = "user_no";
        public const string status = "status";
        public const string op_no = "op_no";
        public const string remark = "remark";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";

    }
    public class t_stockinctnno
    {


        public const string stockin_no = "stockin_no";
        public const string prdct_no = "prdct_no";
        public const string pqty = "pqty";
        public const string qty = "qty";
        public const string nwet = "nwet";
        public const string gwet = "gwet";
        public const string rfid_no = "rfid_no";
        public const string status = "status";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
    }
    public class t_stockinctnnodetail
    {
        public const string rfid_no = "rfid_no";
        public const string ctnno_no = "ctnno_no";
        public const string qty = "qty";
        public const string nwet = "nwet";
        public const string gwet = "gwet";
        public const string status = "status";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
    }
    public class t_stockindetail
    {
        public const string stockin_no = "stockin_no";
        public const string in_item_no = "in_item_no";
        public const string bespeak_no = "bespeak_no";
        public const string item_no = "item_no";
        public const string prdct_no = "prdct_no";
        public const string pc = "pc";
        public const string pqty = "pqty";
        public const string qty = "qty";
        public const string nwet = "nwet";
        public const string gwet = "gwet";
        public const string quanlity = "quanlity";
        public const string remark = "remark";
        public const string status = "status";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
    }
    public class t_stockout
    {

        public const string stockout_no = "stockout_no";
        public const string stockout_date = "stockout_date";
        public const string user_no = "user_no";
        public const string pickup_user = "pickup_user";
        public const string pickup_card = "pickup_card";
        public const string pickup_mobile = "pickup_mobile";
        public const string status = "status";
        public const string remark = "remark";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
    }
    public class t_stockoutctnno
    {

        public const string stockout_id = "stockout_id";
        public const string prdct_no = "prdct_no";
        public const string qty = "qty";
        public const string nwet = "nwet";
        public const string gwet = "gwet";
        public const string rfid_no = "rfid_no";
        public const string status = "status";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
    }
    public class t_stockoutctnnodetail
    {

        public const string rfid_no = "rfid_no";
        public const string ctnno_no = "ctnno_no";
        public const string qty = "qty";
        public const string nwet = "nwet";
        public const string gwet = "gwet";
        public const string status = "status";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
    }
    public class t_stockoutdetail
    {

        public const string stockout_no = "stockout_no";
        public const string out_item_no = "out_item_no";
        public const string cash_no = "cash_no";
        public const string item_no = "item_no";
        public const string prdct_no = "prdct_no";
        public const string pc = "pc";
        public const string pqty = "pqty";
        public const string qty = "qty";
        public const string nwet = "nwet";
        public const string gwet = "gwet";
        public const string quanlity = "quanlity";
        public const string status = "status";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
    }
    public class t_syslogrecd
    {

        public const string log_id = "log_id";
        public const string _operator = "operator";
        public const string message = "message";
        public const string type = "type";
        public const string result = "result";
        public const string mod_id = "mod_id";
        public const string adduser = "adduser";
        public const string addtime = "addtime";
        public const string org_no = "org_no";
    }
    public class t_terminaalarm
    {

        public const string AlarmNo = "AlarmNo";
        public const string AlarmType = "AlarmType";
        public const string TerminalNo = "TerminalNo";
        public const string AlarmDate = "AlarmDate";
        public const string AlarmFlag = "AlarmFlag";
        public const string AlarmReason = "AlarmReason";
        public const string Remark = "Remark";
        public const string UpdUserNo = "UpdUserNo";
        public const string UpdDateTime = "UpdDateTime";

    }
    public class t_stock
    {
        public const string prdct_no = "prdct_no";
        public const string pqty = "pqty";
        public const string qty = "qty";
        public const string nwet = "nwet";
        public const string gwet = "gwet";
        public const string remark = "remark";
        public const string status = "status";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
    }

    public class t_stockdetail
    {
        public const string prdct_no = "prdct_no";
        public const string rfid_no = "rfid_no";
        public const string shelf_no = "shelf_no";
        public const string pqty = "pqty";
        public const string qty = "qty";
        public const string nwet = "nwet";
        public const string gwet = "gwet";
        public const string remark = "remark";
        public const string status = "status";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
    }
    #endregion
    #region  视图/表
    public class ViewOrTable
    {
        public const string m_checkpoint = "m_checkpoint";
        public const string m_classinfo = "m_classinfo";
        public const string m_depot = "m_depot";
        public const string m_devicemodel = "m_devicemodel";
        public const string m_devicerelation = "m_devicerelation";
        public const string m_parameter = "m_parameter";
        public const string m_roledetail = "m_roledetail";
        public const string m_roles = "m_roles";
        public const string m_shelf = "m_shelf";
        public const string m_sysmodule = "m_sysmodule";
        public const string m_sysmoduledetail = "m_sysmoduledetail";
        public const string m_terminaldevice = "m_terminaldevice";
        public const string m_users = "m_users";
        public const string t_interface = "t_interface";
        public const string t_stockin = "t_stockin";
        public const string t_stockinctnno = "t_stockinctnno";
        public const string t_stockinctnnodetail = "t_stockinctnnodetail";
        public const string t_stockindetail = "t_stockindetail";
        public const string t_stockout = "t_stockout";
        public const string t_stockoutctnno = "t_stockoutctnno";
        public const string t_stockoutctnnodetail = "t_stockoutctnnodetail";
        public const string t_stockoutdetail = "t_stockoutdetail";
        public const string t_syslogrecd = "t_syslogrecd";
        public const string t_terminaalarm = "t_terminaalarm";

        public const string t_stock = "t_stock";
        public const string t_stockdetail = "t_stockdetail";

    }
    #endregion

}
