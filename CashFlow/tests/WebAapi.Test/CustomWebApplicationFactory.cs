using CashFlow.Domain.Entities;
using CashFlow.Domain.Security.Criptography;
using CashFlow.Domain.Security.Token;
using CashFlow.Infrastructure.DataAccess;
using CommonTestUtilities.Entities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.Test
{
    public class CustomWebApplicationFactory : WebApplicationFactory<Program>
    {
        private Expense _expense;
        private User _user;
        private string _password;
        private string _token;

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
                    var tokenGenerator = scope.ServiceProvider.GetRequiredService<IAccessTokenGenerator>(); 

                    StartDatabase(dbContext, passworEncripter);

                    _token = tokenGenerator.Generate(_user);
                });
        }

        public string GetEmail() => _user.Email;

        public string GetName() => _user.Name;

        public string GetPassword() => _password;

        public string GetToken() => _token;

        public long GetExpenseId() => _expense.Id;

        private void StartDatabase(CashFlowDbContext dbContext, IPassworEncripter passworEncripter)
        {
            _user = UserBuilder.Build();
            _password = _user.Password;
            _user.Password = passworEncripter.Encrypt(_user.Password);

            dbContext.Users.Add(_user);
            AddExpenses(dbContext, _user);

            dbContext.SaveChanges();
        }

        private void AddUsers(CashFlowDbContext dbContext, IPassworEncripter passworEncripter)
        {

        }

        private  void AddExpenses(CashFlowDbContext dbContext, User user) {
            _expense = ExpenseBuilder.Build(user);

            dbContext.Expenses.Add(_expense);
        }
    }
}
