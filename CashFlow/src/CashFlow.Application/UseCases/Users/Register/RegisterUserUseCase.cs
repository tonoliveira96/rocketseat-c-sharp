using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Security.Criptography;

namespace CashFlow.Application.UseCases.Users.Register
{
    public class RegisterUserUseCase: IRegisterUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IPassworEncripter _passworEncripter;

        public RegisterUserUseCase(IMapper mapper, IPassworEncripter passworEncripter)
        {
            _mapper = mapper;
            _passworEncripter = passworEncripter;
        }

        public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
        {
            Validate(request);

            var user = _mapper.Map<User>(request);
            user.Password = _passworEncripter.Encrypt(request.Password);

            return new ResponseRegisterUserJson
            {
                Name = user.Name,
            };
        }

        private void Validate(RequestRegisterUserJson request)
        {
            var result = new RegisterUserValidator().Validate(request);

            if(result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
            }
        }
    }
}
