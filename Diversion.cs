
using Microsoft.Extensions.Logging;

namespace LogLab
{
    public class Diversion: IDiversion
    {
        private ILogger<Diversion> Logger;

        public Diversion(ILogger<Diversion> logger)
        {
            this.Logger = logger;
        }

        public void Divert()
        {
            this.Logger.LogDebug("Debug diversion");
            this.Logger.LogInformation("Info diversion");
        }
    }
}
