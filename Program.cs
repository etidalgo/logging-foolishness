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
            catch(Exception ex)
            {
                // disappear the exception, this is a practice program
                logger.LogInformation("info: this did not run to distraction", ex.Message);
                logger.LogError("error: this did not run to distraction", ex);
            }

            var diversion = scope.Resolve<IDiversion>();
            diversion.Divert();

            try
            {
                var diversion2 = scope.Resolve<IDiversion>();
                diversion2.Divert();
            }
            catch (Exception ex)
            {
                // disappear the exception, this is a practice program
                logger.LogError("error: this did not run the diversion", ex);
                logger.LogInformation("info: this did not run the diversion", ex);
            }
        }
    }
}
