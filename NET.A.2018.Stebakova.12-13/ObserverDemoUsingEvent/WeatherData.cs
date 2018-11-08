using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ObserverDemoUsingEvent
{
    public class WeatherData
    {
        public event EventHandler<WeatherInfoEventArgs> SetWeatherInfo;

        private Timer timer;

        public void SetNewWeather(int temperature, int humidity, int pressure)
        {
            SetWeatherInfo?.Invoke(this, new WeatherInfoEventArgs(temperature, humidity, pressure));
        }

        public void StartWork()
        {
            timer = new Timer(GenerateWeatherInfo, this, 0, 2000);
        }

        public void GenerateWeatherInfo(object state)
        {
            Random random = new Random();

            int temperature = random.Next(0, 30);
            int humidity = random.Next(0, 100);
            int pressure = random.Next(700, 800);

            SetNewWeather(temperature, humidity, pressure);
        }
    }
}
