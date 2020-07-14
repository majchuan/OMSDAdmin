using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class EmailType
    {
        public EmailType()
        {
            EmailNotification = new HashSet<EmailNotification>();
        }

        public int EmailTypeId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string TypeName { get; set; }

        public ICollection<EmailNotification> EmailNotification { get; set; }
    }
}
