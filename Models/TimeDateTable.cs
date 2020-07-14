using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class TimeDateTable
    {
        public int TimeId { get; set; }
        public DateTime? TheDate { get; set; }
        public string TheDay { get; set; }
        public string TheMonth { get; set; }
        public short? TheYear { get; set; }
        public short? DayOfMonth { get; set; }
        public short? WeekOfYear { get; set; }
        public short? MonthOfYear { get; set; }
        public string QuarterOfYear { get; set; }
        public short? FiscalPeriod { get; set; }
    }
}
