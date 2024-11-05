using System.Collections.Generic;
using Evently.Commons.Application.Contracts.Messaging.Query;
using Evently.Modules.Events.Application.Category.Models;

namespace Evently.Modules.Events.Application.Category.Queries.List;

public sealed record ListOfCategoriesQuery : IQuery<IReadOnlyCollection<CategoryQueryResponse>>;
