using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;
using Evently.Commons.Application.Contracts.Messaging.Command;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Modules.Events.Application.Contracts;
using Evently.Modules.Events.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Application.Event.Commands.Publish;

internal sealed class PublishEventCommandHandler : ICommandHandler<PublishEventCommand>
{
    private readonly IEventRepository _eventRepository;
    private readonly ITicketTypeRepository _ticketTypeRepository;
    private readonly IEventUnitOfWork _unitOfWork;
    public PublishEventCommandHandler(
        IEventRepository eventRepository,
        ITicketTypeRepository ticketTypeRepository,
        IEventUnitOfWork unitOfWork
    )
    {
        _eventRepository = eventRepository;

        _ticketTypeRepository = ticketTypeRepository;

        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(PublishEventCommand request, CancellationToken cancellationToken)
    {
        Result result = Domain.Errors.Event.NotFound(request.Id);

        Func<Guid, Expression<Func<Domain.Entities.Event, bool>>> predicate = 
            (id) => model => model.Id.Equals(id);

        if (await _eventRepository.ExistAsync(predicate(request.Id), cancellationToken))
        {
            result = Domain.Errors.Event.NoTicketsFound;

            if (await _ticketTypeRepository.ExistsAnyTiketForEventByIdAsync(request.Id, cancellationToken))
            {
                Domain.Entities.Event? @event = await _eventRepository.Query()
                    .Where(predicate(request.Id))
                    .SingleAsync(cancellationToken);

                Result resultOfPublish = @event.Publish();

                result = resultOfPublish.IsSuccess
                    ? await _unitOfWork.SaveChangesAsync(cancellationToken) > 0 ? true : Error.None
                    : resultOfPublish.Errors.ToArray();
            }
            
        }

        return result;
    }
}
