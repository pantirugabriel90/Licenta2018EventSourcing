using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Statistics
{
    public class StartedTasksByGrade
    {
        public Dictionary<double, double> StartedTasks { get; set; }

        public StartedTasksByGrade()
        {
            StartedTasks = new Dictionary<double, double>();
        }
    }
}
