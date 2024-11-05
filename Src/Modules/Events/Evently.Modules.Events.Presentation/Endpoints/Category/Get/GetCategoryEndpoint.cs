using System;
using System.Threading;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Commons.Presentation;
using Evently.Modules.Events.Application.Category.Models;
using Evently.Modules.Events.Application.Category.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.Category.Get;

internal sealed class GetCategoryEndpoint : IMapEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(string.Format("{0}/{{id:guid}}", Routes.CategoryRoutePrefix), async (
            [FromRoute]Guid id, 
            [FromServices]ISender sender,
            CancellationToken cancellation
        ) =>
        {
            Result<CategoryQueryResponse> result = await sender.Send(new GetCategoryQuery(id));

            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Errors);
        })
        .WithTags(Domain.Tags.Categories);
    }
}
