using System;
using Evently.Commons.Application.Contracts.Messaging.Query;
using Evently.Modules.Events.Application.Category.Models;

namespace Evently.Modules.Events.Application.Category.Queries.Get;

public sealed record GetCategoryQuery(Guid Id) : IQuery<CategoryQueryResponse>;
