using System;
using Evently.Commons.Application.Contracts.Messaging.Command;
using Evently.Modules.Events.Application.Category.Models;

namespace Evently.Modules.Events.Application.Category.Commands.Create;

public sealed record CreateCategoryCommand(string Name) : CategoryRecord(Name), ICommand<Guid>;
