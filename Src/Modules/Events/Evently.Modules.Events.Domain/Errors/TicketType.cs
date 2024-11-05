using System;
using Evently.Commons.Domain.Abstractions.Result;

namespace Evently.Modules.Events.Domain.Errors;

public static class TicketType
{
    public static Error NotFound(Guid ticketTypeId) =>
        Error.NotFound(
            string.Format("{0}.NotFound", Tags.TicketTypes), 
            ticketTypeId
        );
}
