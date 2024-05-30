using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Enums;
using CashFlow.Exeption;
using CommonTestUtilities.Requests;
using FluentAssertions;

namespace Validators.Tests.Expenses.Register
{
    public class RegisterExpensesValidatorTests
    {
        [Fact]
        public void Success()
        {
            // Arrange
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpensesJsonBuilder.Build();

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeTrue();
        }

        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData(null)]
        public void Error_Title_Empty(string title)
        {
            // Arrange
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpensesJsonBuilder.Build();
            request.Title = title;

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.TITLE_REQUIRED));
        }

        [Fact]
        public void Error_Date_Future()
        {
            // Arrange
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpensesJsonBuilder.Build();
            request.Date = DateTime.UtcNow.AddDays(1);

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.EXPENSES_CANNOT_BE_IN_FUTURE));
        }

        [Fact]
        public void Error_Payment_Type_Ivalid()
        {
            // Arrange
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpensesJsonBuilder.Build();
            request.PaymentType = (PaymentsType) 700;

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.PAYMENT_TYPE_INVALID));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        [InlineData(-7)]
        public void Error_Amount_Invalid(decimal amount)
        {
            // Arrange
            var validator = new RegisterExpenseValidator();
            var request = RequestRegisterExpensesJsonBuilder.Build();
            request.Amount = amount;

            // Act
            var result = validator.Validate(request);

            // Assert
            result.IsValid.Should().BeFalse();
            result.Errors.Should().ContainSingle()
                .And.Contain(e => e.ErrorMessage.Equals(ResourceErrorMessages.VALUE_MUST_BE_GREATER_THAN_ZERO));
        }
    }
}
