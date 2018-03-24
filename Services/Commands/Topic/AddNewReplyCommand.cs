using CQRSlite.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Commands.Topic
{
    public class AddNewReplyCommand : ICommand
    {

        public Guid AggregateId { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string IssuedBy { get; set; }

        public AddNewReplyCommand()
        {
                
        }
        public AddNewReplyCommand(Guid aggregateId, string issuedBy, string content)
        {
            AggregateId = aggregateId;
            Content = content;
            Date = DateTime.UtcNow;
            IssuedBy = issuedBy;
        }

    }
}
