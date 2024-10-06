using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;

namespace BarberBoss.Application.UseCases.Billings.Create;
public class CreateBillingUseCase : ICreateBillingUseCase
{
    public async Task<ResponseCreateBillingJson> Execute(RequestCreateBillingJson request)
    {
        if (request == null) throw new ArgumentNullException(nameof(request));

        return new ResponseCreateBillingJson
        {
            Title = request.Title,
        };
    }
}

