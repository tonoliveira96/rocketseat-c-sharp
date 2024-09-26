using CashFlow.Domain.Entities;

namespace WebApi.Test.Resources
{
    public class ExpensesIdentityManager
    {
        private readonly Expense _expenses;

        public ExpensesIdentityManager(Expense expenses)
        {
            _expenses = expenses;
        }

        public long GetId() => _expenses.Id;
    }
}
