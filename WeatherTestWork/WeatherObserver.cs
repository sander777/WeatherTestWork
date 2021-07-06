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
    static class WeatherObserver
    {
        static string weatherServiceAddr;
        static WeatherObserver()
        {
            string configFileContent;
            try
            {
                configFileContent = File.ReadAllText("../../../config.json");
            }
            catch (Exception _)
            {
                configFileContent = File.ReadAllText("config.json");
            }
            JsonDocument configJson = JsonDocument.Parse(configFileContent);
            weatherServiceAddr = configJson.RootElement.GetProperty("Weather Service").GetString();
        }
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
