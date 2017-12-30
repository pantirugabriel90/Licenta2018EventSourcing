using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    class ReplyUpdatedEvent : EventBase
    {
        public Guid ReplyId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public new string IssuedBy { get; set; }

        public ReplyUpdatedEvent(Guid aggregateId, Type aggregateType, string issuedBy) : base(aggregateId, aggregateType, issuedBy)
        {
        }

        public ReplyUpdatedEvent(Guid aggregateId, Type aggregateType, string issuedBy, string content, DateTime date,Guid replyId) : base(aggregateId, aggregateType, issuedBy)
        {
            ReplyId = replyId;
            IssuedBy = issuedBy;
            Content = content;
            Date = date;
            Type = GetType().Name;
        }
    }
}
