using Evently.Modules.Events.Presentation.Endpoints.Category.Archive;
using Evently.Modules.Events.Presentation.Endpoints.Category.Create;
using Evently.Modules.Events.Presentation.Endpoints.Category.Get;
using Evently.Modules.Events.Presentation.Endpoints.Category.List;
using Evently.Modules.Events.Presentation.Endpoints.Category.Update;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Events.Presentation.Endpoints.Category;

internal static class CategoryEndpoints
{
    internal static void MapCategoryEndpoints(this IEndpointRouteBuilder app)
    {
        // Commands
        CreateCategoryEndpoint.MapEndpoint(app);
        UpdateCategoryEndpoint.MapEndpoint(app);
        ArchiveCategoryEndpoint.MapEndpoint(app);

        // Queries
        GetCategoryEndpoint.MapEndpoint(app);
        ListOfCategoriesEndpoint.MapEndpoint(app);
    }
}
