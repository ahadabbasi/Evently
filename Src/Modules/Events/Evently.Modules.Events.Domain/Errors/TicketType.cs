using System;
using Evently.Commons.Domain.Abstractions.Result;

namespace Evently.Modules.Events.Domain.Errors;

public static class TicketType
{
    public static Error NotFound(Guid ticketTypeId) =>
        Error.NotFound("TicketTypes.NotFound", ticketTypeId);
}
