
using System;
using Evently.Commons.Domain.Abstractions;

namespace Evently.Modules.Events.Domain.Events;

public sealed class EventCreatedDomainEvent : DomainEvent<Guid>
{
    public EventCreatedDomainEvent(Guid eventId) : base(eventId)
    {
    }
}
