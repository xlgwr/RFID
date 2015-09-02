using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace AnXinWH.RFIDScan.MasterTableWHS
{

    #region  表属性
    public partial class mclassinfo
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
    public partial class mdepot
    {
        public const string depot = "depot";
        public const string depot_nm = "depot_nm";
        public const string remark = "remark";
        public const string status = "status";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
    }
    public partial class mroledetail
    {
        public const string role_id = "role_id";
        public const string mod_id = "mod_id";
        public const string opr_code = "opr_code";
    }

    public partial class mroles
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

    public partial class msysmodule
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

    public partial class msysmoduledetail
    {
        public const string mod_id = "mod_id";
        public const string opr_code = "opr_code";
        public const string sort = "sort";
        public const string status = "status";
        public const string upduser = "upduser";
        public const string updtime = "updtime";
    }
    public partial class mparameter
    {
        public const string paramkey = "paramkey";
        public const string paramvalue = "paramvalue";
        public const string remark = "remark";
        public const string paramtype = "paramtype";
        public const string adduser = "adduser";
        public const string upduser = "upduser";
        public const string addtime = "addtime";
        public const string updtime = "updtime";
        public const string org_no = "org_no";
    }
    public partial class musers
    {
        public const string user_no = "user_no";
        public const string user_nm = "user_nm";
        public const string depotno = "depotno";
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

    public partial class tinterface
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

    /// <summary>
    /// t_stockin
    /// </summary>

    public partial class tstockin
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
    /// <summary>
    /// t_stockinctnno
    /// </summary>

    public partial class t_stockinctnno
    {
        public const string ctnno_id = "ctnno_id";
        public const string stockin_no = "stockin_no";
        public const string item_no = "item_no";
        public const string prdct_no = "prdct_no";
        public const string ctnno_no = "ctnno_no";
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
    /// <summary>
    /// t_stockindetail
    /// </summary>

    public partial class t_stockindetail
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

    /// <summary>
    /// t_stockout
    /// </summary>

    public partial class t_stockin
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
    /// <summary>
    /// t_stockinctnno
    /// </summary>

    public partial class t_stockoutctnno
    {
        public const string ctnno_id = "ctnno_id";

        public const string stockin_no = "stockin_no";
        public const string item_no = "item_no";
        public const string prdct_no = "prdct_no";
        public const string ctnno_no = "ctnno_no";

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
    /// <summary>
    /// t_stockindetail
    /// </summary>

    public partial class t_stockoutdetail
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
    
    #endregion
    #region  视图/表
    public class ViewOrTable
    {
        public const string m_classinfo = "m_classinfo";
        public const string m_depot = "m_depot";
        public const string m_parameter = "m_parameter";
        public const string m_roledetail = "m_roledetail";
        public const string m_roles = "m_roles";
        public const string m_sysmodule = "m_sysmodule";
        public const string m_sysmoduledetail = "m_sysmoduledetail";
        public const string m_users = "m_users";
        public const string t_interface = "t_interface";
        public const string t_stockin = "t_stockin";
        public const string t_stockinctnno = "t_stockinctnno";
        public const string t_stockindetail = "t_stockindetail";
        public const string t_stockout = "t_stockout";
        public const string t_stockoutctnno = "t_stockoutctnno";
        public const string t_stockoutdetail = "t_stockoutdetail";
        public const string t_syslogrecd = "t_syslogrecd";
    }
    #endregion

}
