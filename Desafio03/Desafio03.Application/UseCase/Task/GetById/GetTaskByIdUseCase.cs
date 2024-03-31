using Desafio03.Communication.Responses;

namespace Desafio03.Application.UseCase.Task.GetById
{
    public class GetTaskByIdUseCase
    {
        public ResponseTaskJson Execute(int taskId)
        {
            return new ResponseTaskJson
            {
                Id = taskId,
                Name = "Task por ID",
                Description = "Essa task veiopor id",
                DueDate = DateTime.Now,
                TaskPriority = Communication.Enums.TaskPriorityEnum.low,
                TaskStatus = Communication.Enums.TaskStatusEnum.waiting,
            };
        }
    }
}
