using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Views.Entities
{
    public class Event
    {
        public Guid AggregateId { get; set; }
        public int Version { get; set; }
        public string Type { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Data { get; set; }
        public string AggregateType { get; set; }
        public string IssuedBy { get; set; }
    }
}
