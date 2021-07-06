using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace TestWork2
{
    /// <summary> This class is used to get <see cref="WeatherData"></see> of cities </summary>
    static class WeatherObserver
    {
        
        static string weatherServiceAddr;
        static WeatherObserver()
        {
            string configFileContent;
            // If project is loaded from Visual Studio then config.json have this path
            try
            {
                configFileContent = File.ReadAllText("../../../config.json");
            }
            // Else load from current dir
            catch (Exception _)
            {
                configFileContent = File.ReadAllText("config.json");
            }
            JsonDocument configJson = JsonDocument.Parse(configFileContent);
            weatherServiceAddr = configJson.RootElement.GetProperty("Weather Service").GetString();
        }

        /// <summary> Get <see cref="WeatherData"></see> of the city </summary>
        /// <param name="city">String that represent city</param>
        /// <exception cref="WeatherServiceException"></exception>
        public static WeatherData CurrentWeather(string city)
        {
            
            HttpWebRequest weatherRequest = (HttpWebRequest)WebRequest.Create($"{weatherServiceAddr}/{city}");
            WebResponse weatherResponce = weatherRequest.GetResponse();
            string answer;
            using (StreamReader stream = new StreamReader(weatherResponce.GetResponseStream(), Encoding.UTF8))
            {
                answer = stream.ReadToEnd();
            }
            WeatherData weatherData = JsonSerializer.Deserialize<WeatherData>(answer);
            if (weatherData.temperature.Length == 0)
            {
                throw new WeatherServiceException();
            }
            return weatherData;
        }
    }
}
