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
        public string Description { get; set; }
        public double Hours { get; set; }
        public DateTime UpdateDate { get; set; }

        public TaskUpdatedEvent(Guid aggregateId, Type aggregateType, string issuedBy) : base(aggregateId, aggregateType, issuedBy)
        {
        }

        public TaskUpdatedEvent(Guid aggregateId, Type aggregateType, string issuedBy, string title, string description, double hours, DateTime updateDate) : base(aggregateId, aggregateType, issuedBy)
        {
            Type = GetType().Name;
            AggregateId = aggregateId;
            IssuedBy = issuedBy;
            Title = title;
            Description = description;
            Hours = hours;
            UpdateDate = updateDate;

        }
    }
}
