using System;
using Evently.Modules.Events.Application.Event.Models;
using MediatR;

namespace Evently.Modules.Events.Application.Event.Commands.Create;

public sealed record CreateEventCommand(
    string Title,
    string Description,
    string Location,
    DateTime StartAtUtc,
    DateTime? EndsAtUtc
) : EventRecord(Title, Description, Location, StartAtUtc, EndsAtUtc), 
    IRequest<Guid>;
