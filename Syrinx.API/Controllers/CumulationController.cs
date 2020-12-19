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
    /// 累积数据查询控制器
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class CumulationController : ControllerBase
    {
        #region Field
        private ILogger<CumulationController> _logger;

        /// <summary>
        /// 累积数据存储类
        /// </summary>
        private ICumulationRepository cumulationRepository;
        #endregion //Field

        #region Constructor
        public CumulationController(ILogger<CumulationController> logger, ICumulationRepository cumulationRepository)
        {
            this._logger = logger;

            this.cumulationRepository = cumulationRepository;
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 获取设备累积用量
        /// </summary>
        /// <param name="serialNumber">设备序列号</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ResponseData<List<Cumulation>>>> List(string serialNumber)
        {
            var data = await cumulationRepository.GetCumulativeData(serialNumber);

            return RestHelper<List<Cumulation>>.MakeResponse(data, 0, "success");
        }
        #endregion //Action
    }
}
