using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InfluxDB.Client;

namespace Syrinx.DB.DAL
{
    using Microsoft.Extensions.Logging;
    using Syrinx.DB.IDAL;
    using Syrinx.DB.Entity;

    public class CumulationRepository : ICumulationRepository
    {
        #region Field
        private string token = "gbyCQceil3fWCfUzeXDPxG2Xa3rUMz3BRG64vyCqGsv2tsEIhCP1xlDszuxqtCBkUAEMrThcpHXI_U3nNHRaSQ==";

        private ILogger<CumulationRepository> logger;
        #endregion // Field

        #region Constructor
        public CumulationRepository(ILogger<CumulationRepository> logger)
        {
            this.logger = logger;
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
            var influxDBClient = InfluxDBClientFactory.Create("http://47.111.23.211:8086", token);

            this.logger.LogInformation("connect to influxdb");

            var flux = "import \"influxdata/influxdb/schema\" " +
                "from(bucket:\"Molan\") " +
                "|> range(start: -1d) " +
                "|> filter(fn: (r) => r._measurement == \"cumulative\" and r.serialNumber == \"" + serialNumber + "\") " +
                "|> filter(fn: (r) => r._field == \"cumulateHotWater\" or r._field == \"cumulateWorkTime\") " +
                "|> schema.fieldsAsCols() " +
                "|> keep(columns: [\"_time\", \"_measurement\", \"serialNumber\", \"mainboardNumber\", \"cumulateWorkTime\", \"cumulateHotWater\"])";

            var queryApi = influxDBClient.GetQueryApi();

            List<Cumulation> data = new List<Cumulation>();

            //
            // QueryData
            //
            var tables = await queryApi.QueryAsync(flux, "sdj");

            if (tables.Count == 0)
                return data;

            foreach (var record in tables[0].Records)
            {
                Cumulation cum = new Cumulation();
                cum.Time = record.GetTimeInDateTime().Value.ToLocalTime();
                cum.SerialNumber = record.GetValueByKey("serialNumber").ToString();
                cum.HotWater = Convert.ToInt32(record.GetValueByKey("cumulateHotWater"));
                cum.WorkTime = Convert.ToInt32(record.GetValueByKey("cumulateWorkTime"));

                data.Add(cum);
            }

            influxDBClient.Dispose();

            return data;
        }
        #endregion //Method
    }
}
