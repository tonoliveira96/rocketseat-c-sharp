﻿using CashFlow.Application.UseCases.Expenses.Register;
using CashFlow.Communication.Requests;
using CashFlow.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExpensesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Register([FromBody] RequestRegisterExpensesJson request)
        {
            try
            {
                var useCase = new RegisterExpensesUseCase();
                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (ArgumentException ex)
            {
                var errorResponse = new ResponseErrorJson(ex.Message);
                return BadRequest(errorResponse);
            }
            catch
            {
                var errorResponse = new ResponseErrorJson("Unknow error :(");

                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
