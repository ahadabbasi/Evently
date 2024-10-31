using System;
using Evently.Commons.Application.Contracts.Messaging.Command;
using Evently.Modules.Events.Application.Event.Models;

namespace Evently.Modules.Events.Application.Event.Commands.Create;

public sealed record CreateEventCommand(
    string Title,
    string Description,
    string Location,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc
) : EventRecord(Title, Description, Location, StartsAtUtc, EndsAtUtc), 
    ICommand<Guid>;
