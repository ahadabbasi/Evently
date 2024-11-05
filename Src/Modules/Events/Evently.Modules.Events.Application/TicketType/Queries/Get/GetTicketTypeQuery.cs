using System;
using Evently.Commons.Application.Contracts.Messaging.Query;

namespace Evently.Modules.Events.Application.TicketType.Queries.Get;

public sealed record GetTicketTypeQuery(Guid TicketTypeId) : IQuery<GetTicketTypeQueryResponse>;
