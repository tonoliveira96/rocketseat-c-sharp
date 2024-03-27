using Desafio02.Comunication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Desafio02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookstoreController : ControllerBase
    {
        [HttpGet]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetAll()
        {
            var response = new Book();
            return Ok(response.ListAllBooks());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult GetById([FromRoute] int id)
        {
            var books = new Book();
            var response = books.ListAllBooks().Find( b => b.Id == id);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Book), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Create(RequestRegisterBook request)
        {
            return Ok(request);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Update(RequestUpdateBook request)
        {
            return Ok(request);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(Book), StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult Remove([FromRoute] int id)
        {
            return Ok(id);
        }
    }
}
