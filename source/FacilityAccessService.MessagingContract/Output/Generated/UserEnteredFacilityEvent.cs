using System;
using FacilityAccessService.MessagingContract;

namespace FacilityAccessService.Event.Events
{
    public record UserEnteredFacilityEvent : IEvent
    {
        public Guid EventId { get; init; }
        public string EventType { get; init; }
        public DateTime TimeStamp { get; init; }
        public Guid FacilityId { get; init; }
        public string UserId { get; init; }

        public UserEnteredFacilityEvent(Guid facilityId, string userId, Guid? eventId = null)
        {
            this.EventId = eventId ?? Guid.NewGuid();
            this.EventType = nameof(UserEnteredFacilityEvent);
            this.TimeStamp = DateTime.UtcNow;
            this.FacilityId = facilityId;
            this.UserId = userId;
        }
    }
}