﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CQRSlite.Events
{
    public abstract class EventBase : IEvent
    {
        public Guid AggregateId { get; set; }
        public int Version { get; set; }
        public string Type { get; set; }
        public Type AggregateType { get; set; }
        public DateTimeOffset TimeStamp { get; set; }
        public string Data { get; set; }

        public string IssuedBy { get; set; }
        public string CorrelationId { get; set; }

        public EventBase()
        {
                
        }
        protected EventBase(Guid aggregateId, Type aggregateType,string issuedBy)
        {
            AggregateId = aggregateId;
            AggregateType = aggregateType;
            IssuedBy = issuedBy;
        }
    }
}
