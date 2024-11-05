using System;
using System.Collections.Generic;
using Evently.Commons.Application.Contracts.Messaging.Query;
using Evently.Modules.Events.Application.TicketType.Models;

namespace Evently.Modules.Events.Application.TicketType.Queries.List;

public sealed record ListOfTicketTypesQuery(Guid EventId) : IQuery<IReadOnlyCollection<TicketTypeQueryResponse>>;
