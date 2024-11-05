using System;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Evently.Commons.Application.Contracts.Messaging.Command;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Modules.Events.Application.Contracts;
using Evently.Modules.Events.Application.Contracts.Repositories;

namespace Evently.Modules.Events.Application.TicketType.Commands.Create;

internal sealed class CreateTicketTypeCommandHandler : ICommandHandler<CreateTicketTypeCommand, Guid>
{
    private readonly IEventRepository _eventRepository;
    private readonly ITicketTypeRepository _ticketTypeRepository;
    private readonly IEventUnitOfWork _unitOfWork;

    public CreateTicketTypeCommandHandler(
        IEventRepository eventRepository,
        ITicketTypeRepository ticketTypeRepository,
        IEventUnitOfWork unitOfWork
    )
    {
        _eventRepository = eventRepository;

        _ticketTypeRepository = ticketTypeRepository;

        _unitOfWork = unitOfWork;
    }

    public async Task<Result<Guid>> Handle(CreateTicketTypeCommand request, CancellationToken cancellationToken)
    {
        Result<Guid> result = Domain.Errors.Event.NotFound(request.EventId);

        if(await _eventRepository.ExistByIdAsync(request.EventId, cancellationToken))
        {
            Domain.Entities.Event eventEntity = await _eventRepository.GetByIdAsync(request.EventId, cancellationToken);

            var ticketTypeEntity = Domain.Entities.TicketType.Create(
                eventEntity!, 
                request.Name, 
                request.Price, 
                request.Currency, 
                request.Quantity
            );

            await _ticketTypeRepository.InsertAsync(ticketTypeEntity, cancellationToken);

            result = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0 ? ticketTypeEntity.Id : Error.None;
        }

        return result;
    }
}
