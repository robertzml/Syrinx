using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Syrinx.API.Controllers
{
    using Syrinx.API.Models;
    using Syrinx.API.Utility;

    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HealthController : ControllerBase
    {
        #region Action
        /// <summary>
        /// 设备控制
        /// </summary>
        /// <returns></returns>
        public ActionResult<ResponseData<string>> Check()
        {
            return RestHelper<string>.MakeResponse("ok", 0, "success");
        }
        #endregion //Action
    }
}
