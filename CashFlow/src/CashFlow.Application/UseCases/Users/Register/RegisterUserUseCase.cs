using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Domain.Security.Criptography;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Users.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IPassworEncripter _passworEncripter;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;

        public RegisterUserUseCase(IMapper mapper,
            IPassworEncripter passworEncripter,
            IUserReadOnlyRepository userReadOnlyRepository)
        {
            _mapper = mapper;
            _passworEncripter = passworEncripter;
            _userReadOnlyRepository = userReadOnlyRepository;
        }

        public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
        {
            await Validate(request);

            var user = _mapper.Map<User>(request);
            user.Password = _passworEncripter.Encrypt(request.Password);

            return new ResponseRegisterUserJson
            {
                Name = user.Name,
            };
        }

        private async Task Validate(RequestRegisterUserJson request)
        {
            var result = new RegisterUserValidator().Validate(request);

            var emailExist = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);

            if (emailExist)
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, "E-mail já registrado."));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
