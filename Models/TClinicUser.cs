using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class TClinicUser
    {
        public int TClinicUserId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public int? Status { get; set; }
        public int? ClinicUser { get; set; }

        public ClinicUser ClinicUserNavigation { get; set; }
        public Status StatusNavigation { get; set; }
        public Clinic Sublisting { get; set; }
    }
}
