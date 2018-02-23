using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Views.Entities
{
    public class Aggregate
    {
        public Guid AggregateId { get; set; }
        public int Version { get; set; }
        public string Type { get; set; }
    }
}
