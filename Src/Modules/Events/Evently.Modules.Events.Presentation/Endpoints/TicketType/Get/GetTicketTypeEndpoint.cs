using System;
using System.Threading;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Commons.Presentation;
using Evently.Modules.Events.Application.TicketType.Models;
using Evently.Modules.Events.Application.TicketType.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.TicketType.Get;

internal sealed class GetTicketTypeEndpoint : IMapEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(string.Format("{0}/{{id:guid}}", Routes.TicketTypeRoutePrefix), async (
            [FromRoute] Guid id, 
            [FromServices] ISender sender,
            CancellationToken cancellation
        ) =>
        {
            Result<TicketTypeQueryResponse> result = await sender.Send(new GetTicketTypeQuery(id), cancellation);

            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Errors);
        }).WithTags(Tags.TicketTypes);
    }
}
