using Autofac;
using Microsoft.Extensions.Logging;

namespace LogLab
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var cb = new ContainerBuilder();
            cb.RegisterModule<ServicesRegistrationModule>();
            var container = cb.Build();

            using var scope = container.BeginLifetimeScope();

            var loggerFactory = scope.Resolve<ILoggerFactory>();
            loggerFactory.AddLog4Net();

            var logger = scope.Resolve<ILogger<Program>>();

            try
            {
                var distraction = scope.Resolve<IDistraction>();
                distraction.Distract();
            }
            catch
            {
                // disappear the exception, this is a practice program
                logger.LogInformation("info: this did not run to distraction");
                logger.LogError("error: this did not run to distraction");
            }

            try
            {
                var diversion = scope.Resolve<IDiversion>();
                diversion.Divert();
            }
            catch
            {
                // disappear the exception, this is a practice program
                logger.LogError("error: this did not run the diversion");
                logger.LogInformation("info: this did not run the diversion");
            }
        }
    }
}
