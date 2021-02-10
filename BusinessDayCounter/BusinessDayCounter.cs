using BusinessDayCounter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessDayCounter
{
    public class BusinessDayCounter : IBusinessDayCounter
    {
        private static DayOfWeek[] WeekendDays = new[] { DayOfWeek.Saturday, DayOfWeek.Sunday };

        public int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate)
        {
            var countOfWeekdays = 0;

            for(var currentDate = firstDate.AddDays(1); currentDate < secondDate; currentDate = currentDate.AddDays(1))
            {
                if (IsWeekday(currentDate))
                {
                    countOfWeekdays++;
                }
            }

            return countOfWeekdays;
        }

        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays)
        {
            publicHolidays = publicHolidays ?? new List<DateTime>();

            var countOfBusinessDays = 0;
            
            for (var currentDate = firstDate.AddDays(1); currentDate < secondDate; currentDate = currentDate.AddDays(1))
            {
                if (IsWeekday(currentDate) && !publicHolidays.Any(x => x.Date == currentDate.Date))
                {
                    countOfBusinessDays++;
                }
            }

            return countOfBusinessDays;
        }


        public int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<IPublicHolidayDefinition> publicHolidays)
        {
            publicHolidays = publicHolidays ?? new List<IPublicHolidayDefinition>();

            var countOfBusinessDays = 0;
            var countOfDeferredPublicHolidays = 0;

            for (var currentDate = firstDate.AddDays(1); currentDate < secondDate; currentDate = currentDate.AddDays(1))
            {
                var isPublicHoliday = publicHolidays.Any(x => x.IsPublicHoliday(currentDate));

                if (IsWeekday(currentDate))
                {
                    if (!isPublicHoliday)
                    {
                        if (countOfDeferredPublicHolidays > 0)
                        {
                            // Consider currentDate as a deferred public holiday
                            countOfDeferredPublicHolidays--;
                        }
                        else
                        {
                            // Normal business day
                            countOfBusinessDays++;
                        }
                    }
                }
                else
                {
                    // If holiday happens during a weekend
                    if (isPublicHoliday)
                    {
                        countOfDeferredPublicHolidays++;
                    }
                }
            }

            return countOfBusinessDays;
        }

        private bool IsWeekday(DateTime date)
        {
            return !WeekendDays.Contains(date.DayOfWeek);
        }
    }
}
