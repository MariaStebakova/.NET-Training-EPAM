using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObserverDemoUsingEvent.Observers;

namespace ObserverDemoUsingEvent.Console.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var weatherData = new WeatherData();
            var statisticReport = new StatisticConditionsReport();
            var currentReport = new CurrentWeatherConditionsReport();

            statisticReport.Subscribe(weatherData);
            currentReport.Subscribe(weatherData);

            weatherData.StartWork();

            System.Console.ReadLine();
        }
    }
}
