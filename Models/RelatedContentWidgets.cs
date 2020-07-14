using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class RelatedContentWidgets
    {
        public RelatedContentWidgets()
        {
            TContentItems = new HashSet<TContentItems>();
        }

        public int RelatedContentWidgetsId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Title { get; set; }
        public int? WebsiteSection { get; set; }
        public int? Language { get; set; }

        public V51Languages LanguageNavigation { get; set; }
        public ICollection<TContentItems> TContentItems { get; set; }
    }
}
