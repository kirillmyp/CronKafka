namespace CronKafka.Infrastructure.Config
{
    public class ServiceOptions
    {
        /// <summary>
        /// URL of calling service.
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// Method connect.
        /// </summary>
        public string Method { get; set; }

        /// <summary>
        /// Port connect.
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// Delay period of calling service.
        /// </summary>
        public double Delay { get; set; }
    }
}
