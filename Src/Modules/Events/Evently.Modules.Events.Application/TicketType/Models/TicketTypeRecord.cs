using System;

namespace Evently.Modules.Events.Application.TicketType.Models;

public record TicketTypeRecord(
    Guid EventId,
    string Name,
    decimal Price,
    string Currency,
    decimal Quantity
);
