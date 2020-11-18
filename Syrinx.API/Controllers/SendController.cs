using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;

namespace Syrinx.API.Controllers
{
    using Syrinx.API.Models;
    using Syrinx.API.MQ;
    using Syrinx.API.Utility;
    using Syrinx.Core.Entity;

    /// <summary>
    /// 设备操作下发控制器
    /// </summary>
    [Produces("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SendController : ControllerBase
    {
        #region Field
        /// <summary>
        /// 消息队列
        /// </summary>
        private IMessageQueue _messageQueue;

        private ILogger<SendController> _logger;
        #endregion //Field

        #region Constructor
        public SendController(IMessageQueue messageQueue, ILogger<SendController> logger)
        {
            this._messageQueue = messageQueue;
            this._logger = logger;
        }
        #endregion //Constructor

        #region Action
        /// <summary>
        /// 设备控制
        /// </summary>
        /// <param name="model"></param>
        /// <returns>控制结果</returns>
        /// <remarks>
        /// Sample Request:
        /// 
        ///     POST /control
        ///     {
        ///         "serialNumber": "123456",
        ///         "deviceType": 1,
        ///         "controlType": 1,
        ///         "option": 1
        ///      }
        /// </remarks>
        [HttpPost]
        public ActionResult<ResponseData<int>> Control(EquipmentControl model)
        {
            var serializeOptions = new JsonSerializerOptions
            {
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All),
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var msg = JsonSerializer.Serialize<EquipmentControl>(model, serializeOptions);
            this._logger.LogInformation(msg);

            this._messageQueue.Push(msg);
            return RestHelper<int>.MakeResponse(0, 0, "success");
        }
        #endregion // Action
    }
}
