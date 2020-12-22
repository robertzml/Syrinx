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
    /// 报警数据类
    /// </summary>
    [Measurement("cumulative")]
    public class Alarm
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
        /// 记录时间
        /// </summary>
        [Column("logTime")]
        public long LogTime { get; set; }

        /// <summary>
        /// 故障代码
        /// </summary>
        [Column("errorCode")]
        public int ErrorCode { get; set; }

        /// <summary>
        /// 故障时间
        /// </summary>
        [Column("errorTime")]
        public long ErrorTime { get; set; }

        /// <summary>
        /// 时间
        /// </summary>
        [Required]
        [Column(IsTimestamp = true)]
        public DateTime Time { get; set; }
    }
}
