using System;

namespace Evently.Modules.Events.Application.Events.Endpoints;

internal record EventRecord(
    string Title,
    string Description,
    string Location,
    DateTime StartAtUtc,
    DateTime EndsAtUtc
);
