using CQRSlite.Domain;
using Domain.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Task : AggregateRoot
    {
        public Task(Guid aggregateId,string issuedBy, string title, string content, List<string> tags, double hours,DateTime date) {
            
            Id = aggregateId;

            ApplyChange(new TaskCreatedEvent(aggregateId,GetType(),issuedBy,title,content,tags,hours,date));
        }

        public void UpdateTaskDetails(Guid aggregateId, string issuedBy, string title, string description, List<string> tags, double hours, DateTime updateDate) {
            ApplyChange(new TaskUpdatedEvent(aggregateId,GetType(),issuedBy,title,description,tags,hours,updateDate));
        }

        public void CompleteTask(Guid aggregateId,bool completed,string issuedBy)
        {
            ApplyChange(new TaskCompletedEvent(aggregateId, GetType(), issuedBy, completed));
        }

    }
}
