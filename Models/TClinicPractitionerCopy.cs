using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class TClinicPractitionerCopy
    {
        public int TClinicPractitionerId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Name { get; set; }
        public int? Language { get; set; }
        public int? Specialty { get; set; }
        public string PractitionerPhone { get; set; }

        public Clinic Sublisting { get; set; }
    }
}
