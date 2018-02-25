using System;
using System.Linq;
using DataLayer;
using Domain.Events.Tasks;
using Newtonsoft.Json;
using ViewProcessor;

namespace EventsConsummer
{
    public class Program
    {
        static void Main(string[] args)
        {
            var context = new ApplicationContext();

            var events = context.Events.ToList();

            var handler = new TaskListHandler();
            foreach (var evnt in events)
            {
                if (evnt.Type == "TaskCreatedEvent")
                {

                    var taskCreatedEvent = JsonConvert.DeserializeObject<TaskCreatedEvent>(evnt.Data);
                    // new TaskCreatedEvent (evnt.AggregateId,Type.GetType(evnt.AggregateType),evnt.IssuedBy);

                    handler.Handle(taskCreatedEvent);
                }

            }

            Console.WriteLine("Hello World!");
        }
    }
}
