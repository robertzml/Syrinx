﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        #region Action
        /// <summary>
        /// 健康检查
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult<ResponseData<string>> Check()
        {
            return RestHelper<string>.MakeResponse("ok", 0, "success");
        }
        #endregion //Action
    }
}
