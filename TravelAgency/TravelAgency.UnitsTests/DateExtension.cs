using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgency.UnitsTests
{
    public static class DateExtension
    {
        public static DateTime AddWeeks(
                this DateTime _dateTime
            ,   Int32 _numberOfWeeks = 1
        )
        {
            return _dateTime.AddDays(7);
        }
    }
}
