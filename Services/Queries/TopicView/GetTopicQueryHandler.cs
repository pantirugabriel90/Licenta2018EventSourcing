using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace Services.Queries.TopicView
{
    public class GetTopicQueryHandler : IQueryHandler<GetTopicQuery, GetTopicQueryResult>
    {
        private IViewSincronizor _viewSincronizer;
        public GetTopicQueryHandler(IViewSincronizor viewSincronizer)
        {
            _viewSincronizer = viewSincronizer;
        }
        public async Task<GetTopicQueryResult> HandleAsync(GetTopicQuery query)
        {
            _viewSincronizer.Sincornize();
            var context = new ApplicationContext();
            var topic = context.Topics.Include("Replies").FirstOrDefault(t => t.Id == query.AggregateId);
            var result = new GetTopicQueryResult
            {
                Content = topic.Content,
                Date = topic.Date,
                Id = topic.Id,
                IssuedBy = topic.IssuedBy,
                Replies = topic.Replies.OrderBy(r=>r.Date).ToList(),
                Title = topic.Title
            };
            return result;
        }
    }
}
