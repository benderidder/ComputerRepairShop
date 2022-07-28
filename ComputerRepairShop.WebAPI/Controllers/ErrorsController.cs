using ComputerRepairShop.WebAPI.Classes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace ComputerRepairShop.WebAPI.Controllers
{
    [AllowAnonymous]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsController : ControllerBase
    {
        private readonly ILogger<ErrorsController> _logger;

        public ErrorsController(ILogger<ErrorsController> logger)
        {
            _logger = logger;
        }

        [Route("error")]
        public MyErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;
            var code = (int)HttpStatusCode.InternalServerError;

            if (exception is ArgumentException) code = 400;

            Response.StatusCode = (int)HttpStatusCode.BadRequest;

            _logger.LogError("Response, status code: {code}, message: '{message}'", code, exception?.Message ?? "no message");

            return new MyErrorResponse(exception ?? new Exception("Unhandled exception")); // Your error model
        }
    }
}
