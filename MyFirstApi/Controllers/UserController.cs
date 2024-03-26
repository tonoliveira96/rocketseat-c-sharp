using Microsoft.AspNetCore.Mvc;
using MyFirstApi.Comunication.Requests;
using MyFirstApi.Comunication.Responses;

namespace MyFirstApi.Controllers
{
    public class UserController : MyFirstApiBaseController
    {
        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById(int id)
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
        [ProducesResponseType(typeof(List<User>),StatusCodes.Status204NoContent)]
        public IActionResult Remove([FromRoute] int id)
        {
            return NoContent();
        }

        [HttpGet]
        [ProducesResponseType(typeof(User), StatusCodes.Status200OK)]

        public IActionResult GetAll()
        {
            var response = new List<User>()
            {
                new User { Id = 1, Age = 7, Name = "John"},
                new User { Id = 2, Age = 8, Name = "Karen"}
            };
            return Ok(response);
        }

        [HttpPut("change-password")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult ChangePassword([FromBody] RequestChangePasswordJson request)
        {
            return NoContent();
        }
    }
}
