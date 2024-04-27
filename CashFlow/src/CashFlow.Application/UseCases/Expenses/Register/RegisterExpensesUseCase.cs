using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpensesUseCase
    {
        public ResponseRegisterExpensesJson Execute(RequestRegisterExpensesJson request)
        {
            Validate(request);
            return new ResponseRegisterExpensesJson();
        }

        private void Validate(RequestRegisterExpensesJson request)
        {
            var titleIsEmpty = string.IsNullOrWhiteSpace(request.Title);
            if (titleIsEmpty)
            {
                throw new ArgumentException("The Title is required.");
            }

            if (request.Amount <= 0)
            {
                throw new ArgumentException("The Amount must be greater than zero.");
            }

            var isValidDate = DateTime.Compare(request.Date, DateTime.UtcNow);
            if (isValidDate > 0)
            {
                throw new ArgumentException("Expenses cannot be for the future.");
            }

            var paymentsTypeIsValid = Enum.IsDefined(typeof(PaymentsType), request.PaymentType);
            if (paymentsTypeIsValid == false)
            {
                throw new ArgumentException("PaymentType is not valid.");
            }
        }
    }
}
