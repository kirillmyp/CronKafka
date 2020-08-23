using CronKafka.Infrastructure.Config;
using System.Collections.Generic;

namespace CronKafka.Config
{
    /// <summary>
    /// Configuration class with a structure that matches a configuration.
    /// </summary>
    public class AppSettingsOptions
    {
        /// <summary>
        /// The section of configuration that provides service settings.
        /// </summary>
        public IEnumerable<ServiceOptions> Services { get; }
    }
}
