using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;

namespace Framework.Entity
{
    [Serializable]
    public class MyConfig
    {
        public string DeviceNo{get;set;}
        public string DeviceIP { get; set; }
        public string SqlServerIP { get; set; }
        public string SqlServerSA { get; set; }
        public string SqlServerPW { get; set; }

        public MyConfig() {
            this.SqlServerPW = "";
            this.SqlServerIP = "";
            this.SqlServerSA = "";
            this.DeviceNo = "";
            this.DeviceIP = "";
        }
    }
}
