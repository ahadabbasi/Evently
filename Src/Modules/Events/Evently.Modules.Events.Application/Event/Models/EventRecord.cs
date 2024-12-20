﻿using System;

namespace Evently.Modules.Events.Application.Event.Models;

public record EventRecord(
    Guid CategoryId,
    string Title,
    string Description,
    string Location,
    DateTime StartsAtUtc,
    DateTime? EndsAtUtc
);
