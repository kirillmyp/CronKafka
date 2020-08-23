using CronKafka.Infrastructure.Config;
using CronKafka.Infrastructure.Repositories.Interface;
using CronKafka.Infrastructure.Request.Interface;
using System;
using System.Threading.Tasks;

namespace CronKafka.Infrastructure.Repositories
{
    public class AsyncExecutor: IAsyncExecutor
    {
        private readonly IAsyncCallService _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncExecutor"/> class.
        /// </summary>
        /// <param name="client">asyncQueryClient.</param>
        public AsyncExecutor(IAsyncCallService client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        /// <inheritdoc />
        public async Task RunAsync(ServiceOptions service)
        {
            await _client.MakeRequest(service.Url, service.Port);
        }
    }
}
