using System;
using FluentValidation;

namespace Evently.Modules.Events.Application.Event.Commands.Reschedule;

internal sealed class RescheduleEventCommandValidator : AbstractValidator<RescheduleEventCommand>
{
    public RescheduleEventCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .NotEqual(Guid.Empty);

        RuleFor(c => c.StartsAtUtc)
            .NotEmpty();

        RuleFor(c => c.EndsAtUtc)
            .Must((cmd, endsAt) => endsAt > cmd.StartsAtUtc)
            .When(c => c.EndsAtUtc != null);
    }
}
