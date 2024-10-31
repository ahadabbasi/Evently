using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Evently.Modules.Events.Application.Contracts;
using Evently.Modules.Events.Application.Contracts.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Application.Event.Queries.Get;

internal sealed class GetEventQueryHandler : IRequestHandler<GetEventQuery, GetEventQueryResponse?>
{
    private readonly IEventRepository _repository;

    public GetEventQueryHandler(IEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<GetEventQueryResponse?> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        GetEventQueryResponse? result = null;

        Func<Guid, Expression<Func<Domain.Entities.Event, bool>>> predicate = (id) => model => model.Id == id;

        if (await _repository.ExistAsync(predicate(request.Id), cancellationToken))
        {
            result = await _repository.Query()
            .Where(predicate(request.Id))
            .Select(model => 
                new GetEventQueryResponse(
                    model.Id, 
                    model.Title, 
                    model.Location, 
                    model.Description, 
                    model.StartAtUtc, 
                    model.EndsAtUtc
                )
            )
            .SingleAsync(cancellationToken);
        }

        return result;
    }
}
