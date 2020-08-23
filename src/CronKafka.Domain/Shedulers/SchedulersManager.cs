using CronKafka.Infrastructure.Config;
using CronKafka.Infrastructure.Repositories.Interface;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CronKafka.Shedulers
{
    public class SchedulersManager : IHostedService, IDisposable
    {
        public IAsyncExecutor _executorAsyncQuery;
        private readonly List<ServiceOptions> services;
        private List<Timer> timers;

        public SchedulersManager(IAsyncExecutor executorAsyncQuery) => (_executorAsyncQuery) = (executorAsyncQuery);

        /// <inheritdoc />
        public Task StartAsync(CancellationToken cancellationToken)
        {
            timers = new List<Timer>();
            Parallel.ForEach(services, Run);

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public Task StopAsync(CancellationToken cancellationToken)
        {
            foreach (Timer timer in timers)
            {
                timer?.Change(Timeout.Infinite, 0);
            }

            return Task.CompletedTask;
        }

        /// <inheritdoc />
        public void Dispose()
        {
            foreach (Timer timer in timers)
            {
                timer?.Change(Timeout.Infinite, 0);
            }
        }

        private void Run(ServiceOptions service)
        {
            if (service.Delay > 0)
            {
                timers.Add(new Timer((lockObject) => BackgroundTaskAsync(lockObject, service), new { }, TimeSpan.Zero, TimeSpan.FromSeconds(service.Delay)));
            }
        }

        private async void BackgroundTaskAsync(object lockObject, ServiceOptions service)
        {
            await ExecuteAsync(service);
        }

        private async Task ExecuteAsync(ServiceOptions service)
        {
            try
            {
                await _executorAsyncQuery.RunAsync(service);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
