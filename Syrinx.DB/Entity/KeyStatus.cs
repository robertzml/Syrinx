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
    /// 关键数据类
    /// </summary>
    [Measurement("key_status")]
    public class KeyStatus
    {
        #region Property
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
        /// 激活/非激活状态
        /// </summary>
        [Column("activate")]
        public int Activate { get; set; }

        /// <summary>
        /// 设备主板激活时间
        /// </summary>
        [Column("activationTime")]
        public long ActivationTime { get; set; }

        /// <summary>
        /// 解锁/加锁状态
        /// </summary>
        [Column("unlock")]
        public int Unlock { get; set; }

        /// <summary>
        /// 设备允许使用时间
        /// </summary>
        [Column("deadlineTime")]
        public long DeadlineTime { get; set; }

        /// <summary>
        /// 离线/在线
        /// </summary>
        [Column("online")]
        public int Online { get; set; }

        /// <summary>
        /// 离线/在线变化时间点
        /// </summary>
        [Column("lineTime")]
        public long LineTime { get; set; }
        #endregion //Property
    }
}
