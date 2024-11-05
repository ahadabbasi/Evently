using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Evently.Commons.Application.Contracts.Messaging.Query;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Modules.Events.Application.Contracts.Repositories;
using Evently.Modules.Events.Application.Event.Models;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Application.Event.Queries.List;

internal sealed class ListOfEventsQueryHandler : IQueryHandler<ListOfEventsQuery, IReadOnlyCollection<EventQueryResponse>>
{
    private readonly IEventRepository _eventRepository;

    public ListOfEventsQueryHandler(IEventRepository eventRepository)
    {
        _eventRepository = eventRepository;
    }

    public async Task<Result<IReadOnlyCollection<EventQueryResponse>>> Handle(ListOfEventsQuery request, CancellationToken cancellationToken)
    {
        return await _eventRepository
            .Query()
            .Select(model => 
                new EventQueryResponse(
                    model.Id,
                    model.CategoryId,
                    model.Title,
                    model.Location,
                    model.Description,
                    model.StartsAtUtc,
                    model.EndsAtUtc
                )
            )
            .ToListAsync(cancellationToken);
    }
}
