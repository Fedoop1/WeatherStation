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
            weatherData = new WeatherData(0, 0, 0);
            weatherStation = new WeatherStation(weatherData);
            currentConditionReport = new CurrentConditionsReport(weatherStation);
            weatherStation.StartReceivingUpdates();
        }

        [Test]
        public void CurrentConditionReport_NullWeatherStation_ThrowArgumentNullException() => Assert.Throws<ArgumentNullException>(() => new CurrentConditionsReport(null), "Weather station can't be null");

        [Test]
        public void PrintReport_NoWeatherData_ThrowArgumentNullException() => Assert.Throws<ArgumentException>(() => new CurrentConditionsReport(weatherStation).PrintReport(), "There are not any weather information.");
        
        [Test]
        public void StopReceivingUpdates_WeatherDataChangeAndPrintReport_ThrowArgumentException()
        {
            currentConditionReport.StopReceivingUpdates();

            weatherData.Temperature += 1;

            try
            {
                currentConditionReport.PrintReport();
                Assert.Fail();
            }
            catch (ArgumentException)
            {
                Assert.True(true);
            }
        }
    }
}
