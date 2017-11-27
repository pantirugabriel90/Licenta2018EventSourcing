using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;
using CQRSlite.Domain;
using System.Threading;
using System.Threading.Tasks;

namespace Domain
{
    public class SqlEventStore : IEventStore
    {
        public Task<IEnumerable<IEvent>> Get(Guid aggregateId, int fromVersion, CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        public System.Threading.Tasks.Task Save<T>(IEnumerable<IEvent> events, CancellationToken cancellationToken = default(CancellationToken)) where T : AggregateRoot
        {
            throw new NotImplementedException();
        }
    }
}
