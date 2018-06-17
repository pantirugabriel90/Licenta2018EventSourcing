using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Statistics
{
    public class LoggedHoursByGrade
    {
        public Dictionary<double,double> LoggedHours { get; set; }

        public LoggedHoursByGrade()
        {
            LoggedHours = new Dictionary<double, double>();
        }
    }
}
