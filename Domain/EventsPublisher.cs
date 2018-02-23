using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain
{
    public class EventsPublisher : IEventPublisher
    {
        System.Threading.Tasks.Task IEventPublisher.Publish<T>(T @event, CancellationToken cancellationToken)
        {
            return System.Threading.Tasks.Task.FromResult(0);
        }
    }
}
