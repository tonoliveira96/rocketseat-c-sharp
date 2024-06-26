namespace CashFlow.Exeption.ExceptionBase
{
    public class NotFoundException : CashFlowException
    {
        public NotFoundException(string message) : base(message)
        {
        }
    }
}
