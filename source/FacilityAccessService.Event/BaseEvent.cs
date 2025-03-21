using System;

namespace FacilityAccessService.Event
{
    public abstract record BaseEvent
    {
        public Guid EventId { get; init; }

        public string EventType { get; init; }

        public DateTime TimeStamp { get; init; }


        protected BaseEvent(string eventType)
        {
            this.EventId = Guid.NewGuid();
            this.EventType = eventType;
            this.TimeStamp = DateTime.UtcNow;
        }
    }
}