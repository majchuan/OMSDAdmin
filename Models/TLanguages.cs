using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class TLanguages
    {
        public int TLanguagesId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public int? Lan { get; set; }

        public Language LanNavigation { get; set; }
        public Clinic Sublisting { get; set; }
    }
}
