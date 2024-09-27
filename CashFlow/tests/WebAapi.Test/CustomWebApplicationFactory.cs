using CashFlow.Domain.Entities;
using CashFlow.Domain.Enums;
using CashFlow.Domain.Security.Criptography;
using CashFlow.Domain.Security.Token;
using CashFlow.Infrastructure.DataAccess;
using CommonTestUtilities.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebApi.Test.Resources;

namespace WebApi.Test
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        public ExpensesIdentityManager Expense_Admin { get; private set; } = default!;
        public ExpensesIdentityManager Expense_MemberTeam { get; private set; } = default!;
        public UserIdentityManager User_Team_Member { get; private set; } = default!;
        public UserIdentityManager User_Admin { get; private set; } = default!;

        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.UseEnvironment("Test")
                .ConfigureServices(services =>
                {
                    var provider = services.AddEntityFrameworkInMemoryDatabase().BuildServiceProvider();

                    services.AddDbContext<CashFlowDbContext>(config =>
                    {
                        config.UseInMemoryDatabase("InMemoryDbForTesting");
                        config.UseInternalServiceProvider(provider);
                    });

                    var scope = services.BuildServiceProvider().CreateScope();
                    var dbContext = scope.ServiceProvider.GetRequiredService<CashFlowDbContext>();
                    var passworEncripter = scope.ServiceProvider.GetRequiredService<IPassworEncripter>();
                    var accessTokenGenerator = scope.ServiceProvider.GetRequiredService<IAccessTokenGenerator>();

                    StartDatabase(dbContext, passworEncripter, accessTokenGenerator);
                });
        }

        private void StartDatabase(
            CashFlowDbContext dbContext,
            IPassworEncripter passworEncripter,
            IAccessTokenGenerator accessTokenGenerator)
        {
            var userTeamMember = AddUserTeamMember(dbContext, passworEncripter, accessTokenGenerator);
            var expenseMemberTeam = AddExpenses(dbContext, userTeamMember, expenseId: 1);
            Expense_MemberTeam = new ExpensesIdentityManager(expenseMemberTeam);

            var userTeamAdmin = AddUserAdmin(dbContext, passworEncripter, accessTokenGenerator);
            var expenseAdmin =AddExpenses(dbContext, userTeamAdmin, expenseId: 2);
            Expense_Admin = new ExpensesIdentityManager(expenseAdmin);

            dbContext.SaveChanges();
        }

        private User AddUserTeamMember(
            CashFlowDbContext dbContext,
            IPassworEncripter passworEncripter,
            IAccessTokenGenerator accessTokenGenerator)
        {
            var user = UserBuilder.Build();
            user.Id = 1;
            var password = user.Password;

            user.Password = passworEncripter.Encrypt(user.Password);

            dbContext.Users.Add(user);

            var token = accessTokenGenerator.Generate(user);

            User_Team_Member = new UserIdentityManager(user, password, token);

            return user;
        }

        private User AddUserAdmin(
            CashFlowDbContext dbContext,
            IPassworEncripter passworEncripter,
            IAccessTokenGenerator accessTokenGenerator)
        {
            var user = UserBuilder.Build(Roles.ADMIN);
            user.Id = 2;

            var password = user.Password;
            user.Password = passworEncripter.Encrypt(user.Password);

            dbContext.Users.Add(user);

            var token = accessTokenGenerator.Generate(user);

            User_Admin = new UserIdentityManager(user, password, token);

            return user;
        }

        private Expense AddExpenses(CashFlowDbContext dbContext, User user, long expenseId)
        {
            var expense = ExpenseBuilder.Build(user);
            expense.Id = expenseId;

            dbContext.Expenses.Add(expense);

            return expense;
        }
    }
}
