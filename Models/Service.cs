using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class Service
    {
        public Service()
        {
            InverseParentNavigation = new HashSet<Service>();
            TServiceContent = new HashSet<TServiceContent>();
            TServices = new HashSet<TServices>();
        }

        public int ServiceId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Name { get; set; }
        public int? SortOrder { get; set; }
        public int? Parent { get; set; }
        public int? DiabetesId { get; set; }

        public Service ParentNavigation { get; set; }
        public ICollection<Service> InverseParentNavigation { get; set; }
        public ICollection<TServiceContent> TServiceContent { get; set; }
        public ICollection<TServices> TServices { get; set; }
    }
}
