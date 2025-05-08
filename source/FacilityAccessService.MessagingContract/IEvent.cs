using System;

namespace FacilityAccessService.MessagingContract;

public interface IEvent
{
    Guid EventId { get; }
    string EventType { get; }
    DateTime TimeStamp { get; }
}