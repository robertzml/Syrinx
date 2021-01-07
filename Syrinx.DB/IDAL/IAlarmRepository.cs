using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Syrinx.DB.IDAL
{
    using Syrinx.DB.Entity;

    /// <summary>
    /// 报警数据访问接口
    /// </summary>
    public interface IAlarmRepository
    {
        /// <summary>
        /// 获取报警数据
        /// </summary>
        /// <param name="serialNumber">设备序列号</param>
        /// <param name="start">起始时间</param>
        /// <param name="stop">截止时间</param>
        /// <returns></returns>
        Task<List<Alarm>> GetAlarmData(string serialNumber, DateTime start, DateTime stop);
    }
}
