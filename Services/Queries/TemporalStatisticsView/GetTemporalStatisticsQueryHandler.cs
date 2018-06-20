using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataLayer;

namespace Services.Queries.TemporalStatisticsView

{
    public class GetTemporalStatisticsQueryHandler : IQueryHandler<GetTemporalStatisticsQuery, GetTemporalStatisticsQueryResult>
    {
        private IViewSincronizor _viewSincronizer;
        public GetTemporalStatisticsQueryHandler(IViewSincronizor viewSincronizer)
        {
            _viewSincronizer = viewSincronizer;
        }
        public async Task<GetTemporalStatisticsQueryResult> HandleAsync(GetTemporalStatisticsQuery query)
        {
            _viewSincronizer.Sincornize();

            var context = new ApplicationContext();
            var result = new GetTemporalStatisticsQueryResult();
            result.TemporalStatistics = context.TemporalStatistics.Where(t=>t.Username==query.Username).OrderByDescending(t => t.Date).ToList();
            return result;
        }
    }
}
