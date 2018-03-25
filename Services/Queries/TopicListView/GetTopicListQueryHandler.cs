using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace Services.Queries.TopicListView
{
    public class GetTopicListQueryHandler : IQueryHandler<GetTopicListQuery, GetTopicListQueryResult>
    {
        public async Task<GetTopicListQueryResult> HandleAsync(GetTopicListQuery query)
        {
            ViewSincronizor.Sincornize("TopicList");

            var context = new ApplicationContext();
            var result = new GetTopicListQueryResult();
            result.TopicList = context.TopicList.OrderByDescending(t=>t.LastActivity).ToList();
            return result;
        }
    }
}
