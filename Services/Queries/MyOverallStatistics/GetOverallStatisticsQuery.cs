using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Queries.OverallStatistics
{
    public class GetOverallStatisticsQuery : IQuery<GetOverallStatisticsQueryResult>
    {
        public string Username { get; set; }

        public GetOverallStatisticsQuery(string username)
        {
            Username = username;
        }
    }
}
