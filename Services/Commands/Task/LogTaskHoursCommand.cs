using CQRSlite.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Commands.Task
{
    public class LogTaskHoursCommand : ICommand
    {
        public Guid AggregateId { get; set; }
        public double HoursLoggged { get; set; }
        public string IssuedBy { get; set; }
    }
}
