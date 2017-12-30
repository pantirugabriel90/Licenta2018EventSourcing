using CQRSlite.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Commands.Topic
{
    public class ReplyUpdatedCommand : ICommand
    {

        public Guid AggregateId { get; set; }
        public Guid ReplyId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string IssuedBy { get; set; }

        public ReplyUpdatedCommand(string content, DateTime date, string issuedBy, Guid replyId, Guid aggregateId)
        {
            ReplyId = replyId;
            AggregateId = aggregateId;
            Content = content;
            Date = date;
            IssuedBy = issuedBy;
        }
    }
}
