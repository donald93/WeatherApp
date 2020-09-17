using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherApp.Integrations
{
    public class ZonesModel
    {
        public IEnumerable<Features> Features { get; set; }
    }

    public class Features
    {
        public ZoneProperties Properties { get; set; }
    }

    public class ZoneProperties
    {
        public string Id { get; set; }
    }
}
