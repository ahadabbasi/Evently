using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Evently.Commons.Application.Contracts.Messaging.Query;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Modules.Events.Application.Category.Models;
using Evently.Modules.Events.Application.Contracts.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Application.Category.Queries.List;
internal sealed class ListOfCategoriesQueryHandler : IQueryHandler<ListOfCategoriesQuery, IReadOnlyCollection<CategoryQueryResponse>>
{
    private readonly ICategoryRepository _categoryRepository;


    public ListOfCategoriesQueryHandler(
        ICategoryRepository categoryRepository
    )
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Result<IReadOnlyCollection<CategoryQueryResponse>>> Handle(ListOfCategoriesQuery request, CancellationToken cancellationToken)
    {
        return await _categoryRepository
            .Query()
            .Select(model =>
                new CategoryQueryResponse(
                    model.Id,
                    model.Name,
                    model.IsArchived
                )
            )
            .ToListAsync(cancellationToken);
    }
}
