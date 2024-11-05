using System;
using Evently.Commons.Application.Contracts.Messaging.Command;

namespace Evently.Modules.Events.Application.Category.Commands.Archive;

public sealed record ArchiveCategoryCommand(Guid Id) : ICommand;
