using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Syrinx.API.Models
{
    /// <summary>
    /// 返回数据
    /// </summary>
    public class ResponseData<T>
    {
        /// <summary>
        /// 错误码
        /// </summary>
        public int ErrorCode { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 对象
        /// </summary>
        public T Result { get; set; }

        /// <summary>
        /// 响应时间
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 服务端IP
        /// </summary>
        public string IpAddress { get; set; }
    }
}
