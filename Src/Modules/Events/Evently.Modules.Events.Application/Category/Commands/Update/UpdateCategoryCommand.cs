using System;
using Evently.Commons.Application.Contracts.Messaging.Command;
using Evently.Modules.Events.Application.Category.Models;

namespace Evently.Modules.Events.Application.Category.Commands.Update;

public sealed record UpdateCategoryCommand(Guid Id, string Name) : CategoryRecord(Name), ICommand;
