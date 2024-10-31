using System;

namespace Evently.Modules.Events.Application.Event.Models;

public record EventRecord(
    string Title,
    string Description,
    string Location,
    DateTime StartAtUtc,
    DateTime? EndsAtUtc
);
