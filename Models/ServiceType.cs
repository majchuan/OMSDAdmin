using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class ServiceType
    {
        public ServiceType()
        {
            Clinic = new HashSet<Clinic>();
            TServiceTypeContent = new HashSet<TServiceTypeContent>();
            TServiceTypePromo = new HashSet<TServiceTypePromo>();
        }

        public int ServiceTypeId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int? SortOrder { get; set; }

        public ICollection<Clinic> Clinic { get; set; }
        public ICollection<TServiceTypeContent> TServiceTypeContent { get; set; }
        public ICollection<TServiceTypePromo> TServiceTypePromo { get; set; }
    }
}
