using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Statistics
{
    public class NumberOfReplies
    {
        public Dictionary<double, double> NumberOfRepliesByGrade { get; set; }

        public NumberOfReplies()
        {
            NumberOfRepliesByGrade = new Dictionary<double, double>();
        }
    }
}
