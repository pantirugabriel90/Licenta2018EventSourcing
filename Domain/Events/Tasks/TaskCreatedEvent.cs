using System;
using System.Collections.Generic;
using CQRSlite.Events;
using Domain.Views.Entities;

namespace Domain.Events.Tasks
{
    public class TaskCreatedEvent : EventBase
    {
        
        public string Title { get; set; }
        public string Content { get; set; }
        public double Hours { get; set; }
        public List<Tag> Tags { get; set; }

        
        public TaskCreatedEvent(Guid aggregateId, Type aggregateType, string issuedBy) : base(aggregateId, aggregateType, issuedBy)
        {
        }


        public TaskCreatedEvent(Guid aggregateId, Type aggregateType, string issuedBy, string title, string content, double hours,List<Tag> tags) : base(aggregateId, aggregateType, issuedBy)
        {
            Title = title;
            Content = content;
            Hours = hours;
            Tags = tags;
            Type = GetType().Name;
        }
    }
}
