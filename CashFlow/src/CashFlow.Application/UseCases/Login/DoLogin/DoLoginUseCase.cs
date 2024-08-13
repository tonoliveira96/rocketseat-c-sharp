using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Domain.Security.Criptography;
using CashFlow.Domain.Security.Token;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Login.DoLogin
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserReadOnlyRepository _repository;
        private readonly IPassworEncripter _passworEncripter;
        private readonly IAccessTokenGenerator _accessTokenGenerator;

        public DoLoginUseCase(IUserReadOnlyRepository repository,
            IPassworEncripter passworEncripter,
            IAccessTokenGenerator accessTokenGenerator)
        {
            _repository = repository;
            _passworEncripter = passworEncripter;
            _accessTokenGenerator = accessTokenGenerator;
        }

        public async Task<ResponseRegisterUserJson> Execute(RequestLoginJson request)
        {
            var user = await _repository.GetUserByEmail(request.Email);

            if (user is null)
            {
                throw new InvalidLoginException();
            }

            var passwordMatch = _passworEncripter.Verify(request.Password, user.Password);

            if (passwordMatch == false)
            {
                throw new InvalidLoginException();
            }

            return new ResponseRegisterUserJson
            {
                Name = user.Name,
                Token = _accessTokenGenerator.Generate(user)
            };
        }
    }
}
