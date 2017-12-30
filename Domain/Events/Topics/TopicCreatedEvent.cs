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
        public List<Reply> Replies { get; set; }

        public TopicCreatedEvent(Guid aggregateId, Type aggregateType,string issuedBy, string title, string content, DateTime date, List<Reply> replies) : base(aggregateId, aggregateType,issuedBy)
        {
            Title = title;
            Content = content;
            Date = date;
            Replies = replies;
            Type = GetType().Name;
        }
    }
}
