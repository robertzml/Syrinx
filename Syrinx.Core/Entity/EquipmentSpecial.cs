﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syrinx.Core.Entity
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
        public string Option { get; set; }
        #endregion //Property
    }
}
