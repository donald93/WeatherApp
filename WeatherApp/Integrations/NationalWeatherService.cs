using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherApp.Integrations
{
    public class NationalWeatherService : INationalWeatherService
    {

        private readonly HttpClient _client;

        public NationalWeatherService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://api.weather.gov");
            _client = client;
        }

        public async Task<ForecastModel> GetForecastForZone(string zone)
        {
            var url = $"/zones/public/{zone}/forecast";

            var response = await _client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var result = await JsonSerializer.DeserializeAsync<ForecastModel>(responseStream);

            return result;
        }
    }
}
