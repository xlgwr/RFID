using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace AnXinWH.RFIDStockIn
{

    public static class DataFiledTypeMySql
    {

        public static Dictionary<string, MySqlDbType> FiledType = new Dictionary<string, MySqlDbType>();

        static DataFiledTypeMySql()
        {

            #region anxinwh
            FiledType["alarmdate"] = MySqlDbType.Datetime;
            FiledType["over_time"] = MySqlDbType.Datetime;
            FiledType["cash_date"] = MySqlDbType.Datetime;
            FiledType["stockout_date"] = MySqlDbType.Datetime;
            FiledType["paramupdtime"] = MySqlDbType.Datetime;
            FiledType["updtime"] = MySqlDbType.Datetime;
            FiledType["begin_time"] = MySqlDbType.Datetime;
            FiledType["addtime"] = MySqlDbType.Datetime;
            FiledType["stockin_date"] = MySqlDbType.Datetime;
            FiledType["trmnupdtime"] = MySqlDbType.Datetime;
            FiledType["upddatetime"] = MySqlDbType.Datetime;
            FiledType["nwgt"] = MySqlDbType.Float;
            FiledType["nwet"] = MySqlDbType.Float;
            FiledType["qty"] = MySqlDbType.Float;
            FiledType["gwgt"] = MySqlDbType.Float;
            FiledType["pqty"] = MySqlDbType.Float;
            FiledType["gwet"] = MySqlDbType.Float;
            FiledType["readtime"] = MySqlDbType.Int32;
            FiledType["modeflag"] = MySqlDbType.Int32;
            FiledType["type"] = MySqlDbType.Int32;
            FiledType["status"] = MySqlDbType.Int32;
            FiledType["sortno"] = MySqlDbType.Int32;
            FiledType["iconic"] = MySqlDbType.Int32;
            FiledType["downtype"] = MySqlDbType.Int32;
            FiledType["sort"] = MySqlDbType.Int32;
            FiledType["readinterval"] = MySqlDbType.Int32;
            FiledType["alarmflag"] = MySqlDbType.Int32;
            FiledType["islast"] = MySqlDbType.Int32;
            FiledType["connectflag"] = MySqlDbType.Int32;
            FiledType["recd_id"] = MySqlDbType.Int32;
            FiledType["log_id"] = MySqlDbType.Int32;
            FiledType["cls_typno"] = MySqlDbType.Int32;
            FiledType["rolestatus"] = MySqlDbType.Int16;
            FiledType["result"] = MySqlDbType.Int16;
            FiledType["opr_code"] = MySqlDbType.Int16;
            FiledType["alarmtype"] = MySqlDbType.Int16;
            FiledType["paramtype"] = MySqlDbType.Int16;
            FiledType["type"] = MySqlDbType.Int16;
            FiledType["trmnstatus"] = MySqlDbType.Int16;
            FiledType["frmstatus"] = MySqlDbType.Int16;
            FiledType["remark"] = MySqlDbType.Int16;
            FiledType["status"] = MySqlDbType.Int16;
            FiledType["flag"] = MySqlDbType.Int16;
            FiledType["checktime"] = MySqlDbType.Time;
            FiledType["pickup_mobile"] = MySqlDbType.VarChar;
            FiledType["relation2"] = MySqlDbType.VarChar;
            FiledType["carrrier"] = MySqlDbType.VarChar;
            FiledType["role_nm"] = MySqlDbType.VarChar;
            FiledType["checkpointno"] = MySqlDbType.VarChar;
            FiledType["message"] = MySqlDbType.VarChar;
            FiledType["ciphertext"] = MySqlDbType.VarChar;
            FiledType["param5"] = MySqlDbType.VarChar;
            FiledType["relation7"] = MySqlDbType.VarChar;
            FiledType["pc"] = MySqlDbType.VarChar;
            FiledType["area"] = MySqlDbType.VarChar;
            FiledType["upduser"] = MySqlDbType.VarChar;
            FiledType["user_pwd"] = MySqlDbType.VarChar;
            FiledType["param10"] = MySqlDbType.VarChar;
            FiledType["stockin_id"] = MySqlDbType.VarChar;
            FiledType["infoval"] = MySqlDbType.VarChar;
            FiledType["param15"] = MySqlDbType.VarChar;
            FiledType["prdct_no"] = MySqlDbType.VarChar;
            FiledType["terminalname"] = MySqlDbType.VarChar;
            FiledType["depot_nm"] = MySqlDbType.VarChar;
            FiledType["relationno"] = MySqlDbType.VarChar;
            FiledType["contacter"] = MySqlDbType.VarChar;
            FiledType["role_id"] = MySqlDbType.VarChar;
            FiledType["cash_code"] = MySqlDbType.VarChar;
            FiledType["param2"] = MySqlDbType.VarChar;
            FiledType["relation4"] = MySqlDbType.VarChar;
            FiledType["vendorcode"] = MySqlDbType.VarChar;
            FiledType["shelf_no"] = MySqlDbType.VarChar;
            FiledType["remark"] = MySqlDbType.VarChar;
            FiledType["upduserno"] = MySqlDbType.VarChar;
            FiledType["param7"] = MySqlDbType.VarChar;
            FiledType["formid"] = MySqlDbType.VarChar;
            FiledType["quanlity"] = MySqlDbType.VarChar;
            FiledType["mod_nm"] = MySqlDbType.VarChar;
            FiledType["alarmreason"] = MySqlDbType.VarChar;
            FiledType["alarm_type"] = MySqlDbType.VarChar;
            FiledType["param12"] = MySqlDbType.VarChar;
            FiledType["paramkey"] = MySqlDbType.VarChar;
            FiledType["ctnno"] = MySqlDbType.VarChar;
            FiledType["op_no"] = MySqlDbType.VarChar;
            FiledType["version"] = MySqlDbType.VarChar;
            FiledType["infoval3"] = MySqlDbType.VarChar;
            FiledType["bespeak_no"] = MySqlDbType.VarChar;
            FiledType["param17"] = MySqlDbType.VarChar;
            FiledType["prdct_abbr"] = MySqlDbType.VarChar;
            FiledType["checkcode"] = MySqlDbType.VarChar;
            FiledType["pickup_card"] = MySqlDbType.VarChar;
            FiledType["serialnoipaddr"] = MySqlDbType.VarChar;
            FiledType["modenm"] = MySqlDbType.VarChar;
            FiledType["relation1"] = MySqlDbType.VarChar;
            FiledType["mobile"] = MySqlDbType.VarChar;
            FiledType["address"] = MySqlDbType.VarChar;
            FiledType["operator"] = MySqlDbType.VarChar;
            FiledType["trmnremark"] = MySqlDbType.VarChar;
            FiledType["param4"] = MySqlDbType.VarChar;
            FiledType["relation6"] = MySqlDbType.VarChar;
            FiledType["receiptno"] = MySqlDbType.VarChar;
            FiledType["shelf_type"] = MySqlDbType.VarChar;
            FiledType["adduser"] = MySqlDbType.VarChar;
            FiledType["adjunct_value"] = MySqlDbType.VarChar;
            FiledType["user_nm"] = MySqlDbType.VarChar;
            FiledType["param9"] = MySqlDbType.VarChar;
            FiledType["formname"] = MySqlDbType.VarChar;
            FiledType["ctnno_no"] = MySqlDbType.VarChar;
            FiledType["url"] = MySqlDbType.VarChar;
            FiledType["cls_no"] = MySqlDbType.VarChar;
            FiledType["param14"] = MySqlDbType.VarChar;
            FiledType["cash_no"] = MySqlDbType.VarChar;
            FiledType["stockout_id"] = MySqlDbType.VarChar;
            FiledType["terminaltype"] = MySqlDbType.VarChar;
            FiledType["modereamrk"] = MySqlDbType.VarChar;
            FiledType["custorder"] = MySqlDbType.VarChar;
            FiledType["unit"] = MySqlDbType.VarChar;
            FiledType["roleid"] = MySqlDbType.VarChar;
            FiledType["out_item_no"] = MySqlDbType.VarChar;
            FiledType["param1"] = MySqlDbType.VarChar;
            FiledType["relation3"] = MySqlDbType.VarChar;
            FiledType["tanspotno"] = MySqlDbType.VarChar;
            FiledType["org_no"] = MySqlDbType.VarChar;
            FiledType["downtime"] = MySqlDbType.VarChar;
            FiledType["param6"] = MySqlDbType.VarChar;
            FiledType["relation8"] = MySqlDbType.VarChar;
            FiledType["item_no"] = MySqlDbType.VarChar;
            FiledType["location"] = MySqlDbType.VarChar;
            FiledType["rolename"] = MySqlDbType.VarChar;
            FiledType["recd_id"] = MySqlDbType.VarChar;
            FiledType["param11"] = MySqlDbType.VarChar;
            FiledType["infoval2"] = MySqlDbType.VarChar;
            FiledType["param16"] = MySqlDbType.VarChar;
            FiledType["prdct_nm"] = MySqlDbType.VarChar;
            FiledType["pickidentity"] = MySqlDbType.VarChar;
            FiledType["pickup_user"] = MySqlDbType.VarChar;
            FiledType["modelno"] = MySqlDbType.VarChar;
            FiledType["terminalno"] = MySqlDbType.VarChar;
            FiledType["tel"] = MySqlDbType.VarChar;
            FiledType["mod_id"] = MySqlDbType.VarChar;
            FiledType["param3"] = MySqlDbType.VarChar;
            FiledType["relation5"] = MySqlDbType.VarChar;
            FiledType["coo"] = MySqlDbType.VarChar;
            FiledType["shelf_nm"] = MySqlDbType.VarChar;
            FiledType["adjunct_address"] = MySqlDbType.VarChar;
            FiledType["alarmno"] = MySqlDbType.VarChar;
            FiledType["user_no"] = MySqlDbType.VarChar;
            FiledType["param8"] = MySqlDbType.VarChar;
            FiledType["functiontype"] = MySqlDbType.VarChar;
            FiledType["parentid"] = MySqlDbType.VarChar;
            FiledType["depot_no"] = MySqlDbType.VarChar;
            FiledType["cell_no"] = MySqlDbType.VarChar;
            FiledType["param13"] = MySqlDbType.VarChar;
            FiledType["paramvalue"] = MySqlDbType.VarChar;
            FiledType["package"] = MySqlDbType.VarChar;
            FiledType["in_item_no"] = MySqlDbType.VarChar;
            FiledType["bespeak_date"] = MySqlDbType.VarChar;
            FiledType["param18"] = MySqlDbType.VarChar;
            FiledType["prdct_type"] = MySqlDbType.VarChar;
            FiledType["rfid_no"] = MySqlDbType.VarChar;

            #endregion

        }

    }

}
