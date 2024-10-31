using FluentValidation;

namespace Evently.Modules.Events.Application.Event.Commands.Create;

internal sealed class CreateEventCommandValidator : AbstractValidator<CreateEventCommand>
{
    public CreateEventCommandValidator()
    {
        RuleFor(model => model.Title).NotEmpty();
        RuleFor(model => model.Description).NotEmpty();
        RuleFor(model => model.Location).NotEmpty();
        RuleFor(model => model.StartsAtUtc).NotEmpty();
        RuleFor(model => model.EndsAtUtc).Must((model, value) => value > model.StartsAtUtc)
            .When(model => model.EndsAtUtc != null);
    }
}
