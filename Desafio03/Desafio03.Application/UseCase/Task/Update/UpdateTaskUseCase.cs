using Desafio03.Communication.Requests;
using Desafio03.Communication.Responses;

namespace Desafio03.Application.UseCase.Task.Update
{
    public class UpdateTaskUseCase
    {
        public ResponseTaskJson Execute(int id, RequestTaskJson request) { 
            return new ResponseTaskJson
            {
                Id = id,
                Description = request.Description,
                DueDate = request.DueDate,
                Name = request.Name,
                TaskPriority = request.TaskPriority,
                TaskStatus = request.TaskStatus
            };
        }
    }
}
