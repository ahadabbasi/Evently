using System.Collections.Generic;
using Evently.Commons.Application.Contracts.Messaging.Query;
using Evently.Modules.Events.Application.Event.Models;

namespace Evently.Modules.Events.Application.Event.Queries.List;

public sealed record ListOfEventsQuery : IQuery<IReadOnlyCollection<EventQueryResponse>>;

