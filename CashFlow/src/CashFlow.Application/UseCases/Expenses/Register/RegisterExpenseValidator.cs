using CashFlow.Communication.Requests;
using CashFlow.Exeption;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpensesJson>
    {
        public RegisterExpenseValidator()
        {
            RuleFor(expense => expense.Title)
                .NotEmpty()
                .WithMessage(ResourceErrorMessages.TITLE_REQUIRED);
            RuleFor(expense => expense.Amount)
                .GreaterThan(0)
                .WithMessage(ResourceErrorMessages.VALUE_MUST_BE_GREATER_THAN_ZERO);
            RuleFor(expense => expense.Date)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage(ResourceErrorMessages.EXPENSES_CANNOT_BE_IN_FUTURE);
            RuleFor(expense => expense.PaymentType)
                .IsInEnum()
                .WithMessage(ResourceErrorMessages.PAYMENT_TYPE_INVALID);
        }
    }
}
