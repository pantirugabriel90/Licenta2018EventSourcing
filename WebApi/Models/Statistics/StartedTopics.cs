using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Statistics
{
    public class StartedTopics
    {
        public Dictionary<double, double> StartedTopicsByGrade { get; set; }

        public StartedTopics()
        {
            StartedTopicsByGrade = new Dictionary<double, double>();
        }
    }
}
