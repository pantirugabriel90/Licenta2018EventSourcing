using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class TaskCompletedEvent : EventBase
    {
        public TaskCompletedEvent()
        {

        }

        public TaskCompletedEvent(Guid aggregateId, Type aggregateType, string issuedBy) : base(aggregateId, aggregateType, issuedBy)
        {
        }
    }
}
