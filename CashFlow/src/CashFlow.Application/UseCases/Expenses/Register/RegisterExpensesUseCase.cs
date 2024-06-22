using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Enums;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exeption.ExceptionBase;

namespace CashFlow.Application.UseCases.Expenses.Register
{
    public class RegisterExpensesUseCase: IRegisterExpensesUseCase
    {
        private readonly IExpensesRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        public RegisterExpensesUseCase(IExpensesRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public ResponseRegisterExpensesJson Execute(RequestRegisterExpensesJson request)
        {
            Validate(request);

            var entity = new Expense
            {
                Amount = request.Amount,
                Date = request.Date,
                Description = request.Description,
                Title = request.Title,
                PaymentType = (PaymentType)request.PaymentType
            };

            _repository.Add(entity);
            _unitOfWork.Commit();

            return new ResponseRegisterExpensesJson();
        }

        private void Validate(RequestRegisterExpensesJson request)
        {
            var validator = new RegisterExpenseValidator();

            var result = validator.Validate(request);

            if(!result.IsValid)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
