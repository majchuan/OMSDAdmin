using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class Language
    {
        public Language()
        {
            EmailNotification = new HashSet<EmailNotification>();
            TLanguageContentLanguageNavigation = new HashSet<TLanguageContent>();
            TLanguageContentSublisting = new HashSet<TLanguageContent>();
            TLanguages = new HashSet<TLanguages>();
        }

        public int LanguageId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Name { get; set; }
        public int? SortOrder { get; set; }

        public ICollection<EmailNotification> EmailNotification { get; set; }
        public ICollection<TLanguageContent> TLanguageContentLanguageNavigation { get; set; }
        public ICollection<TLanguageContent> TLanguageContentSublisting { get; set; }
        public ICollection<TLanguages> TLanguages { get; set; }
    }
}
