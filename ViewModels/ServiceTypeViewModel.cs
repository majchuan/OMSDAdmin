using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMSDAdmin.ViewModels
{
    public class ServiceTypeViewModel
    {
        public ServiceTypeViewModel()
        {
        }
        public int ServiceTypeId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int? SortOrder { get; set; }


    }
}
