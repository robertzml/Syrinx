using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syrinx.DB.Entity
{
    using InfluxDB.Client.Core;

    /// <summary>
    /// 累积数据表
    /// </summary>
    [Measurement("cumulative")]
    public class Cumulation
    {
        [Column("serialNumber", IsTag = true)] 
        public string SerialNumber { get; set; }

        [Column("value")] 
        public int HotWater { get; set; }

        [Column("cumulateWorkTime")]
        public int WorkTime { get; set; }

        [Column(IsTimestamp = true)] 
        public DateTime Time { get; set; }
    }
}
