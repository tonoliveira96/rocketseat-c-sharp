using BarberBoss.Application.UseCases.Billings.Create;
using BarberBoss.Communication.Request;
using Microsoft.AspNetCore.Mvc;

namespace BarberBoss.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillingController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Upsert([FromBody] RequestCreateBillingJson request)
        {
            var useCase = new CreateBillingUseCase();
            var response = await useCase.Execute(request);

            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] long id)
        {
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove()
        {
            return Ok();
        }
    }
}
