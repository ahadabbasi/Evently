using Evently.Modules.Events.Presentation.Endpoints.Event;
using Evently.Modules.Events.Presentation.Endpoints.TicketType;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation;
public static class Startup
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapEventEndpoints();
        app.MapTicketTypeEndpoints();
    }
}
