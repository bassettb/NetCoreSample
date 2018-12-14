using System;
using RestSharp;

namespace sampleapp
{
    class Program
    {
        static void Main(string[] args)
        {
            var weatherMan = new WeatherMan();
            weatherMan.Location = "2357024";
            var weather = weatherMan.getWeather();
            Console.WriteLine(weather.Temperature + "  " + weather.Condition);
        }
    }
}
