using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class Specialty
    {
        public Specialty()
        {
            TSpecialtyContent = new HashSet<TSpecialtyContent>();
        }

        public int SpecialtyId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Name { get; set; }

        public ICollection<TSpecialtyContent> TSpecialtyContent { get; set; }
    }
}
