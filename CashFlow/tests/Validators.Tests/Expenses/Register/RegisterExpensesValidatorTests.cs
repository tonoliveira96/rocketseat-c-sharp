using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;

namespace Validators.Tests.Expenses.Register
{
    public class RegisterExpensesValidatorTests
    {
        [Fact]
        public void Success()
        {
            // Arrange
            var validator = new RegisterExpenseValidator();
            var request = new RequestRegisterExpensesJson
            {
                Amount = 100,
                Date = DateTime.Now.AddDays(-1),
                Description = "description",
                PaymentType = CashFlow.Communication.Enums.PaymentsType.Cash,
                Title = "title",
            };

            // Act
            var result = validator.Validate(request);

            // Assert
            Assert.True(result.IsValid);
        }
    }
}
