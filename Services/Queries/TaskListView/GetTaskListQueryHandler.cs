﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Services.Queries.TaskListView
{
    public class GetTaskListQueryHandler:IQueryHandler<GetTaskListQuery,GetTaskListQueryResult>
    {
        public Task<GetTaskListQueryResult> HandleAsync(GetTaskListQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
