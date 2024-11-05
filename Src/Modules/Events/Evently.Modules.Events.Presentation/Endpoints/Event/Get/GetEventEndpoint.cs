using System;
using System.Threading;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Commons.Presentation;
using Evently.Modules.Events.Application.Event.Queries.Get;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.Event.Get;

internal sealed class GetEventEndpoint : IMapEndpoint
{
    internal static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapGet(string.Format("{0}/{{id:guid}}", Routes.EventRoutePrefix), async (
            [FromRoute] Guid id,
            [FromServices] ISender sender,
            CancellationToken cancellation
        ) =>
        {
            IResult result = Results.NotFound();

            Result<GetEventQueryResponse> response = await sender.Send(new GetEventQuery(id), cancellation);

            if(response.IsSuccess)
            {
                result = Results.Ok(response.Value);
            }

            return result;
        }).WithTags(Tags.Events);
    }
}
