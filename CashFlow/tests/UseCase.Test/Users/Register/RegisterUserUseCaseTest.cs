using CashFlow.Application.UseCases.Users.Register;
using CommonTestUtilities.Cryptograph;
using CommonTestUtilities.Mapper;
using CommonTestUtilities.Repository;
using CommonTestUtilities.Requests;
using CommonTestUtilities.Token;
using FluentAssertions;

namespace UseCase.Test.Users.Register
{
    public class RegisterUserUseCaseTest
    {
        [Fact]
        public async Task Success()
        {
            // Arrange
            var request = RequestRegisterUserJsonBuilder.Build();
            var useCase = CreateUseCase();

            // Act
            var result = await useCase.Execute(request);

            // Assert
            result.Should().NotBeNull();
            result.Name.Should().Be(request.Name);
            result.Token.Should().NotBeNullOrWhiteSpace();
        }

        private RegisterUserUseCase CreateUseCase()
        {
            var mapper = MapperBuilder.Build();
            var unitOfWork = UnitOfWorkBuilder.Build();
            var writeRepository = UserWriteOnlyRepositoryBuilder.Build();
            var passwordEncripter = PasswordEncripterBuilder.Build(); ;
            var jwtTokenGenerator = JwtTokenGeneratorBuilder.Build(); ;

            return new RegisterUserUseCase(mapper, passwordEncripter, null, writeRepository, unitOfWork, jwtTokenGenerator);
        }
    }
}
