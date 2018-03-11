using System;
using System.Collections.Generic;
using CQRSlite.Domain;
using Domain.Events;
using Domain.Views.Entities;

namespace Domain
{
    public class Task : AggregateRoot
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public double Hours { get; set; }
        public DateTime UpdateDate { get; set; }
        public DateTime Date { get; set; }
        public bool Completed { get; set; }

        public Task()
        {
        }
        public Task(Guid aggregateId, string issuedBy, string title, string content, List<Tag> tags, double hours)
        {

            Id = aggregateId;

            ApplyChange(new TaskCreatedEvent(aggregateId, GetType(), issuedBy, title, content, hours,tags));
        }

        public void UpdateTaskDetails(Guid aggregateId, string issuedBy, string title, string description, List<Tag> tags, double hours, double loggedHours,bool completedStatus)
        {
            ApplyChange(new TaskUpdatedEvent(aggregateId, GetType(), issuedBy, title, description, hours,loggedHours,completedStatus ));
        }

        public void CompleteTask(Guid aggregateId,string issuedBy)
        {
            ApplyChange(new TaskStatusChangedEvent(aggregateId, GetType(), issuedBy));
        }

    }
}
