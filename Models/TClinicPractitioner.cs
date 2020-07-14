using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class TClinicPractitioner
    {
        public int TClinicPractitionerId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Name { get; set; }
        public string PractitionerPhone { get; set; }
        public string Description { get; set; }
        public string Languages { get; set; }
        public int? SortOrder { get; set; }

        public Clinic Sublisting { get; set; }
    }
}
