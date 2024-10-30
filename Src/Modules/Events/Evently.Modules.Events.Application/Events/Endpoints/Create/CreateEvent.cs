using System;
using System.Threading;
using Evently.Modules.Events.Application.Database.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Application.Events.Endpoints.Create;

public static class CreateEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost("events", async (
            [FromBody] CreateEventRequest request,
            [FromServices] EventsDatabaseContext context,
            CancellationToken cancellation
        ) =>
        {
            var eventEntity = new Entities.Event()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.Description,
                Location = request.Location,
                StartAtUtc = request.StartAtUtc,
                EndsAtUtc = request.EndsAtUtc,
                Status = Entities.EventStatus.Draft
            };

            await context.Events.AddAsync(eventEntity, cancellation);

            await context.SaveChangesAsync(cancellation);

            return Results.Ok(eventEntity.Id);
        }).WithTags(Tags.Events);
    }
}
