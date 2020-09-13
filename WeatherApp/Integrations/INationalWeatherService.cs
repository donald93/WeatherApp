using System.Threading.Tasks;

namespace WeatherApp.Integrations
{
    interface INationalWeatherService
    {
        public Task<ForecastModel> GetForecastforZone(string zone);
    }
}
