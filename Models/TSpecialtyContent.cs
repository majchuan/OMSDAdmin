using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class TSpecialtyContent
    {
        public int TSpecialtyContentId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Content { get; set; }
        public int? V51Language { get; set; }

        public Specialty Sublisting { get; set; }
        public V51Languages V51LanguageNavigation { get; set; }
    }
}
