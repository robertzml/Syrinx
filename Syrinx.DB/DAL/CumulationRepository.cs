using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluxDB.Client;

namespace Syrinx.DB.DAL
{
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.Logging;
    using Syrinx.Base.Options;
    using Syrinx.DB.IDAL;
    using Syrinx.DB.Entity;

    /// <summary>
    /// 累积数据数据访问类
    /// </summary>
    public class CumulationRepository : ICumulationRepository, IDisposable
    {
        #region Field
        private ILogger<CumulationRepository> logger;

        private IOptions<InfluxOptions> option;

        /// <summary>
        /// InfluxDB 客户端
        /// </summary>
        private InfluxDBClient influxClient;
        #endregion // Field

        #region Constructor
        public CumulationRepository(ILogger<CumulationRepository> logger, IOptions<InfluxOptions> option)
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
        /// <summary>
        /// 获取累积数据
        /// </summary>
        /// <param name="serialNumber">设备序列号</param>
        /// <param name="start">起始时间</param>
        /// <param name="stop">截止时间</param>
        /// <returns></returns>
        public async Task<List<Cumulation>> GetCumulativeData(string serialNumber, DateTime start, DateTime stop)
        {
            this.logger.LogInformation("get data in influxdb");

            DateTimeOffset dtoStart = new DateTimeOffset(start);
            var s1 = dtoStart.ToUnixTimeSeconds();

            DateTimeOffset dtoStop = new DateTimeOffset(stop);
            var s2 = dtoStop.ToUnixTimeSeconds();

            var flux = "import \"influxdata/influxdb/schema\" " +
                "from(bucket:\"Molan\") " +
                "|> range(start: " + s1.ToString() + ", stop: " + s2.ToString() + ") " +
                "|> filter(fn: (r) => r._measurement == \"cumulative\" and r.serialNumber == \"" + serialNumber + "\") " +
                "|> schema.fieldsAsCols() ";

            var queryApi = influxClient.GetQueryApi();

            var data = await queryApi.QueryAsync<Cumulation>(flux, option.Value.Org);
            data.ForEach(r => r.Time = r.Time.ToLocalTime());

            return data;
        }
        #endregion //Method
    }
}
