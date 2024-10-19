using BarberBoss.Communication.Enums;
using BarberBoss.Communication.Request;
using Bogus;

namespace CommonTestUtils.Request;
public class RequestCreateBillingJsonBuilder
{
    public static RequestCreateBillingJson Build()
    {
        return new Faker<RequestCreateBillingJson>()
            .RuleFor(r => r.Title, faker => faker.Commerce.ProductName())
            .RuleFor(r => r.Date, faker => faker.Date.Past())
            .RuleFor(r => r.PaymentType, faker => faker.PickRandom<PaymentType>())
            .RuleFor(r => r.Value, faker => faker.Random.Decimal(min: 1, max: 1000));
    }
}
