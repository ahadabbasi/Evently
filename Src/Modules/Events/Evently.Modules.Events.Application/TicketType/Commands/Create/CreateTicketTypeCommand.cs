using System;
using Evently.Commons.Application.Contracts.Messaging.Command;
using Evently.Modules.Events.Application.TicketType.Models;

namespace Evently.Modules.Events.Application.TicketType.Commands.Create;

public sealed record CreateTicketTypeCommand(
    Guid EventId,
    string Name,
    decimal Price,
    string Currency,
    decimal Quantity
    ) : TicketTypeRecord(EventId, Name, Price, Currency, Quantity), ICommand<Guid>;
