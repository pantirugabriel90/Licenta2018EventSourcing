using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class TopicCreatedEvent:EventBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }

        public TopicCreatedEvent(Guid aggregateId, Type aggregateType, string issuedBy) : base(aggregateId, aggregateType, issuedBy)
        {
        }

        public TopicCreatedEvent(Guid aggregateId, Type aggregateType,string issuedBy, string title, string content, DateTime date) : base(aggregateId, aggregateType,issuedBy)
        {
            Title = title;
            Content = content;
            Date = date;
            Type = GetType().Name;
        }
    }
}
