using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using Domain.ContextEntities;
using Domain.Events;

namespace EventsConsummer.Handlers
{

    public class TopicListHandler :  IEventsHandler
    {
        private ApplicationContext Context { get; }

        public TopicListHandler()
        {
            Context = new ApplicationContext();
        }

        public void Handle(TopicCreatedEvent message)
        {
            var newTopic = new TopicListElement
            {
                Title = message.Title,
                LastActivity = message.TimeStamp.DateTime,
                IssuedBy = message.IssuedBy,
                NumberOfReplies = 0,
                Id = message.AggregateId
            };
            Context.TopicList.Add(newTopic);
            Context.SaveChanges();
        }

        public void Handle(TopicUpdatedEvent message)
        {
            var topic = Context.TopicList.FirstOrDefault(t => t.Id == message.AggregateId);

            topic.Title = message.Title;
            topic.LastActivity = message.TimeStamp.DateTime;

            Context.SaveChanges();
        }

        public void Handle(ReplyUpdatedEvent message)
        {
            var topic = Context.TopicList.FirstOrDefault(t => t.Id == message.AggregateId);

            topic.LastActivity = message.TimeStamp.DateTime;

            Context.SaveChanges();
        }

        public void Handle(NewReplyAddedEvent message)
        {
            var topic = Context.TopicList.FirstOrDefault(t => t.Id == message.AggregateId);

            topic.NumberOfReplies++;
            topic.LastActivity = message.TimeStamp.DateTime;

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

        public void Handle(TaskCompletedEvent message)
        {
        }

        public void Handle(TaskReopenEvent message)
        {
        }

        public void Handle(TaskHoursLoggedEvent message)
        {
        }
    }
}
