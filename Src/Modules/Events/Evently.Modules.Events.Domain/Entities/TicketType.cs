using System;
using Evently.Commons.Domain.Abstractions.Entity;
using Evently.Modules.Events.Domain.Events.TicketType;

namespace Evently.Modules.Events.Domain.Entities;

public sealed class TicketType : Domain<Guid>
{
    public Guid EventId { get; private set; }

    public string Name { get; private set; }

    public decimal Price { get; private set; }

    public string Currency { get; private set; }

    public decimal Quantity { get; private set; }

    public static TicketType Create(
        Event @event,
        string name,
        decimal price,
        string currency,
        decimal quantity)
    {
        var ticketType = new TicketType
        {
            Id = Guid.NewGuid(),
            EventId = @event.Id,
            Name = name,
            Price = price,
            Currency = currency,
            Quantity = quantity
        };

        ticketType.Raise(new TicketTypeCreatedEvent(ticketType.Id));

        return ticketType;
    }

    public void UpdatePrice(decimal price)
    {
        if (Price == price)
        {
            return;
        }

        Price = price;

        Raise(new TicketTypePriceChangedEvent(Id, Price));
    }
}
