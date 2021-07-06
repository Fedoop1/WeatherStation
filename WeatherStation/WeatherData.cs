using System;

namespace WeatherStation
{
    /// <summary>
    /// Class which provide information about weather, such as humidity, temperature and pressure.
    /// </summary>
    public class WeatherData
    {
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
        /// Occurs when <see cref="Temperature"/> is change.
        /// </summary>
        public event EventHandler<WeatherTemperatureEventArgs> TemperatureChange;

        /// <summary>
        /// Occurs when <see cref="Humidity"/> is change.
        /// </summary>
        public event EventHandler<WeatherHumidityEventArgs> HumidityChange;

        /// <summary>
        /// Occurs when <see cref="Pressure"/> is change.
        /// </summary>
        public event EventHandler<WeatherPressureEventArgs> PressureChange;

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
                    this.OnTemperatureChange(new WeatherTemperatureEventArgs(this.Temperature));
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
                    this.OnPressureChange(new WeatherPressureEventArgs(this.Pressure));
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
                    this.OnHumidityChange(new WeatherHumidityEventArgs(this.Humidity));
                }
            }
        }

        /// <summary>
        /// Raises the temperature change event.
        /// </summary>
        /// <param name="weatherData">The <see cref="WeatherTemperatureEventArgs"/> instance containing the event data.</param>
        protected virtual void OnTemperatureChange(WeatherTemperatureEventArgs weatherData) => this.TemperatureChange?.Invoke(this, weatherData);

        /// <summary>
        /// Raises the humidity change event.
        /// </summary>
        /// <param name="weatherData">The <see cref="WeatherHumidityEventArgs"/> instance containing the event data.</param>
        protected virtual void OnHumidityChange(WeatherHumidityEventArgs weatherData) => this.HumidityChange?.Invoke(this, weatherData);

        /// <summary>
        /// Raises the pressure change event.
        /// </summary>
        /// <param name="weatherData">The <see cref="WeatherPressureEventArgs"/> instance containing the event data.</param>
        protected virtual void OnPressureChange(WeatherPressureEventArgs weatherData) => this.PressureChange?.Invoke(this, weatherData);
    }
}
