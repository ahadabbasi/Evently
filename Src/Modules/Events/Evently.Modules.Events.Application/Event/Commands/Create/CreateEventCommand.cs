using System;
using Evently.Commons.Application.Contracts.Messaging.Command;
using Evently.Modules.Events.Application.Event.Models;

namespace Evently.Modules.Events.Application.Event.Commands.Create;

public sealed record CreateEventCommand(
    Guid CategoryId,
    string Title,
    string Description,
    string Location,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc
) : EventRecord(CategoryId, Title, Description, Location, StartsAtUtc, EndsAtUtc), 
    ICommand<Guid>;
