using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Commons.Presentation;
using Evently.Modules.Events.Application.Category.Models;
using Evently.Modules.Events.Application.Category.Queries.List;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.Category.List;

internal sealed class ListOfCategoriesEndpoint : IMapEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Routes.CategoryRoutePrefix, async (ISender sender) =>
        {
            Result<IReadOnlyCollection<CategoryQueryResponse>> result = await sender.Send(new ListOfCategoriesQuery());

            return Results.Ok(result.Value);
        })
        .WithTags(Domain.Tags.Categories);
    }

}
