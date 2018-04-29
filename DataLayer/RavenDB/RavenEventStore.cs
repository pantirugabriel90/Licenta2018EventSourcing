using CQRSlite.Domain;
using CQRSlite.Events;
using Domain.Views.Entities;
using Newtonsoft.Json;
using Raven.Client.Documents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DataLayer.RavenDB
{
    public class RavenEventStore : IEventStore
    {
        private readonly IDocumentStore store;

        public RavenEventStore(IDocumentStoreHolder documentStore)
        {
            this.store = documentStore.Store;
        }

        public async Task<IEnumerable<IEvent>> Get(Guid aggregateId, int fromVersion, CancellationToken cancellationToken = default(CancellationToken))
        {
            using (var session = this.store.OpenSession())
            {
                var events = (session.Query<Event>().Where(x => x.AggregateId == aggregateId && x.Version > fromVersion));

                 
                return  events.Select(e => (IEvent)e).ToList();
            }
        }

        public async System.Threading.Tasks.Task Save<T>(IEnumerable<IEvent> events, CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot
        {
            using (var session = this.store.OpenAsyncSession())
            {

                foreach (var evnt in events)
                {
                    var dbEvent = new Event
                    {
                        AggregateId = evnt.AggregateId,
                        Version = evnt.Version,
                        Type = evnt.Type,
                        TimeStamp = evnt.TimeStamp,
                        Data = JsonConvert.SerializeObject(evnt),
                        AggregateType = evnt.AggregateType.Name,
                        IssuedBy = evnt.IssuedBy
                    };
                    await session.StoreAsync(dbEvent);
                    await session.SaveChangesAsync();
                }
            }

        }
    }
}
