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

    }
}
