using System.Threading.Tasks;

namespace WeatherApp.Integrations
{
    interface INationalWeatherService
    {
        public Task<ForecastModel> GetForecastForZone(string zone);
    }
}
