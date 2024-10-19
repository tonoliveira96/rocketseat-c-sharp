using BarberBoss.Communication.Request;
using FluentValidation;

namespace BarberBoss.Application.UseCases.Billings.Create;
public class CreateBillingValidation : AbstractValidator<RequestCreateBillingJson>
{
    public CreateBillingValidation()
    {
        RuleFor(b => b.Title).NotEmpty().WithMessage("T�tulo � obrigat�rio.");
        RuleFor(b => b.Value).GreaterThan(0).WithMessage("O valor deve ser maior que 0.");
        RuleFor(b => b.Date).LessThanOrEqualTo(DateTime.UtcNow).WithMessage("A data n�o pode ser no futuro.");
        RuleFor(expense => expense.PaymentType)
                .IsInEnum()
                .WithMessage("Tipo de pagamento inv�lido.");
    }
}

