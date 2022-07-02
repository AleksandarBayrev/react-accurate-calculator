using Microsoft.AspNetCore.Mvc;
using ReactAccurateCalculator.Models;

namespace ReactAccurateCalculator.Controllers.Base
{
    public class BaseAPIController : ControllerBase
    {
        public async Task<IActionResult> Execute<T>(Func<Task<T>> action)
        {
            try
            {
                return Ok(await action.Invoke());
            }
            catch (Exception exception)
            {
                HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
                return new ObjectResult(new ErrorResponse
                {
                    Error = exception.Message,
                    HttpStatus = (int)HttpContext.Response.StatusCode,
                });
            }
        }
    }
}
