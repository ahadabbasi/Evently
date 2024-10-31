using FluentValidation;

namespace Evently.Modules.Events.Application.Commands;

internal sealed class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(model => model.Title).NotEmpty();
        RuleFor(model => model.Description).NotEmpty();
        RuleFor(model => model.Location).NotEmpty();
        RuleFor(model => model.StartAtUtc).NotEmpty();
        RuleFor(model => model.EndsAtUtc).Must((model, value) => value > model.StartAtUtc)
            .When(model => model.EndsAtUtc != null);
    }
}
