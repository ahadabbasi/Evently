using System;
using MediatR;

namespace Evently.Modules.Events.Application.Event.Queries.Get;

public sealed record GetEventQuery(Guid Id) : IRequest<GetEventQueryResponse?>;
