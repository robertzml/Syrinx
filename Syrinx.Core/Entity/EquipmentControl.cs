using System;
using System.Collections.Generic;
using System.Text;

namespace Syrinx.Core.Entity
{
    /// <summary>
    /// 设备控制操作类
    /// </summary>
    public class EquipmentControl
    {
        #region Property
        /// <summary>
        /// 设备序列号
        /// </summary>
        public string SerialNumber { get; set; }

        /// <summary>
        /// 设备类型
        /// </summary>
        public int DeviceType { get; set; }

        /// <summary>
        /// 控制类型
        /// </summary>
        public int ControlType { get; set; }

        /// <summary>
        /// 控制参数
        /// </summary>
        public int Option { get; set; }

        /// <summary>
        /// 允许使用时间(时间戳)
        /// </summary>
        public long Deadline { get; set; }
        #endregion //Property
    }
}
