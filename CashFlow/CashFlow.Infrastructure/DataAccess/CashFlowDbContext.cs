using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.DataAccess
{
    internal class CashFlowDbContext: DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "Server=localhost;Database=cashflowdb;Uid=root;Pwd=#Dev2024;";
            var serverVersion = new MySqlServerVersion(new Version(8,2,0));

            optionsBuilder.UseMySql(connectionString, serverVersion);
        }
    }
}
