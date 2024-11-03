using System;
using System.Threading;
using System.Threading.Tasks;
using Evently.Commons.Infrastructure.Abstractions;
using Evently.Modules.Events.Application.Contracts.Repositories;
using Evently.Modules.Events.Domain.Entities;
using Evently.Modules.Events.Infrastructure.Database.Contexts;

namespace Evently.Modules.Events.Infrastructure.Implementations.Repositories;

internal sealed class TicketTypeRepository : DatabaseContextRepository<EventsDatabaseContext, TicketType, Guid>, ITicketTypeRepository
{
    public TicketTypeRepository(EventsDatabaseContext context) : base(context)
    {
    }

    public async Task<bool> ExistsAnyTiketForEventByIdAsync(Guid eventId, CancellationToken cancellation)
    {
        return await ExistAsync(t => t.EventId == eventId, cancellation);
    }
}
