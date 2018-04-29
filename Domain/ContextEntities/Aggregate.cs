using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain.ContextEntities
{
    public class Aggregate
    {
        [Key]
        public Guid AggregateId { get; set; }
        public int Version { get; set; }
        public string Type { get; set; }
    }
}
