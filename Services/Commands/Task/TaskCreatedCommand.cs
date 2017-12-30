using CQRSlite.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Commands.Task
{
    public class TaskCreatedCommand : ICommand
    {
        public Guid AggregateId { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }
        public double Hours { get; set; }
        public string IssuedBy { get; set; }
        public DateTime Date { get; set; }

        public TaskCreatedCommand(string issuedBy, string title, string content, List<string> tags, double hours,DateTime date)
        {
            AggregateId = Guid.NewGuid();
            Title = title;
            Content = content;
            Tags = tags;
            Hours = hours;
            Date = date;
            IssuedBy = issuedBy;
        }
    }
}
