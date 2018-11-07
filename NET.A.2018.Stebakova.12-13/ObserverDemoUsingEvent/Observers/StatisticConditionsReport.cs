using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverDemoUsingEvent.Observers
{
    public class StatisticConditionsReport: AbstractReport
    {
        private List<WeatherInfoEventArgs> statisticWeatherInfo;

        public StatisticConditionsReport()
        {
            statisticWeatherInfo = new List<WeatherInfoEventArgs>();
        }

        protected override void UpdateData(object sender, WeatherInfoEventArgs weatherInfo)
        {
            statisticWeatherInfo.Add(weatherInfo);
        }

        public override string ShowReport()
        {
            StringBuilder result = new StringBuilder("Statistic: ");

            for (int i = 0; i < statisticWeatherInfo.Count; i++)
            {
                result.Append($"Temperature: {statisticWeatherInfo[i].Temperature}, " +
                              $"humidity: {statisticWeatherInfo[i].Humidity}, pressure: {statisticWeatherInfo[i].Pressure}\n");
            }

            return result.ToString();
        }
    }
}
