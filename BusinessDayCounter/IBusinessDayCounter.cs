using BusinessDayCounter.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessDayCounter
{
    public interface IBusinessDayCounter
    {
        int WeekdaysBetweenTwoDates(DateTime firstDate, DateTime secondDate);

        int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<DateTime> publicHolidays);

        int BusinessDaysBetweenTwoDates(DateTime firstDate, DateTime secondDate, IList<IPublicHolidayDefinition> publicHolidays);

    }
}
