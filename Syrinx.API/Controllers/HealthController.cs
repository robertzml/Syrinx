using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Syrinx.API.Controllers
{
    using Syrinx.API.Models;
    using Syrinx.API.Utility;

    /// <summary>
    /// 健康检查控制器
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        #region Field
        private ILogger<HealthController> _logger;
        #endregion //Field

        #region Constructor
        public HealthController(ILogger<HealthController> logger)
        {
            this._logger = logger;
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 健康检查
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<ResponseData<string>> Check()
        {
            this._logger.LogInformation("health check");
            return RestHelper<string>.MakeSuccess("ok");
        }
        #endregion //Action
    }
}
