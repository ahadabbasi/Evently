using System;
using Evently.Modules.Events.Application.TicketType.Models;

namespace Evently.Modules.Events.Application.TicketType.Models;

public sealed record TicketTypeQueryResponse(
    Guid Id,
    Guid EventId,
    string Name,
    decimal Price,
    string Currency,
    decimal Quantity
) : TicketTypeRecord(EventId, Name, Price, Currency, Quantity);
