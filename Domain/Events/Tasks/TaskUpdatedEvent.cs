using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events.Tasks
{
    public class TaskUpdatedEvent:EventBase
    {
        public TaskUpdatedEvent(Guid aggregateId, Type aggregateType) : base(aggregateId, aggregateType)
        {

        }
    }
}
