using System.Threading;
using System.Threading.Tasks;
using Evently.Commons.Application.Contracts.Messaging.Command;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Modules.Events.Application.Contracts;
using Evently.Modules.Events.Application.Contracts.Repositories;

namespace Evently.Modules.Events.Application.Category.Commands.Archive;
internal sealed class ArchiveCategoryCommandHandler : ICommandHandler<ArchiveCategoryCommand>
{
    private readonly ICategoryRepository _categoryRepository;

    private readonly IEventUnitOfWork _unitOfWork;


    public ArchiveCategoryCommandHandler(
        ICategoryRepository categoryRepository, 
        IEventUnitOfWork unitOfWork
    )
    {
        _categoryRepository = categoryRepository;

        _unitOfWork = unitOfWork;
    }

    public async Task<Result> Handle(ArchiveCategoryCommand request, CancellationToken cancellationToken)
    {
        Result result = Domain.Errors.Category.NotFound(request.Id);

        if(await _categoryRepository.ExistByIdAsync(request.Id, cancellationToken))
        {
            Domain.Entities.Category categoryEntity = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);

            result = Domain.Errors.Category.AlreadyArchived;

            if (!categoryEntity!.IsArchived)
            {
                categoryEntity.Archive();

                result = await _unitOfWork.SaveChangesAsync(cancellationToken) > 0 ? true : Error.None;
            }
        }

        return result;
    }
}
