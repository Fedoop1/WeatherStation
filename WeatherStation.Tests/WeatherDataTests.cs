using System;
using WeatherStation.Interfaces;
using Moq;
using NUnit.Framework;

namespace WeatherStation.Tests
{
    [TestFixture]
    internal class WeatherDataTests
    {
        private WeatherData weatherData;

        [OneTimeSetUp]
        public void SetUp()
        {
            weatherData = new WeatherData(0, 0, 0);
        }

        

        [Test]
        public void SetPressure_ValueLowerThanZero_ThrowArgumentException() => Assert.Throws<ArgumentException>(() => new WeatherData(0, 0, -1));

        [Test]
        public void SetHumidity_ValueLowerThanZero_ThrowArgumentException() => Assert.Throws<ArgumentException>(() => new WeatherData(0, -1, 0));

        [Test]
        public void Update_WeatherDataChange_InvokeEventOnce()
        {
            var observer = new Mock<IObserver>();
            observer.Setup(x => x.Update(It.IsAny<object>(), It.IsAny<EventArgs>()));
            var weatherDataSubsriber = observer.Object;

            weatherData.Register(weatherDataSubsriber);
            weatherData.Temperature += 1;

            observer.Verify(x => x.Update(It.IsAny<object>(), It.IsAny<EventArgs>()), Times.Once);
        }

        [Test]
        public void Unregistry_WeatherDataChange_InvokeEventOnce()
        {
            var observer = new Mock<IObserver>();
            observer.Setup(x => x.Update(It.IsAny<object>(), It.IsAny<EventArgs>()));
            var weatherDataSubsriber = observer.Object;

            weatherData.Register(weatherDataSubsriber);
            weatherData.Temperature += 1;
            weatherData.Unregister(weatherDataSubsriber);
            weatherData.Temperature += 1;

            observer.Verify(x => x.Update(It.IsAny<object>(), It.IsAny<EventArgs>()), Times.Once);
        }
    }
}
