using System;
using Evently.Commons.Application.Contracts.Messaging.Query;
using Evently.Modules.Events.Application.TicketType.Models;

namespace Evently.Modules.Events.Application.TicketType.Queries.Get;

public sealed record GetTicketTypeQuery(Guid TicketTypeId) : IQuery<TicketTypeQueryResponse>;
