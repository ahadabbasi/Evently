using System;
using System.Threading;
using System.Threading.Tasks;
using Evently.Commons.Application.Contracts;
using Evently.Modules.Events.Domain.Entities;

namespace Evently.Modules.Events.Application.Contracts.Repositories;

public interface ITicketTypeRepository : IRepository<Domain.Entities.TicketType, Guid>
{
    Task<bool> ExistsAnyTiketForEventByIdAsync(Guid eventId, CancellationToken cancellation);
}
