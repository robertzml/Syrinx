using System;
using System.Collections.Generic;
using System.Text;

namespace Syrinx.Base.Common
{
    /// <summary>
    /// 应用配置类
    /// </summary>
    public class AppSettings
    {
        /// <summary>
        /// Rabbit MQ 主机
        /// </summary>
        public static string RabbitMQHostName { get; set; }

        /// <summary>
        /// Rabbit MQ 端口
        /// </summary>
        public static int RabbitMQPort { get; set; }

        /// <summary>
        /// Rabbit MQ 用户名
        /// </summary>
        public static string RabbitMQUserName { get; set; }

        /// <summary>
        /// Rabbit MQ 密码
        /// </summary>
        public static string RabbitMQPassword { get; set; }
    }
}
