using System;
using Evently.Commons.Application.Contracts.Messaging.Command;

namespace Evently.Modules.Events.Application.Event.Commands.Cancel;

public sealed record CancelEventCommand(Guid Id) : ICommand
{
}
