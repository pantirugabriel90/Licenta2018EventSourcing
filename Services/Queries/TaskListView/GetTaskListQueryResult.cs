using System;
using System.Collections.Generic;
using System.Text;
using Domain.Views.Entities;

namespace Services.Queries.TaskListView
{
    public class GetTaskListQueryResult:IQueryResult
    {
        public List<TaskListElement> TaskList { get; set; }
    }
}

