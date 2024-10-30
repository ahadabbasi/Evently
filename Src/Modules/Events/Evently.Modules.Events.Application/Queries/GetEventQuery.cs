using System;
using MediatR;

namespace Evently.Modules.Events.Application.Queries;

public sealed record GetEventQuery(Guid Id) : IRequest<GetEventQueryResponse?>;
