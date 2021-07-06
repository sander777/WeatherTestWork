using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWork2
{
    /// <summary>
    /// This class store forecasted weather of the city
    /// </summary>
    public class Forecast
    {
        public string day { get; set; }
        public string temperature { get; set; }
        public string wind { get; set; }
    }

    /// <summary>
    /// Class that store current and forecasted weather of the city 
    /// </summary>
    public class WeatherData
    {
        public string temperature { get; set; }
        public string wind { get; set; }
        public string description { get; set; }
        public IList<Forecast> forecast { get; set; }
    }

    /// <summary>
    /// Represent error that occur during geting weather
    /// </summary>
    public class WeatherServiceException : Exception
    {

    }
}
