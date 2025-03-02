using System;

namespace FacilityAccessService.Event.Events
{
    public record UserLeavedFacilityEvent(string userClientId, string objectId, DateTime time);
}