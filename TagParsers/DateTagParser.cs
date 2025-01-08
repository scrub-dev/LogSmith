using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace logsmith.TagParsers
{
    public class DateTagParser : ITagParser
    {
        public static readonly string Tag = "date";
        public (string parsedString, bool success) Parse(string parameterString)
        {
            if (IsValidTimeFormatString(parameterString)) return (string.Empty , false);
            return (new DateTime(DateTime.Now.Ticks).ToString(parameterString), true);
        }

        private static bool IsValidTimeFormatString(string timeFormatString)
        {
            return DateTime.TryParseExact(new DateTime().ToString(), timeFormatString, CultureInfo.InvariantCulture, DateTimeStyles.None, out _);
        }
    }
}
