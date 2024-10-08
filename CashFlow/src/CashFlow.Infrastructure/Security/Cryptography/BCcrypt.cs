using CashFlow.Domain.Security.Criptography;
using BC = BCrypt.Net.BCrypt;

namespace CashFlow.Infrastructure.Security.Cryptography
{
    public class BCcrypt : IPassworEncripter
    {
        public string Encrypt(string password)
        {
            string passwordHash = BC.HashPassword(password);

            return passwordHash;
        }

        public bool Verify(string password, string passwordHash)
        {
            return BC.Verify(password, passwordHash);
        }
    }
}
