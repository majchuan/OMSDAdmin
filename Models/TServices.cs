using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class TServices
    {
        public int TServicesId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public int? Service { get; set; }

        public Service ServiceNavigation { get; set; }
        public Clinic Sublisting { get; set; }
    }
}
