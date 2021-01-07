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
    [Measurement("basic")]
    public class Basic
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
        /// Device类型
        /// </summary>
        [Column("deviceType")]
        public string DeviceType { get; set; }

        /// <summary>
        /// Controller型号
        /// </summary>
        [Column("controllerType")]
        public string ControllerType { get; set; }

        /// <summary>
        /// wifi模块程序版本号
        /// </summary>
        [Column("wifiVersion")]
        public string WifiVersion { get; set; }

        /// <summary>
        /// 软件功能
        /// </summary>
        [Column("softwareFunction")]
        public string SoftwareFunction { get; set; }

        /// <summary>
        /// ICCID
        /// </summary>
        [Column("iccid")]
        public string ICCID { get; set; }
        #endregion //Property
    }
}
