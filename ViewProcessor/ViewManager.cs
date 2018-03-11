﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Timers;
using DataLayer;
using Domain.Events.Tasks;
using Domain.Views.Entities;
using Microsoft.EntityFrameworkCore.Internal;
using Newtonsoft.Json;

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
                {"TaskList",new TaskListHandler()}
            };
            Context = new ApplicationContext();
        }

        public void InterogateDatabase()
        {
            System.Timers.Timer t = new System.Timers.Timer(1000); // set the time (5 min in this case)
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
                        if (evnt.Type == "TaskCreatedEvent")
                        {
                            var eventType = typeof(Event).Assembly.GetType("Domain.Events." + evnt.Type);
                            var taskCreatedEvent = JsonConvert.DeserializeObject(evnt.Data,eventType);
                            var type = viewHandler.Value.GetType();
                            var method = type.GetMethods().FirstOrDefault(m =>
                                m.Name == "Handle" && m.GetParameters().First().ParameterType == eventType);
                            if (method != null)
                                method.Invoke(viewHandler.Value, new object[] { taskCreatedEvent });

                            //viewHandler.Value.Handle(taskCreatedEvent);
                            Context.Views.FirstOrDefault(v => v.ViewName == viewHandler.Key).NumberOfProcessedEvent++;
                            Context.SaveChanges();
                        }
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

        public void DeleteAllViews()
        {
            using (SqlConnection con = new SqlConnection("Data Source=DESKTOP-P6BH1QB\\SQLEXPRESS;Initial Catalog=Licenta2018;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"))
            {
                SqlCommand com = new SqlCommand("Delete From TaskList ", con);
                con.Open();
                bool Deleted = com.ExecuteNonQuery() > 0;
                com = new SqlCommand("Delete From Views ", con);
                Deleted = com.ExecuteNonQuery() > 0;
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
        }




    }
}
