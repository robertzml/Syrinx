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
        private string token = "Hc6eaZomSLbT1EQ17y0U9qvQC7ZLI5EIbp3ZzdOltZqOHDzMI36tKYWumbZbbTMT6BLpyY8nJLQ9gdBj-kF1jA==";

        private ILogger logger;
        #endregion // Field

        #region Constructor
        public CumulationRepository(ILogger logger)
        {
            this.logger = logger;
        }
        #endregion //Constructor

        #region Method
        public async Task<List<Cumulation>> GetCumulateHotWater(string serialNumber)
        {
            var influxDBClient = InfluxDBClientFactory.Create("http://47.111.23.211:8086", token);

            var flux = "from(bucket:\"Molan\") " +
                "|> range(start: -1d) " +
                "|> filter(fn: (r) => r._measurement == \"cumulative\" and r.serialNumber == \"" + serialNumber + "\") " +
                "|> filter(fn: (r) => r._field == \"cumulateHotWater\" or r._field == \"cumulateWorkTime\")";

            var queryApi = influxDBClient.GetQueryApi();

            List<Cumulation> data = new List<Cumulation>();

            //
            // QueryData
            //
            var tables = await queryApi.QueryAsync(flux, "sdj");

            var len = tables[0].Records.Count;

            for (int i = 0; i < len; i++)
            {
                Cumulation cum = new Cumulation();

                cum.Time = tables[0].Records[i].GetTime().Value.ToDateTimeUtc().ToLocalTime();

                cum.SerialNumber = tables[0].Records[i].GetValueByKey("serialNumber").ToString();
                cum.HotWater = Convert.ToInt32(tables[0].Records[i].GetValueByKey("_value"));
                cum.WorkTime = Convert.ToInt32(tables[1].Records[i].GetValueByKey("_value"));

                data.Add(cum);

                this.logger.LogInformation(cum.ToString());
            }

            //tables.ForEach(table =>
            //{
            //    table.Records.ForEach(record =>
            //    {
            //        Console.WriteLine($"{record.GetTime()}: {record.GetValueByKey("_value")}");
            //        this.logger.LogInformation($"{record.GetTime()}: {record.GetValueByKey("_value")}");
            //    });
            //});

            //var cumulations = await queryApi.QueryAsync<Cumulation>(flux, "sdj");
            //cumulations.ForEach(r =>
            //{
            //    this.logger.LogInformation($"{r.Time}: hot water: {r.HotWater}");
            //});

            influxDBClient.Dispose();

            //return cumulations;

            return data;
        }
        #endregion //Method
    }
}
