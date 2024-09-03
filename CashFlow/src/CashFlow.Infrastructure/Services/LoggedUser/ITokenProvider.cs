namespace CashFlow.Infrastructure.Services.LoggedUser
{
    public interface ITokenProvider
    {
        string TokenOnRequest();
    }
}
