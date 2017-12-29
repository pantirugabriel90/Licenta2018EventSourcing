using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events.Topics
{
    public class TopicUpdatedEvent:EventBase
    {
        public TopicUpdatedEvent(Guid aggregateId, Type aggregateType) : base(aggregateId, aggregateType)
        {

        }
    }
}
