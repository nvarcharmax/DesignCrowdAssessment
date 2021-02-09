using BusinessDayCounter.Models;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Linq;

namespace BusinessDayCounter.Tests
{
    public class PublicHolidayDefinitionTests
    {
        [TestCase("2013-10-07", "2013-10-07", true)]
        [TestCase("2013-10-05", "2013-10-14", false)]
        public void GivenExactPublicHolidayDefinition_CheckIfMatched(string publicHolidayDateStr, string testDateStr, bool expectedOutput)
        {
            // Arrange
            var publicHolidayDate = DateTime.Parse(publicHolidayDateStr);
            var testDate = DateTime.Parse(testDateStr);
            var sut = ExactPublicHolidayDefinition.With(publicHolidayDate);

            // Act
            var actualOutput = sut.IsPublicHoliday(testDate);

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [TestCase(7, 10, "2013-10-07", true)]
        [TestCase(14, 10, "2013-10-14", true)]
        [TestCase(14, 11, "2013-10-14", false)]
        [TestCase(13, 10, "2013-10-14", false)]
        public void GivenYearlyRecurringPublicHolidayDefinition_CheckIfMatched(int day, int month, string testDateStr, bool expectedOutput)
        {
            // Arrange
            var testDate = DateTime.Parse(testDateStr);
            var sut = YearlyRecurringPublicHolidayDefinition.With(day, month);

            // Act
            var actualOutput = sut.IsPublicHoliday(testDate);

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }

        [TestCase(2, DayOfWeek.Tuesday, 2, "2021-02-09", true)]
        [TestCase(1, DayOfWeek.Tuesday, 2, "2021-02-02", true)]
        [TestCase(1, DayOfWeek.Monday, 2, "2021-02-02", false)]
        [TestCase(1, DayOfWeek.Tuesday, 2, "2021-02-09", false)]
        public void GivenYearlyRecurringNthDayOfWeekInMonthPublicHolidayDefinition_CheckIfMatched(int n, DayOfWeek dayOfWeek, int month, string testDateStr, bool expectedOutput)
        {
            // Arrange
            var testDate = DateTime.Parse(testDateStr);
            var sut = YearlyRecurringNthDayOfWeekInMonthPublicHolidayDefinition.With(n, dayOfWeek, month);

            // Act
            var actualOutput = sut.IsPublicHoliday(testDate);

            // Assert
            actualOutput.Should().Be(expectedOutput);
        }
    }
}