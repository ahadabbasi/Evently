using System;
using Evently.Commons.Domain.Abstractions.Result;

namespace Evently.Modules.Events.Domain.Errors;

public static class Event
{
    public static Error NotFound(Guid eventId) => Error.NotFound("Events.NotFound", eventId);

    public static Error AlreadyCanceled = ("Events.AlreadyCanceled", "The event was already canceled");

    public static readonly Error NotDraft = ("Events.NotDraft", "The event is not in draft status");

    public static readonly Error EndDatePrecedesStartDate = (
        "Events.EndDatePrecedesStartDate",
        "The event end date precedes the start date"
    );
}
