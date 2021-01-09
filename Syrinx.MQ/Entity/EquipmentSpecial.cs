using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syrinx.MQ.Entity
{
    /// <summary>
    /// 设备特殊控制
    /// </summary>
    public class EquipmentSpecial
    {
        #region Property
        /// <summary>
        /// 设备序列号
        /// </summary>
        [Required]
        public string SerialNumber { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        [Required]
        public int DeviceType { get; set; }

        /// <summary>
        /// 控制类型
        /// </summary>
        [Required]
        public int ControlType { get; set; }

        /// <summary>
        /// 控制参数
        /// </summary>
        [Required]
        public string Option { get; set; }
        #endregion //Property
    }
}
