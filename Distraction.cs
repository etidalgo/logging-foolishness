using Microsoft.Extensions.Logging;

namespace LogLab
{
    public class Distraction: IDistraction
    {
        private ILogger Logger;
        public Distraction(ILogger logger) {
            this.Logger = logger;
        }

        public void Distract()
        {
            this.Logger.LogDebug("Debug distraction");
            this.Logger.LogInformation("Info distraction");
        }
    }
}
