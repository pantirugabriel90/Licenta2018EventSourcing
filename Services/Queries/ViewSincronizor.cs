using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Timers;
using DataLayer;

namespace Services.Queries
{
    public static class ViewSincronizor
    {

        public static void Sincornize(string viewName)
        {
            Stopwatch stopWatch = Stopwatch.StartNew();

            
            var context = new ApplicationContext();
            var numberOfEvents = context.Events.Count();
            var numberOfUnprocessedEvents =
                context.Views.FirstOrDefault(v => v.ViewName == viewName).NumberOfProcessedEvent;
            while (numberOfUnprocessedEvents < numberOfEvents)
            {
                numberOfEvents = context.Events.Count();
                numberOfUnprocessedEvents =
                   context.Views.FirstOrDefault(v => v.ViewName == viewName).NumberOfProcessedEvent;
                TimeSpan timespan = stopWatch.Elapsed;
                
                if(timespan.Seconds>2)
                    throw new Exception("Unable to sincronize views with events");

            }

        }


    }
}
