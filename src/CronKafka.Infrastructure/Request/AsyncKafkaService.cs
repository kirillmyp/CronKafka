using CronKafka.Infrastructure.Request.Interface;
using System.Net.Http;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace CronKafka.Infrastructure.Request
{
    public class AsyncKafkaService: IAsyncCallService
    {
        private readonly HttpClient _client;

        /// <summary>
        /// Initializes a new instance of the <see cref="AsyncKafkaService"/> class.
        /// </summary>
        /// <param name="client">The <see cref="HttpClient"/> client for sending http request.</param>
        public AsyncKafkaService(HttpClient client) => (_client) = (client);

        /// <summary>
        /// Send a UDP request to service
        /// </summary>
        /// <param name="url">full url of service</param>
        /// <param name="port">port to connection with service</param>
        /// <returns></returns>
        public async Task MakeRequest(string url, int port)
        {
            await new UdpClient(url, port).SendAsync(new byte[0], 0);
        }
    }
}
