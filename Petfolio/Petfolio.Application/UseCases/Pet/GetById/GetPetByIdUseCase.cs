using Petfolio.Communication.Responses;

namespace Petfolio.Application.UseCases.Pet.GetById
{
    public class GetPetByIdUseCase
    {
        public ResponsePetJson Execute(int id)
        {
            return new ResponsePetJson {
                Id = id , 
                Name = "Apollo", 
                Type = Communication.Enum.PetType.Dog,
                Birthday = new DateTime(2016, 05, 01)
            };
        }
    }
}
