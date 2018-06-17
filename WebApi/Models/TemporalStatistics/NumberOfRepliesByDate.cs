using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.TemporalStatistics
{
    public class NumberOfRepliesByDate
    {
        public Dictionary<DateTime, double> NumberOfReplies { get; set; }

        public NumberOfRepliesByDate()
        {
            NumberOfReplies = new Dictionary<DateTime, double>();
        }
    }
}
