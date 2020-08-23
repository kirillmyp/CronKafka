using CronKafka.Infrastructure.Repositories;
using CronKafka.Infrastructure.Repositories.Interface;
using CronKafka.Infrastructure.Request;
using CronKafka.Infrastructure.Request.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CronKafka.Extensions
{
    public static class MiddlewareExtensions
    {
        /// <summary>
        /// Add classes registration for the given types.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to register with.</param>
        /// <returns>The original <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddMiddlewareServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services
                .AddSingleton<IAsyncExecutor, AsyncExecutor>()
                .AddSingleton<IAsyncCallService, AsyncKafkaService>();

            return services;
        }
    }
}
