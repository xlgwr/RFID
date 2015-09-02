using System;
using System.Collections.Generic;
using System.Text;

namespace Framework.Libs
{

    public class T_LogRecord
    {

        public const string TableName = "T_LogRecord";

        public const string RecordId = "RecordId";
        public const string FormId = "FormId";
        public const string FunctionId = "FunctionId";
        public const string OperateTyp = "OperateTyp";
        public const string Remark = "Remark";
        public const string AddDateTime = "AddDateTime";
        public const string AddUserNo = "AddUserNo";
    }

    public class M_FuncForm
    {
        public const string TableName = "M_FuncForm";

        public const string FormId = "FormId";
        public const string FunctionTyp = "FunctionTyp";
        public const string FormName = "FormName";
        public const string SortNo = "SortNo";
        public const string frmStatus = "frmStatus";
    }
}
