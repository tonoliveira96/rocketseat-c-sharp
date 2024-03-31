using Desafio03.Communication.Responses;

namespace Desafio03.Application.UseCase.Task.GetAll
{
    public class GetAllTasksUseCase
    {
        public ResponseTaskJson Excute()
        {
            return new ResponseTaskJson
            {
                Id = 0,
                Name = "Concluir trilhade C#",
                Description = "Devem ser feitos todos so desafios.",
                TaskPriority = Communication.Enums.TaskPriorityEnum.medium,
                DueDate = DateTime.Now,
                TaskStatus = Communication.Enums.TaskStatusEnum.progress
            };
        }
    }
}
