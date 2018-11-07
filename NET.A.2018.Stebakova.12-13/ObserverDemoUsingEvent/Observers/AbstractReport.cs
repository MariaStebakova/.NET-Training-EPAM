using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDemoUsingEvent.Observers
{
    public abstract class AbstractReport
    {
        public void Subscribe(WeatherData weatherData)
        {
            CheckInputData(weatherData);

            weatherData.SetWeatherInfo += Update;
        }

        public void Unsubscribe(WeatherData weatherData)
        {
            CheckInputData(weatherData);

            weatherData.SetWeatherInfo -= Update;
        }

        public abstract string ShowReport();

        protected abstract void UpdateData(object sender, WeatherInfoEventArgs weatherInfoEventArgs);

        private void Update(object sender, WeatherInfoEventArgs weatherInfoEventArgs)
        {
            if (sender == null)
            {
                throw new ArgumentNullException($"{nameof(sender)} can not be null.");
            }

            if (weatherInfoEventArgs == null)
            {
                throw new ArgumentNullException($"{nameof(weatherInfoEventArgs)} can not be null.");
            }

            UpdateData(sender, weatherInfoEventArgs);

            Console.WriteLine(ShowReport() + Environment.NewLine);
        }

        private void CheckInputData(WeatherData weatherData)
        {
            if (weatherData == null)
            {
                throw new ArgumentNullException($"{nameof(weatherData)} can not be null.");
            }
        }
    }
}
