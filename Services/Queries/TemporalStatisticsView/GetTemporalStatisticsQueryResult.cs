using Domain.ContextEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Queries.TemporalStatisticsView
{
    public class GetTemporalStatisticsQueryResult: IQueryResult
    {
        public List<TemporalStatistics> TopicList { get; set; }
    }
}
