using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDemoUsingEvent.Observers
{
    public class CurrentWeatherConditionsReport: AbstractReport
    {
        private WeatherInfoEventArgs currentWeatherInfo;

        protected override void UpdateData(object sender, WeatherInfoEventArgs weatherInfo)
        {
            currentWeatherInfo = weatherInfo;
        }

        public override string ShowReport()
        {
            return $"Current conditions: Temperature {currentWeatherInfo.Temperature}, " +
                   $"humidity {currentWeatherInfo.Humidity}, pressure {currentWeatherInfo.Pressure}";
        }
    }
}
