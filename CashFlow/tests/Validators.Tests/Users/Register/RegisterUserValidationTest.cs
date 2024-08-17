using CashFlow.Application.UseCases.Users.Register;
using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Users.Register
{
    public class RegisterUserValidationTest
    {
        [Fact]
        public void Success()
        {
            // Arrange
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Build();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(null)]
        public void Error_Name_IEmpty(string name)
        {
            // Arrange
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Name = name;

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.NAME_EMPTY));
        }

        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(null)]
        public void Error_Email_Empty(string email)
        {
            // Arrange
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Email = email;

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EMAIL_EMPTY));
        }

        [Fact]
        public void Error_Email_Invalid()
        {
            // Arrange
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Email = "google.com";

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EMAIL_INVALID));
        }

        [Fact]
        public void Error_Password_Empty()
        {
            // Arrange
            var validator = new RegisterUserValidator();
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Password = string.Empty;

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.PASSWORD_INVALID));
        }
    }
}
