using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models
{
    public class OverallStatistics
    {
        public Dictionary<string, double> Statistics { get; set; }

        public OverallStatistics()
        {
            Statistics = new Dictionary<string, double>();
        }
    }
}
