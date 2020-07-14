using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMSDAdmin.ViewModels
{
    public class CityViewModel
    {
        public CityViewModel()
        {
        }

        public int OntarioCityId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Name { get; set; }
        public string Lat { get; set; }
        public string Long { get; set; }
        public int? DiabetesId { get; set; }

    }
}
