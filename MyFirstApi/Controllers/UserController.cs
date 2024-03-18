using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Comunication.Requests;
using MyFirstApi.Comunication.Responses;

namespace MyFirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Get(int id)
        {
            var result = new User
            {
                Id = 1,
                Age = 27,
                Name = "Ton"
            };
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Create([FromBody] RequestRegistertJson request)
        {
            var result = new ResponseRegisterUserJson
            {
                Id = "1",
                Name = "User"
            };
            return Created(string.Empty, result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Update([FromBody] RequestUpdateProfileJson request)
        {
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult Remove([FromRoute] int id)
        {
            return NoContent();
        }
    }
}
