using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class TaskUpdatedEvent:EventBase
    {
        public TaskUpdatedEvent(Guid aggregateId, Type aggregateType, string issuedBy) : base(aggregateId, aggregateType, issuedBy)
        {
            Type = this.GetType().Name;
        }
    }
}
