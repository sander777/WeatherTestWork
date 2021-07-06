using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWork2
{
    public class Forecast
    {
        public string day { get; set; }
        public string temperature { get; set; }
        public string wind { get; set; }
    }

    public class WeatherData
    {
        public string temperature { get; set; }
        public string wind { get; set; }
        public string description { get; set; }
        public IList<Forecast> forecast { get; set; }
    }

    public class WeatherServiceException : Exception
    {

    }
}
