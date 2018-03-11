using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class TaskUpdatedEvent:EventBase
    {
        public new string IssuedBy { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public double Hours { get; set; }
        public double LoggedHours { get; set; }
        public bool CompletedStatus { get; set; }

        public TaskUpdatedEvent()
        {
                
        }
        public TaskUpdatedEvent(Guid aggregateId, Type aggregateType, string issuedBy) : base(aggregateId, aggregateType, issuedBy)
        {
        }

        public TaskUpdatedEvent(Guid aggregateId, Type aggregateType, string issuedBy, string title, string content, double hours, double loggedHours,bool completedStatus) : base(aggregateId, aggregateType, issuedBy)
        {
            Type = GetType().Name;
            AggregateId = aggregateId;
            IssuedBy = issuedBy;
            Title = title;
            Content = content;
            LoggedHours = loggedHours;
            CompletedStatus = completedStatus;
            Hours = hours;

        }
    }
}
