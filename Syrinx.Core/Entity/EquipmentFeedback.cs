using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syrinx.Core.Entity
{
    /// <summary>
    /// 设备状态反馈类
    /// </summary>
    public class EquipmentFeedback
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
        public int Option { get; set; }
        #endregion //Property
    }
}
