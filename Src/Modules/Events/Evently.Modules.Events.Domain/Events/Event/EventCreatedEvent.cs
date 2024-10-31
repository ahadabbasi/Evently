
using System;
using Evently.Commons.Domain.Abstractions.Entity;

namespace Evently.Modules.Events.Domain.Events.Event;

public sealed class EventCreatedEvent : DomainEvent
{
    public EventCreatedEvent(Guid eventId)
    {
        EventId = eventId;
    }

    public Guid EventId { get; private set; }
}
