using Desafio03.Communication.Requests;
using Desafio03.Communication.Responses;

namespace Desafio03.Application.UseCase.Task.Create
{
    public class RegisterTaskUseCase
    {
        public ResponseRegisterTaskJson Execute(RequestTaskJson request)
        {
            return new ResponseRegisterTaskJson
            {
                Name = request.Name,
                Description = request.Description,
                Id = new Random().Next(0, 100),
            };
        }
    }
}
