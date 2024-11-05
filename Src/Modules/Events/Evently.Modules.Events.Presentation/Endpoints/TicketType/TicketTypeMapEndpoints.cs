using Evently.Modules.Events.Presentation.Endpoints.TicketType.ChangePrice;
using Evently.Modules.Events.Presentation.Endpoints.TicketType.Create;
using Evently.Modules.Events.Presentation.Endpoints.TicketType.Get;
using Evently.Modules.Events.Presentation.Endpoints.TicketType.List;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.TicketType;

internal static class TicketTypeMapEndPoints
{
    internal static void MapTicketTypeEndpoints(this IEndpointRouteBuilder app)
    {
        CreateTicketType.MapEndpoint(app);
        GetTicketType.MapEndpoint(app);
        ChangePriceTicketType.MapEndpoint(app);
        ListOfTicketTypes.MapEndpoint(app);
    }
}
