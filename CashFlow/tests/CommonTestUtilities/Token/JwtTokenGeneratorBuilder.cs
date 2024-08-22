using CashFlow.Domain.Entities;
using CashFlow.Domain.Security.Token;
using Moq;

namespace CommonTestUtilities.Token
{
    public class JwtTokenGeneratorBuilder
    {
        public static IAccessTokenGenerator Build()
        {
            var mock = new Mock<IAccessTokenGenerator>();

            mock.Setup(config => config.Generate(It.IsAny<User>())).Returns("skahddjh");

            return mock.Object;
        }
    }
}
