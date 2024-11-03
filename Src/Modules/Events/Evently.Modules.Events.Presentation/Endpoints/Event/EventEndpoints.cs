using Evently.Modules.Events.Presentation.Endpoints.Event.Cancel;
using Evently.Modules.Events.Presentation.Endpoints.Event.Create;
using Evently.Modules.Events.Presentation.Endpoints.Event.Get;
using Evently.Modules.Events.Presentation.Endpoints.Event.Publish;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.Event;

internal static class EventEndpoints
{
    internal static void MapEventEndpoints(this IEndpointRouteBuilder app)
    {
        CancelEvent.MapEndpoint(app);
        CreateEvent.MapEndpoint(app);
        GetEvent.MapEndpoint(app);
        PublishEvent.MapEndpoint(app);
    }

}
