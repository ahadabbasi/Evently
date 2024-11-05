using System;
using Evently.Modules.Events.Application.Event.Models;

namespace Evently.Modules.Events.Application.Event.Models;

public sealed record EventQueryResponse(
    Guid Id,
    string Title,
    string Location,
    string Description,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc
) : EventRecord(Title, Description, Location, StartsAtUtc, EndsAtUtc);
