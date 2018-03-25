using System;
using System.Collections.Generic;
using System.Text;
using Domain.Views.Entities;

namespace Services.Queries.TopicListView
{
    public class GetTopicListQueryResult: IQueryResult
    {
        public List<TopicListElement> TopicList { get; set; }
    }
}
