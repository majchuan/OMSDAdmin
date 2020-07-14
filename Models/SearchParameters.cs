using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class SearchParameters
    {
        public int SearchParametersId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Lat { get; set; }
        public string ServiceType { get; set; }
        public string Ip { get; set; }
        public string Long { get; set; }
        public string CityId { get; set; }
        public string LocatedNear { get; set; }
        public string ServicesOffered { get; set; }
        public int? NumOfResults { get; set; }
        public int? ProximityLimit { get; set; }
        public DateTime? DateSearched { get; set; }
        public int? CityId1 { get; set; }
        public int? Language { get; set; }
        public string Browser { get; set; }
        public string UserAgent { get; set; }

        public OntarioCity CityId1Navigation { get; set; }
    }
}
