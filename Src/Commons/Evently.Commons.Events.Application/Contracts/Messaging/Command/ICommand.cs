using Evently.Commons.Domain.Abstractions.Result;
using MediatR;

namespace Evently.Commons.Application.Contracts.Messaging.Command;

public interface ICommand : IRequest<Result>, IBaseCommand
{ }

public interface ICommand<TResponse> : IRequest<Result<TResponse>>, IBaseCommand
{ }
