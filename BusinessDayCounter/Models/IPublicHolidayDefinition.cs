using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessDayCounter.Models
{

    public interface IPublicHolidayDefinition
    {
        bool AllowPublicHolidayToBeDeferred { get; }
        bool IsPublicHoliday(DateTime date);
    }
}
