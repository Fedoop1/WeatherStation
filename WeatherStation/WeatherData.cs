using System;
using System.Collections.Generic;
using WeatherStation.Interfaces;

namespace WeatherStation
{
    /// <summary>
    /// Class which provide information about weather, such as humidity, temperature and pressure.
    /// </summary>
    public class WeatherData : IObservable
    {
        private readonly List<IObserver> observers = new ();
        private float temperature;
        private int humidity;
        private int pressure;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherData"/> class.
        /// </summary>
        /// <param name="temperature">Weather temperature value.</param>
        /// <param name="humidity">Weather humidity value.</param>
        /// <param name="pressure">Weather pressure value.</param>
        public WeatherData(float temperature, int humidity, int pressure) => (this.Temperature, this.Humidity, this.Pressure) = (temperature, humidity, pressure);

        /// <summary>
        /// Gets or sets the weather temperature value.
        /// </summary>
        /// <value>
        /// The weather temperature value.
        /// </value>
        public float Temperature 
        { 
            get => this.temperature; 
            set
            {
                if (value != this.Temperature)
                {
                    this.temperature = value;
                    ((IObservable)this).Notify();
                }
            }
        }

        /// <summary>
        /// Gets or sets the weather pressure.
        /// </summary>
        /// <value>
        /// The weather pressure value.
        /// </value>
        /// <exception cref="System.ArgumentException">Throws when pressure value lower than zero.</exception>
        public int Pressure
        {
            get => this.pressure;
            set
            {
                if (value != this.Pressure)
                {
                    this.pressure = value >= 0 ? value : throw new ArgumentException("Pressure can't be lower than zero");
                    ((IObservable)this).Notify();
                }
            }
        }

        /// <summary>
        /// Gets or sets the weather humidity value.
        /// </summary>
        /// <value>
        /// The weather humidity value.
        /// </value>
        /// <exception cref="System.ArgumentException">Throws when humidity value lower than zero.</exception>
        public int Humidity
        {
            get => this.humidity;
            set
            {
                if (value != this.Humidity)
                {
                    this.humidity = value >= 0 ? value : throw new ArgumentException("Humidity can't be lower than zero");
                    ((IObservable)this).Notify();
                }
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
