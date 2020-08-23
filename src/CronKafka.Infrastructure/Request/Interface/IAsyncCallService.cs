using System.Threading.Tasks;

namespace CronKafka.Infrastructure.Request.Interface
{
    public interface IAsyncCallService
    {
        /// <summary>
        /// Send a request to service
        /// </summary>
        /// <param name="url">full url of service</param>
        /// <param name="port">port to connection with service</param>
        /// <returns></returns>
        Task MakeRequest(string url, int port);
    }
}
