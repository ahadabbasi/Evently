using System;
using Evently.Commons.Domain.Abstractions.Entity;

namespace Evently.Modules.Events.Domain.Events.Event;

public sealed class EventRescheduledEvent : DomainEvent
{
    public EventRescheduledEvent(Guid eventId, DateTime startsAtUtc, DateTime? endsAtUtc)
    {
        EventId = eventId;

        StartsAtUtc = startsAtUtc;

        EndsAtUtc = endsAtUtc;
    }

    public Guid EventId { get; init; }

    public DateTime StartsAtUtc { get; init; }

    public DateTime? EndsAtUtc { get; init; }
}
