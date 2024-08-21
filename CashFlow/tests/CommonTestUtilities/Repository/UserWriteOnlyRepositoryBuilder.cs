using CashFlow.Domain.Repositories.Users;
using Moq;

namespace CommonTestUtilities.Repository
{
    public class UserWriteOnlyRepositoryBuilder
    {
        public static IUserWriteOnlyRepository Build()
        {
            var mock = new Mock<IUserWriteOnlyRepository>();

            return mock.Object;
        }
    }
}
