using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Evently.Commons.Application.Contracts.Messaging.Command;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Modules.Events.Application.Contracts;
using Evently.Modules.Events.Application.Contracts.Repositories;

namespace Evently.Modules.Events.Application.Event.Commands.Create;

internal sealed class CreateEventCommandHandler : ICommandHandler<CreateEventCommand, Guid>
{
    private readonly IEventRepository _repository;

    private readonly IEventUnitOfWork _unitOfWork;

    public CreateEventCommandHandler(IEventRepository repository, IEventUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        Result<Guid> result = Error.None;

        Result<Domain.Entities.Event> entityResult = Domain.Entities.Event.Create(
            request.Title,
            request.Description,
            request.Location,
            request.StartsAtUtc,
            request.EndsAtUtc
        );

        if (entityResult.IsSuccess)
        {
            await _repository.InsertAsync(entityResult.Value, cancellationToken);

            if (await _unitOfWork.SaveChangesAsync(cancellationToken) > 0)
            {
                result = entityResult.Value.Id;
            }
        }
        else
        {
            result = entityResult.Errors.ToArray();
        }

        return result;
    }
}
