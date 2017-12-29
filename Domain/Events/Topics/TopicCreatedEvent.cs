using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events.Topics
{
    public class TopicCreatedEvent:EventBase
    {
        public TopicCreatedEvent(Guid aggregateId, Type aggregateType) : base(aggregateId, aggregateType)
        {

        }
    }
}
