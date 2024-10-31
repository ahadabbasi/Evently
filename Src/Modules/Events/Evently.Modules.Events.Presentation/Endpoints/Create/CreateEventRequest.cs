﻿using System;
using Evently.Modules.Events.Application.Models;

namespace Evently.Modules.Events.Presentation.Endpoints.Create;

internal sealed record CreateEventRequest(
    string Title,
    string Description,
    string Location,
    DateTime StartAtUtc,
    DateTime EndsAtUtc
) : EventRecord(Title, Description, Location, StartAtUtc, EndsAtUtc);