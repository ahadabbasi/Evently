using System;
using Evently.Commons.Domain.Abstractions.Entity;

namespace Evently.Modules.Events.Domain.Events.TicketType;

public sealed class TicketTypePriceChangedEvent : DomainEvent
{
    public TicketTypePriceChangedEvent(Guid ticketTypeId, decimal price)
    {
        TicketTypeId = ticketTypeId;

        Price = price;
    }

    public Guid TicketTypeId { get; init; }

    public decimal Price { get; init; }
}
