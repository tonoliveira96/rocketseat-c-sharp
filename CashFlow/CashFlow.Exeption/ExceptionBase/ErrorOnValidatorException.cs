namespace CashFlow.Exeption.ExceptionBase
{
    public class ErrorOnValidatorException: CashFlowException
    {
        public List<string> Errors { get; set; }
        public ErrorOnValidatorException(List<string> errorMessages)
        {
            Errors = errorMessages;
        }
    }
}
