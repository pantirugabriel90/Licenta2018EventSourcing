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
        private IViewSincronizor _viewSincronizer;
        public GetTopicListQueryHandler(IViewSincronizor viewSincronizer)
        {
            _viewSincronizer = viewSincronizer;
        }
        public async Task<GetTopicListQueryResult> HandleAsync(GetTopicListQuery query)
        {
            _viewSincronizer.Sincornize("TopicList");

            var context = new ApplicationContext();
            var result = new GetTopicListQueryResult();
            result.TopicList = context.TopicList.OrderByDescending(t=>t.LastActivity).ToList();
            return result;
        }
    }
}
