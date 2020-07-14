using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class ClinicCsv
    {
        public int ClinicCsvId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Document { get; set; }
        public string ClinicType { get; set; }
    }
}
