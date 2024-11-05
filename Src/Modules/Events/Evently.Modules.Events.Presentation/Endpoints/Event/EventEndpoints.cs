using Evently.Modules.Events.Presentation.Endpoints.Event.Cancel;
using Evently.Modules.Events.Presentation.Endpoints.Event.Create;
using Evently.Modules.Events.Presentation.Endpoints.Event.Get;
using Evently.Modules.Events.Presentation.Endpoints.Event.Publish;
using Evently.Modules.Events.Presentation.Endpoints.Event.Reschedule;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.Event;

internal static class EventEndpoints
{
    internal static void MapEventEndpoints(this IEndpointRouteBuilder app)
    {
        // Queries
        GetEventEndpoint.MapEndpoint(app);

        // Commands
        CancelEventEndpoint.MapEndpoint(app);
        CreateEventEndpoint.MapEndpoint(app);
        PublishEventEndpoint.MapEndpoint(app);
        RescheduleEventEndpoint.MapEndpoint(app);
    }

}
