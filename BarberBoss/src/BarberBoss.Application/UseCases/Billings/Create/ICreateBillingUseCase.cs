using BarberBoss.Communication.Request;
using BarberBoss.Communication.Response;

namespace BarberBoss.Application.UseCases.Billings.Create;
public interface ICreateBillingUseCase
{
    Task<ResponseCreateBillingJson> Execute(RequestCreateBillingJson request);
}

