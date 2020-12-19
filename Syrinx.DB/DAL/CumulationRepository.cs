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

    public class CumulationRepository : ICumulationRepository
    {
        #region Field
        private string token = "gbyCQceil3fWCfUzeXDPxG2Xa3rUMz3BRG64vyCqGsv2tsEIhCP1xlDszuxqtCBkUAEMrThcpHXI_U3nNHRaSQ==";

        private ILogger<CumulationRepository> logger;

        private IOptions<InfluxOptions> option;
        #endregion // Field

        #region Constructor
        public CumulationRepository(ILogger<CumulationRepository> logger, IOptions<InfluxOptions> option)
        {
            this.logger = logger;
            this.option = option;
        }
        #endregion //Constructor

        #region Method
        /// <summary>
        /// 获取累积数据
        /// </summary>
        /// <param name="serialNumber">设备序列号</param>
        /// <returns></returns>
        public async Task<List<Cumulation>> GetCumulativeData(string serialNumber)
        {
            var influxDBClient = InfluxDBClientFactory.Create(option.Value.Server, option.Value.Token);

            this.logger.LogInformation("connect to influxdb");

            var flux = "import \"influxdata/influxdb/schema\" " +
                "from(bucket:\"Molan\") " +
                "|> range(start: -1d) " +
                "|> filter(fn: (r) => r._measurement == \"cumulative\" and r.serialNumber == \"" + serialNumber + "\") " +
                "|> filter(fn: (r) => r._field == \"cumulateHotWater\" or r._field == \"cumulateWorkTime\") " +
                "|> schema.fieldsAsCols() " +
                "|> keep(columns: [\"_time\", \"_measurement\", \"serialNumber\", \"mainboardNumber\", \"cumulateWorkTime\", \"cumulateHotWater\"])";

            var queryApi = influxDBClient.GetQueryApi();

            var data = await queryApi.QueryAsync<Cumulation>(flux, option.Value.Org);

            data.ForEach(r => r.Time = r.Time.ToLocalTime());

            influxDBClient.Dispose();

            return data;
        }
        #endregion //Method
    }
}
