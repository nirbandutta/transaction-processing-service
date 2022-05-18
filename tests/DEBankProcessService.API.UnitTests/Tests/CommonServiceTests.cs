using Moq;
using NUnit.Framework;
using TransactionProcessingService.DataLayer.Contracts;
using TransactionProcessingService.Service.Services;
using System;

namespace TransactionProcessingService.API.UnitTests.Tests
{
    [TestFixture]
    public class CommonServiceTests
    {
        private Mock<IProcessDateRepository> _processDateRepositoryMock;
        private const string _publicHolidayDate = "2021-12-26"; 
        private const string _businessDate = "2021-10-08";
        private const string _weekendSaturdayDate = "2021-10-09";
        private const string _weekendSundayDate = "2021-10-10";
        private const string _getBusinessDay = "2021-10-07";
        private const string _getNextBusinessDay = "2021-12-25";


        [SetUp]
        public void Setup()
        {            
            _processDateRepositoryMock = new Mock<IProcessDateRepository>();            
            _processDateRepositoryMock.Setup(x => x.IsPublicHoliday(DateTime.Parse(_publicHolidayDate))).ReturnsAsync(true);
            _processDateRepositoryMock.Setup(x => x.IsPublicHoliday(DateTime.Parse(_businessDate))).ReturnsAsync(false);           
        }

        
        [Theory]
        [TestCase(_getBusinessDay, "2021-10-08")]
        [TestCase(_getNextBusinessDay, "2021-12-27")]
        public void GetNextBusinessDay_Test(string input, string expectedResult)
        {
            var sDate = DateTime.Parse(input);
            var y = new CommonService(_processDateRepositoryMock.Object);
            var response = y.GetNextBusinessDay(sDate);
            Assert.AreEqual(expectedResult, response.Result.ToString("yyyy-MM-dd"));            
        }

        [Theory]
        [TestCase(_businessDate, false)]
        [TestCase(_publicHolidayDate, true)]
        [TestCase(_weekendSaturdayDate, true)]
        [TestCase(_weekendSundayDate, true)]
        public void IsWeekendOrPublicHoliday(string input, bool expectedResult)
        {
            var sDate = DateTime.Parse(input);
            var y = new CommonService(_processDateRepositoryMock.Object);
            var response = y.IsWeekendOrPublicHoliday(sDate);
            Assert.AreEqual(expectedResult, response.Result);
        }
    }
}
