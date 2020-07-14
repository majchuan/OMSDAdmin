using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class Lhinname
    {
        public Lhinname()
        {
            Clinic = new HashSet<Clinic>();
        }

        public int LhinnameId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Name { get; set; }

        public ICollection<Clinic> Clinic { get; set; }
    }
}
