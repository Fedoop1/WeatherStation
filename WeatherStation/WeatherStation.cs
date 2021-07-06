using System;

namespace WeatherStation
{
    /// <summary>
    /// Class describes weather station instance, which contain actual information about weather data.
    /// </summary>
    public class WeatherStation
    {
        private readonly WeatherData weatherData;
        private float temperature;
        private int humidity;
        private int pressure;

        /// <summary>
        /// Initializes a new instance of the <see cref="WeatherStation"/> class.
        /// </summary>
        /// <param name="weatherData">The weather data.</param>
        /// <exception cref="System.ArgumentNullException">Throws when data object is null.</exception>
        public WeatherStation(WeatherData weatherData)
        {
            this.weatherData = weatherData ?? throw new ArgumentNullException(nameof(weatherData), "Weather can't be null");
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
        public int Humidity { get => this.humidity; }

        /// <summary>
        /// Gets the weather pressure value.
        /// </summary>
        /// <value>
        /// The weather pressure value.
        /// </value>
        public int Pressure { get => this.pressure; }

        /// <summary>
        /// Gets the weather temperature value.
        /// </summary>
        /// <value>
        /// The weather temperature value.
        /// </value>
        public float Temperature { get => this.temperature; }

        /// <summary>
        /// Subscribe instance to weather change event to receive new information about weather changes.
        /// </summary>
        public void StartReceivingUpdates()
        {
            this.weatherData.HumidityChange += this.OnHumidityChange;
            this.weatherData.TemperatureChange += this.OnTemperatureChange;
            this.weatherData.PressureChange += this.OnPressureChange;
        }

        /// <summary>
        /// Unsubscribe instance from weather changes updates.
        /// </summary>
        public void StopReceivingUpdates()
        {
            this.weatherData.HumidityChange -= this.OnHumidityChange;
            this.weatherData.TemperatureChange -= this.OnTemperatureChange;
            this.weatherData.PressureChange -= this.OnPressureChange;
        }

        /// <summary>
        /// Raises the weather change event.
        /// </summary>
        /// <param name="weatherData">The <see cref="WeatherDataEventArgs"/> instance containing the event data.</param>
        protected virtual void OnWeatherChange(WeatherDataEventArgs weatherData) => this.WeatherChange?.Invoke(this, weatherData);

        /// <summary>
        /// Called when temperature change event is invoked.
        /// </summary>
        /// <param name="sender">The sender object.</param>
        /// <param name="weatherData">The <see cref="WeatherTemperatureEventArgs"/> instance containing the event data.</param>
        protected virtual void OnTemperatureChange(object sender, WeatherTemperatureEventArgs weatherData)
        {
            if (this.Temperature != weatherData?.Temperature)
            {
                this.temperature = weatherData.Temperature;
                this.OnWeatherChange(new WeatherDataEventArgs(this.temperature, this.humidity, this.pressure));
            }
        }

        /// <summary>
        /// Called when pressure change event is invoked.
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="weatherData">The <see cref="WeatherPressureEventArgs"/> instance containing the event data.</param>
        protected virtual void OnPressureChange(object sender, WeatherPressureEventArgs weatherData)
        {
            if (this.Pressure != weatherData?.Pressure)
            {
                this.pressure = weatherData.Pressure;
                this.OnWeatherChange(new WeatherDataEventArgs(this.temperature, this.humidity, this.pressure));
            }
        }

        /// <summary>
        /// Called when humidity change event is invoked.
        /// </summary>
        /// <param name="sender">The object sender.</param>
        /// <param name="weatherData">The <see cref="WeatherHumidityEventArgs"/> instance containing the event data.</param>
        protected virtual void OnHumidityChange(object sender, WeatherHumidityEventArgs weatherData)
        {
            if (this.Humidity != weatherData?.Humidity)
            {
                this.humidity = weatherData.Humidity;
                this.OnWeatherChange(new WeatherDataEventArgs(this.Temperature, this.Humidity, this.Pressure));
            }
        }
    }
}
