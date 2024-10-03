using CashFlow.Communication.Requests;

namespace CashFlow.Application.UseCases.Users.ChangePassword
{
    public interface IChangePasswordUseCase
    {
        Task Excute(RequestChangePasswordJson request);
    }
}
