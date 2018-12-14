using System;
using RestSharp;
using Newtonsoft.Json.Linq;

namespace sampleapp
{
    public class WeatherMan
    {
        private readonly string url = "https://www.metaweather.com";
        private readonly string locationResource = "api/location/{location}/";

        public string Location { get; set; }

        private int dayIndex = 0;
        public int DayIndex {
            get { return dayIndex; }
            set { dayIndex = value; }
        }
//2357024

        public WeatherModel getWeather()
        {
            var restClient = new RestClient(url);
            var resource = locationResource.Replace("{location}", Location);
            var request = new RestRequest(resource, Method.GET);

            var response = restClient.Execute(request);
            if (!response.IsSuccessful)
                throw new Exception();
            
            var jObj = JObject.Parse(response.Content);
            var temp = (double)jObj.SelectToken($"consolidated_weather[{DayIndex}].the_temp");
            var cond = (string)jObj.SelectToken($"consolidated_weather[{DayIndex}].weather_state_name");

            return new WeatherModel { Temperature = temp, Condition = cond };
        }

        public bool IsValidDayIndex(int dayIndex)
        {
            return (dayIndex >=0 && dayIndex < 5);
        }
    }
}