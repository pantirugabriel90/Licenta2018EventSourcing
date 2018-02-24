using CQRSlite.Events;
using DataLayer;
using Domain.Events;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Events.Tasks;
using Domain.Views.Entities;

namespace ViewProcessor
{
    public class TaskListHandler
    {
        private ApplicationContext Context { get;  }

        public TaskListHandler(ApplicationContext context)
        {
            Context = context;
        }

        public void HandleCreated(TaskCreatedEvent message)
        {
            var newTask = new TaskListElement
            {
                Title = message.Title,
                Completed = false,
                Id = message.AggregateId
            };
            Context.TaskList.Add(newTask);
            Context.SaveChanges();
        }

        public void HandleUpdated(TaskUpdatedEvent message)
        {
            var taskElement = Context.TaskList.FirstOrDefault(t=>t.Id==message.AggregateId);

            if (taskElement != null)
                taskElement.Title = message.Title;
            Context.SaveChanges();
        }

        public void HandleCompleted(TaskStatusChangedEvent message)
        {
            var taskElement = Context.TaskList.FirstOrDefault(t => t.Id == message.AggregateId);

            if (taskElement != null)
                taskElement.Completed = !taskElement.Completed;
            Context.SaveChanges();
        }
    }
}
