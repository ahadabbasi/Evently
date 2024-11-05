using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Commons.Presentation;
using Evently.Modules.Events.Application.TicketType.Commands.Create;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.TicketType.Create;

internal sealed class CreateTicketType : IMapEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPost(Routes.TicketTypeRoutePrefix, async (
            [FromBody] CreateTicketTypeRequest request, 
            [FromServices]ISender sender,
            CancellationToken cancellation
        ) =>
        {
            Result<Guid> result = await sender.Send(
                new CreateTicketTypeCommand(
                    request.EventId,
                    request.Name,
                    request.Price,
                    request.Currency,
                    request.Quantity
                ),
                cancellation
            );

            return result.IsSuccess ? Results.Ok(result.Value) : Results.BadRequest(result.Errors);
        }).WithTags(Tags.TicketTypes);
    }
}
