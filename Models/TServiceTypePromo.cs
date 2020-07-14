using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class TServiceTypePromo
    {
        public int TServiceTypePromoId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string ImageUrl { get; set; }
        public int? Language { get; set; }
        public string Content { get; set; }
        public string ImageLink { get; set; }

        public V51Languages LanguageNavigation { get; set; }
        public ServiceType Sublisting { get; set; }
    }
}
