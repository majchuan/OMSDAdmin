using System;
using System.Collections.Generic;

namespace OMSDAdmin.Models
{
    public partial class TypeOfProblem
    {
        public TypeOfProblem()
        {
            Flag = new HashSet<Flag>();
        }

        public int TypeOfProblemId { get; set; }
        public int Editstate { get; set; }
        public int Sublistingid { get; set; }
        public DateTime Datecreated { get; set; }
        public string Name { get; set; }
        public int? SortOrder { get; set; }

        public ICollection<Flag> Flag { get; set; }
    }
}
