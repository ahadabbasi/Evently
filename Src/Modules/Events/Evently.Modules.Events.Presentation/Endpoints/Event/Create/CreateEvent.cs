﻿using System;
using System.Threading;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Modules.Events.Application.Event.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.Event.Create;

internal static class CreateEvent
{
    internal static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("events", async (
            [FromBody] CreateEventRequest request,
            [FromServices] ISender sender,
            CancellationToken cancellation
        ) =>
        {
            Result<Guid> result = await sender.Send(
                new CreateEventCommand(
                    request.Title,
                    request.Description,
                    request.Location,
                    request.StartsAtUtc,
                    request.EndsAtUtc
                ), 
                cancellation
            );
            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Errors);
        }).WithTags(Tags.Events);
    }
}
