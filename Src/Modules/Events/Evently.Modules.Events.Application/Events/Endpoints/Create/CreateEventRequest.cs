using System;

namespace Evently.Modules.Events.Application.Events.Endpoints.Create;

internal sealed record CreateEventRequest(
    string Title,
    string Description,
    string Location,
    DateTime StartAtUtc,
    DateTime EndsAtUtc
) : EventRecord(Title, Description, Location, StartAtUtc, EndsAtUtc);
