using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core_redis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;

namespace core_redis_rabbitmq
{
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            //获取redis数据连接
            var host = ((ConfigurationSection)Configuration.GetSection("RedisConnectionStrings:Host")).Value;
            var port = ((ConfigurationSection)Configuration.GetSection("RedisConnectionStrings:Port")).Value;
            var password = ((ConfigurationSection)Configuration.GetSection("RedisConnectionStrings:Password")).Value;
            services.AddSingleton(new RedisHelper(host, Convert.ToInt32(port), password));
            //跨域配置
            var urls = Configuration["AppCores"].Split(',');
            services.AddCors(options => options.AddPolicy("Cors",
                policy => policy.WithOrigins(urls).AllowAnyMethod().AllowAnyHeader().AllowCredentials())
            );
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseCors("Cors");
            app.UseMvc();
        }
    }
}
