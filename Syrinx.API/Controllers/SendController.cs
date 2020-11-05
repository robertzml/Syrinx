using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Syrinx.API.Controllers
{
    using Microsoft.VisualBasic;
    using Syrinx.API.MQ;

    /// <summary>
    /// 下发控制器
    /// </summary>
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SendController : ControllerBase
    {
        #region Action
        [HttpPost]
        public ActionResult<string> HeartBeat(SendOption obj)
        {
            Publisher publisher = new Publisher();
            publisher.Send(obj.msg);

            return "success";
        }
        #endregion // Action
    }

    public class SendOption
    {
        public string msg { get; set; }
    }
}
