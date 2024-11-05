using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Evently.Commons.Application.Contracts.Messaging.Query;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Modules.Events.Application.Contracts.Repositories;

namespace Evently.Modules.Events.Application.TicketType.Queries.Get;

internal sealed class GetTicketTypeQueryHandler : IQueryHandler<GetTicketTypeQuery, GetTicketTypeQueryResponse>
{
    private readonly ITicketTypeRepository _ticketTypeRepository;

    public GetTicketTypeQueryHandler(
        ITicketTypeRepository ticketTypeRepository
        )
    {
        _ticketTypeRepository = ticketTypeRepository;
    }

    public async Task<Result<GetTicketTypeQueryResponse>> Handle(GetTicketTypeQuery request, CancellationToken cancellationToken)
    {
        Result<GetTicketTypeQueryResponse> result = Domain.Errors.TicketType.NotFound(request.TicketTypeId);

        if(await _ticketTypeRepository.ExistByIdAsync(request.TicketTypeId, cancellationToken))
        {
            Domain.Entities.TicketType ticketTypeEntity = await _ticketTypeRepository.GetByIdAsync(request.TicketTypeId, cancellationToken);

            result = new GetTicketTypeQueryResponse(
                ticketTypeEntity!.Id,
                ticketTypeEntity!.EventId,
                ticketTypeEntity!.Name,
                ticketTypeEntity!.Price,
                ticketTypeEntity!.Currency,
                ticketTypeEntity!.Quantity
            );
        }

        return result;
    }
}
