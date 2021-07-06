using System;
using System.Collections.Generic;
using WeatherStation.Interfaces;

namespace WeatherStation
{
    /// <summary>
    /// Class describes weather station instance, which contain actual information about weather data.
    /// </summary>
    public class WeatherStation : IObservable, IObserver
    {
        private readonly List<IObserver> observers = new ();

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherStation"/> class and subscribe it for weather data notifications.
        /// </summary>
        /// <param name="weatherData">The weather data instance.</param>
        /// <exception cref="System.ArgumentNullException">Throws when weather data object is null.</exception>
        public WeatherStation(WeatherData weatherData)
        {
            if (weatherData is null)
            {
                throw new ArgumentNullException(nameof(weatherData), "Weather data can't be null");
            }

            weatherData.Register(this);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherStation"/> class.
        /// </summary>
        public WeatherStation()
        {
        }

        /// <summary>
        /// Occurs when weather data is change.
        /// </summary>
        public event EventHandler<WeatherDataEventArgs> WeatherChange;

        /// <summary>
        /// Gets the weather humidity value.
        /// </summary>
        /// <value>
        /// The weather humidity value.
        /// </value>
        public int Humidity { get; private set; }

        /// <summary>
        /// Gets the weather pressure value.
        /// </summary>
        /// <value>
        /// The weather pressure value.
        /// </value>
        public int Pressure { get; private set; }

        /// <summary>
        /// Gets the weather temperature value.
        /// </summary>
        /// <value>
        /// The weather temperature value.
        /// </value>
        public float Temperature { get; private set; }

        /// <inheritdoc/>
        void IObserver.Update(object sender, EventArgs info)
        {
            if (info is WeatherDataEventArgs weatherDataInfo)
            {
                this.Humidity = weatherDataInfo.Humidity;
                this.Pressure = weatherDataInfo.Pressure;
                this.Temperature = weatherDataInfo.Temperature;
                ((IObservable)this).Notify();
                return;
            }
        }

        /// <inheritdoc/>
        public void Register(IObserver observer)
        {
            if (observer is null)
            {
                throw new ArgumentNullException(nameof(observer), "Observer can't be null");
            }

            this.observers.Add(observer);
        }

        /// <inheritdoc/>
        public void Unregister(IObserver observer)
        {
            if (observer is null)
            {
                throw new ArgumentNullException(nameof(observer), "Observer can't be null");
            }

            this.observers.Remove(observer);
        }

        /// <inheritdoc/>
        void IObservable.Notify()
        {
            foreach (var observer in this.observers)
            {
                if (observer != null)
                {
                    observer.Update(this, new WeatherDataEventArgs(this.Temperature, this.Humidity, this.Pressure));
                }
            }
        }
    }
}
