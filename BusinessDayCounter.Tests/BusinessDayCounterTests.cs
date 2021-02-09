using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace BusinessDayCounter.Tests
{
    public class BusinessDayCounterTests
    {
        private IBusinessDayCounter _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new BusinessDayCounter();
        }

        [TestCase("2013-10-07", "2013-10-09", 1)]
        [TestCase("2013-10-05", "2013-10-14", 5)]
        [TestCase("2013-10-07", "2014-01-01", 61)]
        [TestCase("2013-10-07", "2013-10-05", 0)]
        public void GivenDateRange_ReturnCountOfWeekDays(string firstDateStr, string secondDateStr, int expectedDays)
        {
            // Arrange
            var firstDate = DateTime.Parse(firstDateStr);
            var secondDate = DateTime.Parse(secondDateStr);

            // Act
            var actualOutput = _sut.WeekdaysBetweenTwoDates(firstDate, secondDate);

            // Assert
            actualOutput.Should().Be(expectedDays);
        }

        [TestCase("2013-12-25,2013-12-26,2014-01-01","2013-10-07", "2013-10-09", 1)]
        [TestCase("2013-12-25,2013-12-26,2014-01-01", "2013-12-24", "2013-12-27", 0)]
        [TestCase("2013-12-25,2013-12-26,2014-01-01", "2013-10-07", "2014-01-01", 59)]
        public void GivenDateRangeAndPublicHolidays_ReturnCountOfBusinessDays(string publicHolidayDates, string firstDateStr, string secondDateStr, int expectedDays)
        {
            // Arrange
            var publicHolidays = publicHolidayDates.Split(",").Select(DateTime.Parse).ToList();
            var firstDate = DateTime.Parse(firstDateStr);
            var secondDate = DateTime.Parse(secondDateStr);

            // Act
            var actualOutput = _sut.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays);

            // Assert
            actualOutput.Should().Be(expectedDays);
        }

        //[TestCase("2013-10-07", "2013-10-09", 1)]
        //[TestCase("2013-12-24", "2013-12-27", 0)]
        //[TestCase("2013-10-07", "2014-01-01", 59)]
        //public void GivenDateRange_ReturnCountOfBusinessDays(string publicHolidayDates, string firstDateStr, string secondDateStr, int expectedDays)
        //{
        //    // Arrange
        //    var publicHolidays = publicHolidayDates.Split(",").Select(DateTime.Parse).ToList();
        //    var firstDate = DateTime.Parse(firstDateStr);
        //    var secondDate = DateTime.Parse(secondDateStr);

        //    // Act
        //    var actualOutput = _sut.BusinessDaysBetweenTwoDates(firstDate, secondDate, publicHolidays);

        //    // Assert
        //    actualOutput.Should().Be(expectedDays);
        //}
    }
}