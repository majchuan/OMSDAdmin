using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class Status
    {
        public Status()
        {
            Clinic = new HashSet<Clinic>();
            ClinicUser = new HashSet<ClinicUser>();
            TClinicUser = new HashSet<TClinicUser>();
        }

        public int StatusId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Name { get; set; }

        public ICollection<Clinic> Clinic { get; set; }
        public ICollection<ClinicUser> ClinicUser { get; set; }
        public ICollection<TClinicUser> TClinicUser { get; set; }
    }
}
