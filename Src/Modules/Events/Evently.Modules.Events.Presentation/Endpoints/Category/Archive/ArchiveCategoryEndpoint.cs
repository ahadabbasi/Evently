using System;
using System.Threading;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Commons.Presentation;
using Evently.Modules.Events.Application.Category.Commands.Archive;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.Category.Archive;

internal sealed class ArchiveCategoryEndpoint : IMapEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(string.Format("{0}/{{id:guid}}/archive", Routes.CategoryRoutePrefix), async (
            [FromRoute]Guid id, 
            [FromServices]ISender sender,
            CancellationToken cancellation
        ) =>
        {
            Result result = await sender.Send(
                new ArchiveCategoryCommand(id),
                cancellation
            );

            return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Errors);
        }).WithTags(Domain.Tags.Categories);
    }
}
