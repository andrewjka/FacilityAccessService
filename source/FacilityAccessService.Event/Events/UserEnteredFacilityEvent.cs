using System;

namespace FacilityAccessService.Event.Events
{
    public record UserEnteredFacilityEvent(Guid FacilityId, string UserId)
        : BaseEvent(nameof(UserEnteredFacilityEvent));
}