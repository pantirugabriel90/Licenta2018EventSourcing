using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class NewReplyAddedEvent : EventBase
    {
        public Guid ReplyId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public new string IssuedBy { get; set; }

        public NewReplyAddedEvent()
        {
                
        }

        public NewReplyAddedEvent(Guid aggregateId, Type aggregateType, string issuedBy) : base(aggregateId, aggregateType, issuedBy)
        {

        }

        public NewReplyAddedEvent(Guid aggregateId, Type aggregateType, string issuedBy,string content,DateTime date,Guid replyId) : base(aggregateId, aggregateType, issuedBy)
        {
            ReplyId = replyId;
            Content = content;
            Date = date;
            IssuedBy = issuedBy;
            Type = GetType().Name;
        }
    }
}
