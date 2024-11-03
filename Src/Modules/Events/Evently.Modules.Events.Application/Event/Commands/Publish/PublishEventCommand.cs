using System;
using Evently.Commons.Application.Contracts.Messaging.Command;

namespace Evently.Modules.Events.Application.Event.Commands.Publish;

public sealed record PublishEventCommand(Guid Id) : ICommand;
