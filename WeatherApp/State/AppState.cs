using System;
using WeatherApp.Integrations;

namespace WeatherApp.State
{
    public class AppState
    {
        public ForecastModel SelectedForecast { get; private set; }

        public event Action OnChange;

        public void SetForecastModel(ForecastModel model)
        {
            SelectedForecast = model;
            NotifyStateChanged();
        }

        private void NotifyStateChanged() => OnChange?.Invoke();
    }
}
