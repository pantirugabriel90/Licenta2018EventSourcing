using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Statistics
{
    public class StartedTopicsByGrade
    {
        public Dictionary<double, double> StartedTopics{ get; set; }

        public StartedTopicsByGrade()
        {
            StartedTopics = new Dictionary<double, double>();
        }
    }
}
