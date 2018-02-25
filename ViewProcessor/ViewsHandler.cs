using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataLayer;
using Domain.Views.Entities;

namespace ViewProcessor
{
    public class ViewsHandler
    {
        private ApplicationContext Context { get; }

        public ViewsHandler()
        {
            Context= new ApplicationContext();

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
