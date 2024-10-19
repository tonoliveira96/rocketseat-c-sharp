using BarberBoss.Application.UseCases.Billings.Create;
using BarberBoss.Exception;
using CommonTestUtils.Request;
using FluentAssertions;

namespace Validators.Tests.Billing;

public class CreateBillingValidatorTests
{
    [Fact]
    public void Success()
    {
        // Arange
        var validator = new CreateBillingValidator();
        var request = RequestCreateBillingJsonBuilder.Build();

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeTrue();
    }

    [Fact]
    public void Error_TitleIsEmpty()
    {
        // Arange
        var validator = new CreateBillingValidator();
        var request = RequestCreateBillingJsonBuilder.Build();
        request.Title = string.Empty;

        // Act
        var result = validator.Validate(request);

        // Assert
        result.IsValid.Should().BeFalse();
        result.Errors.Should().ContainSingle().And.Contain(e => e.ErrorMessage == ResourceErrorMessages.TITLE_REQUIRED);
    }
}
