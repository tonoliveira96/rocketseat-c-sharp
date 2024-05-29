using Bogus;
using CashFlow.Communication.Enums;
using CashFlow.Communication.Requests;

namespace CommonTestUtilities.Requests
{
    public class RequestRegisterExpensesJsonBuilder
    {
        public static RequestRegisterExpensesJson Build()
        {
            return new Faker<RequestRegisterExpensesJson>()
                .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
                .RuleFor(r => r.Date, faker => faker.Date.Past())
                .RuleFor(r => r.Description, faker => faker.Commerce.ProductDescription())
                .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentsType>())
                .RuleFor(r => r.Amount, faker => faker.Random.Decimal(min: 1, max: 10000));
        }
    }
}
