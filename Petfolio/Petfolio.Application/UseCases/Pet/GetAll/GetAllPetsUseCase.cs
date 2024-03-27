using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pet.GetAll
{
    public class GetAllPetsUseCase
    {
        public ResponseAllPetsJson Execute()
        {
            return new ResponseAllPetsJson
            {
                Pets = new List<ResponsesShortPetJson>
                {
                    new ResponsesShortPetJson
                    {
                        Id = 1,
                        Name = "Test",
                        Type = Communication.Enum.PetType.Dog
                    }
                }
            };
        }
    }
}
