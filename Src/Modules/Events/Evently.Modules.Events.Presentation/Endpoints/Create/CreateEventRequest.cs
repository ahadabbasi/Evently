using System;
using Evently.Modules.Events.Application.Event.Models;

namespace Evently.Modules.Events.Presentation.Endpoints.Create;

internal sealed record CreateEventRequest(
    string Title,
    string Description,
    string Location,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc
) : EventRecord(Title, Description, Location, StartsAtUtc, EndsAtUtc);
