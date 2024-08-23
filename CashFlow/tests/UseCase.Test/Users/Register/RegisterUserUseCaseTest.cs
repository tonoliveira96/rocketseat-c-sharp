using CashFlow.Application.UseCases.Users.Register;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;
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

        [Fact]
        public async Task Error_Email_Empty()
        {
            // Arrange
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Name = string.Empty;

            var useCase = CreateUseCase();

            // Act
            var act = async () => await useCase.Execute(request);

            // Assert
            var result = await act.Should().ThrowAsync<ErrorOnValidationException>();

            result.Where(ex => ex.GetErrors().Count == 1 && ex.GetErrors().Contains(ResourceErrorMessages.NAME_EMPTY));
        }

        private RegisterUserUseCase CreateUseCase()
        {
            var mapper = MapperBuilder.Build();
            var unitOfWork = UnitOfWorkBuilder.Build();
            var writeRepository = UserWriteOnlyRepositoryBuilder.Build();
            var passwordEncripter = PasswordEncripterBuilder.Build(); ;
            var jwtTokenGenerator = JwtTokenGeneratorBuilder.Build(); ;
            var readRepository = new UserReadOnlyRepositoryBuilder();

            return new RegisterUserUseCase(mapper, passwordEncripter, readRepository.Build(), writeRepository, unitOfWork, jwtTokenGenerator);
        }
    }
}
