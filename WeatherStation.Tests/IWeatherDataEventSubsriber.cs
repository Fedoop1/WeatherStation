using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace WeatherStation.Tests
{
    
    internal interface IWeatherDataEventSubsriber
    {
        public void TemperatureChangeHandler(object sender, WeatherTemperatureEventArgs weatherData);

        public void PressureChangeHandler(object sender, WeatherPressureEventArgs weatherData);

        public void HumidityChangeHandler(object sender, WeatherHumidityEventArgs weatherData);

        public void WeatherDataChangeHandler(object sender, WeatherDataEventArgs weatherData);
    }
}
