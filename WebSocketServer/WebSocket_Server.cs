using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WebSocketSharp;
using WebSocketSharp.Server;
using Newtonsoft.Json;


namespace WebSocket_Server
{
    
    class Program
    {
        

        public class Echo : WebSocketBehavior
        {
            
            

            protected override void OnMessage(MessageEventArgs e)
            {

                //Weather newWeather = new Weather();

                //newWeather.cityName = "Istanbul";
                //newWeather.temperature = 25;
                //newWeather.weatherCondition = "Cloudy";

                //List<Weather> weathers = new List<Weather>();

                //weathers.Add(newWeather);

                //Console.WriteLine("Received message from client: \n" + weathers[0].cityName + "\n" + weathers[0].temperature + "\n" + weathers[0].weatherCondition);
                //string a = weathers[0].cityName;
                //string b = weathers[0].weatherCondition;
                //string c = Convert.ToString(weathers[0].temperature);

                //string json = @"{
                //'City' : 'Istanbul',
                //'WeatherCondition' : 'Cloudy',
                //'Temperature' : '25'
                //}";
                var weatherss = new List<Weather> {
                    new Weather
                    {
                        City = "Istanbul",
                        WeatherCondition = "Sunny",
                        Temperature = 26
                    },
                    new Weather
                    {
                        City = "Ankara",
                        WeatherCondition = "Cloudy",
                        Temperature = 29
                    },
                    new Weather
                    {
                        City = "Antalya",
                        WeatherCondition = "Sunny",
                        Temperature = 35
                    }
                };

                var weatherJson = JsonConvert.SerializeObject(weatherss);

                var weatherList = JsonConvert.DeserializeObject<List<Weather>>(weatherJson);
                Console.WriteLine("Created a weather info: ");
                foreach (var item in weatherList)
                {
                    Send(item.City);
                    Send(item.WeatherCondition);
                    Send(Convert.ToString(item.Temperature));
                }
                //Send(Convert.ToString(weatherList[0].City));
                //Send(Convert.ToString(weather.WeatherCondition));
                //Send(Convert.ToString(weather.Temperature));

            }
        }

        static void Main(string[] args)
        {
            WebSocketServer wssv = new WebSocketServer("ws://127.0.0.1:7890");
            wssv.AddWebSocketService<Echo>("/Echo");

            

            wssv.Start();
            Console.WriteLine("WS server started on ws://127.0.0.1:7890/Echo");

            Console.ReadKey();
            wssv.Stop();
        }
    }
}
