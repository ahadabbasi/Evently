using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Evently.Modules.Events.Application.Database.Contexts;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Application.Events.Endpoints.Get;

public static class GetEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("events/{id:guid}", async (
            [FromRoute] Guid id,
            [FromServices] EventsDatabaseContext context,
            CancellationToken cancellation
        ) =>
        {
            IResult result = Results.NotFound();

            Func<Guid, Expression<Func<Events.Entities.Event, bool>>> predicate = (id) => model => model.Id == id;

            if (await context.Events.AnyAsync(predicate(id), cancellation))
            {
                result = Results.Ok(await context.Events
                .Where(predicate(id))
                .Select(model => new GetEventResponse(model.Id, model.Title, model.Location, model.Description, model.StartAtUtc, model.EndsAtUtc))
                .SingleAsync(cancellation));
            }

            return result;
        }).WithTags(Tags.Events);
    }
}
