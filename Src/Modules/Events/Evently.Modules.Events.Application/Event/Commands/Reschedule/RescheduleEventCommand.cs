using System;
using Evently.Commons.Application.Contracts.Messaging.Command;

namespace Evently.Modules.Events.Application.Event.Commands.Reschedule;

public sealed record RescheduleEventCommand(Guid Id, DateTime StartsAtUtc, DateTime? EndsAtUtc) : ICommand;
