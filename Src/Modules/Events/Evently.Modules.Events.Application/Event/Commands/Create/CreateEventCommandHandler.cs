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

    private readonly IDateTimeProvider _dateTimeProvider;

    private readonly ICategoryRepository _categoryRepository;

    private readonly IEventUnitOfWork _unitOfWork;

    public CreateEventCommandHandler(
        IEventRepository repository,
        IEventUnitOfWork unitOfWork,
        IDateTimeProvider dateTimeProvider,
        ICategoryRepository categoryRepository
    )
    {
        _repository = repository;

        _unitOfWork = unitOfWork;

        _dateTimeProvider = dateTimeProvider;

        _categoryRepository = categoryRepository;
    }

    public async Task<Result<Guid>> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        Result<Guid> result = Domain.Errors.Event.StartDateInPast;

        if (request.StartsAtUtc > _dateTimeProvider.UtcNow)
        {
            result = Domain.Errors.Category.NotFound(request.CategoryId);

            if (await _categoryRepository.ExistByIdAsync(request.CategoryId, cancellationToken))
            {

                Result<Domain.Entities.Event> entityResult = Domain.Entities.Event.Create(
                    request.CategoryId,
                    request.Title,
                    request.Description,
                    request.Location,
                    request.StartsAtUtc,
                    request.EndsAtUtc
                );

                result = entityResult.Errors.ToArray();

                if (entityResult.IsSuccess)
                {
                    await _repository.InsertAsync(entityResult.Value!, cancellationToken);

                    result = 
                        await _unitOfWork.SaveChangesAsync(cancellationToken) > 0 ? 
                        entityResult.Value!.Id : 
                        Error.None;
                }
            }
        }

        return result;
    }
}
