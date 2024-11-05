using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Evently.Commons.Application.Contracts.Messaging.Command;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Modules.Events.Application.Contracts;
using Evently.Modules.Events.Application.Contracts.Repositories;

namespace Evently.Modules.Events.Application.TicketType.Commands.UpdatePrice;

internal sealed class UpdatePriceTicketTypeCommandHandler : ICommandHandler<UpdatePriceTicketTypeCommand>
{
    private readonly ITicketTypeRepository _ticketTypeRepository;
    private readonly IEventUnitOfWork _unitOfWork;

    public UpdatePriceTicketTypeCommandHandler(
        ITicketTypeRepository ticketTypeRepository,
        IEventUnitOfWork unitOfWork
    )
    {
        _ticketTypeRepository = ticketTypeRepository;

        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(UpdatePriceTicketTypeCommand request, CancellationToken cancellationToken)
    {
        Result result = Domain.Errors.TicketType.NotFound(request.Id);

        if(await _ticketTypeRepository.ExistByIdAsync(request.Id, cancellationToken))
        {
            Domain.Entities.TicketType ticketTypeEntity = await _ticketTypeRepository.GetByIdAsync(request.Id, cancellationToken);

            ticketTypeEntity!.UpdatePrice(request.Price);

            result = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0 ? true : Error.None;
        }

        return result;
    }
}
