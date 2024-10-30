using Evently.Modules.Events.Presentation.Endpoints.Create;
using Evently.Modules.Events.Presentation.Endpoints.Get;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation;
public static class Startup
{
    public static void MapEndpoints(this IEndpointRouteBuilder app)
    {
        CreateEvent.MapEndpoint(app);
        GetEvent.MapEndpoint(app);
    }
}
