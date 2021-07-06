using System;
using Moq;
using NUnit.Framework;

namespace WeatherStation.Tests
{
    internal class WeatherStationTests
    {
        private WeatherData weatherData;
        private WeatherStation weatherStation;
        private Mock<IWeatherDataEventSubsriber> weatherDataSubsriberMock;

        [OneTimeSetUp]
        public void SetUp()
        {
            weatherData = new WeatherData(0, 0, 0);
            weatherStation = new WeatherStation(weatherData);
            weatherDataSubsriberMock = new Mock<IWeatherDataEventSubsriber>();

        }

        [Test]
        public void Ctor_NullWeatherData_ThrowArgumentNullException() => Assert.Throws<ArgumentNullException>(() => new WeatherStation(null), "Weather station can't be null.");

        [Test]
        public void WeatherChange_WeatherDataChange_InvokeOnce()
        {
            weatherDataSubsriberMock = new Mock<IWeatherDataEventSubsriber>();
            weatherDataSubsriberMock.Setup(x => x.WeatherDataChangeHandler(It.IsAny<object>(), It.IsAny<WeatherDataEventArgs>()));
            var weatherDataSubsriber = weatherDataSubsriberMock.Object;

            weatherStation.WeatherChange += weatherDataSubsriber.WeatherDataChangeHandler;
            weatherStation.StartReceivingUpdates();
            weatherData.Humidity += 1;

            weatherDataSubsriberMock.Verify(x => x.WeatherDataChangeHandler(It.IsAny<object>(), It.IsAny<WeatherDataEventArgs>()), Times.Once);
        }

        [Test]
        public void StopReceivingUpdates_WeatherDataChange_EventNeverInvoke()
        {
            weatherDataSubsriberMock.Setup(x => x.WeatherDataChangeHandler(It.IsAny<object>(), It.IsAny<WeatherDataEventArgs>()));
            var weatherDataSubsriber = weatherDataSubsriberMock.Object;

            weatherStation.WeatherChange += weatherDataSubsriber.WeatherDataChangeHandler;
            weatherStation.StopReceivingUpdates();
            weatherData.Humidity += 1;

            weatherDataSubsriberMock.Verify(x => x.WeatherDataChangeHandler(It.IsAny<object>(), It.IsAny<WeatherDataEventArgs>()), Times.Never);
        }
    }
}
