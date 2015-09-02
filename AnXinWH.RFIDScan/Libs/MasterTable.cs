using System;
using System.Collections.Generic;
using System.Text;

namespace AnXinWH.RFIDScan.MasterTable
{

    /// <summary>
    /// 用户信息
    /// </summary>
    public class M_Users
    {
        public const string TableName = "M_Users";
        public const string Grid_UserAuthor = "Grid_UserAuthor";


        //public const string TableName = "M_Users";

        public const string UserNo = "UserNo";
        public const string DeptNo = "DeptNo";
        public const string UserName = "UserName";

        public const string RoleId = "RoleId";
        public const string RoleName = "RoleName";

        public const string Language = "Language";

        public const string ReceiveMsg = "ReceiveMsg";
        public const string Position = "Position";

        //public const string AuthorOne = "AuthorOne";
        //public const string AuthorTwo = "AuthorTwo";
        //public const string AuthorThree = "AuthorThree";

        //public const string AreaNo1 = "AreaNo1";
        //public const string RoleName1 = "RoleName1";
        //public const string AreaName1 = "AreaName1";
        //public const string AreaType1 = "AreaType1";

        //public const string AreaNo2 = "AreaNo2";
        //public const string RoleName2 = "RoleName2";
        //public const string AreaName2 = "AreaName2";
        //public const string AreaType2 = "AreaType2";

        //public const string AreaNo3 = "AreaNo3";
        //public const string RoleName3 = "RoleName3";
        //public const string AreaName3 = "AreaName3";
        public const string Approval = "Approval";

        public const string Passward = "Passward";
        public const string Phone = "Phone";
        public const string Email = "Email";
        public const string Status = "Status";
        public const string Remark = "Remark";
        public const string AddDateTime = "AddDateTime";
        public const string UpdUserNo = "UpdUserNo";
        public const string UpdDateTime = "UpdDateTime";
        public const string Mobile = "Mobile";
        public const string EndDate = "EndDate";
        public const string BeginDate = "BeginDate";




    }

    /// <summary>
    /// 部品信息
    /// </summary>
    public class M_ProductInfo
    {

        public const string SlctValue = "SlctValue";
        public const string PrdctID = "PrdctID";
        public const string PrdctCd = "PrdctCd";
        public const string VenderCd = "VenderCd";
        public const string PushPull = "PushPull";
        public const string PropertyType = "PropertyType";
        public const string MemberNum = "MemberNum";
        public const string MinLotNum = "MinLotNum";
        public const string StandardNum = "StandardNum";
        public const string CheckType = "CheckType";
        public const string DirectionType = "DirectionType";
        public const string Lines = "Lines";
        public const string SentdPos = "SentdPos";
        public const string StrappingWay = "StrappingWay";
        public const string PrdctTyp = "PrdctTyp";
        public const string PackageTyp = "PackageTyp";
        public const string ContainerTyp = "ContainerTyp";
        public const string Cards = "Cards";
        public const string WareFloor = "WareFloor";
        public const string WareGrp = "WareGrp";
        public const string WareR3Area = "WareR3Area";
        public const string WareArea = "WareArea";
        public const string WarePos = "WarePos";
        public const string Define1 = "Define1";
        public const string Define2 = "Define2";
        public const string Define3 = "Define3";
        public const string Define4 = "Define4";
        public const string Define5 = "Define5";
        public const string Define6 = "Define6";
        public const string Define7 = "Define7";
        public const string Define8 = "Define8";
        public const string Define9 = "Define9";
        public const string Define10 = "Define10";
        public const string PrdctRemark = "PrdctRemark";
        public const string PrdctStatus = "PrdctStatus";
        public const string AddDateTime = "AddDateTime";
        public const string UpdUserNo = "UpdUserNo";
        public const string UpdDateTime = "UpdDateTime";
    }

    /// <summary>
    /// 部品生产线信息
    /// </summary>
    public class M_PrdctFactInfo
    {
        public const string PrdctID = "PrdctID";
        public const string ItemId = "ItemId";
        public const string FactrySL = "FactrySL";
        public const string FactryFloor = "FactryFloor";
        public const string FactryMachGrp = "FactryMachGrp";
        public const string FactryProj = "FactryProj";
        public const string FactryDesk = "FactryDesk";
        public const string FactryOrder = "FactryOrder";
    }

    public class T_Roles
    {
        public const string RoleId = "RoleId";
        public const string RoleName = "RoleName";

    }

    public class T_FunctionInfo
    {
        public const string RoleId = "RoleId";
        public const string FormId = "FormId";
        public const string Status = "Status";

    }

    public class M_FuncForm
    {
        public const string FunctionTyp = "FunctionTyp";
        public const string FormId = "FormId";
        public const string FormName = "FormName";
        public const string frmStatus = "frmStatus";

    }

    public class M_ClassDefine
    {
        public const string ClassNo = "ClassNo";
        public const string ClassType = "ClassType";
        public const string ClassName = "ClassName";
        public const string ClassStatus = "ClassStatus";
        public const string AddDateTime = "AddDateTime";
        public const string UpdUserNo = "UpdUserNo";
        public const string UpdDateTime = "UpdDateTime";
    }

    public class T_RFIDDefine
    {
        public const string Grid_PrdctDefInfo = "Grid_PrdctDefInfo";
        public const string RFIDCardNo = "RFIDCardNo";
        public const string PrdctID = "PrdctID";
        public const string ItemId = "ItemId";
        public const string RequestNum = "RequestNum";
        public const string CardStatus = "CardStatus";
        public const string AddDateTime = "AddDateTime";
        public const string UpdUserNo = "UpdUserNo";
        public const string UpdDateTime = "UpdDateTime";
    }

    public class T_DeliveryTracking
    {
        public const string ReqstRecdNo = "ReqstRecdNo";
        public const string PrdctID = "PrdctID";
        public const string ReqstTime = "ReqstTime";
        public const string NHDelivTime = "NHDelivTime";
        public const string ReqstCases = "ReqstCases";
        public const string ReqstNum = "ReqstNum";
        public const string ReqstStatus = "ReqstStatus";
        public const string WMSUploadStatus = "WMSUploadStatus";
        public const string DelivCases = "DelivCases";
        public const string DelivNum = "DelivNum";
        public const string DelivStatus = "DelivStatus";
        public const string DelivFlag = "DelivFlag";
        public const string InstrCases = "InstrCases";
        public const string InstrNum = "InstrNum";
        public const string InstrStatus = "InstrStatus";
        public const string R3UploadStatus = "R3UploadStatus";
        public const string WMSSendStatus = "WMSSendStatus";
        public const string InstrDelivTime = "InstrDelivTime";

    }
    public class M_SysR3Parameter
    {
        public const string TableName = "M_SysR3Parameter";

        public const string WebServicStatus = "WebServicStatus";
        public const string WebServicTime = "WebServicTime";
        public const string CardFilterMaxTime = "CardFilterMaxTime";
    }

    public class M_SysWorkParameter
    {
        public const string TableName = "M_SysWorkParameter";

        public const string OrderNo = "OrderNo";
        public const string AMTimeStart = "AMTimeStart";
        public const string AMTimeOver = "AMTimeOver";
        public const string LateEnable = "LateEnable";
        public const string UpdUserNo = "UpdUserNo";
        public const string UpdDateTime = "UpdDateTime";
        public const string LCSUploadTime = "LCSUploadTime";
    }

    public class M_OverTimeParameter
    {
        public const string TableName = "M_OverTimeParameter";

        public const string FactType = "FactType";
        public const string BigOverTime = "BigOverTime";
        public const string MidOverTime = "MidOverTime";
        public const string SmallOverTime = "SmallOverTime";
        public const string DinyOverTime = "DinyOverTime";
        public const string NHDelivOverTime = "NHDelivOverTime";
        public const string NHDelivRemind = "NHDelivRemind";
        public const string FactoryInstOverTime = "FactoryInstOverTime";
        public const string ProductPrintOverTime = "ProductPrintOverTime";
        public const string EDelivDelayTime = "EDelivDelayTime";
        public const string AgainAlarmTime = "AgainAlarmTime";
    }

    /// <summary>
    /// 工厂信息
    /// </summary>
    public class M_Factory
    {

        public const string TableName = "M_Factory";
        public const string FactoryNo = "FactoryNo";
        public const string FactoryName = "FactoryName";
        public const string FactType = "FactType";
        public const string FactTypeNm = "FactTypeNm";
        public const string FactRemark = "FactRemark";
        public const string FactStatus = "FactStatus";
        public const string AddDateTime = "AddDateTime";
        public const string UpdUserNo = "UpdUserNo";
        public const string UpdDateTime = "UpdDateTime";
    }

    /// <summary>
    /// RFID采集器信息
    /// </summary>
    public class M_TerminalType
    {

        public const string TerminalTypeNo = "TerminalTypeNo";
        public const string TerTypeNm = "TerTypeNm";
        public const string TypeFlag = "TypeFlag";
        public const string TerRemark = "TerRemark";
    }

    /// <summary>
    /// RFID采集器信息
    /// </summary>
    public class M_TerminalSetting
    {

        public const string TableName = "M_TerminalSetting";
        public const string Grid_TermDeviceInfo = "Grid_TermDeviceInfo";


        public const string TerminalNo = "TerminalNo";
        public const string TerminalName = "TerminalName";
        public const string FactoryNo = "FactoryNo";
        public const string TerminalTypeNo = "TerminalTypeNo";
        public const string ConnectFlag = "ConnectFlag";
        public const string SerialNoIPAddr = "SerialNoIPAddr";
        public const string Agreement = "Agreement";
        public const string SessionFalg = "SessionFalg";
        public const string ReadTime = "ReadTime";
        public const string ReadInterval = "ReadInterval";
        public const string AntRDPower1 = "AntRDPower1";
        public const string AntRDPower2 = "AntRDPower2";
        public const string AntRDPower3 = "AntRDPower3";
        public const string AntRDPower4 = "AntRDPower4";
        public const string AntWRPower1 = "AntWRPower1";
        public const string AntWRPower2 = "AntWRPower2";
        public const string AntWRPower3 = "AntWRPower3";
        public const string AntWRPower4 = "AntWRPower4";
        public const string AntStartStatus1 = "AntStartStatus1";
        public const string AntStartStatus2 = "AntStartStatus2";
        public const string AntStartStatus3 = "AntStartStatus3";
        public const string AntStartStatus4 = "AntStartStatus4";
        public const string TrmnParamUpdTime = "TrmnParamUpdTime";
        public const string TrmnStartTime = "TrmnStartTime";
        public const string TrmnRunStatus = "TrmnRunStatus";
        public const string TrmnUpdTime = "TrmnUpdTime";
        public const string Define1 = "Define1";
        public const string Define2 = "Define2";
        public const string Define3 = "Define3";
        public const string Define4 = "Define4";
        public const string Define5 = "Define5";
        public const string TrmnRemark = "TrmnRemark";
        public const string TrmnStatus = "TrmnStatus";
        public const string AddDateTime = "AddDateTime";
        public const string UpdUserNo = "UpdUserNo";
        public const string UpdDateTime = "UpdDateTime";
    }

    /// <summary>
    /// 南华超时报警
    /// </summary>
    public class T_ExternalDelivWarning
    {
        public const string ExtWarnRecdNo = "ExtWarnRecdNo";
        public const string ReqstRecdNo = "ReqstRecdNo";
        public const string PrdctID = "PrdctID";
        public const string TerminalNo = "TerminalNo";
        public const string RFIDCardNo = "RFIDCardNo";
        public const string ExtWarnType = "ExtWarnType";
        public const string ExtWarnSeason = "ExtWarnSeason";
        public const string ExtWarnRemark = "ExtWarnRemark";
        public const string ExtStatus = "ExtStatus";
        public const string AddDateTime = "AddDateTime";
        public const string UpdUserNo = "UpdUserNo";
        public const string UpdDateTime = "UpdDateTime";
    }

    public class T_ExternalDelivery
    {
        public const string ScanTime = "ScanTime";

        public const string ReqstRecdNo = "ReqstRecdNo";
        public const string PrdctID = "PrdctID";
        public const string TerminalNo = "TerminalNo";
        public const string RFIDCardNo = "RFIDCardNo";
        public const string DelivCases = "DelivCases";
        public const string DelivNum = "DelivNum";
        public const string ProcUserNo = "ProcUserNo";
        public const string DelivProcType = "DelivProcType";
        public const string DelivProcSeason = "DelivProcSeason";
        public const string DelivUpdStatus = "DelivUpdStatus";
        public const string UpdDateTime = "UpdDateTime";
    }


    public class T_InstoreWarning
    {
        public const string InstWarnRecdNo = "InstWarnRecdNo";
        public const string ReqstRecdNo = "ReqstRecdNo";
        public const string PrdctID = "PrdctID";
        public const string TerminalNo = "TerminalNo";
        public const string RFIDCardNo = "RFIDCardNo";
        public const string InstWarnType = "InstWarnType";
        public const string InstWarnSeason = "InstWarnSeason";
        public const string InstWarnRemark = "InstWarnRemark";
        public const string InstStatus = "InstStatus";
        public const string AddDateTime = "AddDateTime";
        public const string UpdUserNo = "UpdUserNo";
        public const string UpdDateTime = "UpdDateTime";
    }

    public class T_BoxTracking
    {
        public const string MoveTime = "MoveTime";
        public const string TerminalNo = "TerminalNo";
        public const string RFIDCardNo = "RFIDCardNo";
    }

    public class T_ProductInstore
    {
        public const string ReqstRecdNo = "ReqstRecdNo";
        public const string PrdctID = "PrdctID";
        public const string TerminalNo = "TerminalNo";
        public const string RFIDCardNo = "RFIDCardNo";
        public const string InstrCases = "InstrCases";
        public const string InstrNum = "InstrNum";
        public const string ScanTime = "ScanTime";
        public const string InstrUpdStatus = "InstrUpdStatus";
        public const string UpdDateTime = "UpdDateTime";
    }

    #region 图纸

    /// <summary>
    /// 盘点计划
    /// </summary>
    public class T_PlanInventory
    {

        public const string TableName = "T_PlanInventory";
        public const string InventoryNo = "InventoryNo";
        public const string totalcount = "totalcount";
        public const string InventBeginDate = "InventBeginDate";
        public const string InventEndDate = "InventEndDate";
        public const string InventStatus = "InventStatus";
        public const string InventStatusText = "InventStatusText";
        public const string InventUserNo = "InventUserNo";
        public const string UpdUserNo = "UpdUserNo";
        public const string UpdDateTime = "UpdDateTime";
    }
    /// <summary>
    /// 盘点计划详细
    /// </summary>
    public class T_InventoryDetail
    {
        public const string TableName = "T_InventoryDetail";
        public const string InventoryNo = "InventoryNo";
        public const string DocNo = "DocNo";
        public const string InventFlag = "InventFlag";
        public const string InventFlagText = "InventFlagText";
        public const string InventStatus = "InventStatus";
        public const string InventStatusText = "InventStatusText";
        public const string UpdUserNo = "UpdUserNo";
        public const string UpdDateTime = "UpdDateTime";
    }
    /// <summary>
    /// 图册
    /// </summary>
    public class M_Documents
    {

        public const string TableName = "M_Documents";
        public const string DocNo = "DocNo";
        public const string DocName_Cn = "DocName_Cn";
        public const string DocName = "DocName";
        public const string DocName_Jp = "DocName_Cn";
        public const string MakeNumbers = "MakeNumbers";
        public const string Pages = "Pages";
        public const string DocMainTitle_Jp = "DocMainTitle_Jp";
        public const string DocMainTitle_Cn = "DocMainTitle_Cn";
        public const string DocSubTitle_Cn = "DocSubTitle_Cn";
        public const string DocSubTitle_Jp = "DocSubTitle_Jp";
        public const string DocSubTitle_Cn1 = "DocSubTitle_Cn1";
        public const string DocSubTitle_Jp1 = "DocSubTitle_Jp1";
        public const string DocSubTitle_Cn2 = "DocSubTitle_Cn2";
        public const string DocSubTitle_Jp2 = "DocSubTitle_Jp2";
        public const string TagNo1 = "TagNo1";
        public const string TagNo2 = "TagNo2";
        public const string TagNo3 = "TagNo3";
        public const string ReadEnable = "ReadEnable";
        public const string ReadEnableText = "ReadEnableText";
        public const string CopyEnable = "CopyEnable";
        public const string CopyEnableText = "CopyEnableText";
        public const string LentEnable = "LentEnable";
        public const string LentEnableText = "LentEnableText";
        public const string Remark = "Remark";
        public const string InventStatus = "InventStatus";
        public const string InventStatusText = "InventStatusText";
        public const string UsedStatus = "UsedStatus";
        public const string UsedStatusText = "UsedStatusText";
        public const string AddDateTime = "AddDateTime";
        public const string UpdUserNo = "UpdUserNo";
        public const string UpdDateTime = "UpdDateTime";
        public const string DocMainTitle = "DocMainTitle";
    }

    #region 图册借出申请

    public class T_DocApplication
    {
        public const string ApplicationNo = "ApplicationNo";
        public const string LentDate = "LentDate";
        public const string ReturnDate = "ReturnDate";
        public const string AppUserNo = "AppUserNo";
        public const string UsedStatus = "UsedStatus";
        public const string AddDateTime = "AddDateTime";
        public const string UpdUserNo = "UpdUserNo";
        public const string UpdDateTime = "UpdDateTime";
        public const string AuditDesigUserNo = "AuditDesigUserNo";
    }

    #endregion

    #region 图册借出申请详细

    public class T_DocApplicationDetail
    {
        public const string TableName = "T_DocApplicationDetail";
        public const string ApplicationID = "ApplicationID";
        public const string ApplicationNo = "ApplicationNo";
        public const string DocNo = "DocNo";
        public const string ReadEnable = "ReadEnable";
        public const string CopyEnable = "CopyEnable";
        public const string LentEnable = "LentEnable";
        public const string LentRemark = "LentRemark";
        public const string ApprvlStatus = "ApprvlStatus";
        public const string ApprvlStatusText = "ApprvlStatusText";
        public const string AuditRemark = "AuditRemark";
        public const string AuditUserNo = "AuditUserNo";
        public const string InventStatus = "InventStatus";
        public const string InventStatusText = "InventStatusText";
        public const string UsedStatus = "UsedStatus";
        public const string AddDateTime = "AddDateTime";
        public const string UpdUserNo = "UpdUserNo";
        public const string UpdDateTime = "UpdDateTime";
        public const string DetailLentDate = "DetailLentDate";
        public const string DetailReturnDate = "DetailReturnDate";
    }


    //图册归还
    public class T_DocReturn
    {
        public const string TableName = "T_DocReturn";
        public const string ReturnNo = "ReturnNo";
        public const string ReturnID = "ReturnID";
        public const string ApplicationID = "ApplicationID";
        public const string DocNo = "DocNo";
        public const string RespUserNo = "RespUserNo";
        public const string ReturnUserNo = "ReturnUserNo";
        public const string ReturnDate = "ReturnDate";
        public const string AlarmNo = "AlarmNo";
        public const string AlarmDate = "AlarmDate";

    }

    #endregion
    #region 视图/表
    public class ViewOrTable
    {
        public const string grid_inventorydetail = "grid_inventorydetail";
        public const string M_Documents = "M_Documents";
        public const string grid_planinventoryinfo = "grid_planinventoryinfo";
        public const string grid_inventorydetail_good = "grid_inventorydetail_good";
        public const string grid_inventorydetail_bad = "grid_inventorydetail_bad";
        public const string grid_userinfo = "grid_userinfo";
        public const string grid_rerurnlistformobile = "grid_rerurnlistformobile";
        public const string grid_inventstatus = "grid_inventstatus";
        //public const string grid_planinventoryinfo = "grid_planinventoryinfo";
    }
    #endregion
    #region 枚举
    /// <summary>
    /// 盘点状态
    /// </summary>
    public enum InventStatus
    {
        /// <summary>
        /// 未完成
        /// </summary>
        NoComplete = 0,
        /// <summary>
        /// 已完成
        /// </summary>
        Completed = 1
    }
    /// <summary>
    /// 子表盘点状态
    /// </summary>
    public enum DetailInventStatus
    {
        /// <summary>
        /// 在库
        /// </summary>
        zaiko = 0,
        /// <summary>
        /// 缺少
        /// </summary>
        Lack = 1,
        /// <summary>
        /// 多余
        /// </summary>
        Redundant = 2
    }
    /// <summary>
    /// 盘点区分
    /// </summary>
    public enum InventFlag
    {
        /// <summary>
        ///计划
        /// </summary>
        plan = 0,
        /// <summary>
        /// 已盘点
        /// </summary>
        Invented = 1,
        /// <summary>
        /// 更新
        /// </summary>
        Updated = 2
    }
    public enum DocInventStatus
    {
        /// <summary>
        /// 在库
        /// </summary>
        Zaiko = 0,
        /// <summary>
        /// 借出
        /// </summary>
        Lent = 1
    }
    public enum OperateTyp
    {
        /// <summary>
        /// 添加
        /// </summary>
        Add = 0,
        /// <summary>
        /// 修改
        /// </summary>
        Edit = 1,
        /// <summary>
        /// 删除
        /// </summary>
        Delete = 2
    }

    #endregion

    #endregion

}
