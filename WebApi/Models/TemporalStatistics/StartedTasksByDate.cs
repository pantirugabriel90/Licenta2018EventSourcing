using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.TemporalStatistics
{
    public class StartedTasksByDate
    {
        public Dictionary<DateTime, double> StartedTasks { get; set; }

        public StartedTasksByDate()
        {
            StartedTasks = new Dictionary<DateTime, double>();
        }
    }
}
