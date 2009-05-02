using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace GoGrid
{
    public static class PublicHelper
    {
        public static DateTimeOffset FromGoGridDateTime(this string input)
        {
            DateTimeOffset output = DateTimeOffset.Now;

            // Strict GoGrid parsing.
            if (DateTimeOffset.TryParseExact(input, "yyyy-MM-dd HH:mm:ss.fff K", null, DateTimeStyles.None, out output)) return output;
            if (DateTimeOffset.TryParseExact(input, "yyyy-MM-dd", null, DateTimeStyles.AssumeUniversal, out output)) return output;
            if (DateTimeOffset.TryParseExact(input, "MM/dd/yyyy", null, DateTimeStyles.AssumeUniversal, out output)) return output;
            if (DateTimeOffset.TryParseExact(input, "MM/dd/yy", null, DateTimeStyles.AssumeUniversal, out output)) return output;

            // Fallback parsing.
            output = DateTimeOffset.Parse(input, null, DateTimeStyles.AssumeUniversal);
            return output;
        }

        public static string ToGoGridDateTime(this DateTimeOffset input)
        {
            return input.ToString("yyyy-MM-dd HH:mm:ss.fff K");
        }
    }
}
