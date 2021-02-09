using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDayCounter.Models
{
    public class YearlyRecurringNthDayOfWeekInMonthPublicHolidayDefinition : IPublicHolidayDefinition
    {
        public int N { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public int Month { get; set; }

        public bool AllowPublicHolidayToBeDeferred => false;

        public bool IsPublicHoliday(DateTime date)
        {
            return date.DayOfWeek == DayOfWeek && 
                date.Month == Month && 
                date.Date == GetNthDayOfWeekOfMonthAndYear(N, DayOfWeek, Month, date.Year);
        }

        public static YearlyRecurringNthDayOfWeekInMonthPublicHolidayDefinition With(int n, DayOfWeek dayOfWeek, int month)
        {
            return new YearlyRecurringNthDayOfWeekInMonthPublicHolidayDefinition() {
                N = n,
                DayOfWeek = dayOfWeek,
                Month = month
            };
        }

        private DateTime GetNthDayOfWeekOfMonthAndYear(int n, DayOfWeek dayOfWeek, int month, int year)
        {
            var runningCountOfDayOfWeek = 0;

            var startOfMonth = new DateTime(year, month, 1);
            for (var currentDate = startOfMonth; currentDate.Month == month; currentDate = currentDate.AddDays(1))
            {
                if (currentDate.DayOfWeek == dayOfWeek)
                {
                    runningCountOfDayOfWeek++;
                    if (runningCountOfDayOfWeek == n)
                    {
                        return currentDate;
                    }
                }
            }

            return DateTime.MinValue;
        }
    }
}
