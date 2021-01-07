using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Syrinx.API
{
    using Syrinx.API.MQ;
    using Syrinx.Base.Options;
    using Syrinx.DB.IDAL;
    using Syrinx.DB.DAL;

    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // 注入RabbitMQ配置
            services.Configure<RabbitOptions>(Configuration.GetSection("RabbitMQ"));

            // 注入InfluxDB配置
            services.Configure<InfluxOptions>(Configuration.GetSection("InfluxDB"));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Syrinx API", Version = "v1" });

                // Set the comments path for the Swagger JSON and UI.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                var coreXmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml".Replace("API", "Core");
                var coreXmlPath = Path.Combine(AppContext.BaseDirectory, coreXmlFile);
                c.IncludeXmlComments(coreXmlPath);

                var dbXmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml".Replace("API", "DB");
                var dbXmlPath = Path.Combine(AppContext.BaseDirectory, dbXmlFile);
                c.IncludeXmlComments(dbXmlPath);
            });

            // 注入消息队列
            services.AddSingleton<IMessageQueue, RabbitQueue>();

            services.AddScoped<ICumulationRepository, CumulationRepository>();
            services.AddScoped<IAlarmRepository, AlarmRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Syrinx API v1"));

                app.UseReDoc(c =>
                {
                    c.SpecUrl("/swagger/v1/swagger.json");
                    c.RoutePrefix = "api-docs";
                    c.DocumentTitle = "Syrinx API V1";
                });
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
