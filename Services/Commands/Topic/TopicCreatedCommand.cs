using CQRSlite.Commands;
using Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Commands.Topic
{
    public class TopicCreatedCommand : ICommand
    {
        public Guid AggregateId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string IssuedBy { get; set; }

        public TopicCreatedCommand(string title, string content,string issuedBy) {

            AggregateId = Guid.NewGuid();
            Title = title;
            Content = content;
            Date = DateTime.UtcNow;
            IssuedBy = issuedBy;
        }
    }
}
