
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Domain.Services.LoggedUser;

namespace CashFlow.Application.UseCases.Users.Delete
{
    public class DeleteUserAccountUseCase : IDeleteUserAccountUseCase
    {
        private readonly ILoggedUser _loggedUser;
        private readonly IUserWriteOnlyRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteUserAccountUseCase(
            ILoggedUser loggedUser, 
            IUserWriteOnlyRepository repository, 
            IUnitOfWork unitOfWork)
        {
            _loggedUser = loggedUser;
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute()
        {
            var loggedUser = await _loggedUser.Get();

            await _repository.Delete(loggedUser);

            await _unitOfWork.Commit();
        }
    }
}
