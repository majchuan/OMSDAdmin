using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class TContentItems
    {
        public int TContentItemsId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Title { get; set; }
        public int? ShowBullet { get; set; }
        public string Upload { get; set; }
        public int? SortOrder { get; set; }
        public string Href { get; set; }

        public RelatedContentWidgets Sublisting { get; set; }
    }
}
