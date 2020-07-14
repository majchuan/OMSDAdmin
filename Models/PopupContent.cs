using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class PopupContent
    {
        public PopupContent()
        {
            TPopupContentItem = new HashSet<TPopupContentItem>();
        }

        public int PopupContentId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Title { get; set; }

        public ICollection<TPopupContentItem> TPopupContentItem { get; set; }
    }
}
