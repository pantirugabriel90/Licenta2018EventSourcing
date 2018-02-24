using System;
using CQRSlite.Events;

namespace Domain.Events.Tasks
{
    public class TaskStatusChangedEvent : EventBase
    {

        public TaskStatusChangedEvent(Guid aggregateId, Type aggregateType, string issuedBy) : base(aggregateId, aggregateType, issuedBy)
        {
        }

    }
}
