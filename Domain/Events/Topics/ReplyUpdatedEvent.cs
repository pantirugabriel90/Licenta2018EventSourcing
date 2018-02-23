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
        public DateTime UpdateDate { get; set; }
        public new string IssuedBy { get; set; }

        public ReplyUpdatedEvent(Guid aggregateId, Type aggregateType, string issuedBy) : base(aggregateId, aggregateType, issuedBy)
        {
        }

        public ReplyUpdatedEvent(Guid aggregateId, Type aggregateType, string issuedBy, string content, DateTime updateDate,Guid replyId) : base(aggregateId, aggregateType, issuedBy)
        {
            ReplyId = replyId;
            IssuedBy = issuedBy;
            Content = content;
            UpdateDate = updateDate;
            Type = GetType().Name;
        }
    }
}
