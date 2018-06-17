using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Statistics
{
    public class CompletedTasksByGrade
    {
        public Dictionary<double, double> CompletedTasks { get; set; }

        public CompletedTasksByGrade()
        {
            CompletedTasks= new Dictionary<double, double>();
        }
    }
}
