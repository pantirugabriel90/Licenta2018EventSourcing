using Domain.ContextEntities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Queries.TopicView
{
    public class GetStatisticsQueryResult: IQueryResult
    {
        public List<GradeStatistics> GradesStatistics { get; set; }

    }
}
