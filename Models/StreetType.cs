using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class StreetType
    {
        public int StreetTypeId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Name { get; set; }
    }
}
