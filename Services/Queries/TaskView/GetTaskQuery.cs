using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Queries.TaskView
{
    public class GetTaskQuery : IQuery<GetTaskQueryResult>
    {
        public Guid AggregateId { get; set; }
    }
}
