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

        var eventEntity = new Domain.Entities.Event()
        {
            Id = Guid.NewGuid(),
            Title = request.Title,
            Description = request.Description,
            Location = request.Location,
            StartAtUtc = request.StartAtUtc,
            EndsAtUtc = request.EndsAtUtc,
            Status = Domain.Entities.EventStatus.Draft
        };

        await _repository.InsertAsync(eventEntity, cancellationToken);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return result;
    }
}
