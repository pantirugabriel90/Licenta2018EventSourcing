using CQRSlite.Events;
using DataLayer;
using Domain.ContextEntities;
using Domain.Events;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventsConsummer.Handlers
{
   
    public class TaskListHandler :IEventsHandler
    {
        public const string ViewName = "TaskList";
        private ApplicationContext Context { get; }

        public TaskListHandler()
        {
            Context = new ApplicationContext();
        }

        public void Handle(TaskCreatedEvent message)
        {
            var newTask = new TaskListElement
            {
                Title = message.Title,
                Completed = false,
                Id = message.AggregateId,
                IssuedBy = message.IssuedBy
            };
            Context.TaskList.Add(newTask);
            Context.SaveChanges();
        }

        public void Handle(TaskUpdatedEvent message)
        {
            var taskElement = Context.TaskList.FirstOrDefault(t => t.Id == message.AggregateId);

            taskElement.Title = message.Title;
            taskElement.Completed = message.CompletedStatus;
            Context.SaveChanges();
        }

        public void Handle(TaskStatusChangedEvent message)
        {
            var taskElement = Context.TaskList.FirstOrDefault(t => t.Id == message.AggregateId);

            if (taskElement != null)
                taskElement.Completed = !taskElement.Completed;
            Context.SaveChanges();
        }

        public void Handle(TaskCompletedEvent message)
        {
            var taskElement = Context.TaskList.FirstOrDefault(t => t.Id == message.AggregateId);

            if (taskElement != null)
                taskElement.Completed = true;
            Context.SaveChanges();
        }

        public void Handle(TaskReopenEvent message)
        {
            var taskElement = Context.TaskList.FirstOrDefault(t => t.Id == message.AggregateId);

            if (taskElement != null)
                taskElement.Completed = false;
            Context.SaveChanges();
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
        }
    }
}
