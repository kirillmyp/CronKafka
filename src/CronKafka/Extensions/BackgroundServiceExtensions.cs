using CronKafka.Shedulers;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CronKafka.Extensions
{
    public static class BackgroundServiceExtensions
    {
        /// <summary>
        /// Add hosted services registration for the given types.
        /// </summary>
        /// <param name="services">The <see cref="IServiceCollection"/> to register with.</param>
        /// <returns>The original <see cref="IServiceCollection"/>.</returns>
        public static IServiceCollection AddBackgroundServices(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services
                .AddHostedService<SchedulersManager>();

            return services;
        }
    }
}
