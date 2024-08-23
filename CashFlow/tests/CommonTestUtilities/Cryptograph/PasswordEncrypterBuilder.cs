using CashFlow.Domain.Security.Criptography;
using Moq;

namespace CommonTestUtilities.Cryptograph
{
    public class PasswordEncrypterBuilder
    {
        private readonly Mock<IPassworEncripter> _mock;

        public PasswordEncrypterBuilder()
        {
            _mock = new Mock<IPassworEncripter>();

            _mock.Setup(config => config.Encrypt(It.IsAny<string>())).Returns("sahdskhfakjdhskjd");
        }

        public PasswordEncrypterBuilder Verify(string? password)
        {
            if (string.IsNullOrWhiteSpace(password) == false)
            {
                _mock.Setup(passwordEncrypter => passwordEncrypter.Verify(password, It.IsAny<string>())).Returns(true);
            }

            return this;
        }

        public IPassworEncripter Build() => _mock.Object;
    }
}
