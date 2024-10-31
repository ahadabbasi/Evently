using System;
using Evently.Commons.Domain.Abstractions.Entity;

namespace Evently.Modules.Events.Domain.Events.Event;

public sealed class EventCanceledEvent : DomainEvent
{
    public EventCanceledEvent(Guid eventId)
    {
        EventId = eventId;
    }

    public Guid EventId { get; init; }

}
