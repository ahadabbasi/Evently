using System;
using Evently.Commons.Domain.Abstractions.Entity;

namespace Evently.Modules.Events.Domain.Events.TicketType;

public sealed class TicketTypeCreatedEvent : DomainEvent
{
    public TicketTypeCreatedEvent(Guid ticketTypeId)
    {
        TicketTypeId = ticketTypeId;
    }

    public Guid TicketTypeId { get; init; }
}
