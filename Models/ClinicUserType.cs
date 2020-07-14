using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class ClinicUserType
    {
        public ClinicUserType()
        {
            ClinicUser = new HashSet<ClinicUser>();
        }

        public int ClinicUserTypeId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Name { get; set; }
        public int SortOrder { get; set; }

        public ICollection<ClinicUser> ClinicUser { get; set; }
    }
}
