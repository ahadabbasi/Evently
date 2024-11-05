using FluentValidation;

namespace Evently.Modules.Events.Application.Category.Commands.Create;

internal sealed class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
{
    public CreateCategoryCommandValidator()
    {
        RuleFor(c => c.Name)
            .NotEmpty();
    }
}
