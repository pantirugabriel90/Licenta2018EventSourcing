using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Events
{
    public class TaskCreatedEvent : EventBase
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public List<string> Tags { get; set; }
        public double Hours { get; set; }
        public DateTime Date { get; set; }

        public TaskCreatedEvent(Guid aggregateId,Type aggregateType, string issuedBy,string title,string content,List<string> tags,double hours,DateTime date) : base(aggregateId, aggregateType, issuedBy)
        {
            Title = title;
            Content = content;
            Tags = tags;
            Hours = hours;
            Date = date;
            Type = GetType().Name;
        }
    }
}
