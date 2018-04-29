using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace Services.Queries.TopicView
{
    public class GetStatisticsQueryHandler : IQueryHandler<GetStatisticsQuery, GetStatisticsQueryResult>
    {
        private IViewSincronizor _viewSincronizer;
        public GetStatisticsQueryHandler(IViewSincronizor viewSincronizer)
        {
            _viewSincronizer = viewSincronizer;
        }
        public async Task<GetStatisticsQueryResult> HandleAsync(GetStatisticsQuery query)
        {
            _viewSincronizer.Sincornize();
            var context = new ApplicationContext();
            var result = new GetStatisticsQueryResult
            {
                GradesStatistics = context.GradesStatistics.ToList()
            };
            return result;
        }
    }
}
