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
    /// 基础数据查询控制器
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BasicController : ControllerBase
    {
        #region Field
        private ILogger<BasicController> _logger;

        /// <summary>
        /// 基础数据存储类
        /// </summary>
        private IBasicRepository basicRepository;
        #endregion //Field

        #region Constructor
        public BasicController(ILogger<BasicController> logger, IBasicRepository basicRepository)
        {
            this._logger = logger;

            this.basicRepository = basicRepository;
        }
        #endregion //Constructor
    }
}
