using Desafio03.Application.UseCase.Task.Create;
using Desafio03.Application.UseCase.Task.DeleteById;
using Desafio03.Application.UseCase.Task.GetAll;
using Desafio03.Application.UseCase.Task.GetById;
using Desafio03.Application.UseCase.Task.Update;
using Desafio03.Communication.Requests;
using Desafio03.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace Desafio03.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController: ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(ResponsesErrorJson), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetAll()
        {
            var useCase = new GetAllTasksUseCase();
            var response = useCase.Excute();
            if (response == null)
            {
                return Ok(response);
            }

            return NoContent();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseTaskJson), StatusCodes.Status404NotFound)]
        public IActionResult Get(int id)
        {
            var useCase = new GetTaskByIdUseCase();
            var response = useCase.Execute(id);

            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterTaskJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponsesErrorJson), StatusCodes.Status400BadRequest)]
        public IActionResult Register([FromBody] RequestTaskJson request)
        {
            var response = new RegisterTaskUseCase().Execute(request);

            return Created(string.Empty, response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponsesErrorJson), StatusCodes.Status400BadRequest)]
        public IActionResult Update([FromRoute] int id, [FromBody] RequestTaskJson request)
        {
            var useCase = new UpdateTaskUseCase();
            useCase.Execute(id, request);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponsesErrorJson), StatusCodes.Status404NotFound)]
        public IActionResult Delete(int id)
        {
            var useCase = new DeleteTaskByIdUseCase();
            useCase.Execute(id);

            return NoContent();
        }

    }
}
