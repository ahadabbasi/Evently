﻿using System;
using System.Threading;
using Evently.Commons.Domain.Abstractions.Result;
using Evently.Commons.Presentation;
using Evently.Modules.Events.Application.TicketType.Commands.UpdatePrice;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.TicketType.ChangePrice;

internal sealed class ChangePriceTicketTypeEndpoint : IMapEndpoint
{
    public static void MapEndpoint(IEndpointRouteBuilder app)
    {
        app.MapPut(string.Format("{0}/{{id:guid}}/price", Routes.TicketTypeRoutePrefix), async (
            [FromRoute] Guid id, 
            [FromBody] ChangePriceTicketTypeRequest request, 
            [FromServices] ISender sender,
            CancellationToken cancellation
        ) =>
        {
            Result result = await sender.Send(
                new UpdatePriceTicketTypeCommand(
                    id, 
                    request.Price
                ),
                cancellation
            );

            return result.IsSuccess ? Results.Ok() : Results.BadRequest(result.Errors);
        }).WithTags(Modules.Events.Domain.Tags.TicketTypes);
    }
}
