using System;

namespace Evently.Modules.Events.Application.Events.Endpoints.Get;

internal sealed record GetEventResponse(
    Guid Id,
    string Title,
    string Location,
    string Description,
    DateTime StartAtUtc,
    DateTime EndsAtUtc
) : EventRecord(Title, Description, Location, StartAtUtc, EndsAtUtc);
