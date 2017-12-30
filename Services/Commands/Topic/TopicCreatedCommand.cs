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
        public List<Reply> Replies { get; set; }
        public string IssuedBy { get; set; }

        public TopicCreatedCommand(string title, string content, DateTime date, List<Reply> replies, string issuedBy) {

            AggregateId = Guid.NewGuid();
            Title = title;
            Content = content;
            Date = date;
            Replies = replies;
            IssuedBy = issuedBy;
        }
    }
}
