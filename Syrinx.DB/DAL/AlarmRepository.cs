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
    /// 报警数据数据访问类
    /// </summary>
    public class AlarmRepository : IAlarmRepository, IDisposable
    {
        #region Field
        private ILogger<AlarmRepository> logger;

        private IOptions<InfluxOptions> option;

        /// <summary>
        /// InfluxDB 客户端
        /// </summary>
        private InfluxDBClient influxClient;
        #endregion // Field

        #region Constructor
        public AlarmRepository(ILogger<AlarmRepository> logger, IOptions<InfluxOptions> option)
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
        /// 获取报警数据
        /// </summary>
        /// <param name="serialNumber">设备序列号</param>
        /// <returns>
        /// 报警数据列表
        /// </returns>
        public async Task<List<Alarm>> GetAlarmData(string serialNumber)
        {
            this.logger.LogInformation("get alarm data in influxdb");

            var flux = "import \"influxdata/influxdb/schema\" " +
                "from(bucket:\"Molan\") " +
                "|> range(start: -1d) " +
                "|> filter(fn: (r) => r._measurement == \"alarm\" and r.serialNumber == \"" + serialNumber + "\") " +
                "|> schema.fieldsAsCols() ";

            var queryApi = influxClient.GetQueryApi();

            var data = await queryApi.QueryAsync<Alarm>(flux, option.Value.Org);
            data.ForEach(r => r.Time = r.Time.ToLocalTime());

            return data;
        }
        #endregion //Method
    }
}
