using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class DaysOfTheWeek
    {
        public DaysOfTheWeek()
        {
        }

        public int DaysOfTheWeekId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }

    }
}
