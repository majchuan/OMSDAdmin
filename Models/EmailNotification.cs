using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class EmailNotification
    {
        public int EmailNotificationId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Sub { get; set; }
        public string Body { get; set; }
        public string AddressFrom { get; set; }
        public int? Type { get; set; }
        public string NameFrom { get; set; }
        public int? EmailLanguage { get; set; }

        public Language EmailLanguageNavigation { get; set; }
        public EmailType TypeNavigation { get; set; }
    }
}
