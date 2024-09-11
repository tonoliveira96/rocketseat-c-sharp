using CashFlow.Exception;
using CommonTestUtilities.Requests;
using FluentAssertions;
using System.Globalization;
using System.Text.Json;
using WebApi.Test;
using WebApi.Test.InlineData;

namespace WebAapi.Test.Users.Register
{
    public class RegisterUserTest : CashFlowClassFixture
    {
        private const string METHOD = "api/User";

        public RegisterUserTest(CustomWebApplicationFactory webApplicationFactory) : base(webApplicationFactory)
        {
        }

        [Fact]
        public async Task Sucess()
        {
            var request = RequestRegisterUserJsonBuilder.Build();

            var result = await DoPost(requestUri: METHOD, request: request);

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);

            var body = await result.Content.ReadAsStreamAsync();

            var response = await JsonDocument.ParseAsync(body);

            response.RootElement.GetProperty("name").GetString().Should().Be(request.Name);
            response.RootElement.GetProperty("token").GetString().Should().NotBeNullOrEmpty();
        }

        [Theory]
        [ClassData(typeof(CultureInlineDataTest))]
        public async Task Error_Empty_Name(string culture)
        {
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Name = string.Empty;

            var result = await DoPost(requestUri: METHOD, request: request, culture: culture);

            result.StatusCode.Should().Be(System.Net.HttpStatusCode.BadRequest);

            var body = await result.Content.ReadAsStreamAsync();

            var response = await JsonDocument.ParseAsync(body);

            var errors = response.RootElement.GetProperty("errorMessages").EnumerateArray();

            var expectedmessage = ResourceErrorMessages.ResourceManager.GetString("NAME_EMPTY", new CultureInfo(culture));

            errors.Should().HaveCount(1).And.Contain(error => error.GetString()!.Equals(expectedmessage));
        }
    }
}
