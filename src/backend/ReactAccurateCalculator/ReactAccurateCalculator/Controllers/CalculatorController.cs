using MediatR;
using Microsoft.AspNetCore.Mvc;
using ReactAccurateCalculator.Controllers.Base;
using ReactAccurateCalculator.Features;
using ReactAccurateCalculator.Models;

namespace ReactAccurateCalculator.Controllers
{
    [Route("")]
    [ApiController]
    public class CalculatorController : BaseAPIController
    {
        private readonly IMediator mediator;

        public CalculatorController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        public Task<IActionResult> GetReactApp([FromQuery] bool reloadFile)
        {
            return base.Execute(async () =>
            {
                HttpContext.Response.ContentType = "text/html";
                await HttpContext.Response.WriteAsync(await mediator.Send(new ReactRenderFeature.ReactRenderQuery { ReloadFile = reloadFile }));
                return Task.CompletedTask;
            });
        }

        [HttpPost("calculate")]
        public Task<IActionResult> Calculate([FromBody] CalculateRequest request)
        {
            return base.Execute(() =>
            {
                return mediator.Send(new CalculateFeature.CalculateQuery
                {
                    Equation = request.Equation
                });
            });
        }
    }
}
