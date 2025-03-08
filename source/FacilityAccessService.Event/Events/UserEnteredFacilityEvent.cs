using System;

namespace FacilityAccessService.Event.Events
{
    public record UserEnteredFacilityEvent(string UserId, string FacilityId, DateTime EnteredTime);
}