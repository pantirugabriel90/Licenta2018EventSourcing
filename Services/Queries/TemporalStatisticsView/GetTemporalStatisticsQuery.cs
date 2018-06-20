using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Queries.TemporalStatisticsView
{
    public class GetTemporalStatisticsQuery:IQuery<GetTemporalStatisticsQueryResult>
    {
        public string Username { get; set; }

        public GetTemporalStatisticsQuery(string username)
        {
            Username = username;
        }
    }
}
