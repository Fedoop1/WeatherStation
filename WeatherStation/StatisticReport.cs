using System;
using System.Collections.Generic;
using System.Linq;
using static System.Globalization.CultureInfo;

namespace WeatherStation
{
    /// <summary>
    /// Class which collect information about weather changes and provide the ability to create statistic report.  
    /// </summary>
    public class StatisticReport
    {
        private readonly WeatherStation weatherStation;
        private readonly List<(DateTime timeOfReport, WeatherDataEventArgs report)> reports = new ();

        /// <summary>
        /// Initializes a new instance of the <see cref="StatisticReport"/> class.
        /// </summary>
        /// <param name="weatherStation">The weather station instance.</param>
        /// <exception cref="System.ArgumentNullException">Throws when weather station is null.</exception>
        public StatisticReport(WeatherStation weatherStation) => this.weatherStation = weatherStation ?? throw new ArgumentNullException(nameof(weatherStation), "Weather station can't be null");

        /// <summary>
        /// Gets the count of collected reports.
        /// </summary>
        /// <value>
        /// The count of reports.
        /// </value>
        public int CountOfReports => this.reports.Count;

        /// <summary>
        /// Subscribe instance to weather change event to receive new information about weather changes.
        /// </summary>
        public void StartReceivingUpdates()
        {
            this.weatherStation.WeatherChange += this.Update;
        }

        /// <summary>
        /// Unsubscribe instance from weather changes updates.
        /// </summary>
        public void StopReceivingUpdates()
        {
            this.weatherStation.WeatherChange -= this.Update;
        }

        /// <summary>
        /// Prints the statistic report based on the weather collected information.
        /// </summary>
        /// <exception cref="System.ArgumentException">Throws when there are not any weather information.</exception>
        public void PrintStatisticReport()
        {
            if (this.CountOfReports == 0)
            {
                throw new ArgumentException("There are not any weather information.");
            }

            Console.WriteLine($"Statistic weather data from {this.reports.First().timeOfReport.ToString("dd.MM.yy hh:mm", InvariantCulture)} to {this.reports.Last().timeOfReport.ToString("dd.MM.yy hh:mm", InvariantCulture)}\n" +
                $"Count of reports: {this.CountOfReports}\n" +
                $"AVG temperature: {this.reports.Sum(x => x.report.Temperature) / this.reports.Count}°С\n" +
                $"AVG pressure: {this.reports.Sum(x => x.report.Pressure) / this.reports.Count}hPa\n" +
                $"AVG humidity: {this.reports.Sum(x => x.report.Humidity) / this.reports.Count}%");
        }

        /// <summary>
        /// Called when weather data change event is invoked.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="weatherData">The <see cref="WeatherDataEventArgs"/> instance containing the event data.</param>
        /// <exception cref="System.ArgumentNullException">Throws when weather data is null.</exception>
        protected virtual void Update(object sender, WeatherDataEventArgs weatherData)
        {
            if (weatherData is null)
            {
                throw new ArgumentNullException(nameof(weatherData), "Weather data can't be null");
            }

            this.reports.Add((DateTime.Now, weatherData));
        }
    }
}
