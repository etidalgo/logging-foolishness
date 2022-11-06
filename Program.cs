using Autofac;

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
            var distraction = scope.Resolve<IDistraction>();

            distraction.Distract();
        }
    }
}