using CQRSlite.Commands;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Commands.Topic
{
    public class TopicUpdatedCommand : ICommand
    {
        public Guid AggregateId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime UpdateDate { get; set; }
        public string IssuedBy { get; set; }

        public TopicUpdatedCommand(Guid aggregateId,string issuedBy, string title, string content)
        {
            AggregateId = aggregateId;
            Title = title;
            Content = content;
            UpdateDate = DateTime.UtcNow;
            IssuedBy = issuedBy;
        }
    }
}
