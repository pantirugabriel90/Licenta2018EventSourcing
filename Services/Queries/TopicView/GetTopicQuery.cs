using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Queries.TopicView
{
    public class GetTopicQuery:IQuery<GetTopicQueryResult>
    {
        public Guid AggregateId { get; set; }
    }
}
