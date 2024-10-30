using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using Evently.Modules.Events.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;

namespace Evently.Modules.Events.Presentation.Endpoints.Get;

public static class GetEvent
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet("events/{id:guid}", async (
            [FromRoute] Guid id,
            [FromServices] ISender sender,
            CancellationToken cancellation
        ) =>
        {
            IResult result = Results.NotFound();

            GetEventQueryResponse response = await sender.Send(new GetEventQuery(id), cancellation);

            if(response != null)
            {
                result = Results.Ok(response);
            }

            return result;
        }).WithTags(Tags.Events);
    }
}
