using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;
using BarberBoss.Exception.ExceptionBase;

namespace BarberBoss.Application.UseCases.Billings.Create;
public class CreateBillingUseCase : ICreateBillingUseCase
{
    public async Task<ResponseCreateBillingJson> Execute(RequestCreateBillingJson request)
    {
        Validate(request);

        return new ResponseCreateBillingJson
        {
            Title = request.Title,
        };
    }

    private void Validate(RequestCreateBillingJson request)
    {
        var validator = new CreateBillingValidator();

        var result = validator.Validate(request);

        if (!result.IsValid)
        {
            var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();

            throw new ErrorOnValidationException(errorMessages);
        }
    }
}

