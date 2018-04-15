using DataLayer;
using Domain.Views.Entities;
using EventsConsummer.Handlers;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Timers;

namespace ViewProcessor
{
    public class ViewManager
    {
        private ApplicationContext Context { get; }
        private Dictionary<string, IEventsHandler> ViewHandlers { get; set; }
        private Object _thisLock = new Object();

        public ViewManager()
        {
            ViewHandlers = new Dictionary<string, IEventsHandler>
            {
                {"TaskList", new TaskListHandler()},
                {"Task", new TaskHandler()},
                {"Topic", new TopicHandler()},
                {"TopicList", new TopicListHandler()}
            };
            Context = new ApplicationContext();
        }

        public void InterogateDatabase()
        {
            System.Timers.Timer t = new System.Timers.Timer(1); 
            t.AutoReset = true;
            t.Elapsed += new System.Timers.ElapsedEventHandler(ProcessEvents);
            t.Start();
        }

        void ProcessEvents(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            System.Console.WriteLine("works");

            lock (_thisLock)
            {

                foreach (var viewHandler in ViewHandlers)
                {
                    var events = GetUnprocessedEvents(viewHandler.Key);
                    foreach (var evnt in events)
                    {
                            var eventType = typeof(Event).Assembly.GetType("Domain.Events." + evnt.Type);
                            var taskCreatedEvent = JsonConvert.DeserializeObject(evnt.Data,eventType);
                            var type = viewHandler.Value.GetType();
                            var method = type.GetMethods().FirstOrDefault(m =>
                                m.Name == "Handle" && m.GetParameters().First().ParameterType == eventType);
                            if (method != null)
                                method.Invoke(viewHandler.Value, new object[] { taskCreatedEvent });

                        //viewHandler.Value.Handle(taskCreatedEvent);
                        var view = Context.Views.FirstOrDefault(v => v.ViewName == viewHandler.Key);
                        view.NumberOfProcessedEvent++;
                        view.DateOfLastProcessedEvent = DateTimeOffset.Now;
                        Context.SaveChanges();
                    }

                }
            }

        }

        public List<Event> GetUnprocessedEvents(string viewName)
        {
            var numberOfProcessedEvents = Context.Views.FirstOrDefault(v => v.ViewName == viewName)?.NumberOfProcessedEvent;
            var events = Context.Events.OrderBy(e => e.TimeStamp).Skip(numberOfProcessedEvents ?? 0);
            return events.ToList();
        }

        public void RestoreAllViews()
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-P6BH1QB\\SQLEXPRESS;Initial Catalog=Licenta2018;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                SqlCommand com = new SqlCommand("Delete From TaskList ", con);
                con.Open();
                com.ExecuteNonQuery();
                com = new SqlCommand("Delete From Views ", con);
                com.ExecuteNonQuery();
                com = new SqlCommand("Delete From Tasks ", con);
                com.ExecuteNonQuery();
                com = new SqlCommand("Delete From Reply ", con);
                com.ExecuteNonQuery();
                com = new SqlCommand("Delete From Topics ", con);
                com.ExecuteNonQuery();
                com = new SqlCommand("Delete From TopicList ", con);
                com.ExecuteNonQuery();
            }
            SeedViewsTable();
            Context.SaveChanges();
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
            Context.Views.Add(new View
            {
                ViewName = "TopicList",
                DateOfLastProcessedEvent = DateTimeOffset.MinValue,
                NumberOfProcessedEvent = 0
            });
            Context.Views.Add(new View
            {
                ViewName = "Topic",
                DateOfLastProcessedEvent = DateTimeOffset.MinValue,
                NumberOfProcessedEvent = 0
            });
        }




    }
}
