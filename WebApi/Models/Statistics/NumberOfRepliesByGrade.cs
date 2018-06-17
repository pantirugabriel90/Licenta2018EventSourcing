using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Statistics
{
    public class NumberOfRepliesByGrade
    {
        public Dictionary<double, double> NumberOfReplies{ get; set; }

        public NumberOfRepliesByGrade()
        {
            NumberOfReplies = new Dictionary<double, double>();
        }
    }
}
