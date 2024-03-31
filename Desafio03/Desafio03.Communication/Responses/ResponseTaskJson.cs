using Desafio03.Communication.Enums;

namespace Desafio03.Communication.Responses
{
    public class ResponseTaskJson
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty ;
        public TaskPriorityEnum TaskPriority { get; set; }
        public DateTime DueDate { get; set; }
        public TaskStatusEnum TaskStatus { get; set; }
    }
}
