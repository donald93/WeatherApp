using System;
using System.Collections.Generic;

namespace WeatherApp.Integrations
{
    public class ForecastModel
    {
        public Properties properties { get; set; }
    }

    public class Properties
    {
        public string zone { get; set; }
        public DateTime updated { get; set; }
        public IEnumerable<Period> periods { get; set; }

    }

    public class Period
    {
        public int number { get; set; }
        public string name { get; set; }
        public string detailedForecast { get; set; }
    }
}
