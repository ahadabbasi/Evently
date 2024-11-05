using System;
using FluentValidation;

namespace Evently.Modules.Events.Application.Category.Commands.Archive;

internal sealed class ArchiveCategoryCommandValidator : AbstractValidator<ArchiveCategoryCommand>
{
    public ArchiveCategoryCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}
