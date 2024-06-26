using System.Net;

namespace CashFlow.Exeption.ExceptionBase
{
    public class NotFoundException : CashFlowException
    {
        public NotFoundException(string message) : base(message) { }

        public override int StatusCode => (int)HttpStatusCode.BadRequest;

        public override List<string> GetErrors()
        {
            return [Message];
        }
    }
}
