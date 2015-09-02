using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Collections;
using Framework.Libs;

namespace Framework.Entity
{
    public class Card
    {
        public const char Spliter = '#';
        public long Kdt { get; set; }
        public string EPC { get; set; }
        public long Dt { get; set; }
        public int Flag { get; set; }


        public Card(long kdt,string epc, long dt)
        {
            this.Kdt = kdt;
            this.EPC = epc;
            this.Dt = dt;
            this.Flag = 0;
        }

        public Card(long kdt, string epc):this(kdt, epc, DateTime.Now.Ticks,0)
        {

        }
        public Card(long kdt, string epc, long dt,int flag)
        {
            this.Kdt = kdt;
            this.EPC = epc;
            this.Dt = dt;
            this.Flag = flag;
        }

        public override string ToString()
        {
            return String.Format("[Kdt:{3},EPC:{0},Dt:{1},Flag:{2}]",this.EPC ,this.Dt ,this.Flag,this.Kdt);
        }

        public string GetKeyCode()
        {
            return String.Format("{0}{1}{2}", this.Kdt, Spliter, this.EPC);
        }

        //private static readonly ILog log = LogManager.GetLogger(typeof(Card));

        public static bool TryParse(DictionaryEntry data, ref Card card)
        {
            try
            {
                if (data.Key is String && data.Value is DateTime)
                {
                    int pos = data.Key.ToString().IndexOf(Spliter);
                    if (pos > 0)
                    {
                        String sKdt = data.Key.ToString().Substring(0, pos);
                        String epc = data.Key.ToString().Substring(pos + 1);
                        card = new Card(long.Parse(sKdt), epc, (data.Value as DateTime?).Value.Ticks);
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                //log.ErrorFormat("card parse error,key:{0},value:{1},msg:{2}", data.Key, data.Value,e.Message );
                LogManager.WriteLog(Framework.Libs.Common.LogFile.Error, string.Format("card parse error,key:{0},value:{1},msg:{2}", data.Key, data.Value, e.Message));

            }
            return false ;
        }
    }
}
