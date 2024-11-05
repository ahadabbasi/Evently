using System;
using System.Threading;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Commons.Presentation;
using Evently.Modules.Events.Application.Category.Commands.Update;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.Category.Update;

internal sealed class UpdateCategoryEndpoint : IMapEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(string.Format("{0}/{{id:guid}}", Routes.CategoryRoutePrefix), async (
            [FromRoute] Guid id, 
            [FromBody] UpdateCategoryRequest request, 
            [FromServices] ISender sender,
            CancellationToken cancellation
        ) =>
        {
            Result result = await sender.Send(
                new UpdateCategoryCommand(
                    id,
                    request.Name
                ),
                cancellation
            );

            return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Errors);
        }).WithTags(Domain.Tags.Categories);
    }
}
