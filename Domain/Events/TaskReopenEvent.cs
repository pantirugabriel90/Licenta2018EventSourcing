using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class TaskReopenEvent : EventBase
    {
        public TaskReopenEvent()
        {

        }

        public TaskReopenEvent(Guid aggregateId, Type aggregateType, string issuedBy) : base(aggregateId, aggregateType, issuedBy)
        {
        }
    }
}
