using CQRSlite.Events;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Domain.Views.Entities
{
    public class Event : IEvent
    {
        [Key]
        [Column(Order = 0)]

        public Guid AggregateId { get; set; }
        public int Version { get; set; }
        public string Type { get; set; }
        [Key]
        [Column(Order = 1)]

        public DateTimeOffset TimeStamp { get; set; }
        public string Data { get; set; }
        public string AggregateType { get; set; }
        public string IssuedBy { get; set; }
        [JsonIgnore]
        Type IEvent.AggregateType { get; set; }
    }
}
