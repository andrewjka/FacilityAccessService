using System;

namespace MessagingContract;

public interface IEvent
{
    Guid EventId { get; }
    string EventType { get; }
    DateTime TimeStamp { get; }
}