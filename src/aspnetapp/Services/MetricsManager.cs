using Prometheus;

namespace aspnetapp.Services
{
    public class MetricsManager
    {
        public static readonly Counter HomeControllerHit = Metrics
            .CreateCounter("home_controller_hit", "Number of times the home controller has been hit");

        public static void Publish()
        {
            HomeControllerHit.Publish();
        }
    }
}