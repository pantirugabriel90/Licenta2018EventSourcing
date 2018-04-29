using CQRSlite.Commands;
using Domain.ContextEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Commands.Task
{
    public class UpdateTaskCommand : ICommand
    {
        public Guid AggregateId { get; set; }
        public string IssuedBy { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public List<Tag> Tags { get; set; }
        public double Hours { get; set; }
        public double LoggedHours { get; set; }

        public bool CompletedStatus { get; set; }

        public UpdateTaskCommand()
        {
                
        }
        public UpdateTaskCommand(Guid aggregateId, string issuedBy, string title, string content, List<Tag> tags, double hours,bool completedStatus,double loggedHours)
        {
            AggregateId = aggregateId;
            IssuedBy = issuedBy;
            Title = title;
            Content = content;
            Tags = tags;
            Hours = hours;
            LoggedHours = loggedHours;
            CompletedStatus = completedStatus;
        }
    }
}
