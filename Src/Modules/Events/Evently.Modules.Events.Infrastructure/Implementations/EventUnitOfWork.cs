using Evently.Commons.Infrastructure.Abstractions;
using Evently.Modules.Events.Application.Contracts;
using Evently.Modules.Events.Infrastructure.Database.Contexts;

namespace Evently.Modules.Events.Infrastructure.Implementations;

internal sealed class EventUnitOfWork : DatabaseContextUnitOfWork<Database.Contexts.EventsDatabaseContext>, IEventUnitOfWork
{
    public EventUnitOfWork(EventsDatabaseContext dbContext) : base(dbContext)
    {
    }
}
