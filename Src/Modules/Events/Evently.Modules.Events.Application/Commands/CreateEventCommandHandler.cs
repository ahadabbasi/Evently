using System;
using System.Threading;
using System.Threading.Tasks;
using Evently.Modules.Events.Application.Contracts;
using MediatR;

namespace Evently.Modules.Events.Application.Commands;

internal sealed class CreateEventCommandHandler : IRequestHandler<CreateEventCommand, Guid>
{
    private readonly IEventRepository _repository;

    private readonly IEventUnitOfWork _unitOfWork;

    public CreateEventCommandHandler(IEventRepository repository, IEventUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(CreateEventCommand request, CancellationToken cancellationToken)
    {
        Guid result = Guid.Empty;

        var eventEntity = Domain.Entities.Event.Create(
            request.Title,
            request.Description,
            request.Location,
            request.StartAtUtc,
            request.EndsAtUtc
        );

        await _repository.InsertAsync(eventEntity, cancellationToken);

        if(await _unitOfWork.SaveChangesAsync(cancellationToken) > 0)
        {
            result = eventEntity.Id;
        }

        return result;
    }
}
