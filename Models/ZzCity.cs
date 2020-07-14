using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class ZzCity
    {
        public int CityId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Name { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
    }
}
