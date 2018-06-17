using Domain.ContextEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Queries.TopicListView
{
    public class GetTopicListQueryResult : IQueryResult
    {
        public List<TopicListElement> TopicList { get; set; }
    }
}
