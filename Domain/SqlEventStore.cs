using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;
using CQRSlite.Domain;
using System.Threading;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Linq;

namespace Domain
{
    public class SqlEventStore : IEventStore
    {
        private readonly string _connectionString;

        public SqlEventStore(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<IEvent>> Get(Guid aggregateId, int fromVersion, CancellationToken cancellationToken = default(CancellationToken))
        {
            List<IEvent> eventList = new List<IEvent>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {

                con.Open();
                string queryString =
            "SELECT * from dbo.Events "
                + "WHERE AggregateId = @aggregateId;";

                SqlCommand command = new SqlCommand(queryString, con);
                command.Parameters.AddWithValue("@aggregateId", aggregateId);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    var y = reader["Type"].ToString();
                    var x = typeof(SqlEventStore).Assembly.GetType("Domain.Events.Tasks."+reader["Type"].ToString());
                    var ev  = (IEvent)Activator.CreateInstance(x, Guid.Parse(reader["AggregateId"].ToString()), typeof(SqlEventStore).Assembly.GetType(reader["AggregateType"].ToString()));
                    ev.AggregateId = Guid.Parse(reader["AggregateId"].ToString());
                    ev.AggregateType = typeof(SqlEventStore).Assembly.GetType(reader["AggregateType"].ToString());
                    ev.Data = reader["Data"].ToString();
                    ev.IssuedBy = reader["IssuedBy"].ToString();
                    ev.TimeStamp = DateTimeOffset.Parse(reader["TimeStamp"].ToString());
                    ev.Type = reader["Type"].ToString();
                    ev.Version = Convert.ToInt32(reader["Version"]);
                    eventList.Add(ev);
                }
                con.Close();
            }
            return eventList;
        }
        
        System.Threading.Tasks.Task IEventStore.Save<T>(IEnumerable<IEvent> events, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
