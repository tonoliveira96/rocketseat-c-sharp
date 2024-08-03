
using CashFlow.Exception;
using FluentValidation;
using FluentValidation.Validators;
using System.Text.RegularExpressions;

namespace CashFlow.Communication.Requests
{
    public class PasswordValidator<T> : PropertyValidator<T, string>
    {
        private const string ERROR_MESSAGE_KEY = "ErrorMessage";
        public override string Name => "PasswordValidator";

        protected override string GetDefaultMessageTemplate(string errorCode)
        {
            return "{ErrorMessage}";
        }

        public override bool IsValid(ValidationContext<T> context, string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_INVALID);
                return false;
            }

            if (password.Length < 8)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_INVALID);
                return false;
            }

            if (Regex.IsMatch(password, @"[A-Z]+") == false)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_INVALID);
                return false;
            }

            if (Regex.IsMatch(password, @"[a-z]+") == false)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_INVALID);
                return false;
            }

            if (Regex.IsMatch(password, @"[0-9]+") == false)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_INVALID);
                return false;
            }

            if (Regex.IsMatch(password, @"[\!\?\*\.]+") == false)
            {
                context.MessageFormatter.AppendArgument(ERROR_MESSAGE_KEY, ResourceErrorMessages.PASSWORD_INVALID);
                return false;
            }

            return true;
        }
    }
}
