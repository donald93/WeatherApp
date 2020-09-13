using System;
using System.Collections.Generic;

namespace WeatherApp.Integrations
{
    public class ForecastModel
    {
        public Properties Properties { get; set; }
    }

    public class Properties
    {
        public string Zone { get; set; }
        public DateTime Updated { get; set; }
        public IEnumerable<Period> Periods { get; set; }

    }

    public class Period
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public string DetailedForecast { get; set; }
    }
}
