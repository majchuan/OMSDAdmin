using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class V51Languages
    {
        public V51Languages()
        {
            RelatedContentWidgets = new HashSet<RelatedContentWidgets>();
            TLanguageContent = new HashSet<TLanguageContent>();
            TPopupContentItem = new HashSet<TPopupContentItem>();
            TServiceContent = new HashSet<TServiceContent>();
            TServiceTypeContent = new HashSet<TServiceTypeContent>();
            TServiceTypePromo = new HashSet<TServiceTypePromo>();
            TSpecialtyContent = new HashSet<TSpecialtyContent>();
        }

        public int V51LanguagesId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public int IsDefault { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<RelatedContentWidgets> RelatedContentWidgets { get; set; }
        public ICollection<TLanguageContent> TLanguageContent { get; set; }
        public ICollection<TPopupContentItem> TPopupContentItem { get; set; }
        public ICollection<TServiceContent> TServiceContent { get; set; }
        public ICollection<TServiceTypeContent> TServiceTypeContent { get; set; }
        public ICollection<TServiceTypePromo> TServiceTypePromo { get; set; }
        public ICollection<TSpecialtyContent> TSpecialtyContent { get; set; }
    }
}
