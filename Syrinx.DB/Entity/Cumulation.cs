using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syrinx.DB.Entity
{
    using InfluxDB.Client.Core;

    /// <summary>
    /// 累积数据类
    /// </summary>
    [Measurement("cumulative")]
    public class Cumulation
    {
        /// <summary>
        /// 设备序列号
        /// </summary>
        [Column("serialNumber", IsTag = true)] 
        public string SerialNumber { get; set; }

        /// <summary>
        /// 主板序列号
        /// </summary>
        [Column("mainboardNumber", IsTag = true)]
        public string MainboardNumber { get; set; }

        /// <summary>
        /// 累积热水用量
        /// </summary>
        [Column("cumulateHotWater")] 
        public int HotWater { get; set; }

        /// <summary>
        /// 累积工作时间
        /// </summary>
        [Column("cumulateWorkTime")]
        public int WorkTime { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [Column(IsTimestamp = true)] 
        public DateTime Time { get; set; }
    }
}
