using Evently.Commons.Domain.Abstractions.Result;
using MediatR;

namespace Evently.Commons.Application.Contracts.Messaging.Query;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{ }
