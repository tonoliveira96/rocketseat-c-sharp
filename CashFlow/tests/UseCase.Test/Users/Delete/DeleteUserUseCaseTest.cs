using CashFlow.Application.UseCases.Users.Delete;
using CashFlow.Domain.Entities;
using CommonTestUtilities.Entities;
using CommonTestUtilities.Repository;
using FluentAssertions;

namespace UseCase.Test.Users.Delete
{
    public class DeleteUserUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            var user = UserBuilder.Build();
            var useCase = CreateUseCase(user);

            var act = async () => await useCase.Execute();

            await act.Should().NotThrowAsync();
        }

        private DeleteUserAccountUseCase CreateUseCase(User user)
        {
            var repository = UserWriteOnlyRepositoryBuilder.Build();
            var loggedUser = LoggedUserBuilder.Build(user);
            var unitOfWork = UnitOfWorkBuilder.Build();

            return new DeleteUserAccountUseCase(loggedUser, repository, unitOfWork);
        }
    }
}
