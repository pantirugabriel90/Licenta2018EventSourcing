using System;
using System.Collections.Generic;
using System.Text;
using Domain.ContextEntities;

namespace Services.Queries.TaskListView
{
    public class GetTaskListQueryResult:IQueryResult
    {
        public List<TaskListElement> TaskList { get; set; }
    }
}

