using System;
using WeatherStation.Interfaces;

namespace WeatherStation
{
    /// <summary>
    /// Class which contain actual information about weather and provide the ability to create current condition report.  
    /// </summary>
    public class CurrentConditionsReport : IObserver
    {
        private WeatherDataEventArgs weatherData;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentConditionsReport"/> class and subscribe it for weather station notifications.
        /// </summary>
        /// <param name="weatherStation">The weather station instance.</param>
        /// <exception cref="System.ArgumentNullException">Throws when weather station is null.</exception>
        public CurrentConditionsReport(WeatherStation weatherStation)
        {
            if (weatherStation is null)
            {
                throw new ArgumentNullException(nameof(weatherStation), "Weather station can't be null");
            }

            weatherStation.Register(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentConditionsReport"/> class.
        /// </summary>
        public CurrentConditionsReport()
        {
        }

        /// <summary>
        /// Prints the current condition weather report.
        /// </summary>
        /// <exception cref="ArgumentException">Throws when there are not any weather information.</exception>
        public void PrintReport()
        {
            if (this.weatherData is null)
            {
                throw new ArgumentException("There are not any weather information.");
            }

            Console.WriteLine($"\tCurrent temperature condition\n" +
                $"Temperature:{this.weatherData.Temperature}°С\n" +
                $"Pressure: {this.weatherData.Pressure}hPa\n" +
                $"Humidity: {this.weatherData.Humidity}%");
        }

        /// <summary>
        /// Gets the current weather report.
        /// </summary>
        /// <returns>Container which contain actual main weather parameters.</returns>
        /// <exception cref="System.ArgumentException">Throws when there are not any weather information.</exception>
        public WeatherDataEventArgs GetReport() => this.weatherData ?? throw new ArgumentException("There are not any weather information.");

        /// <inheritdoc/>
        void IObserver.Update(object sender, EventArgs info)
        {
            if (info is WeatherDataEventArgs weatherDataInfo)
            {
                this.weatherData = weatherDataInfo;
            }
        }
    }
}
