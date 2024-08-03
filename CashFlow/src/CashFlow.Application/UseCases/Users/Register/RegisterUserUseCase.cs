using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;

namespace CashFlow.Application.UseCases.Users.Register
{
    public class RegisterUserUseCase: IRegisterUserUseCase
    {
        private readonly IMapper _mapper;

        public RegisterUserUseCase(IMapper mapper)
        {
            _mapper = mapper;
        }

        public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
        {
            var user = _mapper.Map<User>(request);

            return new ResponseRegisterUserJson
            {
                Name = user.Name,
            };
        }

        private void Validate(RequestRegisterUserJson request)
        {
            var result = new RegisterUserValidator().Validade(request);

            if(result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f -> f.ErrorMessage).ToList();
            }
        }
    }
}
