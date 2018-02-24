using CQRSlite.Messages;
using System;

namespace CQRSlite.Events
{
    /// <summary>
    /// Defines an event with required fields.
    /// </summary>
    public interface IEvent : IMessage
    {
        Guid AggregateId { get; set; }
        int Version { get; set; }
        string Type { get; set; }
        Type AggregateType { get; set; }
        DateTimeOffset TimeStamp { get; set; }
        string IssuedBy { get; set; }
        string Data { get; set; }

    }
}
