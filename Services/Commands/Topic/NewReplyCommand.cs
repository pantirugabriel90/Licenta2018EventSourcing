using CQRSlite.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Commands.Topic
{
    public class NewReplyCommand : ICommand
    {

        public Guid AggregateId { get; set; }
        public Guid ReplyId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string IssuedBy { get; set; }

        public NewReplyCommand(Guid aggregateId, string issuedBy, string content)
        {
            ReplyId = Guid.NewGuid();
            AggregateId = aggregateId;
            Content = content;
            Date = DateTime.UtcNow;
            IssuedBy = issuedBy;
        }

    }
}
