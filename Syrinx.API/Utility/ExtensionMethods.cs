using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Syrinx.API.Utility
{
    using Syrinx.DB.IDAL;
    using Syrinx.DB.DAL;

    /// <summary>
    /// 扩展方法
    /// </summary>
    public static class ExtensionMethods
    {
        /// <summary>
        /// 业务类依赖注入
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
        public static IServiceCollection AddDataService(this IServiceCollection services)
        {
            services.AddScoped<ICumulationRepository, CumulationRepository>();
            services.AddScoped<IAlarmRepository, AlarmRepository>();

            return services;
        }
    }
}
