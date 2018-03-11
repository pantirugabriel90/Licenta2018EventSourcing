using System;
using CQRSlite.Events;

namespace Domain.Events
{
    public class TaskStatusChangedEvent : EventBase
    {
        public TaskStatusChangedEvent()
        {
                
        }

        public TaskStatusChangedEvent(Guid aggregateId, Type aggregateType, string issuedBy) : base(aggregateId, aggregateType, issuedBy)
        {
            Type = GetType().Name;
        }

    }
}
