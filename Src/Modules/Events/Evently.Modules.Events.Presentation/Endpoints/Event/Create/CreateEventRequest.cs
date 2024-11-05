using System;
using Evently.Modules.Events.Application.Event.Models;

namespace Evently.Modules.Events.Presentation.Endpoints.Event.Create;

internal sealed record CreateEventRequest(
    Guid CategoryId,
    string Title,
    string Description,
    string Location,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc
) : EventRecord(CategoryId, Title, Description, Location, StartsAtUtc, EndsAtUtc);
