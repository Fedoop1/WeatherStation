using System;

namespace WeatherStation
{
    /// <summary>
    /// Class container which store information about weather temperature and is used as return type in events.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class WeatherTemperatureEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherTemperatureEventArgs"/> class.
        /// </summary>
        /// <param name="temperature">The temperature.</param>
        public WeatherTemperatureEventArgs(float temperature) => this.Temperature = temperature;

        /// <summary>
        /// Gets the weather temperature value.
        /// </summary>
        /// <value>
        /// The weather temperature value.
        /// </value>
        public float Temperature { get; }
    }
}
