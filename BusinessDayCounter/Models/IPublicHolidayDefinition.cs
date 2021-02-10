using System;

namespace BusinessDayCounter.Models
{
    public interface IPublicHolidayDefinition
    {
        bool IsPublicHoliday(DateTime date);
    }
}
