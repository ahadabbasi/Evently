using System;
using System.Threading;
using Evently.Modules.Events.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.Create;

public static class CreateEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("events", async (
            [FromBody] CreateEventRequest request,
            [FromServices] ISender sender,
            CancellationToken cancellation
        ) =>
        {
            Guid result = await sender.Send(
                new CreateEventCommand(
                    request.Title,
                    request.Description,
                    request.Location,
                    request.StartAtUtc,
                    request.EndsAtUtc
                ), 
                cancellation
            );
            return Results.Ok(result);
        }).WithTags(Tags.Events);
    }
}
