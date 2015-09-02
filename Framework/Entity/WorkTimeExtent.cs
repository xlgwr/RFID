using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Entity
{
    /// <summary>
    /// 计算送货最晚到货时间的类
    /// </summary>
    public class WorkTimeExtent
    {
        public List<Extent> list = new List<Extent>();
        /// <summary>
        /// 添加工作区间
        /// </summary>
        /// <param name="fdt"></param>
        /// <param name="tdt"></param>
        public void Add(DateTime fdt, DateTime tdt)
        {

            if ((fdt.Hour * 60 + fdt.Minute) <= (tdt.Hour * 60 + tdt.Minute)) //fdt.CompareTo(tdt) <= 0
                list.Add(new Extent { From = fdt.Hour * 60 + fdt.Minute, To = tdt.Hour * 60 + tdt.Minute });
            else
            {
                if (list.Count(m => m.From == 0) == 0)
                {
                    list.Add(new Extent { From = fdt.Hour * 60 + fdt.Minute, To = 24 * 60 });
                    list.Add(new Extent { From = 00 * 60, To = tdt.Hour * 60 + tdt.Minute });
                }
                else
                    throw new Exception("工作区间异常，不可能存在两个跨0点区间！");

            }
        }

        public void Add(long fdt, long tdt)
        {
            Add(new DateTime(fdt), new DateTime(tdt));
        }
        protected void Add(Extent ext)
        {
            this.list.Add(ext);
        }

        /// <summary>
        /// 是否是工作时间
        /// </summary>
        /// <param name="minute"></param>
        /// <returns></returns>
        public bool IsWorking(long minute)
        {
            minute = minute % 1440;
            return (list.Count(m => m.From <= minute && minute <= m.To)) > 0;
        }

        /// <summary>
        /// 最晚到货时间
        /// </summary>
        /// <param name="start">起算时间(从空箱出库算起)</param>
        /// <param name="len">到货期限上限(分钟)</param>
        /// <returns></returns>
        public DateTime GetExpiredDateTime(DateTime start, long len)
        {
            long loc = start.Hour * 60 + start.Minute;
            int sec = start.Second;
            long step = 0;
            long expired = 0;

            while (step < len)
            {
                bool b = this.IsWorking(loc + expired);
                if (b)
                {
                    step++;
                }
                expired++;
            }
            return start.Date.AddMinutes(loc + expired).AddSeconds(sec);
        }
        public WorkTimeExtent() { }
        public WorkTimeExtent Clone()
        {
            var wte = new WorkTimeExtent();
            foreach (Extent e in list)
            {
                wte.Add((Extent)e.Clone());
            }
            return wte;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (Extent e in this.list)
            {
                sb.AppendFormat("{0}-->{1}\n", e.From, e.To);
            }
            return sb.ToString();
        }
    }

    /// <summary>
    /// 存储工作时间区间的类
    /// </summary>
    public class Extent : ICloneable
    {
        public long From { get; set; }
        public long To { get; set; }

        #region ICloneable 成员

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        #endregion
    }
}
