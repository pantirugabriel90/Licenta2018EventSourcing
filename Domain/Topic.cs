using CQRSlite.Domain;
using Domain.Events;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class Topic : AggregateRoot
    {
        public Topic(Guid aggregateId,string title,string content,DateTime date,List<Reply> replies,string issuedBy) {
            Id = aggregateId;
            ApplyChange(new TopicCreatedEvent(aggregateId, GetType(), issuedBy, title, content, date, replies));
        }
    } 
}
                    