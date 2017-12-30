using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class TaskCompletedEvent : EventBase
    {
        public bool Completed { get; set; }

        public TaskCompletedEvent(Guid aggregateId, Type aggregateType, string issuedBy) : base(aggregateId, aggregateType, issuedBy)
        {
        }

        public TaskCompletedEvent(Guid aggregateId, Type aggregateType, string issuedBy,bool completed) : base(aggregateId, aggregateType, issuedBy)
        {
            Completed = completed;
            Type = GetType().Name;
        }

    }
}
