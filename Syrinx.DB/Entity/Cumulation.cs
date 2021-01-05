using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
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
        [Column("cumulativeHotWater")] 
        public int CumulativeHotWater { get; set; }

        /// <summary>
        /// 累积工作时间
        /// </summary>
        [Column("cumulativeWorkTime")]
        public int CumulativeWorkTime { get; set; }

        /// <summary>
        /// 累积加热时间
        /// </summary>
        [Column("cumulativeHeatTime")]
        public int CumulativeHeatTime { get; set; }

        /// <summary>
        /// 累积使用电量
        /// </summary>
        [Column("cumulativeUsedPower")]
        public int CumulativeUsedPower { get; set; }

        /// <summary>
        /// 累积节省电量
        /// </summary>
        [Column("cumulativeSavedPower")]
        public int CumulativeSavedPower { get; set; }

        /// <summary>
        /// 冷水进水温度
        /// </summary>
        [Column("coldInTemp")]
        public int ColdInTemp { get; set; }

        /// <summary>
        /// 设定温度
        /// </summary>
        [Column("setTemp")]
        public int SetTemp { get; set; }

        /// <summary>
        /// 节能率
        /// </summary>
        [Column("energySave")]
        public int EnergySave { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [Required]
        [Column(IsTimestamp = true)] 
        public DateTime Time { get; set; }
    }
}
