
using CashFlow.Domain.Security.Criptography;
using BC = BCrypt.Net.BCrypt;

namespace CashFlow.Infrastructure.Security
{
    public class BCcrypt : IPassworEncripter
    {
        public string Encrypt(string password)
        {
            string passwordHash = BC.HashPassword(password);

            return passwordHash;
        }
    }
}
