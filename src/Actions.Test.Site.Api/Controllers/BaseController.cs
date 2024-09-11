using Actions.Test.Site.Application.Dto.Responses.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Actions.Test.Site.Api.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        protected IActionResult SuccessResponse(object data)
        {
            return Ok(new SuccessResponseDto(data));
        }

        protected IActionResult CustomSuccessResponse(int statusCode, object data)
        {
            return StatusCode(statusCode, new SuccessResponseDto(data));
        }

        protected IActionResult NotFoundResponse(string message)
        {
            return NotFound(new ErrorResponseDto(message));
        }

        protected IActionResult UnauthorizedResponse(string message)
        {
            return Unauthorized(new ErrorResponseDto(message));
        }

        protected IActionResult BadRequestResponse(string message)
        {
            var errorResponse = new ErrorResponseDto(message);
            return BadRequest(errorResponse);
        }

        protected IActionResult InternalServerErrorResponse(string message, Exception? exception = null)
        {
            var errorResponse = new ErrorResponseDto(message, exception?.Message ?? "Internal Server Error");
            return StatusCode(500, errorResponse);
        }

        protected IActionResult CustomErrorResponse(int statusCode, string message, Exception? exception = null)
        {
            var errorResponse = new ErrorResponseDto(message, exception?.Message ?? "Internal Server Error");
            return StatusCode(statusCode, errorResponse);
        }
    }
}
