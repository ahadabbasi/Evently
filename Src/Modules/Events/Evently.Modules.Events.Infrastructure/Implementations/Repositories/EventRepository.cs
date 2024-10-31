using System;
using Evently.Commons.Infrastructure.Abstractions;
using Evently.Modules.Events.Application.Contracts.Repositories;
using Evently.Modules.Events.Domain.Entities;
using Evently.Modules.Events.Infrastructure.Database.Contexts;

namespace Evently.Modules.Events.Infrastructure.Implementations.Repositories;

internal sealed class EventRepository : DatabaseContextRepository<EventsDatabaseContext, Event, Guid>, IEventRepository
{
    public EventRepository(EventsDatabaseContext context) : base(context)
    {
    }
}
