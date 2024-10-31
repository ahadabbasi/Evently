using System;

namespace Evently.Modules.Events.Application.Models;

public record EventRecord(
    string Title,
    string Description,
    string Location,
    DateTime StartAtUtc,
    DateTime? EndsAtUtc
);
