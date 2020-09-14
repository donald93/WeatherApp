using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using WeatherApp.Integrations;

namespace WeatherApp.State
{
    public class AppState
    {
        public ForecastModel SelectedForecast { get; private set; }

        private IEnumerable<Action> OnChanged = new List<Action>();

        public void SetForecastModel(ForecastModel model)
        {
            SelectedForecast = model;
            NotifyStateChanged();
        }

        public void Subscribe(Action action)
        {
            OnChanged = OnChanged.Append(action);
        }

        public void Unsubscribe(Action action)
        {
            OnChanged = OnChanged.Where(c => c != action);
        }

        private void NotifyStateChanged()
        {
            foreach(var changed in OnChanged)
            {
                changed.Invoke();
            }
        }
    }
}
