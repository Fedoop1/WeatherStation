using System;
using Moq;
using NUnit.Framework;
using WeatherStation.Interfaces;

namespace WeatherStation.Tests
{
    internal class WeatherStationTests
    {
        private WeatherData weatherData;
        private WeatherStation weatherStation;

        [OneTimeSetUp]
        public void SetUp()
        {
            weatherData = new WeatherData(0, 0, 0);
            weatherStation = new WeatherStation(weatherData);

        }

        [Test]
        public void Ctor_NullWeatherData_ThrowArgumentNullException() => Assert.Throws<ArgumentNullException>(() => new WeatherStation(null), "Weather station can't be null.");

        [Test]
        public void Update_WeatherDataChange_InvokeOnce()
        {
            var observer = new Mock<IObserver>();
            observer.Setup(x => x.Update(It.IsAny<object>(), It.IsAny<EventArgs>()));
            var weatherDataSubsriber = observer.Object;

            weatherStation.Register(weatherDataSubsriber);
            weatherData.Humidity += 1;

            observer.Verify(x => x.Update(It.IsAny<object>(), It.IsAny<EventArgs>()), Times.Once);
        }

        [Test]
        public void Unregistry_WeatherDataChange_InvokeOnce()
        {
            var observer = new Mock<IObserver>();
            observer.Setup(x => x.Update(It.IsAny<object>(), It.IsAny<EventArgs>()));
            var weatherDataSubsriber = observer.Object;

            weatherStation.Register(weatherDataSubsriber);
            weatherData.Humidity += 1;
            weatherStation.Unregister(weatherDataSubsriber);
            weatherData.Humidity += 1;


            observer.Verify(x => x.Update(It.IsAny<object>(), It.IsAny<EventArgs>()), Times.Once);
        }
    }
}
