using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Expenses;

namespace CashFlow.Infrastructure.DataAccess.Repositories
{
    internal class ExpensesRepository : IExpensesRepository
    {
        public void Add(Expense expense)
        {
            var dbContent = new CashFlowContext();

            dbContent.Expenses.Add(expense);

            dbContent.SaveChanges();
        }
    }
}
