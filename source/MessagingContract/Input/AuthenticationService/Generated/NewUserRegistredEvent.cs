using System;
using MessagingContract;

public record NewUserRegisteredEvent : IEvent
{
    public NewUserRegisteredEvent(string userId, Guid? eventId = null, DateTime? timeStamp = null)
    {
        EventId = eventId ?? Guid.NewGuid();
        EventType = nameof(NewUserRegisteredEvent);
        TimeStamp = timeStamp ?? DateTime.UtcNow;
        UserId = userId;
    }

    public string UserId { get; init; }
    public Guid EventId { get; init; }
    public string EventType { get; init; }
    public DateTime TimeStamp { get; init; }
}