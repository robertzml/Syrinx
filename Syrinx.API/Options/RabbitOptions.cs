using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Syrinx.API.Options
{
    public class RabbitOptions : IOptions<RabbitOptions>
    {
        public RabbitOptions Value => this;

        /// <summary>
        /// Rabbit MQ 主机
        /// </summary>
        public string HostName { get; set; }

        /// <summary>
        /// Rabbit MQ 端口
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Rabbit MQ 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Rabbit MQ 密码
        /// </summary>
        public string Password { get; set; }
    }
}
