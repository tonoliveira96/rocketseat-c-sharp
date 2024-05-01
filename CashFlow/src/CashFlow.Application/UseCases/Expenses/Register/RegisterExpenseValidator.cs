using CashFlow.Communication.Requests;
using FluentValidation;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpenseValidator : AbstractValidator<RequestRegisterExpensesJson>
    {
        public RegisterExpenseValidator()
        {
            RuleFor(expense => expense.Title)
                .NotEmpty()
                .WithMessage("The Title is required.");
            RuleFor(expense => expense.Amount)
                .GreaterThan(0)
                .WithMessage("The Amount must be greater than zero.");
            RuleFor(expense => expense.Date)
                .LessThanOrEqualTo(DateTime.UtcNow)
                .WithMessage("Expenses cannot be for the future.");
            RuleFor(expense => expense.PaymentType)
                .IsInEnum().
                WithMessage("PaymentType is not valid.");
        }
    }
}
