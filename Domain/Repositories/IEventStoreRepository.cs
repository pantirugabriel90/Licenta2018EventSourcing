using CQRSlite.Events;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repositories
{
    public interface IEventStoreRepository
    {
        List<IEvent> GetEventsByAggregateId();
    }
}
