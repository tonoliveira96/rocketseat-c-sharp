
using FluentValidation;
using FluentValidation.Validators;

namespace CashFlow.Communication.Requests
{
    public class PasswordValidator<T> : PropertyValidator<T, string>
    {
        public override string Name => "PasswordValidator";

        public override bool IsValid(ValidationContext<T> context, string password)
        {
            
        }
    }
}
