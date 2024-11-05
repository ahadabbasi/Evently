using System;
using System.Collections.Generic;
using System.Threading;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Commons.Presentation;
using Evently.Modules.Events.Application.TicketType.Models;
using Evently.Modules.Events.Application.TicketType.Queries.List;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.TicketType.List;

internal sealed class ListOfTicketTypes : IMapEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(string.Format("{0}/event/{{eventId:guid}}", Routes.TicketTypeRoutePrefix), async (
            [FromRoute] Guid eventId, 
            [FromServices] ISender sender,
            CancellationToken cancellation
        ) =>
        {
            Result<IReadOnlyCollection<TicketTypeQueryResponse>> result = await sender.Send(
                new ListOfTicketTypesQuery(eventId));

            return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Errors);

        }).WithTags(Tags.TicketTypes);
    }
}
