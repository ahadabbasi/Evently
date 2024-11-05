using System;
using Evently.Modules.Events.Application.Event.Models;

namespace Evently.Modules.Events.Application.Event.Models;

public sealed record EventQueryResponse(
    Guid Id,
    Guid CategoryId,
    string Title,
    string Location,
    string Description,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc
) : EventRecord(CategoryId, Title, Description, Location, StartsAtUtc, EndsAtUtc);
