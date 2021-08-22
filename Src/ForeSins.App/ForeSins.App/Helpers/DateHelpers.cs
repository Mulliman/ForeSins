using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ForeSins.App.Helpers
{
    public static class DateHelpers
    {
        public static string ToDateString(this DateTime? date)
        {
            return date?.ToString("dd MMM yy");
        }
    }
}
