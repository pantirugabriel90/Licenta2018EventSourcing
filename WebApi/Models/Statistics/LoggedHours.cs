using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.Statistics
{
    public class LoggedHours
    {
        public Dictionary<double,double> LoggedHoursByGrade { get; set; }

        public LoggedHours()
        {
            LoggedHoursByGrade = new Dictionary<double, double>();
        }
    }
}
