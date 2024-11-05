using Evently.Modules.Events.Presentation.Endpoints.Category.Get;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.Category;

internal static class CategoryEndpoints
{
    internal static void MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        // Commands

        // Queries
        GetCategoryEndpoint.MapEndpoint(app);
    }
}
