using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace Syrinx.Base.Options
{
    /// <summary>
    /// InfluxDB 配置
    /// </summary>
    public class InfluxOptions : IOptions<InfluxOptions>
    {
        public InfluxOptions Value => this;

        /// <summary>
        /// InfluxDB 服务器
        /// </summary>
        public string Server { get; set; }

        /// <summary>
        /// InfluxDB Token
        /// </summary>
        public string Token { get; set; }

        /// <summary>
        /// InfluxDB 组织
        /// </summary>
        public string Org { get; set; }
    }
}
