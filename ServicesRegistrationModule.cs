

using Autofac;
using Microsoft.Extensions.Logging;

namespace LogLab
{
    public class ServicesRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            builder.RegisterType<Distraction>().AsImplementedInterfaces();

            // Standard stuff to register logger classes
            // It's a bit bullshitty.
            // It covers generic ILogger<type> but not ILogger without type.
            builder.RegisterInstance(new LoggerFactory())
             .As<ILoggerFactory>();

            builder.RegisterGeneric(typeof(Logger<>))
                   .As(typeof(ILogger<>))
                   .SingleInstance();

            // register something to resolve ILogger
        }
    }
}
