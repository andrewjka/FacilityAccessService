using System;
using MessagingContract;

namespace FacilityAccessService.Event.Events;

public record UserEnteredFacilityEvent : IEvent
{
    public UserEnteredFacilityEvent(Guid facilityId, string userId, Guid? eventId = null)
    {
        EventId = eventId ?? Guid.NewGuid();
        EventType = nameof(UserEnteredFacilityEvent);
        TimeStamp = DateTime.UtcNow;
        FacilityId = facilityId;
        UserId = userId;
    }

    public Guid FacilityId { get; init; }
    public string UserId { get; init; }
    public Guid EventId { get; init; }
    public string EventType { get; init; }
    public DateTime TimeStamp { get; init; }
}