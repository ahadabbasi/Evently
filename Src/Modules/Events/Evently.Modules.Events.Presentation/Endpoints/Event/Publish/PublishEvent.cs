using System;
using System.Threading;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Modules.Events.Application.Event.Commands.Publish;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.Event.Publish;

internal static class PublishEvent
{
    internal static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(string.Format("{0}/{{id:guid}}/publish", Routes.EventRoutePrefix), async (
            [FromRoute]Guid id, 
            [FromServices]ISender sender,
            CancellationToken cancellation
            ) =>
        {
            Result result = await sender.Send(new PublishEventCommand(id), cancellation);

            return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Errors);
        })
        .WithTags(Tags.Events);
    }
}
