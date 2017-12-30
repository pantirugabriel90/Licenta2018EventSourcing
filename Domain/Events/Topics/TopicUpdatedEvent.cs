using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class TopicUpdatedEvent:EventBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime UpdateDate { get; set; }
        public List<Reply> Replies { get; set; }

        public TopicUpdatedEvent(Guid aggregateId, Type aggregateType, string issuedBy) : base(aggregateId, aggregateType, issuedBy)
        {
        }

        public TopicUpdatedEvent(Guid aggregateId, Type aggregateType, string issuedBy, string title, string content, DateTime updateDate) : base(aggregateId, aggregateType,issuedBy)
        {
            Title = title;
            Content = content;
            UpdateDate = updateDate;
            Type = GetType().Name;
        }
    }
}
