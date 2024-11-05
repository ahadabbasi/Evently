using System;
using System.Threading;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Modules.Events.Application.Event.Commands.Reschedule;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.Event.Reschedule;

internal sealed class RescheduleEventEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(string.Format("{0}/{{id:guid}}/reschedule", Routes.EventRoutePrefix), async (
            [FromRoute] Guid id, 
            [FromBody] RescheduleEventRequest request, 
            [FromServices] ISender sender,
            CancellationToken cancellation
        ) =>
        {
            Result result = await sender.Send(
                new RescheduleEventCommand(
                    id, 
                    request.StartsAtUtc, 
                    request.EndsAtUtc
                ),
                cancellation
            );

            return result.IsSuccess ? Results.Ok() : Results.BadRequest();
        })
        .WithTags(Tags.Events);
    }
}
