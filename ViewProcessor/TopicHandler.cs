using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using Domain.Events;
using Domain.Views.Entities;

namespace ViewProcessor
{
    public class TopicHandler : IEventsHandler
    {
        private ApplicationContext Context { get; }

        public TopicHandler()
        {
            Context = new ApplicationContext();
        }
        public void Handle(TopicCreatedEvent message)
        {
            var newTopic = new Topic
            {
                Title = message.Title,
                IssuedBy = message.IssuedBy,
                Id = message.AggregateId,
                Content = message.Content,
                Date = message.Date,
                Replies = new List<Reply>()
            };
            Context.Topics.Add(newTopic);
            Context.SaveChanges();
        }

        public void Handle(TopicUpdatedEvent message)
        {
            var topic = Context.Topics.FirstOrDefault(t => t.Id == message.AggregateId);

            topic.Title = message.Title;
            topic.Content = message.Content;

            Context.SaveChanges();
        }

        public void Handle(ReplyUpdatedEvent message)
        {
            var topic = Context.Topics.FirstOrDefault(t => t.Id == message.AggregateId);
            var reply = topic.Replies.FirstOrDefault(r => r.Id == message.ReplyId);
            reply.Content = message.Content;

            Context.SaveChanges();
        }

        public void Handle(NewReplyAddedEvent message)
        {
            var topic = Context.Topics.FirstOrDefault(t => t.Id == message.AggregateId);

            var newReply = new Reply
            {
                Content = message.Content,
                Date = message.Date,
                Id = message.ReplyId,
                IssuedBy = message.IssuedBy
            };

            topic.Replies.Add(newReply);
            Context.SaveChanges();

        }

        public void Handle(TaskCreatedEvent message)
        {
        }

        public void Handle(TaskUpdatedEvent message)
        {
        }

        public void Handle(TaskStatusChangedEvent message)
        {
        }
    }
}
