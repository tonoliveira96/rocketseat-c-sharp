using CashFlow.Communication.Requests;
using FluentAssertions;
using FluentValidation;

namespace Validators.Tests.Users
{
    public class PasswordValidatorTest
    {
        [Theory]
        [InlineData("")]
        [InlineData("    ")]
        [InlineData(null)]
        [InlineData("aaaa")]
        [InlineData("aaaaaaaa")]
        [InlineData("AAAAAAAA")]
        [InlineData("AAAAAAA1")]
        public void Error_Password_Invalid(string password)
        {
            // Arrange
            var validator = new PasswordValidator<RequestRegisterUserJson>();

            // Act
            var result = validator.IsValid(new ValidationContext<RequestRegisterUserJson>(new RequestRegisterUserJson()), password);

            // Assert
            result.Should().BeFalse();
        }
    }
}
