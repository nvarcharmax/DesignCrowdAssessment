using System;

namespace BusinessDayCounter.Models
{
    public class ExactPublicHolidayDefinition : IPublicHolidayDefinition
    {
        public DateTime Date { get; set; }

        public bool AllowPublicHolidayToBeDeferred => true;

        public bool IsPublicHoliday(DateTime date)
        {
            return (Date.Date == date.Date);
        }

        public static ExactPublicHolidayDefinition With(DateTime date)
        {
            return new ExactPublicHolidayDefinition()
            {
                Date = date
            };
        }
    }
}
