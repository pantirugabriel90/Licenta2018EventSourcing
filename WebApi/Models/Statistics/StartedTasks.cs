using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Statistics
{
    public class StartedTasks
    {
        public Dictionary<double, double> StartedTasksByGrade { get; set; }

        public StartedTasks()
        {
            StartedTasksByGrade = new Dictionary<double, double>();
        }
    }
}
