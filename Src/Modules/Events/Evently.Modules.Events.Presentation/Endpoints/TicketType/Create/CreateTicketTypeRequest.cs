using System;

namespace Evently.Modules.Events.Presentation.Endpoints.TicketType.Create;

internal sealed record CreateTicketTypeRequest(
    Guid EventId,
    string Name,
    decimal Price,
    string Currency,
    decimal Quantity
);
