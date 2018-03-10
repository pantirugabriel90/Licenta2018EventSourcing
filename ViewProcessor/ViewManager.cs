using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using DataLayer;
using Domain.Events.Tasks;
using Domain.Views.Entities;
using Newtonsoft.Json;

namespace ViewProcessor
{
    public class ViewManager
    {
        private ApplicationContext Context { get; }

        public ViewManager()
        {
            Context = new ApplicationContext();
        }

        public void InterogateDatabase()
        {
            Timer t = new Timer(1000); // set the time (5 min in this case)
            t.AutoReset = true;
            t.Elapsed += new System.Timers.ElapsedEventHandler(ProcessEvents);
            t.Start();
        }

        void ProcessEvents(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            System.Console.WriteLine("works");

            var context = new ApplicationContext();

            var events = context.Events.ToList();

            var handler = new TaskListHandler();
            foreach (var evnt in events)
            {
                if (evnt.Type == "TaskCreatedEvent")
                {
                    var taskCreatedEvent = JsonConvert.DeserializeObject<TaskCreatedEvent>(evnt.Data);
                    // new TaskCreatedEvent (evnt.AggregateId,Type.GetType(evnt.AggregateType),evnt.IssuedBy);

                    //handler.Handle(taskCreatedEvent);
                }

            }


        }

        public List<Event> GetUnprocessedEvents(string viewName)
        {
            var numberOfProcessedEvents = Context.Views.FirstOrDefault(v => v.ViewName == viewName)?.NumberOfProcessedEvent;
            var events = Context.Events.OrderBy(e => e.TimeStamp).Skip(numberOfProcessedEvents ?? 0);
            return events.ToList();
        }

        public void DeleteAllViews()
        {
            Context.TaskList.ToList().Clear();
            Context.Views.ToList().Clear();
            SeedViewsTable();
        }

        public void SeedViewsTable()
        {

            Context.Views.Add(new View
            {
                ViewName = "TaskList",
                DateOfLastProcessedEvent = DateTimeOffset.MinValue,
                NumberOfProcessedEvent = 0
            });
            Context.Views.Add(new View
            {
                ViewName = "Task",
                DateOfLastProcessedEvent = DateTimeOffset.MinValue,
                NumberOfProcessedEvent = 0
            });
        }




    }
}
