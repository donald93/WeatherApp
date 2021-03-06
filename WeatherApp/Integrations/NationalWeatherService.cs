﻿using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace WeatherApp.Integrations
{
    public class NationalWeatherService
    {
        private readonly HttpClient _client;

        public NationalWeatherService(HttpClient client)
        {
            client.BaseAddress = new Uri("https://api.weather.gov");
            _client = client;
        }

        public async Task<ForecastModel> GetForecastForZone(string zone)
        {
            ForecastModel result;
            try
            {
                var url = $"/zones/public/{zone}/forecast";

                var response = await _client.GetAsync(url);

                response.EnsureSuccessStatusCode();

                using var responseStream = await response.Content.ReadAsStreamAsync();

                result = await JsonSerializer.DeserializeAsync<ForecastModel>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
            }
            catch(HttpRequestException e)
            {
                result = new ForecastModel { ErrorMessage = e.Message };
            }

            return result;
        }

        public async Task<ZonesModel> GetZones(string area, string type)
        {
            var url = $"/zones?area={area}&type={type}";

            var response = await _client.GetAsync(url);

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();

            var result = await JsonSerializer.DeserializeAsync<ZonesModel>(responseStream, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return result;
        }


    }
}
