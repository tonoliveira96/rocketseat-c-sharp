using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Exeption.ExceptionBase;

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
            var validator = new RegisterExpenseValidator();

            var result = validator.Validate(request);

            if(!result.IsValid)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidatorException(errorMessages);
            }
        }
    }
}
