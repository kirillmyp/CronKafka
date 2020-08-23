using CronKafka.Config;
using CronKafka.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CronKafka
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">Configuration.</param>
        /// <param name="loggerFactory">logger factory.</param>
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to register with.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettingsOptions>(_configuration);

            services.AddHealthChecks();
            services.AddBackgroundServices();
            services.AddHttpContextAccessor();
            services.AddMiddlewareServices();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAllOrigins", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowCredentials().AllowAnyMethod());
            });

            //services.AddHttpClient<IAsyncQueryService, AsyncQueryService>();
        }

        /// <summary>
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The <see cref="IApplicationBuilder"/> to provide the mechanisms to configure an application's request pipeline.</param>
        /// <param name="env">The <see cref="IHostingEnvironment"/> to provide information about the web hosting environment an application is running in.</param>
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseHealthChecks("/health");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
