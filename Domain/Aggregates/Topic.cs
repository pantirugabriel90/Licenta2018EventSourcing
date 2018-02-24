using CQRSlite.Domain;
using Domain.Events;
using System;
using System.Collections.Generic;

namespace Domain
{
    public class Topic : AggregateRoot
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public List<Reply> Replies { get; set; }
        public DateTime UpdateDate { get; set; }

        public Topic()
        {
            Replies = new List<Reply>();
        }
        public Topic(Guid aggregateId,string title,string content,DateTime date,string issuedBy) {
            Id = aggregateId;
            ApplyChange(new TopicCreatedEvent(aggregateId, GetType(), issuedBy, title, content, date));
        }

        public void UpdateMainTopic(Guid aggregateId,string title,string content,DateTime updateDate,string issuedBy) {

            ApplyChange(new TopicUpdatedEvent(aggregateId, GetType(), issuedBy, title, content, updateDate));
        }
        public void AddNewReply(Guid aggregateId,string content,DateTime date,string issuedBy,Guid replyId) {
            ApplyChange(new NewReplyEvent(aggregateId,GetType(),issuedBy,content,date,replyId));
        }

        public void UpdateReply(Guid aggregateId, string content, DateTime updateDate, string issuedBy, Guid replyId)
        {
            ApplyChange(new ReplyUpdatedEvent(aggregateId,GetType(),issuedBy,content,updateDate,replyId));
        }
    } 


}
                    