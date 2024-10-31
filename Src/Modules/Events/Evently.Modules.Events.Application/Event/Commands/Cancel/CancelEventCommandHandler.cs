using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Evently.Commons.Application.Contracts.Messaging.Command;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Modules.Events.Application.Contracts;
using Evently.Modules.Events.Application.Contracts.Repositories;
using Evently.Modules.Events.Application.Event.Queries.Get;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Application.Event.Commands.Cancel;

internal sealed class CancelEventCommandHandler : ICommandHandler<CancelEventCommand>
{
    private readonly IDateTimeProvider _dateTimeProvider;

    private readonly IEventRepository _repository;

    private readonly IEventUnitOfWork _unitOfWork;

    public CancelEventCommandHandler(
        IDateTimeProvider dateTimeProvider,
        IEventRepository repository,
        IEventUnitOfWork unitOfWork
    )
    {
        _dateTimeProvider = dateTimeProvider;

        _repository = repository;

        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(CancelEventCommand request, CancellationToken cancellationToken)
    {
        Result result = Domain.Errors.Event.NotFound(request.Id);

        Func<Guid, Expression<Func<Domain.Entities.Event, bool>>> predicate = (id) => model => model.Id == id;

        if (await _repository.ExistAsync(predicate(request.Id), cancellationToken))
        {
            Domain.Entities.Event entity = await _repository.Query()
            .Where(predicate(request.Id))
            .SingleAsync(cancellationToken);

            result = entity.Cancel(_dateTimeProvider.UtcNow);

            if (result.IsSuccess)
            {
                result = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0 ? true : Error.None;
            }

        }

        return result;
    }
}
