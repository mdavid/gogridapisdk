using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoGrid
{
    public class DateRange : IModifier
    {
        public DateRange(DateTimeOffset from, DateTimeOffset to)
        {
            this.FromDate = from;
            this.ToDate = to;
        }

        public DateTimeOffset FromDate { get; set; }
        public DateTimeOffset ToDate { get; set; }

        public static DateRange None
        {
            get
            {
                DateRange range = new DateRange(DateTimeOffset.MinValue, DateTimeOffset.MaxValue);
                return range;
            }
        }

        public static DateRange From(DateTimeOffset from)
        {
            DateRange range = new DateRange(from, DateTimeOffset.MaxValue);
            return range;
        }

        public static DateRange From(string from)
        {
            return DateRange.From(from.FromGoGridDateTime());
        }

        public static DateRange To(DateTimeOffset to)
        {
            DateRange range = new DateRange(DateTimeOffset.MinValue, to);
            return range;
        }

        public static DateRange To(string to)
        {
            return DateRange.To(to.FromGoGridDateTime());
        }

        public static DateRange Between(DateTimeOffset from, DateTimeOffset to)
        {
            DateRange range = new DateRange(from, to);
            return range;
        }

        public static DateRange Between(string from, string to)
        {
            return DateRange.Between(from.FromGoGridDateTime(), to.FromGoGridDateTime());
        }

        public void Apply(Dictionary<string, string> parameters, Connection connection)
        {
            if (this.FromDate == DateTimeOffset.MinValue && this.ToDate == DateTimeOffset.MaxValue) return;

            if (this.FromDate == DateTimeOffset.MinValue && this.ToDate != DateTimeOffset.MaxValue)
            {
                parameters.Add("enddate", this.ToDate.ToGoGridDateTime());
                return;
            }

            if (this.FromDate != DateTimeOffset.MinValue && this.ToDate == DateTimeOffset.MaxValue)
            {
                parameters.Add("startdate", this.FromDate.ToGoGridDateTime());
                return;
            }

            parameters.Add("startdate", this.FromDate.ToGoGridDateTime());
            parameters.Add("enddate", this.ToDate.ToGoGridDateTime());
        }
    }
}
