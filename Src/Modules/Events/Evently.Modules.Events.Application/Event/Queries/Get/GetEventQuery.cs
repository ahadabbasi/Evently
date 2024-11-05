using System;
using Evently.Commons.Application.Contracts.Messaging.Query;
using Evently.Modules.Events.Application.Event.Models;
using MediatR;

namespace Evently.Modules.Events.Application.Event.Queries.Get;

public sealed record GetEventQuery(Guid Id) : IQuery<EventQueryResponse>;
