using System;
using Evently.Commons.Domain.Abstractions.Result;

namespace Evently.Modules.Events.Domain.Errors;

public static class Event
{
    public static Error NotFound(Guid eventId) => Error.NotFound("Events.NotFound", eventId);
}
