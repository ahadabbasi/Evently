using System;
using Evently.Modules.Events.Application.Event.Models;

namespace Evently.Modules.Events.Application.Event.Queries.Get;

public sealed record GetEventQueryResponse(
    Guid Id,
    string Title,
    string Location,
    string Description,
    DateTime StartAtUtc,
    DateTime? EndsAtUtc
) : EventRecord(Title, Description, Location, StartAtUtc, EndsAtUtc);
