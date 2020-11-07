using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Syrinx.API.Controllers
{
    using Syrinx.API.MQ;
    using Syrinx.Core.Entity;

    /// <summary>
    /// 设备操作下发控制器
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

        /// <summary>
        /// 设备控制
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ActionResult<string> Control(EquipmentControl model)
        {
            return "success";
        }
        #endregion // Action
    }

    public class SendOption
    {
        public string msg { get; set; }
    }
}
