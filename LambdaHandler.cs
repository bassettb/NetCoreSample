using System;
using System.Collections.Generic;
using System.Net;
using Amazon.Lambda.Core;
using Amazon.Lambda.APIGatewayEvents;
using Newtonsoft.Json;

[assembly: LambdaSerializer(typeof(Amazon.Lambda.Serialization.Json.JsonSerializer))] 

namespace sampleapp
{
    public class LambdaHandler
    {
        public APIGatewayProxyResponse Get(APIGatewayProxyRequest request, ILambdaContext context)
        {
            var weatherMan = new WeatherMan();
            weatherMan.Location = "2357024";
            weatherMan.DayIndex = 1;
            var weather = weatherMan.getWeather();

            return CreateResponse(weather);
        }

        APIGatewayProxyResponse CreateResponse(object result)
        {
            int statusCode = (result != null) ? 
                (int)HttpStatusCode.OK : 
                (int)HttpStatusCode.InternalServerError;

            string body = (result != null) ? 
                JsonConvert.SerializeObject(result) : string.Empty;

            var response = new APIGatewayProxyResponse
            {
                StatusCode = statusCode,
                Body = body,
                Headers = new Dictionary<string, string>
                { 
                    { "Content-Type", "application/json" }, 
                    { "Access-Control-Allow-Origin", "*" } 
                }
            };
            
            return response;
        }
    }
}
