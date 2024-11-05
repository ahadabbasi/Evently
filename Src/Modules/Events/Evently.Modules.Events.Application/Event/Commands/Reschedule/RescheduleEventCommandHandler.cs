using System.Threading;
using System.Threading.Tasks;
using Evently.Commons.Application.Contracts.Messaging.Command;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Modules.Events.Application.Contracts;
using Evently.Modules.Events.Application.Contracts.Repositories;

namespace Evently.Modules.Events.Application.Event.Commands.Reschedule;

internal sealed class RescheduleEventCommandHandler : ICommandHandler<RescheduleEventCommand>
{
    private readonly IDateTimeProvider _dateTimeProvider;

    private readonly IEventRepository _eventRepository;

    private readonly IEventUnitOfWork _unitOfWork;

    public RescheduleEventCommandHandler(
        IDateTimeProvider dateTimeProvider,
        IEventRepository eventRepository,
        IEventUnitOfWork unitOfWork
    )
    {
        _dateTimeProvider = dateTimeProvider;

        _eventRepository = eventRepository;

        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(RescheduleEventCommand request, CancellationToken cancellationToken)
    {
        Result result = Domain.Errors.Event.StartDateInPast;

        if (request.StartsAtUtc > _dateTimeProvider.UtcNow)
        {
            result = Domain.Errors.Event.NotFound(request.Id);

            if (await _eventRepository.ExistByIdAsync(request.Id, cancellationToken))
            {
                Domain.Entities.Event eventEntity = await _eventRepository.GetByIdAsync(request.Id, cancellationToken);

                eventEntity!.Reschedule(request.StartsAtUtc, request.EndsAtUtc);

                result = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0 ? true : Error.None;
            }
        }

        return result;
    }
}
