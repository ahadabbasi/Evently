using System;
using Evently.Modules.Events.Application.Contracts;

namespace Evently.Modules.Events.Infrastructure.Implementations;

internal sealed class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
