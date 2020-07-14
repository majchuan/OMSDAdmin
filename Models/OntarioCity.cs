using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class OntarioCity
    {
        public OntarioCity()
        {
            ClinicMailingCityNavigation = new HashSet<Clinic>();
            ClinicPhysicalCityNavigation = new HashSet<Clinic>();
            SearchParameters = new HashSet<SearchParameters>();
        }

        public int OntarioCityId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Name { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public int? DiabetesId { get; set; }

        public ICollection<Clinic> ClinicMailingCityNavigation { get; set; }
        public ICollection<Clinic> ClinicPhysicalCityNavigation { get; set; }
        public ICollection<SearchParameters> SearchParameters { get; set; }
    }
}
