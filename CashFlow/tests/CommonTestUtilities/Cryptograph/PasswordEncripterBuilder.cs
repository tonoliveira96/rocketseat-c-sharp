using CashFlow.Domain.Security.Criptography;
using Moq;

namespace CommonTestUtilities.Cryptograph
{
    public class PasswordEncripterBuilder
    {
        public static IPassworEncripter Build()
        {
            var mock = new Mock<IPassworEncripter>();

            mock.Setup(config => config.Encrypt(It.IsAny<string>())).Returns("sahdskhfakjdhskjd");

            return mock.Object;
        }
    }
}
