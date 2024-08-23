using CashFlow.Application.UseCases.Login.DoLogin;
using CommonTestUtilities.Cryptograph;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Repository;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Token;
using FluentAssertions;

namespace UseCase.Test.Login.DoLogin
{
    public class DoLoginUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var request = RequestLoginJsonBuilder.Build();
            var user = UserBuilder.Build();

            var useCase = CreateUseCase(user);

            var result = await useCase.Execute(request);

            result.Should().NotBeNull();
            result.Name.Should().Be(user.Name);
            result.Token.Should().NotBeNullOrWhiteSpace();
        }

        private DoLoginUseCase CreateUseCase(CashFlow.Domain.Entities.User user)
        {
            var passwordEncripter = PasswordEncripterBuilder.Build();
            var tokenGenerator = JwtTokenGeneratorBuilder.Build();
            var readRepository = new UserReadOnlyRepositoryBuilder().GetUserByEmail(user).Build();

            return new DoLoginUseCase(readRepository, passwordEncripter, tokenGenerator);
        }
    }
}
