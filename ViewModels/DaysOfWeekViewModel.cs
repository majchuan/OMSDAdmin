using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OMSDAdmin.ViewModels
{
    public class DaysOfWeekViewModel
    {
        public DaysOfWeekViewModel()
        {
        }

        public int DaysOfTheWeekId { get; set; }
        public DateTime Datecreated { get; set; }
        public string Name { get; set; }
        public string Abbreviation { get; set; }
    }

}
