using System;
using Evently.Commons.Domain.Abstractions.Result;

namespace Evently.Modules.Events.Domain.Errors;

public static class Event
{
    public static Error NotFound(Guid eventId) => Error.NotFound(
        string.Format("{0}.NotFound", Tags.Events), 
            eventId
        );

    public static readonly Error StartDateInPast = (
        string.Format("{0}.StartDateInPast", Tags.Events),
        "The event start date is in the past"
    );

    public static readonly Error AlreadyCanceled = (
        string.Format("{0}.AlreadyCanceled", Tags.Events), 
        "The event was already canceled"
    );

    public static readonly Error NotDraft = (
        string.Format("{0}.NotDraft", Tags.Events), 
        "The event is not in draft status"
    );

    public static readonly Error EndDatePrecedesStartDate = (
        string.Format("{0}.EndDatePrecedesStartDate", Tags.Events),
        "The event end date precedes the start date"
    );

    public static readonly Error AlreadyStarted = (
        string.Format("{0}.AlreadyStarted", Tags.Events),
        "The event has already started"
    );

    public static readonly Error NoTicketsFound = (
        string.Format("{0}.NoTicketsFound", Tags.Events),
        "The event does not have any ticket types defined"
        
    );
}
