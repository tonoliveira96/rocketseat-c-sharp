using Petfolio.Communication.Enum;

namespace Petfolio.Communication.Responses
{
    public class ResponsesShortPetJson
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public PetType Type { get; set; }
    }
}
