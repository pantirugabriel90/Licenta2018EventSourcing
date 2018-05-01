using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class TaskHoursLoggedEvent : EventBase
    {
        public double Hours { get; set; }

        public TaskHoursLoggedEvent()
        {

        }

        public TaskHoursLoggedEvent(Guid aggregateId, Type aggregateType, string issuedBy,double hours) : base(aggregateId, aggregateType, issuedBy)
        {
            Type = GetType().Name;
            Hours = hours;
        }
    }
}
