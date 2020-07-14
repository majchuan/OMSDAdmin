using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class V51Navigation
    {
        public int Editstate { get; set; }
        public int V51NavigationId { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public int? Parent { get; set; }
        public string NavigationTitle { get; set; }
        public string Description { get; set; }
        public int Csid { get; set; }
        public int SOrder { get; set; }
        public int ShowNav { get; set; }
        public int ShowLink { get; set; }
        public int? PageObject { get; set; }
        public string Url { get; set; }
        public string FullPath { get; set; }
    }
}
