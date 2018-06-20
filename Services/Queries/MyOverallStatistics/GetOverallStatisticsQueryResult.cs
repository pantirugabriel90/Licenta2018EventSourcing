using Domain.ContextEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Queries.OverallStatistics
{
    public class GetOverallStatisticsQueryResult : IQueryResult
    {
        public StudentStatistics StudentStatistics { get; set; }

    }
}
