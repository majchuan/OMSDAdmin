using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class Province
    {
        public Province()
        {
            ClinicUser = new HashSet<ClinicUser>();
        }

        public int ProvinceId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Name { get; set; }

        public ICollection<ClinicUser> ClinicUser { get; set; }
    }
}
