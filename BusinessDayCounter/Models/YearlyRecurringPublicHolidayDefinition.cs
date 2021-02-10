using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDayCounter.Models
{
    public class YearlyRecurringPublicHolidayDefinition : IPublicHolidayDefinition
    {
        public DateTime Date { get; set; }

        public bool IsPublicHoliday(DateTime date)
        {
            return (Date.Day == date.Day && Date.Month == date.Month);
        }

        public static YearlyRecurringPublicHolidayDefinition With(int day, int month)
        {
            return new YearlyRecurringPublicHolidayDefinition() {
                Date = new DateTime(DateTime.MinValue.Year, month, day)
            };
        }
    }
}
