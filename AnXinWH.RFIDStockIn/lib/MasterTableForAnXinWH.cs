using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AnXinWH.RFIDStockIn
{
    #region  表属性

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

    public class t_AlarmData
    {
        public const string recd_id = "recd_id";
        public const string alarm_type = "alarm_type";
        public const string depot_no = "depot_no";
        public const string cell_no = "cell_no";
        public const string begin_time = "begin_time";
        public const string over_time = "over_time";
        public const string remark = "remark";
        public const string status = "status";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
    }
    public class t_stockinctnnodetail
    {
        public const string stockin_id = "stockin_id";
        public const string prdct_no = "prdct_no";
        public const string rfid_no = "rfid_no";
        public const string ctnno_no = "ctnno_no";
        public const string receiptno = "receiptNo";
        public const string pqty = "pqty";
        public const string qty = "qty";
        public const string nwet = "nwet";
        public const string gwet = "gwet";
        public const string status = "status";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
    }

    public class t_stockinctnno
    {

        public const string stockin_id = "stockin_id";
        public const string prdct_no = "prdct_no";
        public const string pqty = "pqty";
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
        public const string stockin_id = "stockin_id";
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

    public class t_stockin
    {
        public const string stockin_id = "stockin_id";
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

    public class t_stockdetail
    {
        public const string prdct_no = "prdct_no";
        public const string rfid_no = "rfid_no";
        public const string receiptno = "receiptNo";
        public const string shelf_no = "shelf_no";
        public const string ctnno_no = "ctnno_no";
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

    public class m_products
    {
        public const string prdct_no = "prdct_no";
        public const string prdct_nm = "prdct_nm";
        public const string prdct_abbr = "prdct_abbr";
        public const string depot_no = "depot_no";
        public const string prdct_type = "prdct_type";
        public const string unit = "unit";
        public const string remark = "remark";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
        public const string adduser = "adduser";
        public const string status = "status";
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

    #endregion

    #region  视图/表
    public class ViewOrTable
    {
        public const string m_checkpoint = "m_checkpoint";
        public const string m_classinfo = "m_classinfo";
        public const string m_depot = "m_depot";
        public const string m_devicemodel = "m_devicemodel";
        public const string m_devicerelation = "m_devicerelation";
        public const string m_funcform = "m_funcform";
        public const string m_parameter = "m_parameter";
        public const string m_products = "m_products";
        public const string m_roledetail = "m_roledetail";
        public const string m_roles = "m_roles";
        public const string m_shelf = "m_shelf";
        public const string m_sysmodule = "m_sysmodule";
        public const string m_sysmoduledetail = "m_sysmoduledetail";
        public const string m_terminaldevice = "m_terminaldevice";
        public const string m_users = "m_users";
        public const string t_alarmdata = "t_alarmdata";
        public const string t_bespeak = "t_bespeak";
        public const string t_bespeakdetail = "t_bespeakdetail";
        public const string t_cash = "t_cash";
        public const string t_cashdetail = "t_cashdetail";
        public const string t_functioninfo = "t_functioninfo";
        public const string t_interface = "t_interface";
        public const string t_roles = "t_roles";
        public const string t_stock = "t_stock";
        public const string t_stockdetail = "t_stockdetail";
        public const string t_stockin = "t_stockin";
        public const string t_stockinctnno = "t_stockinctnno";
        public const string t_stockinctnnodetail = "t_stockinctnnodetail";
        public const string t_stockindetail = "t_stockindetail";
        public const string t_stockout = "t_stockout";
        public const string t_stockoutctnno = "t_stockoutctnno";
        public const string t_stockoutctnnodetail = "t_stockoutctnnodetail";
        public const string t_stockoutdetail = "t_stockoutdetail";
        public const string t_stockoutsign = "t_stockoutsign";
        public const string t_syslogrecd = "t_syslogrecd";
        public const string t_terminaalarm = "t_terminaalarm";




    }
    #endregion

}
