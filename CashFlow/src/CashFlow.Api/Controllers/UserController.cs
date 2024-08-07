﻿using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterUserJson),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async IActionResult Register([FromServices] useCase, [FromBody] 
            RequestRegisterUserJson request)
        {

            var response = await useCase.Execute(request);

            return Created(string.Empty, response);
        }
    }
}
