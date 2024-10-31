using System;

namespace Evently.Modules.Events.Application.Contracts;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
