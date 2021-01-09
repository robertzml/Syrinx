using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;

namespace Syrinx.DB.DAL
{
    using Syrinx.Base.Options;
    using Syrinx.DB.IDAL;
    using Syrinx.DB.Entity;
    using InfluxDB.Client;

    /// <summary>
    /// 基础数据数据访问类
    /// </summary>
    public class BasicRepository : IBasicRepository, IDisposable
    {
        #region Field
        private ILogger<BasicRepository> logger;

        private IOptions<InfluxOptions> option;

        /// <summary>
        /// InfluxDB 客户端
        /// </summary>
        private InfluxDBClient influxClient;
        #endregion // Field

        #region Constructor
        public BasicRepository(ILogger<BasicRepository> logger, IOptions<InfluxOptions> option)
        {
            this.logger = logger;
            this.option = option;

            this.influxClient = InfluxDBClientFactory.Create(option.Value.Server, option.Value.Token);
            this.logger.LogInformation("connect to influx");
        }

        public void Dispose()
        {
            this.influxClient.Dispose();
            this.logger.LogInformation("dispose in influx");
        }
        #endregion //Constructor

        #region Method

        #endregion //Method
    }
}
