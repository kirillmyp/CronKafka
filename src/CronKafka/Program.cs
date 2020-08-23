using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace CronKafka
{
    public class Program
    {
        /// <summary>
        /// An entry point for an application.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        /// <summary>
        /// Host configuration builder.
        /// </summary>
        /// <param name="args">Command-line arguments.</param>
        /// <returns>The <see cref="IHostBuilder"/> instance.</returns>
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
