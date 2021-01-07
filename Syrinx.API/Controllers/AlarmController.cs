using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syrinx.API.Controllers
{
    using Microsoft.Extensions.Logging;
    using Syrinx.API.Models;
    using Syrinx.API.Utility;
    using Syrinx.DB.IDAL;
    using Syrinx.DB.DAL;
    using Syrinx.DB.Entity;

    /// <summary>
    /// 报警数据查询控制器
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AlarmController : ControllerBase
    {
        #region Field
        private ILogger<AlarmController> _logger;

        /// <summary>
        /// 报警数据存储类
        /// </summary>
        private IAlarmRepository alarmRepository;
        #endregion //Field

        #region Constructor
        public AlarmController(ILogger<AlarmController> logger, IAlarmRepository alarmRepository)
        {
            this._logger = logger;

            this.alarmRepository = alarmRepository;
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 获取设备报警数据
        /// </summary>
        /// <param name="serialNumber">设备序列号</param>
        /// <param name="start">起始时间</param>
        /// <param name="stop">截止时间</param>
        /// <returns>
        /// 报警数据列表
        /// </returns>
        [HttpGet]
        public async Task<ActionResult<ResponseData<List<Alarm>>>> List(string serialNumber, DateTime start, DateTime stop)
        {
            var data = await alarmRepository.GetAlarmData(serialNumber, start, stop);

            return RestHelper<List<Alarm>>.MakeResponse(data, 0, "success");
        }
        #endregion //Action
    }
}
