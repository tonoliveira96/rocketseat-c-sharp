namespace CashFlow.Domain.Security.Criptography
{
    public interface IPassworEncripter
    {
        string Encrypt(string password);
    }
}
