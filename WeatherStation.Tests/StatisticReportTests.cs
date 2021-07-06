using NUnit.Framework;
using Moq;
using System;

namespace WeatherStation.Tests
{
    [TestFixture]
    internal class StatisticReportTests
    {
        private WeatherData weatherData;
        private WeatherStation weatherStation;
        private StatisticReport statisticReport;

        [OneTimeSetUp]
        public void SetUp()
        {
            weatherData = new WeatherData(0, 0, 0);
            weatherStation = new WeatherStation(weatherData);
            statisticReport = new StatisticReport(weatherStation);
        }

        [Test]
        public void Ctor_NullWeatherStation_ThrowArgumentNullException() => Assert.Throws<ArgumentNullException>(() => new StatisticReport(null), "Weather station can't be null");

        [Test]
        public void PrintStatisticReport_NoRecords_ThrowArgumentException() => Assert.Throws<ArgumentException>(() => new StatisticReport(weatherStation).PrintStatisticReport(), "There are not any weather information.");

        [Test]
        public void CountOfReports_WeatherDataChange_IncrementCountOfReports()
        {
            int countOfRecords = statisticReport.CountOfReports;

            weatherData.Humidity += 1;

            Assert.AreEqual(++countOfRecords, statisticReport.CountOfReports);
        }
    }
}
