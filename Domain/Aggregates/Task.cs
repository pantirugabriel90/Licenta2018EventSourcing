using System;
using System.Collections.Generic;
using CQRSlite.Domain;
using Domain.ContextEntities;
using Domain.Events;

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
            Completed = false;
        }

        public void UpdateTaskDetails(Guid aggregateId, string issuedBy, string title, string description, List<Tag> tags, double hours, double loggedHours,bool completedStatus)
        {
            ApplyChange(new TaskUpdatedEvent(aggregateId, GetType(), issuedBy, title, description, hours,loggedHours,completedStatus ));
        }

        public void ReopenTask(Guid aggregateId, string issuedBy)
        {
                ApplyChange(new TaskReopenEvent(aggregateId, GetType(), issuedBy));
        }
        public void CompleteTask(Guid aggregateId, string issuedBy)
        {
                ApplyChange(new TaskCompletedEvent(aggregateId, GetType(), issuedBy));
        }

        public void LogHours(Guid aggregateId, string issuedBy, double hours)
        {
            ApplyChange(new TaskHoursLoggedEvent(aggregateId, GetType(), issuedBy,hours));
        }

    }
}
