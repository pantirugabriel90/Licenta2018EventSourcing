using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.TemporalStatistics
{
    public class CompletedTasksByDate
    {
        public Dictionary<DateTime, double> CompletedTasks { get; set; }

        public CompletedTasksByDate()
        {
            CompletedTasks = new Dictionary<DateTime, double>();
        }
    }
}
