using CQRSlite.Events;
using DataLayer;
using DataLayer.RavenDB;
using Domain.ContextEntities;
using EventsConsummer.Handlers;
using Newtonsoft.Json;
using Raven.Client.Documents;
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

        private readonly IDocumentStore store;

        public ViewManager(IDocumentStoreHolder documentStore)
        {
            this.store = documentStore.Store;
            ViewHandlers = new Dictionary<string, IEventsHandler>
            {
                {"TaskList", new TaskListHandler()},
                {"Task", new TaskHandler()},
                {"Topic", new TopicHandler()},
                {"TopicList", new TopicListHandler()},
                {"GradeStatistics", new GradeStatisticsHandler() }
            };
            Context = new ApplicationContext();
        }

        public void InterogateDatabase()
        {
            System.Timers.Timer t = new System.Timers.Timer(100); 
            t.AutoReset = true;
            t.Elapsed += new System.Timers.ElapsedEventHandler(ProcessEvents);
            t.Start();
        }

        void ProcessEvents(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            System.Console.WriteLine("works");

            lock (_thisLock)
            {
                var events = GetUnprocessedEvents();
                foreach (var evnt in events)
                {
                    var eventType = typeof(Event).Assembly.GetType("Domain.Events." + evnt.Type);
                    var taskCreatedEvent = JsonConvert.DeserializeObject(evnt.Data, eventType);

                    foreach (var viewHandler in ViewHandlers)
                    {
                        
                        var type = viewHandler.Value.GetType();
                        var method = type.GetMethods().FirstOrDefault(m =>
         m.Name == "Handle" && m.GetParameters().First().ParameterType == eventType);
                        if (method != null)
                        {
                            method.Invoke(viewHandler.Value, new object[] { taskCreatedEvent });
                            //viewHandler.Value.Handle(taskCreatedEvent);
                        }
                    }
                    var view = Context.Views.FirstOrDefault();
                    view.DateOfLastProcessedEvent = DateTimeOffset.Now;

                    view.NumberOfProcessedEvent++;
                    Context.SaveChanges();
                }
            }

        }

        public List<Event> GetUnprocessedEvents()
        {
            var numberOfProcessedEvents = Context.Views.FirstOrDefault()?.NumberOfProcessedEvent;
            List<Event> events = null;
            using (var session = this.store.OpenSession())
            {
                events = session.Query<Event>().Customize(x => x.WaitForNonStaleResults()).OrderBy(e => e.TimeStamp).Skip(numberOfProcessedEvents ?? 0).ToList();
            }

            return events;
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
                com = new SqlCommand("Delete From GradesStatistics ", con);
                com.ExecuteNonQuery();
                com = new SqlCommand("Delete From StudentStatistics ", con);
                com.ExecuteNonQuery();
            }
            SeedViewsTable();
            Context.SaveChanges();
        }

        public void SeedViewsTable()
        {
            Context.Views.Add(new View
            {
                ViewName = "ProcessedEvents",
                DateOfLastProcessedEvent = DateTimeOffset.MinValue,
                NumberOfProcessedEvent = 0
            });
            for(int i=4;i<=10;i++)
                Context.GradesStatistics.Add(new GradeStatistics { Grade = i });

            Context.StudentStatistics.Add(new StudentStatistics { Username = "Gabi9", Grade = 10 });
            Context.StudentStatistics.Add(new StudentStatistics { Username = "Stefan", Grade = 9 });
            Context.StudentStatistics.Add(new StudentStatistics { Username = "Olea", Grade = 8 });


            //Context.Views.Add(new View
            //{
            //    ViewName = "Task",
            //    DateOfLastProcessedEvent = DateTimeOffset.MinValue,
            //    NumberOfProcessedEvent = 0
            //});
            //Context.Views.Add(new View
            //{
            //    ViewName = "TopicList",
            //    DateOfLastProcessedEvent = DateTimeOffset.MinValue,
            //    NumberOfProcessedEvent = 0
            //});
            //Context.Views.Add(new View
            //{
            //    ViewName = "Topic",
            //    DateOfLastProcessedEvent = DateTimeOffset.MinValue,
            //    NumberOfProcessedEvent = 0
            //});
        }
    }
}
