using System;
using System.Threading;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Modules.Events.Application.Event.Commands.Cancel;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.Event.Cancel;

internal static class CancelEvent
{
    internal static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapDelete("events/{id}/cancel", async (
            [FromRoute] Guid id,
            [FromServices] ISender sender,
            CancellationToken cancellation
        ) =>
        {
            Result result = await sender.Send(new CancelEventCommand(id), cancellation);

            return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Errors);
        }).WithTags(Tags.Events);
    }
}
