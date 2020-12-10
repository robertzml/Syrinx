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
    using Syrinx.DB.DAL;

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
        #endregion //Field

        #region Constructor
        public CumulationController(ILogger<CumulationController> logger)
        {
            this._logger = logger;
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 获取设备累积热水用量
        /// </summary>
        /// <param name="serialNumber">设备序列号</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<ResponseData<string>>> GetHotWater(string serialNumber)
        {
            CumulationRepository repository = new CumulationRepository(this._logger);
            await repository.GetCumulateHotWater(serialNumber);

            return RestHelper<string>.MakeResponse("ok", 0, "success");
        }
        #endregion //Action
    }
}
