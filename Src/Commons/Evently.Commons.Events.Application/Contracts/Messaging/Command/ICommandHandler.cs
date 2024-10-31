﻿using Evently.Commons.Domain.Abstractions.Result;
using MediatR;

namespace Evently.Commons.Application.Contracts.Messaging.Command;

public interface ICommandHandler<in TCommand> : IRequestHandler<TCommand, Result>
    where TCommand : ICommand
{ }

public interface ICommandHandler<in TCommand, TResponse> : IRequestHandler<TCommand, Result<TResponse>>
    where TCommand : ICommand<TResponse>
{ }
