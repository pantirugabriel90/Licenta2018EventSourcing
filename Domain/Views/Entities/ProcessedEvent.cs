using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Views.Entities
{
    public class ProcessedEvent
    {
        [Key]
        [Column(Order = 0)]
        public Guid AggregateId { get; set; }
        [Key]
        [Column(Order = 1)]
        public int Version { get; set; }
    }
}
