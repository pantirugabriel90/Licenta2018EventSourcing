using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using Domain.ContextEntities;
using Domain.Events;

namespace EventsConsummer.Handlers
{
    public class TaskHandler : IEventsHandler
    {
        public const string ViewName = "Task";
        private ApplicationContext Context { get; }

        public TaskHandler()
        {
            Context = new ApplicationContext();
        }

        public void Handle(TaskCreatedEvent message)
        {
            var newTask = new Task
            {
                Title = message.Title,
                Id = message.AggregateId,
                CompletedStatus = false,
                Content = message.Content,
                Date = message.TimeStamp.DateTime,
                Hours = message.Hours,
                LoggedHours = 0,
                IssuedBy = message.IssuedBy,
                Tags = new List<Tag>()

            };
            Context.Tasks.Add(newTask);
            Context.SaveChanges();
        }

        public void Handle(TaskUpdatedEvent message)
        {
            var task = Context.Tasks.FirstOrDefault(t => t.Id == message.AggregateId);

            try
            {
                task.LoggedHours = message.LoggedHours;
                task.CompletedStatus = message.CompletedStatus;
                task.Content = message.Content;
                task.Hours = message.Hours;
                task.Title = message.Title;

                Context.SaveChanges();

            }
            catch 
            {
                throw new Exception("Aggregate not found");
            } 

        }

        public void Handle(TaskStatusChangedEvent message)
        {
            var task = Context.Tasks.FirstOrDefault(t => t.Id == message.AggregateId);

            try
            {
                task.CompletedStatus = !task.CompletedStatus;

                Context.SaveChanges();

            }
            catch
            {
                throw new Exception("Aggregate not found");
            }
        }

        public void Handle(TaskCompletedEvent message)
        {
            var task = Context.Tasks.FirstOrDefault(t => t.Id == message.AggregateId);

            try
            {
                task.CompletedStatus = true;

                Context.SaveChanges();

            }
            catch
            {
                throw new Exception("Aggregate not found");
            }
        }

        public void Handle(TaskReopenEvent message)
        {
            var task = Context.Tasks.FirstOrDefault(t => t.Id == message.AggregateId);

            try
            {
                task.CompletedStatus = false;

                Context.SaveChanges();

            }
            catch
            {
                throw new Exception("Aggregate not found");
            }
        }

        public void Handle(TopicCreatedEvent message)
        {
        }

        public void Handle(TopicUpdatedEvent message)
        {
        }

        public void Handle(ReplyUpdatedEvent message)
        {
        }

        public void Handle(NewReplyAddedEvent message)
        {
        }
        
        public void Handle(TaskHoursLoggedEvent message)
        {
            var task = Context.Tasks.FirstOrDefault(t => t.Id == message.AggregateId);

            try
            {
                task.LoggedHours = task.LoggedHours + message.Hours;

                Context.SaveChanges();

            }
            catch
            {
                throw new Exception("Aggregate not found");
            }
        }
    }
}
