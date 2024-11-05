using System.Threading;
using System.Threading.Tasks;
using Evently.Commons.Application.Contracts.Messaging.Query;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Modules.Events.Application.Category.Models;
using Evently.Modules.Events.Application.Contracts.Repositories;

namespace Evently.Modules.Events.Application.Category.Queries.Get;

internal sealed class GetCategoryQueryHandler : IQueryHandler<GetCategoryQuery, CategoryQueryResponse>
{
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryQueryHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<CategoryQueryResponse>> Handle(GetCategoryQuery request, CancellationToken cancellationToken)
    {
        Result<CategoryQueryResponse> result = Domain.Errors.Category.NotFound(request.Id);

        if(await _categoryRepository.ExistByIdAsync(request.Id, cancellationToken))
        {
            Domain.Entities.Category categoryEntity = await _categoryRepository.GetByIdAsync(request.Id, cancellationToken);

            result = new CategoryQueryResponse(
                categoryEntity!.Id,
                categoryEntity!.Name,
                categoryEntity!.IsArchived
            );
        }

        return result;
    }
}
