using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpensesWriteOnlyRepository
    {
        Task Add(Expense expense);
        /// <summary>
        /// This function ruturns TRUE if the deletion has success otherwise returns FALSE.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task Delete(long id);
    }
}
