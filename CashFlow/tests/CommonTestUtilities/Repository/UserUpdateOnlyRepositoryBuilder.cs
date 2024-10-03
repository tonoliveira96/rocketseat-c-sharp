using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Users;
using Moq;

namespace CommonTestUtilities.Repository
{
    public class UserUpdateOnlyRepositoryBuilder
    {
        public static IUserUpdateOnlyRepository Build(User user)
        {
            var mock = new Mock<IUserUpdateOnlyRepository>();

            mock.Setup(repository => repository.GetById(user.Id)).ReturnsAsync(user);

            return mock.Object;
        }
    }
}
