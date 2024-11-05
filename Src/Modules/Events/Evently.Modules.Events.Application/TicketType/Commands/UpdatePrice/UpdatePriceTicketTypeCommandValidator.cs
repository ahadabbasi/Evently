using System;
using FluentValidation;

namespace Evently.Modules.Events.Application.TicketType.Commands.UpdatePrice;

internal sealed class UpdatePriceTicketTypeCommandValidator : AbstractValidator<UpdatePriceTicketTypeCommand>
{
    public UpdatePriceTicketTypeCommandValidator()
    {
        RuleFor(c => c.Id).NotEmpty().NotEqual(Guid.Empty);
        RuleFor(c => c.Price).GreaterThan(decimal.Zero);
    }
}
