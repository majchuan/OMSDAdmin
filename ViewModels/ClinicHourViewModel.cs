using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OMSDAdmin.Models;

namespace OMSDAdmin.ViewModels
{
    public class ClinicHourViewModel
    {
        public int TClinicHoursId { get; set; }
        public int Editstate { get; set; }
        public int ClinicID { get; set; }
        public DateTime Datecreated { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int? Day { get; set; }

        public int DaysOfTheWeekId { get; set; }
        public string DaysOfTheWeekName { get; set; }
        public string DaysOfTheWweekAbbre {get;set;}
    }
}
