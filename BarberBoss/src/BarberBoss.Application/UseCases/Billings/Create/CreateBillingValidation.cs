using BarberBoss.Communication.Request;
using BarberBoss.Exception;
using FluentValidation;

namespace BarberBoss.Application.UseCases.Billings.Create;
public class CreateBillingValidation : AbstractValidator<RequestCreateBillingJson>
{
    public CreateBillingValidation()
    {
        RuleFor(b => b.Title).NotEmpty().WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
        RuleFor(b => b.Value).GreaterThan(0).WithMessage(ResourceErrorMessages.VALUE_MUST_BE_GREATER_THAN_ZERO);
        RuleFor(b => b.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage(ResourceErrorMessages.BILLING_CANNOT_BE_IN_FUTURE);
        RuleFor(expense => expense.PaymentType).IsInEnum().WithMessage(ResourceErrorMessages.PAYMENT_TYPE_INVALID);
    }
}
