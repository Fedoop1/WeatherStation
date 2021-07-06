using System;

namespace WeatherStation
{
    /// <summary>
    /// Class which contain actual information about weather and provide the ability to create current condition report.  
    /// </summary>
    public class CurrentConditionsReport
    {
        private readonly WeatherStation weatherStation;
        private WeatherDataEventArgs weatherData;

        /// <summary>
        /// Initializes a new instance of the <see cref="CurrentConditionsReport"/> class.
        /// </summary>
        /// <param name="weatherStation">The weather station.</param>
        /// <exception cref="System.ArgumentNullException">Throws when weather station is null.</exception>
        public CurrentConditionsReport(WeatherStation weatherStation) => this.weatherStation = weatherStation ?? throw new ArgumentNullException(nameof(weatherStation), "Weather station can't be null");

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
        /// Prints the current condition weather report.
        /// </summary>
        /// <exception cref="System.ArgumentException">Throws when there are not any weather information.</exception>
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

            this.weatherData = weatherData;
        }
    }
}
