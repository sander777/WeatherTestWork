using System;

namespace TestWork2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Input city:");
                string city = Console.ReadLine();

                WeatherData weatherData;
                try
                {
                    weatherData = WeatherObserver.CurrentWeather(city);
                }
                catch (WeatherServiceException ex)
                {
                    Console.WriteLine("City name error. Try more");
                    continue;
                }
                Console.WriteLine(weatherData.temperature);
            }
        }
    }
}
