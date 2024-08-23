using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Users;
using CashFlow.Domain.Security.Criptography;
using CashFlow.Domain.Security.Token;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionBase;

namespace CashFlow.Application.UseCases.Users.Register
{
    public class RegisterUserUseCase : IRegisterUserUseCase
    {
        private readonly IMapper _mapper;
        private readonly IPassworEncripter _passworEncripter;
        private readonly IUserReadOnlyRepository _userReadOnlyRepository;
        private readonly IUserWriteOnlyRepository _userWriteOnlyRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAccessTokenGenerator _tokenGenerator;

        public RegisterUserUseCase(IMapper mapper,
            IPassworEncripter passworEncripter,
            IUserReadOnlyRepository userReadOnlyRepository,
            IUserWriteOnlyRepository userWriteOnlyRepository,
            IUnitOfWork unitOfWork,
            IAccessTokenGenerator tokenGenerator)
        {
            _mapper = mapper;
            _passworEncripter = passworEncripter;
            _userReadOnlyRepository = userReadOnlyRepository;
            _userWriteOnlyRepository = userWriteOnlyRepository;
            _unitOfWork = unitOfWork;
            _tokenGenerator = tokenGenerator;
        }

        public async Task<ResponseRegisterUserJson> Execute(RequestRegisterUserJson request)
        {
            await Validate(request);

            var user = _mapper.Map<Domain.Entities.User>(request);
            user.Password = _passworEncripter.Encrypt(request.Password);
            user.UserIdentifier = Guid.NewGuid();

            await _userWriteOnlyRepository.Add(user);
            await _unitOfWork.Commit();

            return new ResponseRegisterUserJson
            {
                Name = user.Name,
                Token = _tokenGenerator.Generate(user)
            };
        }

        private async Task Validate(RequestRegisterUserJson request)
        {
            var result = new RegisterUserValidator().Validate(request);

            var emailExist = await _userReadOnlyRepository.ExistActiveUserWithEmail(request.Email);

            if (emailExist)
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceErrorMessages.EMAIL_ALREAD_EXIST));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);
            }
        }
    }
}
