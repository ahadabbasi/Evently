using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Evently.Commons.Application.Contracts.Messaging.Query;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Modules.Events.Application.Contracts.Repositories;
using Evently.Modules.Events.Application.TicketType.Models;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Application.TicketType.Queries.List;

internal sealed class ListOfTicketTypesQueryHandler : IQueryHandler<ListOfTicketTypesQuery, IReadOnlyCollection<TicketTypeQueryResponse>>
{
    private readonly ITicketTypeRepository _repository;

    public ListOfTicketTypesQueryHandler(ITicketTypeRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<IReadOnlyCollection<TicketTypeQueryResponse>>> Handle(ListOfTicketTypesQuery request, CancellationToken cancellationToken)
    {
        return await _repository.Query()
            .Where(model => model.EventId.Equals(request.EventId))
            .Select(model => 
                new TicketTypeQueryResponse(
                    model.Id,
                    model.EventId,
                    model.Name,
                    model.Price,
                    model.Currency,
                    model.Quantity
                )
            )
            .ToListAsync(cancellationToken);
    }
}
