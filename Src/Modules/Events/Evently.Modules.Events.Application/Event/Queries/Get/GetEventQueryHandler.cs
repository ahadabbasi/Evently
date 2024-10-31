using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Evently.Commons.Application.Contracts.Messaging.Query;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Modules.Events.Application.Contracts;
using Evently.Modules.Events.Application.Contracts.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Application.Event.Queries.Get;

internal sealed class GetEventQueryHandler : IQueryHandler<GetEventQuery, GetEventQueryResponse>
{
    private readonly IEventRepository _repository;

    public GetEventQueryHandler(IEventRepository repository)
    {
        _repository = repository;
    }

    public async Task<Result<GetEventQueryResponse>> Handle(GetEventQuery request, CancellationToken cancellationToken)
    {
        Result<GetEventQueryResponse> result = Domain.Errors.Event.NotFound(request.Id);

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
                    model.StartsAtUtc, 
                    model.EndsAtUtc
                )
            )
            .SingleAsync(cancellationToken);
        }

        return result;
    }
}
