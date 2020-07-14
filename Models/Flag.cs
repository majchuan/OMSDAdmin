using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class Flag
    {
        public int FlagId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Name { get; set; }
        public int? TypeOfProblem { get; set; }
        public string Details { get; set; }
        public int Clinic { get; set; }
        public string Email { get; set; }
        public string InternalNotes { get; set; }
        public int? Closed { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime? CreatedDate { get; set; }

        public Clinic ClinicNavigation { get; set; }
        public TypeOfProblem TypeOfProblemNavigation { get; set; }
    }
}
