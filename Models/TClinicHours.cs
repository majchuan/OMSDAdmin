using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class TClinicHours
    {
        public int TClinicHoursId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int? Day { get; set; }

        public Clinic Sublisting { get; set; }
    }
}
