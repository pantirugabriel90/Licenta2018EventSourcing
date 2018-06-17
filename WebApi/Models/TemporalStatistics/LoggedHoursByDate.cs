using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Models.TemporalStatistics
{
    public class LoggedHoursByDate
    {
        public Dictionary<DateTime, double> LoggedHours { get; set; }

        public LoggedHoursByDate()
        {
            LoggedHours = new Dictionary<DateTime, double>();
        }
    }
}
