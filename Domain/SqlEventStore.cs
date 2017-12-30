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
            try
            {
                using (SqlConnection con = new SqlConnection(_connectionString))
                {

                    con.Open();
                    string queryString =
                "SELECT * from dbo.Events "
                    + "WHERE AggregateId = @aggregateId " +
                    "AND Version > @version;";

                    SqlCommand command = new SqlCommand(queryString, con);
                    command.Parameters.AddWithValue("@aggregateId", aggregateId);

                    command.Parameters.AddWithValue("@version", fromVersion);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {

                        while (reader.Read())
                        {
                            var eventType = typeof(SqlEventStore).Assembly.GetType("Domain.Events." + reader["Type"].ToString());
                            var ev = (IEvent)Activator.CreateInstance(eventType, Guid.Parse(reader["AggregateId"].ToString()),
                                typeof(SqlEventStore).Assembly.GetType(reader["AggregateType"].ToString()),
                                reader["IssuedBy"].ToString());
                            ev.Data = reader["Data"].ToString();
                            ev.TimeStamp = DateTimeOffset.Parse(reader["TimeStamp"].ToString());
                            ev.Type = reader["Type"].ToString();
                            ev.Version = Convert.ToInt32(reader["Version"]);
                            eventList.Add(ev);
                        }
                    }
                    con.Close();
                }
            }
            catch (Exception ex) {
                throw ex;
            }
            return eventList;
        }

        public System.Threading.Tasks.Task Save<T>(IEnumerable<IEvent> events, CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot
        {
            try
            {
                var eventsGroupedById = events.GroupBy(e => e.AggregateId);
                // create connection
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    connection.Open();

                    foreach (var group in eventsGroupedById)
                    {
                        InsertEvents(group, connection);
                    }
                    connection.Close();
                }
            }
            catch (Exception ex) {
                throw ex;
            }

            return System.Threading.Tasks.Task.CompletedTask;
        }

        private int GetVersionNumberForAggregate(IEvent _event, SqlConnection connection) {
            string countQuery =
           "SELECT count(*) from dbo.Aggregates "
               + "WHERE AggregateId = @aggregateId;";

            SqlCommand countCommand = new SqlCommand(countQuery, connection);

            countCommand.Parameters.AddWithValue("@aggregateId", _event.AggregateId);
            int numrows = (int)countCommand.ExecuteScalar();
            if (numrows == 0)
            {
                InsertNewAggregate(_event, connection);
                return 0;
            }
            else
            {
                string versionQuery =
               "SELECT * from dbo.Aggregates "
                   + "WHERE AggregateId = @aggregateId;";

                SqlCommand getVersionCommand = new SqlCommand(versionQuery, connection);
                getVersionCommand.Parameters.AddWithValue("@aggregateId", _event.AggregateId);

                int version;
                using (SqlDataReader reader = getVersionCommand.ExecuteReader())
                {
                    reader.Read();
                    version = Convert.ToInt32(reader["Version"]);
                }
                return version;
            }
            
        }

        private void InsertNewAggregate(IEvent _event, SqlConnection connection)
        {
            string insertStatement = "INSERT INTO dbo.Aggregates " +
                          "VALUES (@AggregateId, @Type, @Version) ";

            using (SqlCommand insertCommand = new SqlCommand(insertStatement, connection))
            {
                // define parameters and their values
                insertCommand.Parameters.Add("@AggregateId", SqlDbType.UniqueIdentifier).Value = _event.AggregateId;
                insertCommand.Parameters.Add("@Version", SqlDbType.Int).Value = _event.Version;
                insertCommand.Parameters.Add("@Type", SqlDbType.VarChar, 100).Value = _event.AggregateType.Name;
                insertCommand.ExecuteNonQuery();
            }

        }

        private void InsertEvents(IEnumerable<IEvent> events, SqlConnection connection) {
            // define INSERT query with parameters

            string insertStatement = "INSERT INTO dbo.Events " +
                           "VALUES (@AggregateId, @Version, @Type, @TimeStamp, @Data, @AggregateType, @IssuedBy) ";

            int lastVersion = GetVersionNumberForAggregate(events.FirstOrDefault(), connection);
            foreach (var ev in events)
            {
                lastVersion++;
                using (SqlCommand insertCommand = new SqlCommand(insertStatement, connection))
                {
                    // define parameters and their values
                    insertCommand.Parameters.Add("@AggregateId", SqlDbType.UniqueIdentifier).Value = ev.AggregateId;
                    insertCommand.Parameters.Add("@Version", SqlDbType.Int).Value = lastVersion;
                    insertCommand.Parameters.Add("@Type", SqlDbType.VarChar, 100).Value = ev.Type;
                    insertCommand.Parameters.Add("@TimeStamp", SqlDbType.DateTimeOffset, 7).Value = ev.TimeStamp;
                    insertCommand.Parameters.Add("@Data", SqlDbType.VarChar, -1).Value = "";
                    insertCommand.Parameters.Add("@AggregateType", SqlDbType.VarChar, 100).Value = ev.AggregateType.Name;
                    insertCommand.Parameters.Add("@IssuedBy", SqlDbType.VarChar, 50).Value = ev.IssuedBy;
                    //insert
                    insertCommand.ExecuteNonQuery();
                }
            }
            UpdateAggregatesTable(events.FirstOrDefault().AggregateId,lastVersion,connection);

        }

        private void UpdateAggregatesTable(Guid aggregateId, int newVersion, SqlConnection connection) {

            string updateStatement = "UPDATE dbo.Aggregates SET Version = @version WHERE AggregateId = @aggregateId";
            SqlCommand updateCommand = new SqlCommand(updateStatement, connection);
            updateCommand.Parameters.AddWithValue("@aggregateId", aggregateId);
            updateCommand.Parameters.AddWithValue("@version", newVersion);
            updateCommand.ExecuteNonQuery();
        }

    }
}
