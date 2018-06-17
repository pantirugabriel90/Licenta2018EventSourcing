using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.TemporalStatistics
{
    public class StartedTopicsByDate
    {
        public Dictionary<DateTime, double> StartedTopics{ get; set; }

        public StartedTopicsByDate()
        {
            StartedTopics = new Dictionary<DateTime, double>();
        }
    }
}
