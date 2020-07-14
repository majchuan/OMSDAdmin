using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class TServiceTypeContent
    {
        public int TServiceTypeContentId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Title { get; set; }
        public string Summary { get; set; }
        public int? V51Languages { get; set; }
        public string OptionalLinkName { get; set; }
        public string OptionalLinkUrl { get; set; }
        public string TitlePlural { get; set; }
        public string LearnMoreLink { get; set; }
        public string Tooltip { get; set; }
        public string TitleLegend { get; set; }

        public ServiceType Sublisting { get; set; }
        public V51Languages V51LanguagesNavigation { get; set; }
    }
}
