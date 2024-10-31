using System;
using Evently.Commons.Application.Contracts.Messaging.Query;
using MediatR;

namespace Evently.Modules.Events.Application.Event.Queries.Get;

public sealed record GetEventQuery(Guid Id) : IQuery<GetEventQueryResponse>;
