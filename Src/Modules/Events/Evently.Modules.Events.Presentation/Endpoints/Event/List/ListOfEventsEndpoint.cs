using System.Collections.Generic;
using System.Threading;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Commons.Presentation;
using Evently.Modules.Events.Application.Event.Models;
using Evently.Modules.Events.Application.Event.Queries.List;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.Event.List;

internal sealed class ListOfEventsEndpoint : IMapEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(Routes.EventRoutePrefix, async (
            [FromServices]ISender sender,
            CancellationToken cancellation
        ) =>
        {
            Result<IReadOnlyCollection<EventQueryResponse>> result = await sender.Send(
                new ListOfEventsQuery(),
                cancellation
            );

            return Results.Ok(result.Value);
        }).WithTags(Modules.Events.Domain.Tags.Events);
    }
}
