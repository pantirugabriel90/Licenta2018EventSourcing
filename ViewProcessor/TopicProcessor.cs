using CQRSlite.Events;
using DataLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace ViewProcessor
{
    public class TopicProcessor
    {
        public ApplicationContext Context { get; set; }
        public IEventStore _eventStore { get; set; }

        public TopicProcessor(IEventStore eventStore)
        {
            _eventStore = eventStore;
            Context = new ApplicationContext();
        }

        public async List<IEvent> GetUnprocessedEvents() {
            var aggregates = await Context.Aggregates.ToListAsync();
            
        }
    }
}
