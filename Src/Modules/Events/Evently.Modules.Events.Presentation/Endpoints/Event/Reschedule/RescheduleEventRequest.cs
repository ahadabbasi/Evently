using System;

namespace Evently.Modules.Events.Presentation.Endpoints.Event.Reschedule;

public sealed record RescheduleEventRequest(DateTime StartsAtUtc, DateTime? EndsAtUtc);
