using System;

namespace FacilityAccessService.Event.Events
{
    public record UserEnteredFacilityEvent(string userClientId, string objectId, DateTime time);
}