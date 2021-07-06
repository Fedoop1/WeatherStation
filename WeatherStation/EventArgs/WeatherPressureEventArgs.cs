using System;

namespace WeatherStation
{
    /// <summary>
    /// Class container which store information about weather pressure and is used as return type in events.
    /// </summary>
    /// <seealso cref="System.EventArgs" />
    public class WeatherPressureEventArgs : EventArgs
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherPressureEventArgs"/> class.
        /// </summary>
        /// <param name="pressure">The pressure.</param>
        public WeatherPressureEventArgs(int pressure) => this.Pressure = pressure;

        /// <summary>
        /// Gets the weather pressure value.
        /// </summary>
        /// <value>
        /// The weather pressure value.
        /// </value>
        public int Pressure { get; }
    }
}
