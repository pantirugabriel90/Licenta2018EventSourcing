using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.EntityFrameworkCore;

namespace Services.Queries.OverallStatistics
{
    public class GetOverallStatisticsQueryHandler : IQueryHandler<GetOverallStatisticsQuery, GetOverallStatisticsQueryResult>
    {
        private IViewSincronizor _viewSincronizer;
        public GetOverallStatisticsQueryHandler(IViewSincronizor viewSincronizer)
        {
            _viewSincronizer = viewSincronizer;
        }
        public async Task<GetOverallStatisticsQueryResult> HandleAsync(GetOverallStatisticsQuery query)
        {
            _viewSincronizer.Sincornize();
            var context = new ApplicationContext();
            var result = new GetOverallStatisticsQueryResult
            {
                StudentStatistics = context.StudentStatistics.FirstOrDefault(s=>s.Username==query.Username)
            };
            return result;
        }
    }
}
