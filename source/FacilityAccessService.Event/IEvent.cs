using System;

namespace FacilityAccessService.Event
{
    public interface IEvent
    {
        public Guid EventId { get; }

        public string EventType { get; }

        public DateTime TimeStamp { get; }
    }
}