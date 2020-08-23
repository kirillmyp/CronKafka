using CronKafka.Infrastructure.Config;
using System.Threading.Tasks;

namespace CronKafka.Infrastructure.Repositories.Interface
{
    public interface IAsyncExecutor
    {
        public Task RunAsync(ServiceOptions service);
    }
}
