using Evently.Commons.Domain.Abstractions.Result;
using MediatR;

namespace Evently.Commons.Application.Contracts.Messaging.Query;

public interface IQueryHandler<in TQuery, TResponse> : IRequestHandler<TQuery, Result<TResponse>>
    where TQuery : IQuery<TResponse>

{
}
