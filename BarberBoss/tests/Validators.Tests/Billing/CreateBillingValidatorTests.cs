using BarberBoss.Application.UseCases.Billings.Create;
using BarberBoss.Communication.Request;
using FluentAssertions;

namespace Validators.Tests.Billing;

public class CreateBillingValidatorTests
{
    [Fact]
    public void Success()
    {
        // Arange
        var validator = new CreateBillingValidator();
        var request = new RequestCreateBillingJson
        {
            Date = DateTime.Now,
            PaymentType = BarberBoss.Communication.Enums.PaymentType.CreditCard,
            Title = "Barba",
            Value = 35
        };

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeTrue();
    }
}
