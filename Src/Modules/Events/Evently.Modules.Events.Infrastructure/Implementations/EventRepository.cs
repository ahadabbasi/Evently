using System;
using Evently.Commons.Infrastructure.Abstractions;
using Evently.Modules.Events.Application.Contracts;
using Evently.Modules.Events.Domain.Entities;
using Evently.Modules.Events.Infrastructure.Database.Contexts;

namespace Evently.Modules.Events.Infrastructure.Implementations;

internal sealed class EventRepository : DatabaseContextRepository<EventsDatabaseContext, Event, Guid>, IEventRepository
{
    public EventRepository(EventsDatabaseContext context) : base(context)
    {
    }
}
