using System;

namespace WeatherStation
{
    /// <summary>
    /// Class container which store information about weather humidity and is used as return type in events.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class WeatherHumidityEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherHumidityEventArgs"/> class.
        /// </summary>
        /// <param name="humidity">The weather humidity value.</param>
        public WeatherHumidityEventArgs(int humidity) => this.Humidity = humidity;

        /// <summary>
        /// Gets the weather humidity value.
        /// </summary>
        /// <value>
        /// The weather humidity value.
        /// </value>
        public int Humidity { get; }
    }
}
