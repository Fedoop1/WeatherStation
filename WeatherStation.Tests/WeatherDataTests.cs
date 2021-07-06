using System;
using Moq;
using Moq.Protected;
using NUnit.Framework;

namespace WeatherStation.Tests
{
    [TestFixture]
    internal class WeatherDataTests
    {
        private WeatherData weatherData;
        private Mock<IWeatherDataEventSubsriber> weatherDataSubsriberMock;

        [OneTimeSetUp]
        public void SetUp()
        {
            weatherData = new WeatherData(0, 0, 0);
            weatherDataSubsriberMock = new Mock<IWeatherDataEventSubsriber>();
        }

        

        [Test]
        public void SetPressure_ValueLowerThanZero_ThrowArgumentException() => Assert.Throws<ArgumentException>(() => new WeatherData(0, 0, -1));

        [Test]
        public void SetHumidity_ValueLowerThanZero_ThrowArgumentException() => Assert.Throws<ArgumentException>(() => new WeatherData(0, -1, 0));

        [Test]
        public void OnTemperatureChange_TemperatureChange_InvokeEventOnce()
        {
            weatherDataSubsriberMock.Setup(x => x.TemperatureChangeHandler(It.IsAny<object>(), It.IsAny<WeatherTemperatureEventArgs>()));
            var weatherDataSubsriber = weatherDataSubsriberMock.Object;

            weatherData.TemperatureChange += weatherDataSubsriber.TemperatureChangeHandler;
            weatherData.Temperature += 1;

            weatherDataSubsriberMock.Verify(x => x.TemperatureChangeHandler(It.IsAny<object>(), It.IsAny<WeatherTemperatureEventArgs>()), Times.Once);
        }

        [Test]
        public void OnHumidityChange_HumidityChange_InvokeEventOnce()
        {
            weatherDataSubsriberMock.Setup(x => x.HumidityChangeHandler(It.IsAny<object>(), It.IsAny<WeatherHumidityEventArgs>()));
            var weatherDataSubsriber = weatherDataSubsriberMock.Object;

            weatherData.HumidityChange += weatherDataSubsriber.HumidityChangeHandler;
            weatherData.Humidity += 1;

            weatherDataSubsriberMock.Verify(x => x.HumidityChangeHandler(It.IsAny<object>(), It.IsAny<WeatherHumidityEventArgs>()), Times.Once);
        }

        [Test]
        public void OnPressureChange_PressureChange_InvokeEventOnce()
        {
            weatherDataSubsriberMock.Setup(x => x.PressureChangeHandler(It.IsAny<object>(), It.IsAny<WeatherPressureEventArgs>()));
            var weatherDataSubsriber = weatherDataSubsriberMock.Object;

            weatherData.PressureChange += weatherDataSubsriber.PressureChangeHandler;
            weatherData.Pressure += 1;

            weatherDataSubsriberMock.Verify(x => x.PressureChangeHandler(It.IsAny<object>(), It.IsAny<WeatherPressureEventArgs>()), Times.Once);
        }
    }
}
