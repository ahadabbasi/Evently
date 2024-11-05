using System;
using Evently.Commons.Domain.Abstractions.Result;

namespace Evently.Modules.Events.Domain.Errors;

public static class Category
{
    public static Error NotFound(Guid categoryId) => Error.NotFound(
        string.Format("{0}.NotFound", Tags.Categories), 
        categoryId
    );

    public static readonly Error AlreadyArchived = (
        string.Format("{0}.AlreadyArchived", Tags.Categories),
        "The category was already archived"
    );
}
