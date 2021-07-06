using System;

namespace WeatherStation
{
    /// <summary>
    /// Class container which store weather data information and is used as return type in events.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class WeatherDataEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherDataEventArgs"/> class.
        /// </summary>
        /// <param name="temperature">The weather temperature value.</param>
        /// <param name="humidity">The weather humidity value.</param>
        /// <param name="pressure">The weather pressure value.</param>
        public WeatherDataEventArgs(float temperature, int humidity, int pressure) => (this.Temperature, this.Humidity, this.Pressure) = (temperature, humidity, pressure);

        /// <summary>
        /// Gets the weather pressure value.
        /// </summary>
        /// <value>
        /// The weather pressure value.
        /// </value>
        public int Pressure { get; }

        /// <summary>
        /// Gets the weather humidity value.
        /// </summary>
        /// <value>
        /// The weather humidity value.
        /// </value>
        public int Humidity { get; }

        /// <summary>
        /// Gets the weather temperature value.
        /// </summary>
        /// <value>
        /// The weather temperature value.
        /// </value>
        public float Temperature { get; }
    }
}
