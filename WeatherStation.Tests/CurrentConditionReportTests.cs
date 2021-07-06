using System;
using NUnit.Framework;

namespace WeatherStation.Tests
{
    [TestFixture]
    internal class CurrentConditionReportTests
    {
        private WeatherData weatherData;
        private WeatherStation weatherStation;
        private CurrentConditionsReport currentConditionReport;

        [OneTimeSetUp]
        public void SetUp()
        {
            weatherData = new WeatherData(1, 1, 1);
            weatherStation = new WeatherStation(weatherData);
            currentConditionReport = new CurrentConditionsReport(weatherStation);
        }

        [Test]
        public void CurrentConditionReport_NullWeatherStation_ThrowArgumentNullException() => Assert.Throws<ArgumentNullException>(() => new CurrentConditionsReport(null), "Weather station can't be null");

        [Test]
        public void PrintReport_NoWeatherData_ThrowArgumentNullException() => Assert.Throws<ArgumentException>(() => new CurrentConditionsReport(weatherStation).PrintReport(), "There are not any weather information.");

        [Test]
        public void GetReport_ObservableChange_WheatherDataChange()
        {

            this.weatherData.Humidity += 1;
            var firstWeatherData = currentConditionReport.GetReport();
            this.weatherData.Humidity += 1;
            var secondWeatherData = currentConditionReport.GetReport();

            Assert.IsTrue(firstWeatherData.Humidity != secondWeatherData.Humidity);
        }
        
    }
}
