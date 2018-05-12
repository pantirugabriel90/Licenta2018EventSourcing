using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Statistics
{
    public class CompletedTasks
    {
        public Dictionary<double, double> CompletedTasksByGrade { get; set; }

        public CompletedTasks()
        {
            CompletedTasksByGrade = new Dictionary<double, double>();
        }
    }
}
