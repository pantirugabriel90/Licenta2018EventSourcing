using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Domain.Views.Entities;
using Microsoft.EntityFrameworkCore;

namespace Services.Queries.TopicView
{
    public class GetTopicQueryHandler : IQueryHandler<GetTopicQuery, GetTopicQueryResult>
    {
        public async Task<GetTopicQueryResult> HandleAsync(GetTopicQuery query)
        {
            ViewSincronizor.Sincornize("Topic");
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
